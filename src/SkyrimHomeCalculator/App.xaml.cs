using System;
using System.Windows;
using System.Windows.Threading;

namespace SkyrimHomeCalculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            OutputException(args.Exception);

            args.Handled = true;
        }

        private static void OutputException(Exception ex)
        {
            Console.WriteLine("--{0}", ex.Message);
            Console.WriteLine("StackTrace:");
            Console.WriteLine(ex.StackTrace);

            if (ex.InnerException != null)
            {
                Console.Write("--");
                OutputException(ex.InnerException);
            }
        }
    }
}
