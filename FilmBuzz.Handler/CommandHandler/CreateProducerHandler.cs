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
    public class CreateProducerHandler : ICommandHandler<CreateProducer>
    {
        public void Execute(CreateProducer command)
        {
            RepositoryFactory.GetInstance<TBL_PRODUCERS>().Create(command);           
         
        }
    }
}
