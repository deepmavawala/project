using Employee_Management_System.Models;
using Employee_Management_System.Models.Data;
using Employee_Management_System.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employee_Management_System.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly ApplicationDbContext _db;
		public EmployeeController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			return View();
		}
		//GET
		public IActionResult Upsert(int? id)
		{
			EmployeeVM employeeVM = new()
			{
				employee = new(),
				roleList = _db.roles.Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() })
			};
			if (id == 0 || id == null)
			{
				return View(employeeVM);
			}
			else
			{
				var employeefromdb = _db.employees.Find(id);

				if (employeefromdb == null)
				{
					return NotFound();
				}
				return View(employeefromdb);
			}
		}

		[HttpPost]
		public IActionResult Upsert(EmployeeDetail obj)
		{
			return View();
		}
		//public IActionResult Index()
		//{
		//	IEnumerable<EmployeeDetail> objEmployeelist = _db.EmployeeDetails;
		//	return View(objEmployeelist);
		//}
		//public IActionResult Create()
		//{
		//	return View();
		//}
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public IActionResult Create(Category obj)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		_db.Categories.Add(obj);
		//		_db.SaveChanges();
		//		return RedirectToAction("Index");
		//	}
		//	return View();
		//}
		//public IActionResult Edit(int? id)
		//{
		//	var objcategory = _db.Categories.Find(id);
		//	return View(objcategory);
		//}
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public IActionResult Edit(Category obj)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		_db.Categories.Update(obj);
		//		_db.SaveChanges();
		//		return RedirectToAction("Index");
		//	}
		//	return View();
		//}
		//public IActionResult Delete(int id)
		//{
		//	var objcategory = _db.Categories.Find(id);
		//	return View(objcategory);
		//}
		//[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		//public IActionResult DeletePOST(Category obj)
		//{
		//	var deleterange = _db.Categories.Where(u => u.ParentCategoryId == obj.CategoryId).ToList();
		//	foreach (var x in deleterange)
		//	{
		//		var check = _db.Categories.Where(data => data.ParentCategoryId == x.CategoryId).ToList();

		//		_db.RemoveRange(check);
		//	}
		//	_db.Categories.RemoveRange(deleterange);
		//	_db.Categories.Remove(obj);
		//	_db.SaveChanges();
		//	return RedirectToAction("Index");
		//}
		//public IActionResult AddChild(int id)
		//{
		//	ViewBag.Id = id;
		//	return View();
		//}
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public IActionResult AddChild(Category obj)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		_db.Categories.Add(obj);
		//		_db.SaveChanges();
		//		return PartialView("_TableView", obj);
		//	}
		//	return View();
		//}
		//#region API CALLS
		//[HttpGet]
		//public IActionResult GetAll()
		//{
		//	var categorylist = _db.Categories.ToList();
		//	return Json(new { Data = categorylist });
		//}
		//#endregion
	}
}
