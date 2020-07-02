using System;

namespace IDTPAdminUI.Models
{
    public class QRCodeViewModel
    {
        public string RecipientName { get; set; }
        public double? Amount { get; set; }
        public string PIN { get; set; }
        public string QRCodeImage { get; set; }
    }
}
