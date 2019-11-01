using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.UI
{
	public class UIDataBase : ScriptableObject
	{
		[SerializeField] private string title = "";
		[SerializeField] private string content = "";
		[SerializeField] private Sprite image;

		internal string Title => title;

		internal string Content
		{
			get => content;
			set => content = value;
		}

		public Sprite Image => image;

		public override string ToString() => Title;
	}
}