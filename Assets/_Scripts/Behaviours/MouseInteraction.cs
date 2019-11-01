using System;
using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using com.ArkAngelApps.TheAvarice.Scriptable.UI;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public sealed class MouseInteraction : MouseCursorHelper, IPointerEnterHandler, IPointerExitHandler
	{
		// This struct is used to simply provide a collapsible section for each event
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
			if (cursorType == CursorType.Custom)
			{
				SystemVariables.Instance.cursors.SetCursor(customCursorData.hoverCursor);
			} else
			{
				SystemVariables.Instance.cursors.SetCursor(cursorType);
			}

			if (onHover && !_hoverStay)
			{
				_hoverStay = true;
				onHoverEvent.unityEvent.Invoke();
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

			if (cursorType == CursorType.Custom)
			{
				SystemVariables.Instance.cursors.SetCursor(customCursorData.defaultCursor);
			} else
			{
				SystemVariables.Instance.cursors.SetDefaultCursor();
			}

			if (onHoverExit)
			{
				onHoverExitEvent.unityEvent.Invoke();
			}
		}

		private void OnLeftClick()
		{
			Debug.Log("Left Click");

			onLeftClickEvent.unityEvent.Invoke();
		}

		private void OnRightClick()
		{
			Debug.Log("Right Click");

			onRightClickEvent.unityEvent.Invoke();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			OnMouseOver();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			OnMouseExit();
		}
	}
}