using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Model
{
    internal class ConnectionString
    {
        public static string connectionString = @"Data Source=LAPTOP-68IT06KU;Initial Catalog=QLBanHang;Integrated Security=True";

        //public DataTable Execute(string sqlStr)
        //{
        //    adapter = new SqlDataAdapter(sqlStr, sqlConnection);
        //    dataTable = new DataTable();
        //    adapter.Fill(dataTable);
        //    return dataTable;
        //}

        //public void ExecuteNonQuery(string strSQL)
        //{
        //    SqlCommand sqlcmd = new SqlCommand(strSQL, sqlConnection);
        //    sqlConnection.Open();
        //    sqlcmd.ExecuteNonQuery();
        //    sqlConnection.Close();
        //}
    }
}
