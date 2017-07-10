using Castle.DynamicProxy;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WCCCommon.Exceptions
{
    public class WCCException : IInterceptor
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Intercept(IInvocation invocation)
        {
            var debugBefore = String.Format("Method: {0}, parameters:{1} ",
                invocation.Method.Name,
                String.Join(", ", invocation.Arguments.Select(JsonConvert.SerializeObject)));

            _logger.Debug(debugBefore);

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine(string.Format("Before: {0}", debugBefore));

            invocation.Proceed();

            var debugAfter = String.Format("Method: {0}, ReturnValue:{1} ",
                invocation.Method.Name,
                String.Join(", ", JsonConvert.SerializeObject(invocation.ReturnValue)));

            _logger.Debug(debugAfter);
            Console.WriteLine(string.Format("After: {0}", debugAfter));

            Console.ResetColor();
        }
    }
}
