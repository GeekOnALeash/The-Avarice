using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.UI
{
	public enum CursorType
	{
		Hover,
		Help,
		Info,
		Default,
		Custom
	}

	[CreateAssetMenu(fileName = "NewMouseCursors", menuName = "ScriptableObjects/UI/Mouse Cursors", order = 4)]
	public sealed class MouseCursorData : ScriptableObject
	{
		public Texture2D defaultCursor;
		public Texture2D hoverCursor;

		public Vector2 hotspot = Vector2.zero;

		internal void SetDefaultCursor() => SetCursor(CursorType.Default);

		internal void SetCursor(CursorType cursorType)
		{
			switch (cursorType)
			{
				case CursorType.Default:
					SetCursor(defaultCursor);
					break;
				case CursorType.Hover:
					SetCursor(hoverCursor);
					break;
				case CursorType.Custom:
					break;
				case CursorType.Help:
					break;
				case CursorType.Info:
					break;
				default:
					SetCursor(defaultCursor);
					break;
			}
		}

		internal void SetCursor(Texture2D cursor)
		{
			Cursor.SetCursor(cursor, hotspot, CursorMode.Auto);
		}
	}
}