using FilmBuzz.Common.Interface;
using FilmBuzz.Common.Model;
using FilmBuzz.Handler.Command;
using FilmBuzz.Handler.CommandHandler;
using FilmBuzz.Handler.Query;
using FilmBuzz.Handler.QueryHandler;
using FilmBuzz.Handler.QueryResult;
using System.Collections.Generic;

namespace FilmBuzz.App_Start
{
    public static class DispatcherConfig
    {
        public static IDispatcher RegisterComponents()
        {
            ///Register all handlers relevant to this api's
            var dispatcher = new Dispatcher();
            dispatcher.Register<Test, bool>(new TestHandler());
            dispatcher.Register<CreateProducer>(new CreateProducerHandler());
            dispatcher.Register<CreateActor>(new CreateActorHandler());
            dispatcher.Register<CreateMovie>(new CreateMovieHandler());
            dispatcher.Register<GetActors,IEnumerable<GetActorsResult>>(new GetActorsHandler());
            dispatcher.Register<GetMovies, IEnumerable<GetMoviesResult>>(new GetMoviesHandler());
            dispatcher.Register<GetProducers, IEnumerable<GetProducersResult>>(new GetProducersHandler()); 
            dispatcher.Register<GetProducersById, GetProducersResult>(new GetProducersByIdHandler());
            dispatcher.Register<GetActorsById, GetActorsResult>(new GetActorsByIdHandler());
            dispatcher.Register<GetMovieById, GetMoviesResult>(new GetMovieByIdHandler());
            dispatcher.Register<UpdateMovie>(new UpdateMovieHandler());
            return dispatcher;
        }
    }
}