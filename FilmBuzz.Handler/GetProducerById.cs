using FilmBuzz.Common.Model;
using FilmBuzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmBuzz.Handler
{
    public static class GetProducerById
    {
        public static string GetName(int? id)
        {
            return RepositoryFactory.GetInstance<TBL_PRODUCERS>().GetAll().FirstOrDefault(filter => filter.ProducerId == id).Name;
        }
    }
}
