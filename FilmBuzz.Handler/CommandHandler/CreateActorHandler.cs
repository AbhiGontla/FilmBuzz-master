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
    public class CreateActorHandler : ICommandHandler<CreateActor>
    {
        public void Execute(CreateActor command)
        {
            RepositoryFactory.GetInstance<TBL_ACTORS>().Create(command);
        }
    }
}
