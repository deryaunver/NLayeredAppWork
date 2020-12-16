using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Business.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;

namespace Northwind.Business.Concrete
{

  
    public class ProductManager:IProductService
    {
        //data access katmanjnı newliyordum 
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        public List<Product> GetAll()
        {
            //business Code
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryID == categoryId);
        }

        public List<Product> GetProductsByProductName(string productName,int categoryId)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()) && p.CategoryID==categoryId);
        }
    }
}
