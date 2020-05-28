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
    public class GetMoviesHandler : IQueryHandler<GetMovies, IEnumerable<GetMoviesResult>>
    {
        public IEnumerable<GetMoviesResult> Execute(GetMovies query)
        {
            var c = RepositoryFactory.GetInstance<TBL_MOVIES>().GetAll().ToList();
            // selects the distinct movie names
            var d=c.GroupBy(car => car.Name).Select(g => g.First()).ToList();
            return (from rows in d
                    select new GetMoviesResult()
                    {
                        MovieId=rows.MovieId,
                        Name = rows.Name,
                        ActorId = rows.ActorId,
                        Plot = rows.Plot,                        
                        YearofRelease = rows.YearofRelease,
                        ProducerName=GetProducerById.GetName(rows.ProducerId)

                    }).OrderBy(data => data.MovieId);
        }
    }
}
