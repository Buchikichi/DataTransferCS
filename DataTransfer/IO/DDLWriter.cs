using DataTransfer.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataTransfer.IO
{
    class DDLWriter
    {
        private string BuildAttribute(EntityInfo entity)
        {
            var list = new List<string>();
            var pk = new List<string>();

            foreach (var attr in entity)
            {
                var buff = new StringBuilder();

                buff.Append("  ");
                buff.Append(attr.Name);
                list.Add(buff.ToString());
                if (attr.Pk)
                {
                    pk.Add(attr.Name);
                }
            }
            if (0 < pk.Count)
            {
                var keys = string.Join(", ", pk);

                list.Add($"  PRIMARY KEY ({keys})");
            }
            return string.Join(",\n", list);
        }

        private string BuildComment(EntityInfo entity)
        {
            var table = entity.Name;
            var list = new List<string>
            {
                $"COMMENT ON TABLE {table} IS '{entity.Comment}';"
            };
            foreach (var attr in entity)
            {
                list.Add($"COMMENT ON TABLE {table}.{attr.Name} IS '{attr.Comment}';");
            }
            return string.Join("\n", list);
        }

        private string BuildDefinition(EntityInfo entity)
        {
            var buff = new StringBuilder();
            var table = entity.Name;

            buff.Append($"-- DROP TABLE {table} CASCADE;\n");
            buff.Append($"CREATE TABLE {table} (\n");
            buff.Append(BuildAttribute(entity));
            buff.Append("\n);\n");
            buff.Append(BuildComment(entity));
            buff.Append("\n");
            return buff.ToString();
        }

        public void Save(string baseDir, SchemaInfo schema)
        {
            var dt = DateTime.Now.ToString("yyMMdd_HHmmss");
            var dir = baseDir + Path.DirectorySeparatorChar + dt;

            Directory.CreateDirectory(dir);
            foreach (var entity in schema)
            {
                var file = dir + Path.DirectorySeparatorChar + entity.Name + ".sql";

                using (var writer = new StreamWriter(file, false, Encoding.UTF8))
                {
                    writer.Write(BuildDefinition(entity));
                }
            }
        }
    }
}
