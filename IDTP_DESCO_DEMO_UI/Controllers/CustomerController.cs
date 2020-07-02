using IDTPDescoDemoUI.Helper;
using IDTPDomainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using X.PagedList;

namespace IDTPDescoDemoUI.Controllers
{
    /**
    * Description:         This controller is designed for fetching the Customers list for DESCO portal.
    */

    public class CustomerController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly string BaseAddress;
        public CustomerController(IConfiguration iConfig)
        {
            configuration = iConfig ?? throw new ArgumentNullException(nameof(iConfig));
            this.BaseAddress = configuration.GetSection("BaseUrl").Value;
        }

        /// <summary>
        /// Retrieving All Customers for View Page
        /// </summary>
        /// <params>page number</params>
        public ActionResult Index(int? page)
        {
            var list = new List<Customer>();
            HttpClientHelper<Customer> httpClientHelper = new Helper.HttpClientHelper<Customer>();
            try
            {
                list = httpClientHelper.GetAll(new Uri(BaseAddress + "Customer/GetCustomers")).OrderByDescending(m => m.Id).ToList();
            }
            catch (WebException)
            {

            }
            return View(list.ToPagedList(page ?? 1, 7));
        }

    }
}