using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Northwind.Business.Abstract;
using Northwind.Business.Utilities;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;

namespace Northwind.Business.Concrete
{


    public class ProductManager : IProductService
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

        public List<Product> GetProductsByProductName(string productName, int categoryId)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()) && p.CategoryID == categoryId);
        }



        public void Add(Product product)
        {
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(product);
            //if (result.Errors.Count > 0)
            //{
            //    throw new ValidationException(result.Errors);
            //}
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);

        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
            }
            catch (Exception exception)
            {
                throw new Exception("Silme Gerçekleşemedi!!!");
            }


        }
    }
}
