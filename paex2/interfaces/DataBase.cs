using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace paex2.interfaces
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
