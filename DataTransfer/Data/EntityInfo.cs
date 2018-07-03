using System.Collections;
using System.Collections.Generic;

namespace DataTransfer.Data
{
   public class EntityInfo : IEnumerable<AttributeInfo>
    {
        #region Attributes
        private List<AttributeInfo> list = new List<AttributeInfo>();
        private Dictionary<string, AttributeInfo> dict = new Dictionary<string, AttributeInfo>();

        public SchemaInfo Schema { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        #endregion

        public void Add(AttributeInfo attr)
        {
            list.Add(attr);
            dict.Add(attr.Name, attr);
        }

        public AttributeInfo GetAttribute(string attrName)
        {
            if (!dict.ContainsKey(attrName))
            {
                return null;
            }
            return dict[attrName];
        }

        public IEnumerator<AttributeInfo> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
