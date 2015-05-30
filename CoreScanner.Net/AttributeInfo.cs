using Light;
using System;
using System.Linq;
using System.Xml.Linq;

namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    public struct AttributeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public AttributeId Id
        {
            get { return id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public AttributeType Type
        {
            get { return type; }
        }

        /// <summary>
        /// 
        /// </summary>
        public AttributePermission Permission
        {
            get { return permission; }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Value
        {
            get { return value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeInfoXml"></param>
        /// <returns></returns>
        public static AttributeInfo Parse(String attributeInfoXml)
        {
            AttributeInfo attributeInfo = new AttributeInfo();
            XElement attribute = attributeInfoXml
                .ParseXmlDocument()
                .Elements("attribute")
                .FirstOrDefault();
            if (attribute == null)
                throw new FormatException();

            attributeInfo.id = attribute
                .Elements("id")
                .Select(id => (AttributeId)id.Value.ToInt32())
                .FirstOrDefault();
            attributeInfo.name = attribute
                .Elements("name")
                .Select(name => name.Value)
                .FirstOrDefault();
            attributeInfo.type = attribute
                .Elements("datatype")
                .Select(datatype => datatype.Value.ToAttributeType())
                .FirstOrDefault();
            attributeInfo.permission = attribute
                .Elements("permission")
                .Select(permission => permission.Value.ToAttributePermission())
                .FirstOrDefault();
            attributeInfo.value = attribute
                .Elements("value")
                .Select(datatype => datatype.Value)
                .FirstOrDefault();
            return attributeInfo;
        }

        private AttributeId id;
        private String name;
        private AttributeType type;
        private AttributePermission permission;
        private String value;
    }
}
