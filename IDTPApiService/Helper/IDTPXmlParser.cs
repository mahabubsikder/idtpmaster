using System.Xml.Linq;

namespace IDTPApiService.Helper
{
    /**
    * Description:This class is responsible for preparing succcess and failure XML response message for partner api.
    * 
    */
    public static class IDTPXmlParser
    {
        /// <summary>
        /// Prepare Success XML response
        /// </summary>
        /// <param name="parentTag"></param>
        /// <param name="refTagName"></param>
        /// <param name="refValue"></param>
        /// <returns>Success XML response</returns>
        public static string PrepareSuccessResponse(string parentTag, string refTagName, string refValue)
        {

            XElement xml = new XElement(parentTag,
                new XElement("Code", "200"),
                new XElement("Message", "Success"),
                new XElement(refTagName, refValue));

            return xml.ToString();
        }
        /// <summary>
        /// Prepare Failure XML response
        /// </summary>
        /// <param name="parentTag"></param>
        /// <returns>Failure XML response</returns>
        public static string PrepareFailResponse(string parentTag)
        {

            XElement xml = new XElement(parentTag,
                new XElement("Code", "400"),
                new XElement("Message", "Invalid Request"));

            return xml.ToString();
        }
    }
}
