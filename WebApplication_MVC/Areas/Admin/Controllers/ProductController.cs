using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebApp.DataAccess.Repository.IRepository;
using WebApp.Models;

namespace WebApplication_MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
			return View(objProductList);
		}

		public IActionResult Create()
		{
			IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category
				.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.CategoryId.ToString(),
				});
			ViewBag.CategoryList = CategoryList;
			return View();
		}

		[HttpPost]
		public IActionResult Create(Product product)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Product.Add(product);
				_unitOfWork.Save();
				TempData["success"] = "Product added successfully";
				return RedirectToAction("Index");
			}
			return View(product);
		}

		public IActionResult Edit(int id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Product productFromDb = _unitOfWork.Product.Get(u => u.ProductId == id);

			if (productFromDb == null)
			{
				NotFound();
			}
			return View(productFromDb);
		}

		[HttpPost]
		public IActionResult Edit(Product product)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Product.Update(product);
				_unitOfWork.Save();
				TempData["success"] = "Product edited successfully";
				return RedirectToAction("Index");
			}
			return View(product);
		}

		public IActionResult Delete(int id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Product productFromDb = _unitOfWork.Product.Get(u => u.ProductId == id);

			if (productFromDb == null)
			{
				NotFound();
			}
			return View(productFromDb);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int id)
		{
			Product productFromDb = _unitOfWork.Product.Get(u => u.ProductId == id);
			if (productFromDb == null)
			{
				NotFound();
			}
			_unitOfWork.Product.Delete(productFromDb);
			_unitOfWork.Save();
			TempData["success"] = "Product deleted successfully";
			return RedirectToAction("Index");
		}
	}
}
