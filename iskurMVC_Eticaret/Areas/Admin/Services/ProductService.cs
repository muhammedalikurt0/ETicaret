using iskurMVC_Eticaret.Areas.Admin.Models.ProductModels;
using iskurMVC_Eticaret.Data;
using iskurMVC_Eticaret.Data.Entities;
using iskurMVC_Eticaret.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Areas.Admin.Services
{
    public class ProductService
    {
        MVCE_TicaretDbContext dbContext;
        public ProductService()
        {
            dbContext = new MVCE_TicaretDbContext();
        }

        public List<ProductViewModel> GetAllProducts()
        {
            var productList = dbContext.Products.Select(x => new ProductViewModel
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                CategoryName = x.Category.CategoryName,
                UnitPrice = x.UnitPrice
            }).ToList();
            return productList;
        }

        public ProductUpdateModel GetProductByProductID(int ProductID)
        {
            var productList = dbContext.Products.Where(x => x.ProductID == ProductID).Select(x => new ProductUpdateModel()
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                CategoryID = x.CategoryID,
                UnitPrice = x.UnitPrice,
                Description = x.Description,
                Info = x.Info,
                ImageUrl = x.ImageUrl
            }).SingleOrDefault();
            return productList;
        }

        public void InsertProduct(ProductInsertModel productInsertModel)
        {
            Products product = new Products()
            {
                ProductName = productInsertModel.ProductName,
                CategoryID = productInsertModel.CategoryID,
                UnitPrice = productInsertModel.UnitPrice,
                Description = productInsertModel.Description,
                Info = productInsertModel.Info,
                ImageUrl = productInsertModel.ImageUrl
            };

            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }

        public void UpdateProduct(ProductUpdateModel productUpdateModel)
        {
            var selectedProduct = dbContext.Products.SingleOrDefault(x => x.ProductID == productUpdateModel.ProductID);
            selectedProduct.ProductName = productUpdateModel.ProductName;
            selectedProduct.CategoryID = productUpdateModel.CategoryID;
            selectedProduct.UnitPrice = productUpdateModel.UnitPrice;
            selectedProduct.Description = productUpdateModel.Description;
            selectedProduct.Info = productUpdateModel.Info;
            selectedProduct.ImageUrl = productUpdateModel.ImageUrl;
            dbContext.SaveChanges();
        }

        public void DeleteProduct(int productID)
        {
            var selectedProduct = dbContext.Products.SingleOrDefault(x => x.ProductID == productID);
            dbContext.Products.Remove(selectedProduct);
            dbContext.SaveChanges();
        }


    }
}