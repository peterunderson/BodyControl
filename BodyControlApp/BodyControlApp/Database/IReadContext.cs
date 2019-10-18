using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BodyControlApp.Database.SqLite.Tables;

namespace BodyControlApp.Database
{
    interface IReadContext
    {
         Task<Table> ReadSingle<Table>(Func<Table, bool> predicate) where Table : ITable;

         Task<IList<Table>> ReadMultiple<Table>(Func<Table, bool> predicate) where Table : ITable;

         Task<bool> DeleteSingle<Table>(object value) where Table : ITable;

         Task<bool> DeleteMultiple<Table>(IList<Table> list) where Table : ITable;
    }
}
