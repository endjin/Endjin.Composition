using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Endjin.Core.Composition.Samples.WP8.Resources;

namespace Endjin.Core.Composition.Samples.WP8
{
    using Endjin.Core.Composition.Samples.WP8.Contracts;

    public partial class MainPage : PhoneApplicationPage
    {
        private readonly IRepository repository;
        private string message;

        public MainPage()
        {
            this.repository = ApplicationServiceLocator.Container.Resolve<IRepository>();

            this.message = this.repository.GetMessage();

            InitializeComponent();

        }

        public string Message
        {
            get { return this.message; }
        }

    }
}