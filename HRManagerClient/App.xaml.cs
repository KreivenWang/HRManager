using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Threading;
using HRModel;

namespace HRManagerClient
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try {
                base.OnStartup(e);
                DispatcherHelper.Initialize();
                SplashScreen ss = new SplashScreen("ClientRes/wallpaper-2753250.png");
                ss.Show(true);
                this.ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown;
                Steelsa.Localization.LocalizationManager.InitializeResource(global::HRManagerClient.Properties.Resources.ResourceManager);
                ModelSource.UpdateData();
                LoginDialog dlg = new LoginDialog();
                if (dlg.ShowDialog()) {
                    ModelSource.ChangeAuthority(dlg.User);
                    MainWindow w = new MainWindow();
                    w.Dispatcher.UnhandledException += Dispatcher_UnhandledException;
                    w.Show();
                }
            } catch (Exception ex) {
                WriteException(ex);
            }

        }

        private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            //WriteException(e.Exception);
            //e.Handled = true;
        }

        private void WriteException(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ex.Source: ");
            sb.AppendLine(ex.Source);
            sb.AppendLine();
            sb.Append("ex.StackTrace: ");
            sb.AppendLine(ex.StackTrace);
            sb.AppendLine();
            sb.Append("ex.TargetSite.Name: ");
            sb.AppendLine(ex.TargetSite.Name);
            sb.AppendLine();
            if (ex.InnerException != null) {
                sb.Append("ex.InnerException.Message: ");
                sb.AppendLine(ex.InnerException.Message);
                sb.AppendLine();
            }
            sb.Append("ex.Message: ");
            sb.AppendLine(ex.Message);
            sb.AppendLine();
            Console.WriteLine(sb.ToString());
        }
    }
}
