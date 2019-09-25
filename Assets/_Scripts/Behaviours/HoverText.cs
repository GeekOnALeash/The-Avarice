using com.ArkAngelApps.TheAvarice.Abstracts;
using com.ArkAngelApps.TheAvarice.Behaviours.UI;
using com.ArkAngelApps.TheAvarice.Helpers;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public sealed class HoverText : UICaller
	{
		[SerializeField]
		private Text text;

		[SerializeField]
		private float2 offset;

		internal bool hideText;

		public void UpdateHoverText(string s)
		{
			if (!hideText)
			{
				ShowUI();
			}

			float2 mousePosition = MouseCursorHelper.GetMousePosition();
			Vector2 newPosition = new float2(mousePosition.x + offset.x, mousePosition.y + offset.y);

			transform.position = newPosition;
			text.text = s;
		}

		public void SetHideText(bool state)
		{
			hideText = state;
			HideUI();
		}
	}
}
