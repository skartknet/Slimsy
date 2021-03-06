﻿
namespace TestSite.Common.Controllers
{
    using Models.ViewModels;
    using Slimsy;
    using System.Web.Mvc;
    using Umbraco.Web;
    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;
    using Umbraco.Web.PublishedModels;

    public class ProductController : RenderMvcController
    {
        private readonly SlimsyService _slimsyService;

        public ProductController(SlimsyService slimsyService)
        {
            this._slimsyService = slimsyService;
        }

        public override ActionResult Index(ContentModel model)
        {
            var product = model.Content as Product;

            var photo = product.Photos;
            var vm = new ProductViewModel(product)
            {
                PhotoSrc = this._slimsyService.GetCropUrl(photo, "feature"),
                PhotoSrcSetUrls = this._slimsyService.GetSrcSetUrls(photo, "feature")
            };

            return this.CurrentTemplate(vm);
        }
    }
}
