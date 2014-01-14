namespace Endjin.Core.Composition.Samples.Mvc5.Net45.Controllers
{
    using System.Web.Mvc;
    using Endjin.Core.Composition.Samples.Mvc5.Net45.Contracts;
    using Endjin.Core.Composition.Samples.Mvc5.Net45.Models;


    public class SampleController : Controller
    {
        private readonly IRepository repository;

        public SampleController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var viewModel = new SampleViewModel
            {
                Message = this.repository.GetMessage()
            };

            return this.View(viewModel);
        }
    }
}