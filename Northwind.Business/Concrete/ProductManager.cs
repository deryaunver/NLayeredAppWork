using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccess.Concrete;
using Northwind.Entities.Concrete;

namespace Northwind.Business.Concrete
{

  
    public class ProductManager
    {
        ProductDal _productDal= new ProductDal();
        public List<Product> GetAll()
        {
            //business Code
            return _productDal.GetAll();
        }

        public Product Get(int id)
        {
            return _productDal.Get(id);
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }
    }
}
