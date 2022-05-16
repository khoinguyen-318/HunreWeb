using HunreWeb.Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HunreWeb.Data.Dao
{
    public class CatergoryDao
    {
        HunreDBContext db = null;
        public CatergoryDao()
        {
            db = new HunreDBContext();
        }
        public List<catergory> GetCategoryList()
        {
            return db.catergories.Where(x => x.Status == true).ToList();
        }
        public catergory getByID(long id)
        {
            return db.catergories.SingleOrDefault(x => x.ID == id);
        }
        public IEnumerable<catergory> ListAllPageing(string searchString, int page, int pageSize)
        {
            IQueryable<catergory> model = db.catergories;
            if (string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return db.catergories.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public bool Update(catergory cat)
        {
            try
            {
                var id = db.catergories.Find(cat.ID);
                id.Name = cat.Name;
                id.MetaTitle = cat.MetaTitle;
                id.DisplayOrder = cat.DisplayOrder;
                id.Status = cat.Status;
                id.IDMenu = cat.IDMenu;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public long Insert(catergory cat)
        {
            cat.CreateDate = DateTime.Now;
            db.catergories.Add(cat);
            db.SaveChanges();
            return cat.ID;
        }
        public bool Delete(long id)
        {
            try
            {
                var cat = db.catergories.Find(id);
                db.catergories.Remove(cat);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        /// <summary>
        /// Client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public catergory ViewDetail(long id)
        {
            return db.catergories.Find(id);
        }
         
    }
}