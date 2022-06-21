using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebUI.Infrastructure.Abstract;

namespace WebUI.Infrastructure.Concrete
{
    public class FornAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool rezult = FormsAuthentication.Authenticate(username, password);
            if (rezult)
                FormsAuthentication.SetAuthCookie(username, false);
            return rezult;
        }
    }
}