using System;

// ReSharper disable CheckNamespace

namespace com.ArkAngelApps.MyDebug.Exceptions
{
	public sealed class UnexpectedEnumValueException : Exception
	{
		public UnexpectedEnumValueException(object value) :
			base($"The enum value \"{value}\" in type \"{value.GetType().Name}\" was not expected.") { }
	}
}
