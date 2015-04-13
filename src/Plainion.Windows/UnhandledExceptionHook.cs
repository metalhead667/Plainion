﻿using System.Windows;
using System.Windows.Threading;

namespace Plainion.Windows
{
    /// <summary>
    /// Encapsulates handling of unhandled exceptions by popping up a message box on occurence.
    /// </summary>
    public class UnhandledExceptionHook
    {
        public UnhandledExceptionHook( Application app )
        {
            app.DispatcherUnhandledException += OnUnhandledException;
        }

        private void OnUnhandledException( object sender, DispatcherUnhandledExceptionEventArgs e )
        {
            MessageBox.Show( e.Exception.ToString(), "Unhandled exception", MessageBoxButton.OK, MessageBoxImage.Error );

            e.Handled = true;
        }
    }
}
