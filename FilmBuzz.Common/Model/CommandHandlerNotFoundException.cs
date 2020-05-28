using System;

namespace FilmBuzz.Common.Interface
{
    public class CommandHandlerNotFoundException : Exception
    {
        private Type type;
        public CommandHandlerNotFoundException(string message) : base(message)
        {
        }

    }
}
