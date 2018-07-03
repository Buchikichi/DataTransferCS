using System.Collections;
using System.Collections.Generic;

namespace DataTransfer.Data
{
    public class SchemaInfo : IEnumerable<EntityInfo>
    {
        #region Attributes
        private List<EntityInfo> list = new List<EntityInfo>();
        private Dictionary<string, EntityInfo> dict = new Dictionary<string, EntityInfo>();

        public string Name { get; set; }
        public int NumOfEntity => list.Count;
        #endregion

        public void Add(EntityInfo entity)
        {
            list.Add(entity);
            dict.Add(entity.Name, entity);
        }

        public EntityInfo GetEntity(string tableName)
        {
            if (!dict.ContainsKey(tableName))
            {
                return null;
            }
            return dict[tableName];
        }

        public IEnumerator<EntityInfo> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
