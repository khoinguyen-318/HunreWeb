using HunreWeb.Data.Dao;
using HunreWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HunreWeb.Areas.Admin.Controllers
{
    public class SlideController : BaseController
    {
        // GET: Admin/Slide
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new SlideDao();
            var model = dao.ListAllPageing(searchString, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var slide = new SlideDao().ViewDetail(id);
            return View(slide);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Slide slide)
        {
            if (ModelState.IsValid)
            {
                long id = new SlideDao().Insert(slide);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Slide");
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
        public ActionResult Edit(Slide slide)
        {
            if (ModelState.IsValid)
            {
                bool result = new SlideDao().Update(slide);
                if (result)
                {
                    return RedirectToAction("Index", "Slide");
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
            new SlideDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}