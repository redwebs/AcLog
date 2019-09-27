using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace AclTrek
{
	public class Log4netTraceListener : System.Diagnostics.TraceListener
	{
		private static Dictionary<string, ILog> _Loggers = new Dictionary<string, ILog>();
		private string messageSoFar = String.Empty;


		public override void Write(string message)
		{
			messageSoFar += message;
		}

		public override void WriteLine(string message)
		{
			string completeMessage = messageSoFar + message;

			ILog log;

			// Get or create a logger for this TraceSource
			if (_Loggers.ContainsKey(Name))
			{
				log = _Loggers[Name];
			}
			else
			{
				log = LogManager.GetLogger(Name);
				_Loggers.Add(Name, log);
			}

			// Strip out TraceSource name from message and log
			log.Debug(completeMessage.Replace(Name, string.Empty));

			messageSoFar = String.Empty;
		}
	}
}

/* Add to log4net.config and to app config:
 * 
 * <system.diagnostics>
		<sources>
			<source name="Microsoft.Practices.ObjectBuilder" switchValue="Verbose">
				<listeners>
					<add name="Microsoft.Practices.ObjectBuilder" type="Tavis.Framework.Tools.Log4netTraceListener, TavisFramework"/>
				</listeners>
			</source>
			<source name="Microsoft.Practices.CompositeUI.Commands.Command" switchValue="Verbose">
				<listeners>
					<add name="Microsoft.Practices.CompositeUI.Commands.Command" type="Tavis.Framework.Tools.Log4netTraceListener, TavisFramework"/>
				</listeners>
			</source>

			<source name="Microsoft.Practices.CompositeUI.WorkItem" switchValue="Verbose">
				<listeners>
					<add name="Microsoft.Practices.CompositeUI.WorkItem" type="Tavis.Framework.Tools.Log4netTraceListener, TavisFramework"/>
				</listeners>
			</source>

		</sources>
	</system.diagnostics>*/
