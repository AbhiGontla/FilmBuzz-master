using FilmBuzz.Common.Interface;
using FilmBuzz.Handler.QueryResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmBuzz.Handler.Query
{
    public class GetMovieById:IQuery<GetMoviesResult>
    {
        public int MovieId { get; set; }
    }
}
