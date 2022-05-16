using HunreWeb.Data.Dao;
using HunreWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HunreWeb.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ContentDao();
            var model = dao.ListAllPageing(searchString, page, pageSize);
            return View(model);
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
            var dao = new ContentDao();
            var content = dao.getByID(id);
            setViewBag(content.CatergoryID);
            return View(content);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {
                bool res = new ContentDao().Update(model);
                if (res)
                {
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                }
            }
            setViewBag(model.CatergoryID);
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Content model)
        {
            if (ModelState.IsValid)
            {
                long id = new ContentDao().Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                }
            }
            setViewBag();
            return View();
        }
        public void setViewBag(long? selectID = null) //Select catergory trong form create
        {
            var dao = new CatergoryDao();
            ViewBag.CatergoryID = new SelectList(dao.GetCategoryList(), "ID", "Name", selectID);
        }
        public ActionResult Delete(long id)
        {
            new ContentDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}