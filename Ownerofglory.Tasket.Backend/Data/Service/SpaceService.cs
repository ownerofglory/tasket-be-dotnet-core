using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ownerofglory.Tasket.Backend.Data.Context;
using Ownerofglory.Tasket.Backend.Data.Model;

namespace Ownerofglory.Tasket.Backend.Data.Service
{
    public class SpaceService : ISpaceService
    {
        private readonly TasketMysqlDbContext _dbContext;

        public SpaceService(TasketMysqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Space space)
        {
            _dbContext.Spaces.Add(space);
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Space> GetAll()
        {
            var spaces = _dbContext.Spaces.ToList();
            return spaces;
        }

        public IEnumerable<Space> GetAllForUser(long userId)
        {
            var spaces = _dbContext.Spaces
                .Where(s => s.UserId == userId);

            return spaces.ToList();
        }

        public Space GetById(long id)
        {
            var space = _dbContext.Spaces
                .Include(s => s.TaskLists)
                .FirstOrDefault(s => s.Id == id);
            return space;
        }

        public void Update(Space space)
        {
            throw new NotImplementedException();
        }

        public bool UserHasPermission(long id, long userId)
        {
            var space = _dbContext.Spaces.FirstOrDefault(s => s.Id == id);

            return space.UserId == userId;
        }
    }
}
