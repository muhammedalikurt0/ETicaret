using iskurMVC_Eticaret.Data;
using iskurMVC_Eticaret.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Services
{
    public class OrdersOrderDetailsService
    {
        MVCE_TicaretDbContext dbContext;
        public OrdersOrderDetailsService()
        {
            dbContext = new MVCE_TicaretDbContext();
        }
        public string InserOrderOrderDetails(Orders orders, List<OrderDetails> orderDetailList)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var insertedOrder = dbContext.Orders.Add(orders);
                    foreach (var item in orderDetailList)
                    {
                        item.OrderID = insertedOrder.OrderID;
                        dbContext.OrderDetails.Add(item);
                    }
                    dbContext.SaveChanges();
                    transaction.Commit();
                    return "Siparişiniz alınmıştır";
                }
                catch
                {
                    transaction.Rollback();
                    return "Hata";
                }
            }
        }
    }
}