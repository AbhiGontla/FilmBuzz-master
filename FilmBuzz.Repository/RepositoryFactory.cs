using FilmBuzz.Common.Interface;
using System.Collections.Generic;

namespace FilmBuzz.Repository
{
    public static class RepositoryFactory
    {
        private static Dictionary<object, object> _repositories = new Dictionary<object, object>();

        /// <summary>
        /// Returns an instance of repository for given model type for global
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static IRepository<T> GetInstance<T>()
        {
            IRepository<T> repo
                    = (IRepository<T>)_repositories[typeof(T)];
            return repo;
        }

        /// <summary>
        /// Retruns true if the rpository for given model is already regsitered.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Contains<T>()
        {
            return _repositories.ContainsKey(typeof(T));
        }

        /// <summary>
        /// Register repository for individial business model that will be returned by this factory class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repo"></param>
        public static void Register<T>(IRepository<T> repo)
        {
            _repositories.Add(typeof(T), repo);
        }
    }
}