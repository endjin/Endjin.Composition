using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Endjin.Core.Composition.Samples.WinRT
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly IRepository repository;

        private readonly string message;

        public MainPage()
        {
            this.repository = ApplicationServiceLocator.Container.Resolve<IRepository>();
            this.InitializeComponent();

            this.message = repository.GetMessage();
        }

        public string Message
        {
            get { return message; }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }

    public interface IRepository
    {
        string GetMessage();
    }
}
