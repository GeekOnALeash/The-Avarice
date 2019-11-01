using com.ArkAngelApps.TheAvarice.Handlers.Items;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace com.ArkAngelApps.TheAvarice.Behaviours.UI
{
	public sealed class HoverText : UICaller
	{
		[SerializeField] private Text text;

		private RectTransform _rect;

		private void Start()
		{
			_rect = GetComponent<RectTransform>();
			Assert.IsNotNull(_rect);
		}

		/// <summary>
		/// Used to calculate the position to set based on the mouse position on the screen.
		/// </summary>
		/// <returns>float2 is returned with the adjusted position.</returns>
		private float2 GetAdjustedPosition()
		{
			Vector3 mousePos = MouseCursorHelper.GetMousePosition();
			_rect.pivot = new float2(0, 0);

			float2 offset = float2.zero;
			float2 sizeDelta = _rect.sizeDelta;
			float horizontal = sizeDelta.x + mousePos.x > SystemVariables.Instance.mainCamera.camera.pixelWidth ? 1 : 0;
			float vertical = sizeDelta.y + mousePos.y > SystemVariables.Instance.mainCamera.camera.pixelHeight ? 1 : 0;

			if (horizontal.Equals(1))
			{
				offset.x = -horizontal + (SystemVariables.Instance.mainCamera.camera.pixelWidth - mousePos.x);
			} else
			{
				offset.x = 0;
			}

			if (vertical.Equals(1))
			{
				offset.y = -vertical + (SystemVariables.Instance.mainCamera.camera.pixelHeight - mousePos.y);
			} else
			{
				offset.y = 0;
			}

			//Change tooltip position according to your mouseposition and overdraw/correction values
			return new float2(mousePos.x + offset.x, mousePos.y + offset.y);
		}

		public void UpdateHoverText(string s)
		{
			ToggleUI();

			Vector2 newPosition = GetAdjustedPosition();

			transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
			text.text = s;
		}

		// ReSharper disable once AnnotateNotNullParameter
		[UsedImplicitly]
		public void UpdateHoverText(ItemHandler itemData)
		{
			UpdateHoverText(itemData.data.name);
		}
	}
}