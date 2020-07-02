using System;
using System.Drawing;
using System.IO;
using System.Text;


namespace IDTPBusinessLayerCore.Helper
{

    public static class StringEncoder
    {
        public static MemoryStream Base64ToMemoryStream(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);

            System.IO.MemoryStream stream = new System.IO.MemoryStream(imageBytes);

            return stream;


        }


        public static MemoryStream StringToMemoryStream(string inputString)
        {
            // Convert String to byte[]

            byte[] byteArray = Encoding.Unicode.GetBytes(inputString);
            //byte[] byteArray = Encoding.ASCII.GetBytes(imageString);

            MemoryStream ms = new MemoryStream(byteArray, 0,
              byteArray.Length);

            // MemoryStream ms = new  MemoryStream(byteArray);

            return ms;

        }
        public static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image?.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
    }

}