using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Abstract;
using Data.Models;

namespace Core.Services
{
    public class AccessService : IAccessService
    {
        private readonly IDataService _data;

        public AccessService(IDataService data)
        {
            _data = data;
        }

        public bool CheckLogin(string login, string passwordHash)
        {
            Worker worker = _data.GetSingleWorkerByEmail(login);
            if (worker != null)
            {
                if (!_data.IsWorkerActive(worker.Id, DateTime.Now))
                    return false;
                return (worker.PasswordHash == passwordHash);
            }

            return false;
        }

        public bool CheckUserRole(string login, string role)
        {
            Worker worker = _data.GetSingleWorkerByEmail(login);

            return worker?.AccessRoles.Any(r => r.Name == "superuser" || r.Name == role) ?? false;
        }
    }
}
