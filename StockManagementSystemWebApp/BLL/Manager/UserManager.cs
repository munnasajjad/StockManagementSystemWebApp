using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.BLL.Manager
{
    public class UserManager
    {
        private UserGateway userGateway;

        public UserManager()
        {
            userGateway = new UserGateway();
        }

        public bool IsExistsUser(string userName, string password)
        {
            return userGateway.IsExistsUser(userName, password);
        }
    }
}
