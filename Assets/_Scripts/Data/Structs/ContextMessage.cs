using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Data.Structs
{
	[System.Serializable]
	public struct ContextMessage
	{
		public string message;
		public Color color;

		public bool hasTimer;
		public int timer;

		public ContextMessage(string text, Color color, bool hasTimer, int timer)
		{
			this.message = text;
			this.color = color;
			this.hasTimer = hasTimer;
			this.timer = timer;
		}
	}
}