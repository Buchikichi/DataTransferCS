﻿using DataTransfer.Data;
using System;
using System.Data;
using System.Data.Common;

namespace DataTransfer.DB
{
    public abstract class DbConnector : IDisposable
    {
        #region Methods
        protected virtual SchemaInfo CreateSchemaInfo()
        {
            return new SchemaInfo();
        }

        /// <summary>
        /// カラム一覧を取得.
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="tableName"></param>
        /// <param name="schema"></param>
        /// <returns></returns>
        protected virtual void ListColumns(EntityInfo entity)
        {
            var schema = entity.Schema.Name;
            var tableName = entity.Name;
            var query = "SELECT * FROM information_schema.columns"
                + $" WHERE table_schema = '{schema}' AND table_name = '{tableName}'"
                + " ORDER BY table_name, ordinal_position";

            Command.CommandText = query;
            using (var reader = Command.ExecuteReader())
            {
                foreach (IDataRecord rec in reader)
                {
                    entity.Add(new AttributeInfo
                    {
                        Name = (string)rec["column_name"],
                    });
                }
            }
        }

        protected virtual string BuildTableListQuery(SchemaInfo schema)
        {
            return "SELECT * FROM information_schema.tables"
                + $" WHERE table_schema = '{schema.Name}' AND table_type='BASE TABLE'"
                + " ORDER BY table_name";
        }

        protected virtual void ListTables(SchemaInfo schema)
        {
            Command.CommandText = BuildTableListQuery(schema);
            using (var reader = Command.ExecuteReader())
            {
                foreach (IDataRecord rec in reader)
                {
                    schema.Add(new EntityInfo
                    {
                        Schema = schema,
                        Name = (string)rec["table_name"],
                    });
                }
            }
        }

        public SchemaInfo LoadSchema()
        {
            var schema = CreateSchemaInfo();

            ListTables(schema);
            foreach (var entity in schema)
            {
                ListColumns(entity);
            }
            return schema;
        }
        #endregion

        #region Begin/End
        protected abstract DbConnection CreateDbConnection();

        protected abstract DbCommand CreateDbCommand();

        public void Dispose()
        {
            Connection.Dispose();
        }

        public DbConnector(ConnectionInfo info)
        {
            _info = info;
            Connection = CreateDbConnection();
            Command = CreateDbCommand();
            Connection.Open();
        }
        #endregion

        #region Attributes
        protected readonly ConnectionInfo _info;
        protected DbConnection Connection { get; set; }
        public DbCommand Command { get; set; }
        #endregion
    }
}
