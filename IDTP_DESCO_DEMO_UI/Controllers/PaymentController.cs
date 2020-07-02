using IDTPDataTransferObjects;
using IDTPDescoDemoUI.Helper;
using IDTPDescoDemoUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using X.PagedList;

namespace IDTPDescoDemoUI.Controllers
{
    /**
    * Description:         This controller is designed for fetching the Payments list for DESCO portal.
    */
    public class PaymentController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly string BaseAddress;
        public PaymentController(IConfiguration iConfig)
        {
            configuration = iConfig ?? throw new ArgumentNullException(nameof(iConfig));
            this.BaseAddress = configuration.GetSection("BaseUrl").Value;
        }

        /// <summary>
        /// Retrieving All Payments for View Page
        /// </summary>
        /// <params>page number</params>
        public ActionResult Index(int? page)
        {
            //var listCustomer = new List<Customer>();
            var listPayment = new List<PaymentDTO>();
            var listPaymentViewModel = new List<PaymentViewModel>();
            try
            {
                HttpClientHelper<PaymentDTO> httpClientHelper = new Helper.HttpClientHelper<PaymentDTO>();

                //listCustomer = HttpClientHelper<Customer>.GetAll(BaseAddress + "Customer/GetCustomers");
                listPayment = httpClientHelper.GetAll(new Uri(BaseAddress + "Payment/GetAllPayment"));

                listPaymentViewModel = (from p in listPayment
                                        select new PaymentViewModel
                                        {
                                            Id = p.Id.ToString(new CultureInfo("en-US")),
                                            CustomerName = p.CustomerName,
                                            ContactNumber = p.ContactNumber,
                                            AccountNumber = p.AccountNumber,
                                            TransactionId = p.TransactionId,
                                            PaymentAmount = p.PaymentAmount
                                        }).OrderByDescending(m => m.Id).ToList();
            }
            catch (WebException)
            {

            }
            return View(listPaymentViewModel.ToPagedList(page ?? 1, 7));
        }

    }
}