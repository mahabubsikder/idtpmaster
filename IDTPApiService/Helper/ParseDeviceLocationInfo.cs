using IDTPBusinessLayer;
using IDTPDomainModel;
using System.Xml;

namespace IDTPApiService.Helper
{
   /**
   * Description: This class is responsible for inserting Device and Location info which is provided in the partner api.
   * 
   */
    public static class ParseDeviceLocationInfo
    {
        /// <summary>
        /// Inserts the Device and location info
        /// </summary>
        /// <param name="xmlData">The XmlDocument which is provided in the partner api</param>
        /// <returns>The ID of the inserted row</returns>
        public static int SaveInfo(XmlDocument xmlData)
        {

            DeviceLocationInfo deviceLocation = new DeviceLocationInfo();

            if (xmlData != null)
            {
                string mobileNumber, latLong, location, IP, IEMEIID, OS, App, capability;

                XmlNode parentItem = xmlData.GetElementsByTagName("Device").Item(0);
                XmlNodeList itemList = parentItem.SelectNodes("Tag");

                mobileNumber = itemList.Item(0).Attributes["value"].Value;
                latLong = itemList.Item(1).Attributes["value"].Value;
                location = itemList.Item(2).Attributes["value"].Value;
                IP = itemList.Item(3).Attributes["value"].Value;
                IEMEIID = itemList.Item(4).Attributes["value"].Value;
                OS = itemList.Item(5).Attributes["value"].Value;
                App = itemList.Item(6).Attributes["value"].Value;
                capability = itemList.Item(7).Attributes["value"].Value;



                deviceLocation.MobileNumber = mobileNumber;
                deviceLocation.LatLong = latLong;
                deviceLocation.Location = location;
                deviceLocation.IP = IP;
                deviceLocation.IEMEIID = IEMEIID;
                deviceLocation.OS = OS;
                deviceLocation.App = App;
                deviceLocation.Capability = capability;
                deviceLocation.EntityState = EntityState.Added;

                
                using (BusinessLayer businessLayer = new BusinessLayer()) {
                    businessLayer.AddDeviceLocationInfo(deviceLocation);
                }
                
            }
            return deviceLocation.Id;
        }
    }
}
