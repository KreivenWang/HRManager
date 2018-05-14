using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Steelsa.ViewModel
{
    public class DataGridRepairedBehavior
    {
        #region AutoGeneratingColumn_EventToCommand

        public static ICommand GetAutoGeneratingColumnEventToCommand(DependencyObject obj)
        {
            return (ICommand) obj.GetValue(AutoGeneratingColumnEventToCommandProperty);
        }

        public static void SetAutoGeneratingColumnEventToCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(AutoGeneratingColumnEventToCommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for AutoGeneratingColumnEventToCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoGeneratingColumnEventToCommandProperty =
            DependencyProperty.RegisterAttached("AutoGeneratingColumnEventToCommand", typeof (ICommand),
                typeof (DataGridRepairedBehavior),
                new PropertyMetadata(null, AutoGeneratingColumnEventToCommand_PropertyChangedCallback));

        private static void AutoGeneratingColumnEventToCommand_PropertyChangedCallback(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var dataGrid = d as DataGrid;
            if (dataGrid == null) return;
            if (e.OldValue != null) {
                dataGrid.AutoGeneratingColumn -= OnAutoGeneratingColumn;
            }
            if (e.NewValue != null) {
                dataGrid.AutoGeneratingColumn += OnAutoGeneratingColumn;
            }
        }

        private static void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var dependencyObject = sender as DependencyObject;
            if (dependencyObject == null) return;
            var command = dependencyObject.GetValue(AutoGeneratingColumnEventToCommandProperty) as ICommand;
            if (command != null && command.CanExecute(e)) {
                command.Execute(e);
            }
        }

        #endregion

        #region LoadingRow_EventToCommand

        public static ICommand GetLoadingRowEventToCommand(DependencyObject obj)
        {
            return (ICommand) obj.GetValue(LoadingRowEventToCommandProperty);
        }

        public static void SetLoadingRowEventToCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(LoadingRowEventToCommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadingRowEventToCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadingRowEventToCommandProperty =
            DependencyProperty.RegisterAttached("LoadingRowEventToCommand", typeof (ICommand),
                typeof (DataGridRepairedBehavior),
                new PropertyMetadata(null, LoadingRowEventToCommand_PropertyChangedCallback));

        private static void LoadingRowEventToCommand_PropertyChangedCallback(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var dataGrid = d as DataGrid;
            if (dataGrid == null) return;
            if (e.OldValue != null) {
                dataGrid.LoadingRow -= OnLoadingRow;
            }
            if (e.NewValue != null) {
                dataGrid.LoadingRow += OnLoadingRow;
            }
        }

        private static void OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            var dependencyObject = sender as DependencyObject;
            if (dependencyObject == null) return;
            var command = dependencyObject.GetValue(LoadingRowEventToCommandProperty) as ICommand;
            if (command != null && command.CanExecute(e)) {
                command.Execute(e);
            }
        }

        #endregion
    }
}
