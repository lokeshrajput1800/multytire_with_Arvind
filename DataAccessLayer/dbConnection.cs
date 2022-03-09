using System;
using Microsoft.Data.SqlClient;
using CommanLayer.models;

namespace DataAccessLayer
{
    public class dbConnection
    {
        public SqlConnection Cnn;
        public dbConnection()
        {
            Cnn = new SqlConnection(Connection.ConnectionStr);
        }



    }
}
