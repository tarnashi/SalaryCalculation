using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract
{
    public interface IAccessService
    {
        bool CheckLogin(string login, string passwordHash);
        bool CheckUserRole(string login, string role);
    }
}
