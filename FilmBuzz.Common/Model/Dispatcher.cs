using FilmBuzz.Common.Interface;
using System;
using System.Collections.Generic;

namespace FilmBuzz.Common.Model
{
    public class Dispatcher : IDispatcher
    {
        Dictionary<object, object> _commands = new Dictionary<object, object>();
        Dictionary<object, object> _queries = new Dictionary<object, object>();

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            try
            {
                ICommandHandler<TCommand> _cmd
                    = (ICommandHandler<TCommand>)Activator.CreateInstance(_commands[typeof(TCommand)].GetType());
                if (_cmd != null)
                {
                    _cmd.Execute(command);
                }
            }
            catch (KeyNotFoundException ex)
            {
                throw (new CommandHandlerNotFoundException(String.Format("Dispatcher did not find registered handler for type {0}", typeof(TCommand).ToString())));
            }
        }

        public TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            try
            {
                IQueryHandler<TQuery, TResult> _query
                    = (IQueryHandler<TQuery, TResult>)Activator.CreateInstance(_queries[typeof(TQuery)].GetType());
                if (_query != null)
                {

                    return _query.Execute(query);
                }

            }
            catch (KeyNotFoundException ex)
            {
                throw (new QueryHandlerNotFoundException(String.Format("Dispatcher did not find registered handler for type {0}", typeof(TQuery).ToString())));
            }
            return default(TResult);
        }

        public void Register<TCommand>(ICommandHandler<TCommand> command) where TCommand : ICommand
        {
            _commands.Add(typeof(TCommand), command);
        }

        public void Register<TQuery, TResult>(IQueryHandler<TQuery, TResult> query) where TQuery : IQuery<TResult>
        {
            _queries.Add(typeof(TQuery), query);
        }
    }
}
