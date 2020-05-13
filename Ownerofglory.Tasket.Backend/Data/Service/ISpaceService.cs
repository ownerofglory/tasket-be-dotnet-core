using System;
using System.Collections.Generic;
using Ownerofglory.Tasket.Backend.Data.Model;

namespace Ownerofglory.Tasket.Backend.Data.Service
{
    public interface ISpaceService
    {
        void Create(Space space);
        void Update(Space space);
        IEnumerable<Space> GetAll();
        IEnumerable<Space> GetAllForUser(long userId);
        bool UserHasPermission(long spaceId, long userId);
        Space GetById(long id);
        void Delete(long id);
    }
}
