using System;
using System.Collections.Generic;
using Ownerofglory.Tasket.Backend.Data.Model;

namespace Ownerofglory.Tasket.Backend.Data.Service
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(long id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(long id);
    }
}
