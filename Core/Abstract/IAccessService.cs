using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract
{
    public interface IAccessService
    {
        bool CheckLogin(string login, string password);
        bool CheckUserRole(string login, string role);
        bool MayViewProfile(string login, int workerId);
    }
}
