using FilmBuzz.Common.Interface;
using FilmBuzz.Common.Model;
using FilmBuzz.Handler.Command;
using FilmBuzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmBuzz.Handler.CommandHandler
{
    public class CreateMovieHandler : ICommandHandler<CreateMovie>
    {
        public void Execute(CreateMovie command)
        {
            RepositoryFactory.GetInstance<TBL_MOVIES>().Create(command);
        }
    }
}
