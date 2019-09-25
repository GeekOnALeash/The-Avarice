using System;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	public sealed class HideFlagsSetter : MonoBehaviour
	{
		public HideFlags customHideFlags;

		public enum Mode
		{
			GameObject,
			Component
		}

		public Mode setOn = Mode.GameObject;

		private void OnEnable()
		{
			switch (setOn)
			{
				case Mode.GameObject:
					gameObject.hideFlags = customHideFlags;
					break;
				case Mode.Component:
					hideFlags = customHideFlags;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}