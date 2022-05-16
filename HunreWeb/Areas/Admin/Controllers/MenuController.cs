using HunreWeb.Data.Dao;
using HunreWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HunreWeb.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Admin/Menu
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new MenuDao();
            var model = dao.ListAllPageing(searchString, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new MenuDao();
            var menu = dao.getById(id);
            return View(menu);
        }

        [HttpPost]
        public ActionResult Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                bool res = new MenuDao().Update(menu);
                if (res)
                {
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                long id = new MenuDao().Insert(menu);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                }
            }
            return View();
        }
        public ActionResult Delete(long id)
        {
            new MenuDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}