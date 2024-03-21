using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityFramework;

namespace Model.DAO
{
    public class CategoryDAO
    {
        TiemThomDbContext db = null;
        public CategoryDAO()
        {
            db = new TiemThomDbContext();
        }
        public int Insert(category category)
        {
            db.categories.Add(category);
            db.SaveChanges();
            return category.id;
        }
        public List<category> ListAll()
        {
            return db.categories.ToList();
        }
        public product ViewDetail(int id)
        {
            return db.products.Find(id);
        }

        public category GetById(int id)
        {
            var data = db.categories.Find(id);
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public int UpdateCategory(category category)
        {
            var data = db.categories.Find(category.id);
            if (data == null)
            {
                return -1; 
            }

            try
            {
                if (!string.IsNullOrEmpty(category.name))
                {
                    data.name = category.name;
                }

                if (category.order != null)
                {
                    data.order = category.order;
                }

                if (category.parent_id != null)
                {
                    data.parent_id = category.parent_id;
                }

                data.status = category.status;
                data.modified_at = DateTime.Now;

                db.SaveChanges(); 
                return 1; 
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DeleteCategory(int id)
        {
            try
            {
                var category = db.categories.Find(id);
                if (category == null)
                {
                    return -1;
                }

                db.categories.Remove(category);
                db.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
