namespace FilmBuzz.Common.Interface
{
    public interface IDispatcher
    {
        void Execute<TCommand>(TCommand command)
           where TCommand : ICommand;

        void Register<TCommand>(ICommandHandler<TCommand> command)
            where TCommand : ICommand;

        TResult Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>;

        void Register<TQuery, TResult>(IQueryHandler<TQuery, TResult> query)
          where TQuery : IQuery<TResult>;
    }
}