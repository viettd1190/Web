using Microsoft.AspNetCore.Mvc;
using Web.Factories.Product;
using Web.Models.Product;

namespace Web.Controllers
{
    public class ProductGroupController : Controller
    {
        private readonly IProductGroupModelFactory _productGroupModelFactory;

        public ProductGroupController(IProductGroupModelFactory productGroupModelFactory)
        {
            _productGroupModelFactory = productGroupModelFactory;
        }

        public virtual IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual IActionResult List()
        {
            //prepare model
            var model = _productGroupModelFactory.PrepareProductGroupSearchModel(new ProductGroupSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult List(ProductGroupSearchModel searchModel)
        {
            //prepare model
            var model = _productGroupModelFactory.PrepareProductGroupListModel(searchModel);

            return Json(model);
        }
    }
}
