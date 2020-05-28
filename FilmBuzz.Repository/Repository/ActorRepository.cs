using FilmBuzz.Common.Interface;
using FilmBuzz.Common.Model;
using FilmBuzz.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TBL_ACTORS = FilmBuzz.Common.Model.TBL_ACTORS;

namespace FilmBuzz.Repository.Repository
{
    public class ActorRepository : IRepository<TBL_ACTORS>
    {
        public bool Create(TBL_ACTORS entity)
        {
            using (var _dbContext = new FilmBuzzDbContext())
            {
                _dbContext.TBL_ACTORS.Add(new TBL_ACTORS()
                {
                    Name = entity.Name,
                    Sex = entity.Sex,
                    Bio = entity.Bio,
                    DOB = entity.DOB
                });
                return _dbContext.SaveChanges() == 1 ? true : false;
            }
        }

        public bool Delete(TBL_ACTORS entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TBL_ACTORS> GetAll()
        {
            using (var _dbContext = new FilmBuzzDbContext())
            {
                return _dbContext.TBL_ACTORS.ToListAsync().Result;
            }
        }

        public IEnumerable<TBL_ACTORS> GetAllWith(object param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TBL_ACTORS> GetAllWith(Expression<Func<TBL_ACTORS, bool>> Expression)
        {
            using (var _dbContext = new FilmBuzzDbContext())
            {
                return _dbContext.TBL_ACTORS.Where(Expression).ToListAsync().Result;
            }
        }

        public bool Update(TBL_ACTORS entity)
        {
            throw new NotImplementedException();
        }
    }
}
