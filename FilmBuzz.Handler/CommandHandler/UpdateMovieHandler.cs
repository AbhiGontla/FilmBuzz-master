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
    public class UpdateMovieHandler : ICommandHandler<UpdateMovie>
    {
        public void Execute(UpdateMovie command)
        {
            RepositoryFactory.GetInstance<TBL_MOVIES>().Update(command);
        }
    }
}
