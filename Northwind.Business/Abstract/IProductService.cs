﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities.Concrete;

namespace Northwind.Business.Abstract
{
     public interface IProductService
     {
         List<Product> GetAll();
         Product Get(int id);
         void Add(Product product);
         void Update(Product product);
         void Delete(Product product);

     }
}
