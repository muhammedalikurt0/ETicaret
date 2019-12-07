using iskurMVC_Eticaret.Data;
using iskurMVC_Eticaret.Data.Entities;
using iskurMVC_Eticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Services
{
    public class CreditCardService
    {
        MVCE_TicaretDbContext _dbContext;
        public CreditCardService(MVCE_TicaretDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CreditCardModel> GetAllCreditCard()
        {
            return _dbContext.CreditCards.Select(x => new CreditCardModel()
            {
                CardID = x.CardID,
                Balance = x.Balance,
                CardTitle = x.CardTitle,
                CustomerFullName = x.CustomerFullName,
                CVC = x.CVC,
                IBAN = x.IBAN,
                Valid = x.Valid
            }).ToList();
        }
    }
}