using iskurMVC_Eticaret.Data;
using iskurMVC_Eticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace iskurMVC_Eticaret.Services
{
    public class ShoppingCartService
    {
        MVCE_TicaretDbContext dbContext;
        public ShoppingCartService()
        {
            dbContext = new MVCE_TicaretDbContext();
        }
        [WebMethod(EnableSession = true)]
        public ShoppingCart AddtoCart(int productID)
        {
            var products = dbContext.Products.Where(x => x.ProductID == productID).Select(x => new ShoppingCart
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                Quantity = 1,
                UnitPrice = x.UnitPrice,
                ImageUrl = x.ImageUrl
            }).FirstOrDefault();
            return products;
        }
    }
}