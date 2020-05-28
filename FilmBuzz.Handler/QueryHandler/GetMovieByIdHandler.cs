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
    public class GetMovieByIdHandler : IQueryHandler<GetMovieById, GetMoviesResult>
    {
        public GetMoviesResult Execute(GetMovieById query)
        {
            List<TBL_ACTORS> _ACTORS = new List<TBL_ACTORS>();
            var entity = RepositoryFactory.GetInstance<TBL_MOVIES>().GetAllWith(filter => filter.MovieId == query.MovieId).FirstOrDefault();
            var c = RepositoryFactory.GetInstance<TBL_MOVIES>().GetAllWith(filter => filter.Name == entity.Name).ToList();
            foreach (var item in c)
            {
                var d = RepositoryFactory.GetInstance<TBL_ACTORS>().GetAllWith(filter => filter.ActorId == item.ActorId).FirstOrDefault();
                _ACTORS.Add(new TBL_ACTORS()
                {
                    Name = d.Name,
                    Bio = d.Bio,
                    Sex = d.Sex,
                    DOB = d.DOB,
                    ActorId=d.ActorId
                });
            }

            int count = _ACTORS.Count();
            int[] actors = new int[count];
            for (int i = 0; i < count; i++)
            {
                actors[i] = _ACTORS[i].ActorId;
             }
            return new GetMoviesResult()
            {
                Name = entity.Name,
                ActorId = entity.ActorId,
                Plot = entity.Plot,
                ProducerName = GetProducerById.GetName(entity.ProducerId),
                YearofRelease = entity.YearofRelease,
                ProducerId = entity.ProducerId,
                Actors = _ACTORS,
                ActorsId = actors
            };
        }
    }
}
