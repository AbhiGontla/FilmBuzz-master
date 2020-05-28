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
using TBL_PRODUCERS = FilmBuzz.Common.Model.TBL_PRODUCERS;

namespace FilmBuzz.Repository.Repository
{
    public class ProducerRepository : IRepository<TBL_PRODUCERS>
    {
        public bool Create(TBL_PRODUCERS entity)
        {
            using (var _dbContext = new FilmBuzzDbContext())
            {
                _dbContext.TBL_PRODUCERS.Add(new TBL_PRODUCERS()
                {
                    Name = entity.Name,
                    Sex = entity.Sex,
                    Bio = entity.Bio,
                    DOB = entity.DOB
                });
                return _dbContext.SaveChanges() == 1 ? true : false;
            }
        }

        public bool Delete(TBL_PRODUCERS entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TBL_PRODUCERS> GetAll()
        {
            using (var _dbContext = new FilmBuzzDbContext())
            {
                return _dbContext.TBL_PRODUCERS.ToListAsync().Result;
            }
        }

        public IEnumerable<TBL_PRODUCERS> GetAllWith(object param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TBL_PRODUCERS> GetAllWith(Expression<Func<TBL_PRODUCERS, bool>> Expression)
        {
            using (var _dbContext = new FilmBuzzDbContext())
            {
                return _dbContext.TBL_PRODUCERS.Where(Expression).ToListAsync().Result;
            }
        }

        public bool Update(TBL_PRODUCERS entity)
        {
            throw new NotImplementedException();
        }
    }
}
