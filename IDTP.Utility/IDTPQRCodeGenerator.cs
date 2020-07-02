using QRCoder;
using System.Drawing;

namespace IDTP.Utility
{
/**
* Description: This class is responsible for Generating QR Code.
* 
*/
    public static class IDTPQRCodeGenerator
    {
        /// <summary>
        /// Generated QR Code for the provided string
        /// </summary>
        /// <param name="qrText">The String for which the QR Code to be generated</param>
        /// <returns>The QR Code</returns>
        public static string GenerateQRCode(string qrText)
        {

            string imageString;
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    Bitmap qrCodeImage = qrCode.GetGraphic(20);
                    imageString = IDTPDataCoverter.BitmapToBase64String(qrCodeImage);
                }
            }

            return imageString;
        }
    }
}
