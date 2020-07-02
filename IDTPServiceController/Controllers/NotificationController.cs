using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IDTPDataAccessLayer.Models;
using IDTPDataLayerAccess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDTPServiceController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly ICosmosDbServiceNotification _cosmosDbService;

        public NotificationController(ICosmosDbServiceNotification cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetNotification(String id)
        {
            Notification notification = await _cosmosDbService.GetItemAsync(id);

            if (notification == null)
            {
                return NotFound();
            }

            return notification;
        }

        [HttpGet("/GetNotificationsByUserId", Name = "GetNotificationsByUserId")]
        public async Task<IEnumerable<Notification>> GetNotificationsByUserId(String userId)
        {
            //return await _cosmosDbService.GetNotificationsByUserIdAsync(userId);
            IEnumerable<Notification> notifications = await _cosmosDbService.GetItemsAsync();
            return notifications.ToList().Where(x => x.UserId.Equals(userId));
        }

        [HttpGet("/GetNotificationMessageByUserId", Name = "GetNotificationMessageByUserId")]
        public async Task<String> GetNotificationMessageByUserId(String userId)
        {
            //return await _cosmosDbService.GetNotificationsByUserIdAsync(userId);
            IEnumerable<Notification> notifications = await _cosmosDbService.GetItemsAsync();
            notifications.ToList().Where(x => x.UserId.Equals(userId));
            string notificationMessage = "";
            foreach (Notification notification in notifications)
            {
                if(notification.UserId == userId)
                {
                    if(notificationMessage == "")
                    {
                        notificationMessage += notification.StatusMessage;
                    }
                    else
                    {
                        notificationMessage += ", " + notification.StatusMessage;
                    }
                }
            }
            return notificationMessage;
        }

        [HttpGet("/GetNotificationMessageByUserIdAndTransactionId", Name = "GetNotificationMessageByUserIdAndTransactionId")]
        public async Task<String> GetNotificationMessageByUserIdAndTransactionId(String userId, String transactionId)
        {
            IEnumerable<Notification> notifications = await _cosmosDbService.GetItemsAsync();
            notifications.ToList().Where(x => x.UserId.Equals(userId));
            string notificationMessage = "";
            foreach (Notification notification in notifications)
            {
                if (notification.UserId == userId && notification.TransactionId == transactionId)
                {
                    if (notificationMessage == "")
                    {
                        notificationMessage += notification.StatusMessage;
                    }
                    else
                    {
                        notificationMessage += ", " + notification.StatusMessage;
                    }
                }
            }
            return notificationMessage;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([Bind("Id,TransactionId,UserId,TransactionTypeId,SenderId,ReceiverId,SenderAccNo,ReceiverAccNo,Amount,StatusId")] Notification notification)
        {

            await _cosmosDbService.AddItemAsync(notification);
            return CreatedAtAction(nameof(GetNotification), new { id = notification.Id }, notification);
        }

		#region message publish and subscribe

		//private static ConcurrentBag<StreamWriter> clients;

		//[HttpGet]
		//public async Task Get()
		//{
		//	string[] data = new string[]
		//	{
		//		"Hello",
		//		"How are you?",
		//		"What are you doing?",
		//		"Are you there?"
		//	};
		//	Response.Headers.Add("Content-Type", "text/event-stream");

		//	for(int i= 0; i < data.Length; i++)
		//	{
		//		string message = $"data:{i+1}.{data[i]}\n\n";
		//		byte[] messageBytes = ASCIIEncoding.ASCII.GetBytes(message);
		//		await Response.Body.WriteAsync(messageBytes,0,messageBytes.Length);
		//		await Response.Body.FlushAsync();
		//	}
		//}

		#endregion
	}
}