using System;
using System.Windows.Forms;
using log4net;

namespace AclTrek
{
	public class Log4Form
	{
		string _DateTimeFormat = "yy.MM.dd HH:mm:ss";
		private ILog _Log;
		private RichTextBox _RtextBox = null;

		public Log4Form(string origin)
		{
			_Log = LogManager.GetLogger(origin);
		}

		public Log4Form(string origin, RichTextBox txtBox)
		{
			_RtextBox = txtBox;
			_Log = LogManager.GetLogger(origin);
		}

		public void Debug(object message)
		{
			WriteTextBox(" Debug: " + message.ToString());
			_Log.Debug(message);
		}

		public void Info(object message)
		{
			WriteTextBox(" Info: " + message.ToString());
			_Log.Info(message);
		}

		public void Fatal(object message)
		{
			WriteTextBox(" Fatal: " + message.ToString());
			_Log.Fatal(message);
		}

		public void Error(object message)
		{
			WriteTextBox(" Error: " + message.ToString());
			_Log.Error(message);
		}

		public void Warn(object message)
		{
			WriteTextBox(" Warn: " + message.ToString());
			_Log.Warn(message);
		}


		private void WriteTextBox(string message)
		{
			if (_RtextBox != null)
			{
				DateTime dt = DateTime.Now;
				_RtextBox.Text = dt.ToString(_DateTimeFormat) + message + "\r\n" + _RtextBox.Text;
			}
		}

	}

}
