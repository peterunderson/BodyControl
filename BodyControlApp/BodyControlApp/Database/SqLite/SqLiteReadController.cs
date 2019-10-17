using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BodyControlApp.Database.SqLite.Tables;

namespace BodyControlApp.Database.SqLite
{
    class SqLiteReadController : IReadContext
    {
        public async Task<bool> DeleteMultiple<Table>(IList<Table> list) where Table : ITable
        {
            return true;
        }

        public async Task<bool> DeleteSingle<Table>(object value) where Table : ITable
        {
            return true;
        }

        public async Task<IList<Table>> ReadMultiple<Table>(Func<Table, bool> predicate) where Table : ITable
        {
            throw new NotImplementedException();
        }

        public async Task<Table> ReadSingle<Table>(Func<Table, bool> predicate) where Table : ITable
        {
            throw new NotImplementedException();
        }
    }
}
