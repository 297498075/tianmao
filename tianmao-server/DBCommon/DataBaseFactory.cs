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
                return new MySQL.MySQL();
            else
                return null;
        }
    }

    public enum DataBaseType
    {
        main
    }

}
