using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.DAL
{
    public class UserGateway : BaseGateway
    {
        public bool IsExistsUser(string userName, string password)
        {
            string query = "SELECT * FROM UserAccount WHERE " +
                           "UserName = '" + userName + "' AND Password = '" + password + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExistsUser = reader.HasRows;
            connection.Close();

            return IsExistsUser;
        }
    }
}