using Unity.Mathematics;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.UI
{
	internal enum CursorType
	{
		Default,
		Hover
	}

	[CreateAssetMenu(fileName = "NewMouseCursors", menuName = "ScriptableObjects/UI/Mouse Cursors", order = 4)]
	public sealed class MouseCursorData : ScriptableObject
	{
		public Texture2D defaultCursor;
		public Texture2D hoverCursor;

		public float2 hotspot = float2.zero;

		internal void SetDefaultCursor()
		{
			SetCursor(defaultCursor);
		}

		internal void SetHoverCursor()
		{
			SetCursor(hoverCursor);
		}

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