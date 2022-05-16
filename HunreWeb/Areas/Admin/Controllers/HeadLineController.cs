using HunreWeb.Data.Dao;
using HunreWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HunreWeb.Areas.Admin.Controllers
{
    public class HeadLineController : BaseController
    {
        // GET: Admin/HeadLine
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new HeadLineDao();
            var model = dao.ListAllPageing(searchString, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(long id)
        {
            var headline = new HeadLineDao().ViewDetail(id);
            return View(headline);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(HeadLine headline)
        {
            if (ModelState.IsValid)
            {
                long id = new HeadLineDao().Insert(headline);
                if (id > 0)
                {
                    return RedirectToAction("Index", "HeadLine");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                }

            }
            return View("Index");

        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(HeadLine headline)
        {
            if (ModelState.IsValid)
            {
                bool result = new HeadLineDao().Update(headline);
                if (result)
                {
                    return RedirectToAction("Index", "HeadLine");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }

            }
            return View("Index");

        }
        public ActionResult Delete(int id)
        {
            new HeadLineDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}