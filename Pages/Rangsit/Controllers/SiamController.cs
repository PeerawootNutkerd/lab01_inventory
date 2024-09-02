using Microsoft.AspNetCore.Mvc;
namespace lab01.Pages.Rangsit.Controllers
{
	public class SiamController : Controller
	{
		// Action Method สำหรับหน้า Index
		public IActionResult Index()
		{
			return View();
		}
		// Action Method สำหรับการแก้ไขข้อมูล (Edit)
		public IActionResult EditSiam(int itemid)
		{
			// Logic สำหรับการดึงข้อมูลที่ต้องการแก้ไขมาแสดง
			// เช่น คุณสามารถใช้ itemid ในการดึงข้อมูลจากฐานข้อมูล
			return View();
		}
		// Action Method สำหรับการสร้างข้อมูลใหม่ (Create)
		public IActionResult CreateSiam()
		{
			// Logic สำหรับการสร้างข้อมูลใหม่
			return View();
		}
		// Action Method สำหรับการลบข้อมูล (Delete)
		public IActionResult DeleteSiam(int itemid)
		{
			// Logic สำหรับการลบข้อมูลตาม itemid
			return RedirectToAction("Index");
		}
	}
}