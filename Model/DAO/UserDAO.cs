using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityFramework;

namespace Model.DAO
{
    public class userDAO
    {
        TiemThomDbContext db = null;
        public userDAO()
        {
            db = new TiemThomDbContext();
        }

        public long Insert(user entity)
        {
            db.users.Add(entity);
            db.SaveChanges();
            return entity.id;
        }

        public bool Update(user entity)
        {
            try
            {
                var user = db.users.Find(entity.id);
                user.first_name = entity.first_name;
                user.last_name = entity.last_name;
                if (!string.IsNullOrEmpty(entity.password))
                {
                    user.password= entity.password;
                }
                user.address = entity.address;
                user.email = entity.email;
                user.modified_at = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }


        public user GetById(string userName)
        {
            return db.users.SingleOrDefault(x => x.username == userName);
        }
        public user ViewDetail(int id)
        {
            return db.users.Find(id);
        }

        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.users.SingleOrDefault(x => x.username == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.role_id == 1)
                    {
                        if (result.status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.password == passWord)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }

        public bool ChangeStatus(long id)
        {
            var user = db.users.Find(id);
            user.status = !user.status;
            db.SaveChanges();
            return user.status;
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.users.Find(id);
                db.users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool CheckuserName(string userName)
        {
            return db.users.Count(x => x.username == userName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.users.Count(x => x.email == email) > 0;
        }
    }
}
