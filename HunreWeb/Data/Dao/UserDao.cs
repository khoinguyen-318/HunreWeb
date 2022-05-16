using HunreWeb.Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HunreWeb.Data.Dao
{
    public class UserDao
    {
        HunreDBContext hunreDB = null;
        public UserDao()
        {
            hunreDB = new HunreDBContext();
        }
        public long Insert(User user)
        {
            user.CreateDate = DateTime.Now;
            hunreDB.Users.Add(user);
            hunreDB.SaveChanges();
            return user.ID;
        }
        public bool Login(String userName, String passWord)
        {
            var result = hunreDB.Users.Count(x => x.UserName == userName && x.PassWord == passWord);
            if (result > 0)
            {
                return true;
            }
            else { return false; }
        }
        public IEnumerable<User> ListAllPageing(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = hunreDB.Users;
            if (string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.PassWord.Contains(searchString));
            }
            return hunreDB.Users.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public bool Update(User user)
        {
            try
            {
                var id = hunreDB.Users.Find(user.ID);
                id.UserName = user.UserName;
                id.PassWord = user.PassWord;
                hunreDB.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public User getByID(string username)
        {
            return hunreDB.Users.SingleOrDefault(x => x.UserName == username);
        }
        public User ViewDetail(long id) => hunreDB.Users.Find(id);
        public bool Delete(long id)
        {
            try
            {
                var user = hunreDB.Users.Find(id);
                hunreDB.Users.Remove(user);
                hunreDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}