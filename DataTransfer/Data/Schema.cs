using System.Collections;
using System.Collections.Generic;

namespace DataTransfer.Data
{
    class Schema : IEnumerable<Entity>
    {
        #region Attributes
        private List<Entity> list = new List<Entity>();
        private Dictionary<string, Entity> dict = new Dictionary<string, Entity>();

        public string Name { get; set; }
        public int NumOfEntity => list.Count;
        #endregion

        public void Add(Entity entity)
        {
            list.Add(entity);
            dict.Add(entity.Name, entity);
        }

        public Entity GetEntity(string tableName)
        {
            if (!dict.ContainsKey(tableName))
            {
                return null;
            }
            return dict[tableName];
        }

        public IEnumerator<Entity> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
