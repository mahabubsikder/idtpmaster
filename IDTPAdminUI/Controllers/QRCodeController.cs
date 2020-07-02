using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using IDTP.Utility;
using IDTPAdminUI.Models;
using Microsoft.AspNetCore.Authorization;

namespace IDTPDemoUI.Controllers
{
/**
* Description:         The service is triggered automatically when a FCM message is received in the device for a definite app instance.
* Invocation:          No need of invocation. Auto triggered when FCM message is received.
* Implementation Flow:
*                      a. Get a QR code for the provided parameters.
*/
    public class QRCodeController : Controller
    {
        /// <summary>
        /// Shows the view to enter information to generate QR Code
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Index() {
            QRCodeViewModel qRCodeViewModel = new QRCodeViewModel();
            return View(qRCodeViewModel);
        }

        /// <summary>
        /// Generates the QR code with the data from view
        /// </summary>
        /// <returns>QR Code Image</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult Index(string name, double amount, string pin) {

            string imageString=string.Empty;
            var qrText = $"{name} Amount: {amount}";
            imageString= IDTPQRCodeGenerator.GenerateQRCode(qrText);

            QRCodeViewModel qRCodeViewModel = new QRCodeViewModel() { RecipientName = name, Amount = amount, PIN = pin, QRCodeImage = imageString };
            return View(qRCodeViewModel);
        }

        
    }
}
