using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BodyControlApp.Database.SqLite
{
   static class DataBaseHelper
    {
        static BodyControlDataBase database;
        public static BodyControlDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new BodyControlDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Foods.sqlite"));
                }
                return database;
            }
        }
    }
}
