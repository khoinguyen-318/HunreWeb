using HunreWeb.Data.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HunreWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Menu = new MenuDao().listMenu();
            ViewBag.FeaturePost = new ContentDao().getFeaturePost(6);
            ViewBag.Post = new ContentDao().ListContent();
            ViewBag.FeaturePostCat = new CatergoryDao().GetCategoryList();
            return View();
        }
        public ActionResult ViewCatergory(long id,int page=1,int pagesize=12)
        {
            var catergory = new ContentDao().ListAllContent(id, page, pagesize);
            ViewBag.CatergoryName = new CatergoryDao().getByID(id);
            return View(catergory);
        }
        public ActionResult Detail(long id)
        {
            var content = new ContentDao().ViewDetail(id);
            ViewBag.CatergoryID = new CatergoryDao().ViewDetail((long)content.CatergoryID);
            return View(content);
        }
        [ChildActionOnly]
        public ActionResult BannerTop()
        {
            ViewBag.Banner = new SlideDao().getBannerTop();
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            ViewBag.MenuList = new MenuDao().listMenu();
            ViewBag.CatergoryList = new CatergoryDao().GetCategoryList();
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult RightSlide()
        {
            ViewBag.RightSlide = new SlideDao().getRightBanner();
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult HeadLine()
        {
            ViewBag.HeadLineList = new HeadLineDao().ListAll();
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult PostFooter()
        {
            ViewBag.Newest = new ContentDao().ListNewest();
            return PartialView();
        }
    }
}