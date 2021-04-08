using BANKEST2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BANKEST2.Core.Interfaces
{
    public interface IAuthService 
    {
        bool AuthenticateUser(string UserName, string Password);
    }
}
