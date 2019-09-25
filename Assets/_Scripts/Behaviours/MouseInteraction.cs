using System;
using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	public sealed class MouseInteraction : MouseCursorHelper
	{
		[Serializable]
		public struct MouseEvents
		{
			public UnityEvent unityEvent;
		}

		[Header("Events")]
		[SerializeField]
		private bool onHover;

		[ShowWhen(nameof(onHover))] [SerializeField]
		private MouseEvents onHoverEvent;

		[SerializeField] private bool onHoverExit;

		[ShowWhen(nameof(onHoverExit))] [SerializeField]
		private MouseEvents onHoverExitEvent;

		[SerializeField] private bool onLeftClick;

		[ShowWhen(nameof(onLeftClick))] [SerializeField]
		private MouseEvents onLeftClickEvent;

		[SerializeField] private bool onRightClick;

		[ShowWhen(nameof(onRightClick))] [SerializeField]
		private MouseEvents onRightClickEvent;

		private bool _hoverStay;

		[SuppressMessage("ReSharper", "InvertIf")]
		private void OnMouseOver()
		{
			if (hoverCursor)
			{
				if (hasCustomCursors)
				{
					SystemVariables.Instance.cursors.SetCursor(cursorData.hoverCursor);
				} else
				{
					SystemVariables.Instance.cursors.SetHoverCursor();
				}
			}

			if (onHover && !_hoverStay)
			{
				_hoverStay = true;
				OnHover();
			}

			if (onLeftClick)
			{
				if (SystemVariables.Instance.keybinds.MouseDownPrimary())
				{
					OnLeftClick();
				}
			} else if (onRightClick)
			{
				if (SystemVariables.Instance.keybinds.MouseDownSecondary())
				{
					OnRightClick();
				}
			}
		}

		private void OnMouseExit()
		{
			_hoverStay = false;

			if (hoverCursor)
			{
				if (hasCustomCursors)
				{
					SystemVariables.Instance.cursors.SetCursor(cursorData.defaultCursor);
				} else
				{
					SystemVariables.Instance.cursors.SetDefaultCursor();
				}
			}

			if (onHoverExit)
			{
				OnExit();
			}
		}

		private void OnHover()
		{
			onHoverEvent.unityEvent.Invoke();
		}

		private void OnExit()
		{
			onHoverExitEvent.unityEvent.Invoke();
		}

		private void OnLeftClick()
		{
			if (leftClickCursor)
			{
				// Add code and cursor for left click cursor depending on item
			}

			onLeftClickEvent.unityEvent.Invoke();
		}

		private void OnRightClick()
		{
			if (rightClickCursor)
			{
				// Add code and cursor for right click cursor depending on item
			}

			Debug.Log("Right Click");

			onRightClickEvent.unityEvent.Invoke();
		}
	}
}