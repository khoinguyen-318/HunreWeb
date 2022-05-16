using HunreWeb.Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HunreWeb.Data.Dao
{
    public class MenuDao
    {
        HunreDBContext db = null;
        public MenuDao()
        {
            db = new HunreDBContext();
        }
        public Menu getById(long id)
        {
            return db.Menus.SingleOrDefault(x => x.ID == id);
        }
        public List<Menu> getMenuList()
        {
            return db.Menus.Where(m => m.Status == true).ToList();
        }
        public IEnumerable<Menu> ListAllPageing(string searchString, int page, int pageSize)
        {
            IQueryable<Menu> model = db.Menus;
            if (string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return db.Menus.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public long Insert(Menu menu)
        {
            menu.CreateDate = DateTime.Now;
            db.Menus.Add(menu);
            db.SaveChanges();
            return menu.ID;
        }
        public bool Delete(long id)
        {
            try
            {
                var menu = db.Menus.Find(id);
                db.Menus.Remove(menu);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Menu menu)
        {
            try
            {
                var id = db.Menus.Find(menu.ID);
                id.Name = menu.Name;
                id.Metatitle = menu.Metatitle;
                id.DisplayOrder = menu.DisplayOrder;
                id.Status = menu.Status;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        // Client
        public List<Menu> listMenu()
        {
            return db.Menus.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}