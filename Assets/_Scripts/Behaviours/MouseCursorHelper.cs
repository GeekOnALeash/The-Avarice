using com.ArkAngelApps.TheAvarice.Scriptable.System;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using com.ArkAngelApps.TheAvarice.Scriptable.UI;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	public class MouseCursorHelper : MonoBehaviour
	{
		[Header("Cursors to Show")]
		public bool hoverCursor;

		public bool leftClickCursor;
		public bool rightClickCursor;

		public bool hasCustomCursors;

		[ShowWhen(nameof(hasCustomCursors))] public MouseCursorData cursorData;

		internal static Vector2 GetMousePosition() =>
			SystemVariables.Instance.mainCamera.camera.ScreenToWorldPoint(Input.mousePosition);
	}
}
