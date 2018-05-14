using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HRManagerClient.CustomControls
{
    public class DBNavigationBar : Control
    {
        public string AddText
        {
            get { return (string)GetValue(AddTextProperty); }
            set { SetValue(AddTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddTextProperty =
            DependencyProperty.Register("AddText", typeof(string), typeof(DBNavigationBar));



        public string RemoveText
        {
            get { return (string)GetValue(RemoveTextProperty); }
            set { SetValue(RemoveTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemoveText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemoveTextProperty =
            DependencyProperty.Register("RemoveText", typeof(string), typeof(DBNavigationBar));


        public ICommand AddItemCommand
        {
            get { return (ICommand)GetValue(AddItemCommandProperty); }
            set { SetValue(AddItemCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddItemCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddItemCommandProperty =
            DependencyProperty.Register("AddItemCommand", typeof(ICommand), typeof(DBNavigationBar));



        public ICommand RemoveItemCommand
        {
            get { return (ICommand)GetValue(RemoveItemCommandProperty); }
            set { SetValue(RemoveItemCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemoveItemCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemoveItemCommandProperty =
            DependencyProperty.Register("RemoveItemCommand", typeof(ICommand), typeof(DBNavigationBar));




        public ICommand SaveChangesCommand
        {
            get { return (ICommand)GetValue(SaveChangesCommandProperty); }
            set { SetValue(SaveChangesCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SaveChangesCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SaveChangesCommandProperty =
            DependencyProperty.Register("SaveChangesCommand", typeof(ICommand), typeof(DBNavigationBar));



        public ICommand RefreshCommand
        {
            get { return (ICommand)GetValue(RefreshCommandProperty); }
            set { SetValue(RefreshCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RefreshCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RefreshCommandProperty =
            DependencyProperty.Register("RefreshCommand", typeof(ICommand), typeof(DBNavigationBar));

        
    }
}
