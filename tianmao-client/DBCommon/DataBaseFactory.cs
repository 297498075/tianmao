using System;
using System.Collections.Generic;
using System.Text;

namespace DBCommon
{
    public static class DataBaseFactory
    {
        public static IDataBase GetDataBase(DataBaseType dataBaseType)
        {
            if (dataBaseType == DataBaseType.main)
                return MySQL.MySQL.GetDataBase();
            else
                return null;
        }
    }

    public enum DataBaseType
    {
        main
    }

}
