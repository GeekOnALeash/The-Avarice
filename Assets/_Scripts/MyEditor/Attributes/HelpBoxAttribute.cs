using UnityEngine;

// ReSharper disable CheckNamespace
namespace com.ArkAngelApps.UtilityLibraries.Attributes
{
	public enum HelpBoxMessageType
	{
		None,
		Info,
		Warning,
		Error
	}

	public sealed class HelpBoxAttribute : PropertyAttribute
	{
		public HelpBoxMessageType messageType;
		public string text;

		public HelpBoxAttribute(string text, HelpBoxMessageType messageType = HelpBoxMessageType.None)
		{
			this.text = text;
			this.messageType = messageType;
		}
	}
}