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

        public bool CheckLogin(string login, string password)
        {
            Worker worker = _data.GetSingleWorkerByEmail(login);
            if (worker != null)
            {
                if (!_data.IsWorkerActive(worker.Id, DateTime.Now))
                    return false;
                return (worker.PasswordHash.ToLower() == CreateMd5(password).ToLower());
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

        public static string CreateMd5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
