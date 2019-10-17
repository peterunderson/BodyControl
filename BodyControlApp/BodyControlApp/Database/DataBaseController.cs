using System;
using System.Collections.Generic;
using System.Text;
using BodyControlApp.Database.SqLite;

namespace BodyControlApp.Database
{
    class DataBaseController
    {
        public IReadContext ReadContext { get; set; }

        public IWriteContext WriteContext { get; set; }

        public DataBaseController()
        {
            ReadContext = new SqLiteReadController();
        }
    }
}
