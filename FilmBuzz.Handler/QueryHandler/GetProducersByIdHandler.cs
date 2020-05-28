using FilmBuzz.Common.Interface;
using FilmBuzz.Common.Model;
using FilmBuzz.Handler.Query;
using FilmBuzz.Handler.QueryResult;
using FilmBuzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmBuzz.Handler.QueryHandler
{
    public class GetProducersByIdHandler : IQueryHandler<GetProducersById, GetProducersResult>
    {
        public GetProducersResult Execute(GetProducersById query)
        {
            List<TBL_MOVIES> n = new List<TBL_MOVIES>();
            var user = RepositoryFactory.GetInstance<TBL_PRODUCERS>().GetAllWith(filter => filter.ProducerId == query.ProducerId).FirstOrDefault();
            List<TBL_MOVIES> c = RepositoryFactory.GetInstance<TBL_MOVIES>().GetAllWith(filter => filter.ProducerId == user.ProducerId).ToList();
            var DistinctItems = c.GroupBy(x => x.Name).Select(y => y.First());

            foreach (var item in DistinctItems)
            {
                n.Add(item);
            }
            return new GetProducersResult()
            {
                Name = user.Name,
                Sex = user.Sex,
                Bio = user.Bio,
                DOB = user.DOB,
                _movieslist = n
            };
        }
    }
}
