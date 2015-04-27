using ApplicationBike.BusinessLayer.Contracts;
using ApplicationBike.BusinessLayer.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBike.BusinessLayer
{
    public class CommandInvoker
    {
        /// <summary>
        /// Entry point for execution of different commands
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static TResult InvokeCommand<TRequest, TResult>(TRequest command)
                                                                                where TRequest : Command
                                                                                where TResult : CommandResult
        {
            //
            IHandler _handler = GetHandler<TRequest>();
            TResult _result = default(TResult);
            //
            if (_handler != null)
            {
                _result = (TResult)_handler.Execute(command);
            }
            //
            return _result;
        }

        /// <summary>
        /// Factory method for creating handlers
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        private static IHandler GetHandler<TRequest>()
        {
            if (typeof(TRequest) == typeof(BikeSearchCommand))
            {
                return new BikeSearchCommandHandler();
            }
            //
            return null;
        }
    }
}

