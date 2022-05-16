using HunreWeb.Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HunreWeb.Data.Dao
{
    public class SlideDao
    {
        HunreDBContext db = null;
        public SlideDao()
        {
            db = new HunreDBContext();
        }
        public long Insert(Slide slide)
        {
            slide.CreateDate = DateTime.Now;
            db.Slides.Add(slide);
            db.SaveChanges();
            return slide.ID;
        }
        public IEnumerable<Slide> ListAllPageing(string searchString, int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slides;
            if (string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Link.Contains(searchString));
            }
            return db.Slides.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public bool Update(Slide slide)
        {
            try
            {
                var id = db.Slides.Find(slide.ID);
                id.Link = slide.Link;
                id.DisplayOrder = slide.DisplayOrder;
                id.Status = slide.Status;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public Slide getByID(int  id)
        {
            return db.Slides.SingleOrDefault(x => x.ID == id);
        }
        public Slide ViewDetail(int id) => db.Slides.Find(id);
        public bool Delete(int id)
        {
            try
            {
                var slide = db.Slides.Find(id);
                db.Slides.Remove(slide);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Slide> getBannerTop()
        {
            return db.Slides.Where(x => x.DisplayOrder == 0 && x.Status == true).Take(1).ToList();
        }
        public List<Slide> getRightBanner()
        {
            return db.Slides.Where(x=>x.Status==true&&x.DisplayOrder>0).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}