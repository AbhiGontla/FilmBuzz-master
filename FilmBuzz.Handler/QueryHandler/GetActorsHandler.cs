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
    public class GetActorsHandler : IQueryHandler<GetActors, IEnumerable<GetActorsResult>>
    {
        public IEnumerable<GetActorsResult> Execute(GetActors query)
        {
            var c = RepositoryFactory.GetInstance<TBL_ACTORS>().GetAll().ToList();
            return (from rows in c
                    select new GetActorsResult()
                    {
                        Name = rows.Name,
                        Sex = rows.Sex,
                        Bio = rows.Bio,
                        DOB = rows.DOB,
                        ActorId = rows.ActorId
                    }).OrderBy(data => data.ActorId);
        }
    }
}
