using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.DataAccess.Concrete.NHibernate
{
   public  class NhProductDal:IProductDal
    {
      

     

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product>
            {
                new Product{ProductID = 1,ProductName = "Laptop",UnitPrice = 3000,QuantityPerUnit = "1 in a box",UnitsInStock = 11}
            };
            return products;
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            throw new NotImplementedException();

        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
