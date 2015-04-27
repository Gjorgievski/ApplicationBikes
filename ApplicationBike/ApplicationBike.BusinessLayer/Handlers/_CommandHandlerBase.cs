using ApplicationBike.BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBike.BusinessLayer.Handlers
{
    /// <summary>
    /// Abstract class for all command handlers
    /// </summary>
    internal abstract class CommandHandlerBase<TRequest, TResult> : IHandler
                                                                    where TRequest : Command
                                                                    where TResult : CommandResult
    {
        
        public CommandResult Execute(Command command)
        {
            return ExecuteCommand((TRequest)command);
        }

        /// <summary>
        /// The method that executes the command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected abstract TResult ExecuteCommand(TRequest command);

    }

    internal interface IHandler
    {
        CommandResult Execute(Command command);
    }
}

