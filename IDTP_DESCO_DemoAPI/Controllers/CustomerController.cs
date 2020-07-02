using IDTPBusinessLayer;
using IDTPDomainModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.Common;
using System.Net;


namespace IDTPServiceController.Controllers
{
    /**
    * Description:         The service will get the request from the DESCO portal and do the storing things. [This is primariry imitated for DESCO portal]
    * Invocation:          No need of invocation. Auto triggered when IDTP external gateway will throw the request.
    * Implementation Flow:
    *                      a. Get All Customers.
    *                      b. Get Customer by Id.
    *                      c. Create Customer.
    *                      d. Update Customer.
    *                      e. Delete Customer.
    */

    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IBusinessLayer _businessLayer;
        public CustomerController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        /// <summary>
        /// Retrieving All Customers
        /// </summary>
        /// <remarks>
        /// Implementation: a. Get All Customers.
        /// </remarks>
        /// <returns>Returns the full Customers document </returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        /// 
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _businessLayer.GetAllCustomers();
        }

        /// <summary>
        /// Retrieving Specific Customer info
        /// </summary>
        /// <remarks>
        /// Implementation:  b. Get Customer by Id.
        /// </remarks>
        /// <params>Customer Id</params>
        /// <returns>Returns the specific Customer document </returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        /// 
        [HttpGet]
        public ActionResult<Customer> GetCustomerById(int id)
        {

            Customer customer = _businessLayer.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        /// <summary>
        /// Creating Customer
        /// </summary>
        /// <remarks>
        /// Implementation: c. Create Customer.
        /// </remarks>
        /// <params>Customer Object</params>
        /// <returns>Returns the created Customer document </returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        /// 
        [HttpPost]
        public ActionResult CreateCustomer([Bind("Id,Name,AccountNumber,ContactNumber,TotalPaidAmount,TotalDueAmount")] Customer customer)
        {
            if (customer != null)
            {
                try
                {
                    customer.EntityState = EntityState.Added;
                    _businessLayer.AddCustomer(customer);
                    return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
                }
                catch (DbException ex)
                {
                    return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), ex.Message });
                }
            }
            else
            {
                return Ok("Customer Object Can Not be Null");
            }

        }

        /// <summary>
        /// Updating Customer
        /// </summary>
        /// <remarks>
        /// Implementation: d. Update Customer.
        /// </remarks>
        /// <params>Customer Object</params>
        /// <returns>Update the specific Customer document </returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        /// 
        [HttpPost]
        public ActionResult UpdateCustomer([Bind("Id,Name,AccountNumber,ContactNumber,TotalPaidAmount,TotalDueAmount")] Customer customer)
        {
            if (customer != null)
            {
                Customer customerTest = _businessLayer.GetCustomerById(customer.Id);
                if (customerTest == null)
                {
                    return Content("No User Found with this Id");
                }
                else
                {
                    customer.EntityState = EntityState.Modified;
                    _businessLayer.UpdateCustomer(customer);
                    return Content("Update Successful of customer : " + customer.Name);
                }
            }

            else
            {
                return Ok("Customer Object Can Not be Null");
            }

        }

        /// <summary>
        /// Deleting Customer
        /// </summary>
        /// <remarks>
        /// Implementation: e. Delete specific Customer.
        /// </remarks>
        /// <params>Payment Id</params>
        /// <returns>Delete the specific Customer document </returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        /// 
        [HttpPost("{id}")]
        public ActionResult DeleteCustomer([Bind("Id")] int id)
        {
            var customer = _businessLayer.GetCustomerById(id);
            if (customer == null)
            {
                return Content("No User Found with this Id");
            }
            else
            {
                customer.EntityState = EntityState.Deleted;
                _businessLayer.RemoveCustomer(customer);
                return NoContent();
            }
        }

    }

}
