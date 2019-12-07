using iskurMVC_Eticaret.Data;
using iskurMVC_Eticaret.Data.Entities;
using iskurMVC_Eticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Services
{

    public class AddressService
    {
        MVCE_TicaretDbContext dbContext;
        public AddressService()
        {
            dbContext = new MVCE_TicaretDbContext();
        }
        public List<AddressModel> GetAddressByUserID(int userID)
        {
            var Addresses = dbContext.Addresses.Where(x => x.UserID == userID).Select(x => new AddressModel
            {
                AddressID = x.AddressID,
                Title = x.AddresName,
                _Address = x._Address,
                UserID = x.UserID
            }).ToList();
            return Addresses;
        }

        public void InsertAddres(AddressModel addressModel)
        {
            Address address = new Address()
            {
                AddresName = addressModel.Title,
                UserID = addressModel.UserID,
                _Address = addressModel._Address,
            };

            dbContext.Addresses.Add(address);
            dbContext.SaveChanges();
        }
    }
}