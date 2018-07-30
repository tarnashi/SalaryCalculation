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

            if (IsSuperUser(worker))
                return true;

            return worker?.AccessRoles.Any(r => r.Name == role) ?? false;
        }

        //смотреть профиль может или начальник любого уровня иерархии, или суперпользователь
        public bool MayViewProfile(string login, int workerId)
        {
            Worker currentWorker = _data.GetSingleWorkerByEmail(login);

            if (IsSuperUser(currentWorker))
                return true;

            return _data.IsWorkerSuperior(currentWorker.Id, workerId);
        }

        private bool IsSuperUser(Worker worker)
        {
            return worker?.AccessRoles.Any(r => r.Name == "superuser") ?? false;
        }
    }
}
