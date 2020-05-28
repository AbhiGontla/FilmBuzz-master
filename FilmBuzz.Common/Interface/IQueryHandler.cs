﻿namespace FilmBuzz.Common.Interface
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Execute(TQuery query);
    }
}
