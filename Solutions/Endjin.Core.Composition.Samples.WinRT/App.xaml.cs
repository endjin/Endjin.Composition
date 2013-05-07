namespace Endjin.Core.Composition.Samples.WinRT
{
    #region Using Directives

    using System;
    using Windows.ApplicationModel;
    using Windows.ApplicationModel.Activation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Endjin.Core.Container;

    #endregion

    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                // Initialize the container for the application using the WinRT Bootstrapper
                await ApplicationServiceLocator.InitializeAsync(
                     new Container(),
                     new WinRtBootstrapper());
                
                rootFrame = new Frame();

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            Window.Current.Activate();
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
