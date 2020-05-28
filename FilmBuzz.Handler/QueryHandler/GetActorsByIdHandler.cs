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
    public class GetActorsByIdHandler : IQueryHandler<GetActorsById, GetActorsResult>
    {
        public GetActorsResult Execute(GetActorsById query)
        {
            List<TBL_MOVIES> _ACTORS = new List<TBL_MOVIES>();
            var user = RepositoryFactory.GetInstance<TBL_ACTORS>().GetAllWith(filter => filter.ActorId == query.ActorId).FirstOrDefault();
            List<TBL_MOVIES> c = RepositoryFactory.GetInstance<TBL_MOVIES>().GetAllWith(filter => filter.ActorId == user.ActorId).ToList();

            return new GetActorsResult()
            {
                Name = user.Name,
                Sex = user.Sex,
                Bio = user.Bio,
                DOB = user.DOB,
                ActorId = user.ActorId,
                _movieslist = c
            };
        }
    }
}
