using Celebration_Of_Capitalism___The_Finale.Models;
using Celebration_Of_Capitalism___The_Finale.Services;
using Celebration_Of_Capitalism___The_Finale.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Celebration_Of_Capitalism___The_Finale.Controllers
{
	public class COCProductController : Controller
	{
		private readonly ICOCProductService productService;

		public COCProductController(COCProductService productService)
		{
			this.productService = productService;
		}

		/**
         * Shows the Views/[your controller name]/Index.cshtml page
         * Here Views/Product/Index.cshtml
         */
		public IActionResult Index(int? id)
		{
			if (id == null)
				throw new ArgumentNullException("id");

			COCProduct? toShow = productService.GetProduct((int)id);
			toShow.Id = (int)id;
			return View(toShow);
		}

		public IEnumerable<COCProduct> GetAllProducts()
		{
			return productService.GetAllProducts();
		}

		public int AddProduct(COCProduct product)
		{
			return productService.AddProduct(product);
		}

		public bool DeleteProduct(int id)
		{
			return productService.DeleteProduct(id);
		}

		public COCProduct? GetProduct(int id)
		{
			return productService.GetProduct(id);
		}

		public bool UpdateProduct(int id, COCProduct product)
		{
			return productService.UpdateProduct(id, product);
		}
	}
}
