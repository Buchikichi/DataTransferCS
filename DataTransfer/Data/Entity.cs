using System.Collections;
using System.Collections.Generic;

namespace DataTransfer.Data
{
    class Entity : IEnumerable<Attribute>
    {
        #region Attributes
        private List<Attribute> list { get; } = new List<Attribute>();
        private Dictionary<string, Attribute> dict = new Dictionary<string, Attribute>();

        public string Name { get; set; }
        #endregion

        public void AddRange(List<Attribute> attributes)
        {
            list.AddRange(attributes);
            foreach (var attr in attributes)
            {
                dict.Add(attr.Name, attr);
            }
        }

        public Attribute GetAttribute(string attrName)
        {
            if (!dict.ContainsKey(attrName))
            {
                return null;
            }
            return dict[attrName];
        }

        public IEnumerator<Attribute> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
