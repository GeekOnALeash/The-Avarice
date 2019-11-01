using com.ArkAngelApps.TheAvarice.Scriptable.System;
using com.ArkAngelApps.TheAvarice.Scriptable.UI;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public class MouseCursorHelper : MonoBehaviour
	{
		public CursorType cursorType = CursorType.Default;

		[ShowWhen(nameof(cursorType), CursorType.Custom)]
		public MouseCursorData customCursorData;

		/// <summary>
		/// Get the mouse pointer position on screen based of camer.ScreenToWorldPoint.
		/// </summary>
		/// <returns>World point position based of screen position of the mouse pointer.</returns>
		internal static Vector2 GetMousePosition() =>
			SystemVariables.Instance.mainCamera.camera.ScreenToWorldPoint(Input.mousePosition);
	}
}
