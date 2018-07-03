using System;
using System.Data.Common;

namespace DataTransfer.Data
{
    interface IDbConnector : IDisposable
    {
        SchemaInfo LoadSchema();
        DbCommand Command { get; set; }
    }
}
