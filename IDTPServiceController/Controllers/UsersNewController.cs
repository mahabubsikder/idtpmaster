// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.using System;

using System.Threading.Tasks;
using IDTPService.Core.Interfaces;
using IDTPService.Core.Models;
using IDTPService.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;


namespace IDTPServiceController.Controllers
{
   // [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]

    public class UsersNewController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UsersNewController(IUserRepository repo)
        {
            _repo = repo;
        }

        ///// <summary>
        ///// Creating a new User Item
        ///// </summary>
        ///// <param name="newUser"> JSON New User document</param>
        ///// <returns>Returns the new User Id </returns>
        ///// <returns>Returns 201 Created success</returns>
        ///// <returns>Returns 400 Bad Request error</returns>
        ///// <returns>Returns 500 Internal Server Error </returns>

        [HttpPost("/CreateNewUser", Name = "CreateNewUser")]
        public async Task<ActionResult> CreateNewUserAsync([Bind("Id,UserName,NID,Email,ContactNo,AccountNo,Balance,PIN")]  IDTPService.Core.Models.User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await _repo.AddAsync(newUser);

            return Ok(user);
        }

        /// <summary>
        /// Retrieving a User using its User Id
        /// </summary>
        /// <remarks>
        /// Retrieves a User using its User Id
        /// </remarks>
        /// <param name="userId">The Id of the User item to be retrieved</param>
        /// <returns>Returns the full User document </returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>

        [HttpGet("/GetExistingUser{userId}", Name = "GetExistingUser")]
        public async Task<ActionResult> GetExistingUserAsync(string userId)
        {
            try
            {
                var user = await _repo.GetByIdAsync(userId);
                return Ok(user);
            }
            catch (EntityNotFoundException)
            {
                return NotFound(userId);
            }
        }


        ///// <summary>
        ///// Updating User item 
        ///// </summary>
        ///// <remarks>Updates an existing item </remarks>
        ///// <param name="userId">Id of an existing User that needs to be updated</param>
        ///// <param name="updatedItem">JSON User document to be updated in an existing User</param>
        ///// <returns>Returns 200 OK success</returns>
        ///// <returns>Returns 400 Bad Request error</returns>
        ///// <returns>Returns 404 Not Found error</returns>
        ///// <returns>Returns 500 Internal Server Error </returns>

        //[HttpPut("/UpdateExistingUser{userId},{updateUser}", Name = "UpdateExistingUser")]
        //public async Task<ActionResult> UpdateExistingUser(string userId, [FromBody]User updatedUser)
        //{
        //    if (updatedUser.Id != userId)
        //    {
        //        return BadRequest(updatedUser.Id);
        //    }

        //    try
        //    {
        //        if (userId == null)
        //        {
        //            return NotFound(userId);
        //        }

        //        await _repo.UpdateAsync(updatedUser);
        //        return Ok();
        //    }
        //    catch (EntityNotFoundException)
        //    {
        //        return NotFound(userId);
        //    }
        //}

        ///// <summary>
        ///// Deleting an existing User
        ///// </summary>
        ///// <remarks>Deletes an existing User item list</remarks>
        ///// <param name="userId"> Id of an existing User that needs to be deleting</param>
        ///// <returns>Returns 204 No Content success</returns>
        ///// <returns>Returns 404 Not Found error</returns>
        ///// <returns>Returns 500 Internal Server Error </returns>

        //[HttpDelete("/RemoveExistingUser{userId}", Name = "RemoveExistingUser")]
        //public async Task<ActionResult> RemoveExistingUser(string userId)
        //{
        //    try
        //    {
        //        var userDelete = await _repo.GetByIdAsync(userId);

        //        if (userDelete == null)
        //        {
        //            return NotFound(userId);
        //        }


        //        await _repo.DeleteAsync(userDelete);

        //        return NoContent();
        //    }
        //    catch (EntityNotFoundException)
        //    {
        //        return NotFound(userId);
        //    }
        //}


    }
}
