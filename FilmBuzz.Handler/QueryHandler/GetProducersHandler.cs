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
    public class GetProducersHandler : IQueryHandler<GetProducers, IEnumerable<GetProducersResult>>
    {
        public IEnumerable<GetProducersResult> Execute(GetProducers query)
        {
            var c = RepositoryFactory.GetInstance<TBL_PRODUCERS>().GetAll().ToList();
            return (from rows in c
                    select new GetProducersResult()
                    {
                        Name = rows.Name,
                        Sex = rows.Sex,
                        Bio = rows.Bio,
                        DOB = rows.DOB,
                        ProducerId = rows.ProducerId
                    }).OrderBy(data => data.ProducerId);
        }
    }
}
