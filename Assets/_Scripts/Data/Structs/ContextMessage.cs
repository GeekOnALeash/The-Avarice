using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Data.Structs
{
	[System.Serializable]
	public struct ContextMessage
	{
		[SerializeField] private string message;
		[SerializeField] private Color color;
		[SerializeField] private bool hasTimer;
		[SerializeField] private int timer;

		public string Message
		{
			get => message;
			set => message = value;
		}

		public Color Color
		{
			get => color;
			set => color = value;
		}

		public bool HasTimer
		{
			get => hasTimer;
			set => hasTimer = value;
		}

		public int Timer
		{
			get => timer;
			set => timer = value;
		}
	}
}