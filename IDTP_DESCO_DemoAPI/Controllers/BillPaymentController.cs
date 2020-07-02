using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace IDTPDescoDemoAPI.Controllers
{

    /**
    * Description:         The service will get the request from IDTP External Gateway and do the storing things. [This is primariry imitated for DESCO gateway]
    * Invocation:          No need of invocation. Auto triggered when IDTP external gateway will throw the request.
    * Implementation Flow:
    *                      a. Get All Payments.
    *                      b. Get Payment by Id.
    *                      c. Create Payment.
    *                      d. Update Payment.
    *                      e. Delete Payment.
    */
    [Route("[controller]/[action]")]
    [ApiController]
    public class BillPaymentController : ControllerBase
    {

        private readonly IBusinessLayer _businessLayer;
        public BillPaymentController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;

        }
        /// <summary>
        /// Completing Payment
        /// </summary>
        /// <remarks>
        /// Implementation: c. Create Payment.
        /// </remarks>
        /// <params>Payment Object</params>
        /// <returns>Returns the desco reference number for transaction </returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [HttpPost]
        public string BillPayment(TransactionBillDTO transaction)
        {

            if (transaction != null)
            {
                try
                {
                    string descoRefId = "DESCO" + Guid.NewGuid().ToString().Substring(0, 6);
                    Payment payment = new Payment
                    {
                        TransactionId = transaction.TransactionId,
                        AccountNumber = transaction.SenderAccNo,
                        PaymentAmount = (decimal)transaction.Amount,
                        CreatedOn = DateTime.Now
                    };

                    Customer customer = _businessLayer.GetAllCustomers().Where(x => x.AccountNumber == transaction.SenderAccNo).SingleOrDefault();
                    var user = _businessLayer.GetAllBankUsers().Where(x => x.AccountNumber == transaction.SenderAccNo).FirstOrDefault();
                    if (customer != null)
                    {

                        payment.CustomerId = customer.Id;
                        customer.TotalPaidAmount += (decimal)transaction.Amount;
                        customer.TotalDueAmount -= (decimal)transaction.Amount;
                        customer.EntityState = EntityState.Modified;
                        _businessLayer.UpdateCustomer(customer);
                    }
                    else
                    {
                        Customer newCustomer = new Customer
                        {
                            AccountNumber = transaction.SenderAccNo,
                            Name = user.AccountName,
                            ContactNumber = user.ContactNo,
                            TotalDueAmount = 10000,
                            TotalPaidAmount = 500,
                            EntityState = EntityState.Added
                        };
                        _businessLayer.AddCustomer(newCustomer);
                        payment.CustomerId = newCustomer.Id;
                    }
                    payment.EntityState = EntityState.Added;
                    _businessLayer.AddPayment(payment);

                    return descoRefId;
                }
                catch (WebException ex)
                {
                    return "Error: " + ex.ToString();
                }
            }

            else
            {
                return "Transaction Object Can not be Null";
            }


        }

    }
}