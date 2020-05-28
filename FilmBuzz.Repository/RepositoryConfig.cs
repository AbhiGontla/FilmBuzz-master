using FilmBuzz.Common.Model;
using FilmBuzz.Repository.Repository;

namespace FilmBuzz.Repository
{
    public static class RepositoryConfig
    {
        public static void RegisterComponents()
        {
            //RepositoryFactory.Register<T>(new TRepository());
            RepositoryFactory.Register<TBL_PRODUCERS>(new ProducerRepository());
            RepositoryFactory.Register<TBL_ACTORS>(new ActorRepository());
            RepositoryFactory.Register<TBL_MOVIES>(new MovieRepository());
        }
    }
}