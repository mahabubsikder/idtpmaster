using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    public class PaymentController : ControllerBase
    {
        private readonly IBusinessLayer _businessLayer;
        public PaymentController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;

        }

        /// <summary>
        /// Retrieving All Payments
        /// </summary>
        /// <remarks>
        /// Implementation: a. Get All Payments.
        /// </remarks>
        /// <returns>Returns the full Payment document </returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        /// 
        [HttpGet]
        public List<PaymentDTO> GetAllPayment()
        {

            List<PaymentDTO> paymentDTOs =
              (from n in _businessLayer.GetAllPayments()
               .Where(x=> x.CreatedOn >= DateTime.Today)
               select new PaymentDTO
               {
                   Id = n.Id,
                   CustomerName = n.Customer.Name,
                   ContactNumber = n.Customer.ContactNumber,
                   AccountNumber = n.Customer.AccountNumber,
                   TransactionId = n.TransactionId,
                   PaymentAmount = n.PaymentAmount


               }).ToList();

            return paymentDTOs;
        }

        /// <summary>
        /// Retrieving Specific Payment info
        /// </summary>
        /// <remarks>
        /// Implementation:  b. Get Payment by Id.
        /// </remarks>
        /// <params>Payment Id</params>
        /// <returns>Returns the specific Payment document </returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        /// 
        [HttpGet]
        public ActionResult<Payment> GetPaymentById(int id)
        {
            Payment payment = _businessLayer.GetPaymentById(id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        /// <summary>
        /// Creating Payment
        /// </summary>
        /// <remarks>
        /// Implementation: c. Create Payment.
        /// </remarks>
        /// <params>Payment Object</params>
        /// <returns>Returns the created Payment document </returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        /// 
        [HttpPost]
        public ActionResult CreatePayment(TransactionDTO transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }
            try
            {
                var payment = new Payment();
                var beneficiary = _businessLayer.GetBeneficiaryById(transaction.ReceiverId.GetValueOrDefault());
                payment.TransactionId = transaction.TransactionId.ToString();
                payment.AccountNumber = beneficiary.AccountNumber;
                payment.PaymentAmount = Convert.ToDecimal(transaction.Amount);
                payment.EntityState = EntityState.Added;

                Customer customer = _businessLayer.GetAllCustomers().Where(x => x.AccountNumber == beneficiary.AccountNumber).SingleOrDefault();

                payment.CustomerId = customer.Id;
                _businessLayer.AddPayment(payment);

                if (customer != null)
                {
                    customer.TotalPaidAmount += Convert.ToDecimal(transaction.Amount);
                    customer.TotalDueAmount -= Convert.ToDecimal(transaction.Amount);
                    customer.EntityState = EntityState.Modified;
                    _businessLayer.UpdateCustomer(customer);
                }
                return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Id }, payment);
            }
            catch (WebException ex)
            {
                return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), ex.Message });
            }
        }

        /// <summary>
        /// Updating Payment
        /// </summary>
        /// <remarks>
        /// Implementation: d. Update Payment.
        /// </remarks>
        /// <params>Payment Object</params>
        /// <returns>Update the specific Payment document </returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        /// 
        [HttpPost]
        public ActionResult UpdatePayment(PaymentDTO paymentDTO)
        {
            if (paymentDTO != null)
            {
                Payment payment = _businessLayer.GetPaymentById(paymentDTO.Id);

                if (payment == null)
                {
                    return Content("No Payment Found with this Id");
                }
                else
                {
                    payment.CustomerId = paymentDTO.CustomerId;
                    payment.AccountNumber = paymentDTO.AccountNumber;
                    payment.TransactionId = paymentDTO.TransactionId;
                    payment.PaymentAmount = paymentDTO.PaymentAmount;
                    payment.EntityState = EntityState.Modified;
                    _businessLayer.UpdatePayment(payment);
                    return Content("Update Successful of payment from : " + payment.AccountNumber);
                }
            }
            else
            {
                return Content("DTO WAS NULL");
            }
        }

        /// <summary>
        /// Deleting Payment
        /// </summary>
        /// <remarks>
        /// Implementation: e. Delete specific payment.
        /// </remarks>
        /// <params>Payment Id</params>
        /// <returns>Delete the specific payment document </returns>
        /// <returns>Returns 204 No Content Response </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        /// 
        [HttpPost("{id}")]
        public ActionResult DeletePayment(int id)
        {
            var payment = _businessLayer.GetPaymentById(id);
            if (payment == null)
            {
                return Content("No User Found with this Id");
            }
            else
            {
                payment.EntityState = EntityState.Deleted;
                _businessLayer.RemovePayment(payment);
                return NoContent();
            }
        }
    }
}