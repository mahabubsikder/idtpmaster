using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace IDTP.Utility
{
/**
* Description: This class is responsible for data convesion from one type to anothor.
* 
*/
    public static class IDTPDataCoverter
    {
        /// <summary>
        /// Converts Bitmap to Base64 String
        /// </summary>
        /// <param name="img">The Bitmap to be converted</param>
        /// <returns>The Base64 String</returns>
        public static string BitmapToBase64String(Bitmap img)
        {
            string res = string.Empty;

            using (MemoryStream stream = new MemoryStream())
            {
                if (img != null)
                {
                    img.Save(stream, ImageFormat.Png);
                    res = Convert.ToBase64String(stream.ToArray());
                }
            }
            return res;
        }
    }
}
