using HunreWeb.Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HunreWeb.Data.Dao
{
    public class HeadLineDao
    {
        HunreDBContext db = null;
        public HeadLineDao()
        {
                db = new HunreDBContext();
        }
        public long Insert(HeadLine headline)
        {
            headline.CreateDate = DateTime.Now;
            db.HeadLines.Add(headline);
            db.SaveChanges();
            return headline.ID;
        }
        public IEnumerable<HeadLine> ListAllPageing(string searchString, int page, int pageSize)
        {
            IQueryable<HeadLine> model = db.HeadLines;
            if (string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return db.HeadLines.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public bool Update(HeadLine headline)
        {
            try
            {
                var id = db.HeadLines.Find(headline.ID);
                id.Name = headline.Name;
                id.DisplayOrder = headline.DisplayOrder;
                id.Status = headline.Status;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public HeadLine getByID(long id)
        {
            return db.HeadLines.SingleOrDefault(x => x.ID == id);
        }
        public HeadLine ViewDetail(long id) => db.HeadLines.Find(id);
        public bool Delete(long id)
        {
            try
            {
                var headline = db.HeadLines.Find(id);
                db.HeadLines.Remove(headline);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<HeadLine> ListAll()
        {
            return db.HeadLines.ToList();
        }
    }
}