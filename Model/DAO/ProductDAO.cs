using System;
using System.Collections.Generic;
using System.Linq;
using Model.EntityFramework;

namespace Model.DAO
{
    public class ProductDAO
    {
        private readonly TiemThomDbContext db;

        public ProductDAO()
        {
            db = new TiemThomDbContext();
        }

        public int Insert(product product)
        {
            db.products.Add(product);
            db.SaveChanges();
            return product.id;
        }

        public List<product> ListAll()
        {
            return db.products.ToList();
        }

        public List<product> ListOfCategory(int id)
        {
            return db.products.Where(x => x.category_id == id).ToList();
        }

        public product ViewDetail(int id)
        {
            return db.products.Find(id);
        }

        public product GetById(int id)
        {
            return db.products.Find(id);
        }

        public int UpdateProduct(product product)
        {
            var data = db.products.Find(product.id);
            if (data == null)
            {
                return -1;
            }

            try
            {
                if (!string.IsNullOrEmpty(product.name))
                {
                    data.name = product.name;
                }

                if (product.description != null)
                {
                    data.description = product.description;
                }

                if (product.price != null)
                {
                    data.price = product.price;
                }

                if (product.image != null)
                {
                    data.image = product.image;
                }

                if (product.category_id != null)
                {
                    data.category_id = product.category_id;
                }

                if (product.discount != null)
                {
                    data.discount = product.discount;
                }

                if (product.quantity != null)
                {
                    data.quantity = product.quantity;
                }

                data.status = product.status;
                data.modified_at = DateTime.Now;

                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                // Handle exception, log error, etc.
                return 0;
            }
        }

        public int DeleteProduct(int id)
        {
            try
            {
                var product = db.products.Find(id);
                if (product == null)
                {
                    return -1;
                }

                db.products.Remove(product);
                db.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                // Handle exception, log error, etc.
                return 0;
            }
        }
    }
}
