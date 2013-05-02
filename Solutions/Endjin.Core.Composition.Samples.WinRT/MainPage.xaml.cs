using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Endjin.Core.Composition.Samples.WinRT
{
    public sealed partial class MainPage : Page
    {
        private readonly IRepository repository;

        private readonly string message;

        public MainPage()
        {
            // User Application Service Locator to resolve the interface
            this.repository = ApplicationServiceLocator.Container.Resolve<IRepository>();
            
            this.message = this.repository.GetMessage();

            this.InitializeComponent();
        }

        public string Message
        {
            get { return message; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }

    public interface IRepository
    {
        string GetMessage();
    }
}
