using HunreWeb.Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HunreWeb.Data.Dao
{
    public class ContentDao
    {
        HunreDBContext db = null;
        public ContentDao()
        {
            db = new HunreDBContext();
        }
        public IEnumerable<Content> ListAllPageing(string searchString, int page, int pageSize)
        {
            IQueryable<Content> model = db.Contents;
            if (string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return db.Contents.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public Content getByID(long id)
        {
            return db.Contents.SingleOrDefault(x => x.ID == id);
        }
        public long Insert(Content content)
        {
            content.CreateDate = DateTime.Now;
            db.Contents.Add(content);
            db.SaveChanges();
            return content.ID;
        }
        public bool Update(Content content)
        {
            try
            {
                var id = db.Contents.Find(content.ID);
                id.Name = content.Name;
                id.Image = content.Image;
                id.MetaTitle = content.MetaTitle;
                id.Detail = content.Detail;
                id.CatergoryID = content.CatergoryID;
                id.TopHot = content.TopHot;
                id.TopHot = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public Content ViewDetail(long id) => db.Contents.Find(id);
        public bool Delete(long id)
        {
            try
            {
                var content = db.Contents.Find(id);
                db.Contents.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        // Guest
        /// <summary>
        /// Tra ve danh sach bai viet
        /// </summary>
        /// <param name="top"></param>
        /// <returns>Top content</returns>
        public List<Content> ListContent()
        {
            return db.Contents.Where(x=>x.Status==true).ToList();
        }
        public List<Content> ListNewest()
        {
            return db.Contents.Where(x => x.Status == true).OrderByDescending(x=>x.CreateDate).Take(3).ToList();
        }
        public List<Content> getFeaturePost(int top)
        {
            var content = from a in db.Contents join b in db.catergories on a.CatergoryID equals b.ID where (a.Status == true) select a;
            return content.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public IEnumerable<Content> ListAllContent(long catId, int page, int pageSize)
        {
            IQueryable<Content> model = db.Contents.Where(x=>x.CatergoryID==catId && x.Status==true);           
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
    }
}