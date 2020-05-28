using System;

namespace FilmBuzz.Common.Model
{
    public class QueryHandlerNotFoundException : Exception
    {
        private Type type;
        public QueryHandlerNotFoundException(string message) : base(message)
        {
        }
    }
}
