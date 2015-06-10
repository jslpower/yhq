using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PayAPI.Toolkit
{
   public static class StringExtensions
   {
      public static int GetInt(this string str)
      {
         int res;
         if (int.TryParse(str, out res))
         {
            return res;
         }
         return 0;
      }

      public static string Format(this DateTime time)
      {
         return time.ToString("yyyy-MM-dd");
      }

      #region XElement
      /// <summary>
      /// Get XAttribute Value
      /// </summary>
      /// <param name="XAttribute">xAttribute</param>
      /// <returns>Value</returns>
      public static string GetXAttributeValue(XAttribute xAttribute)
      {
          if (xAttribute == null)
              return string.Empty;

          return xAttribute.Value;
      }

      /// <summary>
      /// Get XAttribute Value
      /// </summary>
      /// <param name="xElement">XElement</param>
      /// <param name="attributeName">Attribute Name</param>
      /// <returns></returns>
      public static string GetXAttributeValue(XElement xElement, string attributeName)
      {
          return GetXAttributeValue(xElement.Attribute(attributeName));
      }

      /// <summary>
      /// Get XElement
      /// </summary>
      /// <param name="xElement">parent xElement</param>
      /// <param name="xName">xName</param>
      /// <returns>XElement</returns>
      public static XElement GetXElement(XElement xElement, string xName)
      {
          XElement x = xElement.Element(xName);

          if (x != null) return x;

          return new XElement(xName);
      }

      /// <summary>
      /// Get XElements
      /// </summary>
      /// <param name="xElement">parent xElement</param>
      /// <param name="xName">xName</param>
      /// <returns>XElements</returns>
      public static IEnumerable<XElement> GetXElements(XElement xElement, string xName)
      {
          var x = xElement.Elements(xName);
          if (x == null)
              return new List<XElement>();

          return x;
      }

      /// <summary>
      /// Get XElement Value
      /// </summary>
      /// <param name="xElement"></param>
      /// <returns></returns>
      public static string GetXElementValue(XElement xElement)
      {
          if (xElement == null) return string.Empty;

          return xElement.Value;
      }
      #endregion
   }
}
