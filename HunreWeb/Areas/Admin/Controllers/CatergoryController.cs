using HunreWeb.Data.Dao;
using HunreWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HunreWeb.Areas.Admin.Controllers
{
    public class CatergoryController : BaseController
    {
        // GET: Admin/Catergory
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CatergoryDao();
            var model = dao.ListAllPageing(searchString, page, pageSize);
            return View(model);
        }
        public void setViewBag(long? selectID = null)
        {
            var dao = new MenuDao();
            ViewBag.IDMenu = new SelectList(dao.getMenuList(), "ID", "Name", selectID);
        }
        [HttpGet]
        public ActionResult Create()
        {
            setViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var cat = new CatergoryDao().getByID(id);
            setViewBag(cat.IDMenu);
            return View(cat);
        }
        [HttpPost]
        public ActionResult Create(catergory cat)
        {
            if (ModelState.IsValid)
            {

                long id = new CatergoryDao().Insert(cat);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Catergory");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                }

            }
            setViewBag();
            return View("Index");

        }
        [HttpPost]
        public ActionResult Edit(catergory cat)
        {
            if (ModelState.IsValid)
            {
                bool result = new CatergoryDao().Update(cat);
                if (result)
                {
                    return RedirectToAction("Index", "Catergory");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }

            }
            setViewBag(cat.IDMenu);
            return View("Index");

        }
        public ActionResult Delete(long id)
        {
            new CatergoryDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}