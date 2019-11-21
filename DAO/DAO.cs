using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public abstract class DAO
    {
        public SqlConnection con;
        public DAO()
        {
          
            this.con = new SqlConnection("Server=198.71.226.6,1433;Database=CatanDB;User Id=CatanAdmin;Password = CatanAdmin!@1; ");
        }
    }
}
