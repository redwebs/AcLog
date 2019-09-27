using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcLogServices
{
	public class AcLogData
	{
		#region Private

		const string _StdDateDispFmt = "MM/dd/yyyy hh:mm tt";

		#endregion Private

		#region Public Properties

		#endregion Public Properties

		#region Construtors

		public AcLogData()
		{
		}

		#endregion Constructors

		#region Public Functions

		public string ToString(string dateFormat)
		{
			return FormatObject(dateFormat);
		}

		public override string ToString()
		{
			return FormatObject(_StdDateDispFmt);
		}

		#endregion Public Functions

		#region Private Functions

		private string FormatObject(string dateDispFmt)
		{
			var sb = new StringBuilder();
			sb.AppendLine("\r\nAcLogData Properties:");
		
			return sb.ToString();
		}

		private string DateTimeMinOrMax(DateTime dateTime, string subValue, string format)
		{
			if (dateTime.Equals(DateTime.MinValue) || dateTime.Equals(DateTime.MaxValue))
			{
				return subValue;
			}
			else
			{
				return (dateTime.ToString(format));
			}
		}
		#endregion
	}

}
