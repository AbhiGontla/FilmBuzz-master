using FilmBuzz.Common.Interface;
using FilmBuzz.Handler.Query;

namespace FilmBuzz.Handler.QueryHandler
{
    public class TestHandler : IQueryHandler<Test, bool>
    {
        public bool Execute(Test query)
        {
            return true;
        }
    }
}
