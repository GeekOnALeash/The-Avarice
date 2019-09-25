using com.ArkAngelApps.TheAvarice.Handlers.UI.Windows;
using UnityEngine;
using UnityEngine.EventSystems;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public sealed class DragPanel : MonoBehaviour, IPointerDownHandler, IDragHandler
	{
		public WindowHandler window;
		private Vector2 _originalLocalPointerPosition;
		private Vector3 _originalPanelLocalPosition;
		private RectTransform _panelRectTransform;
		private RectTransform _parentRectTransform;

		private void Awake()
		{
			_panelRectTransform = transform.parent as RectTransform;
			if (_panelRectTransform != null)
			{
				_parentRectTransform = _panelRectTransform.parent as RectTransform;
			}
		}

		public void OnPointerDown(PointerEventData data)
		{
			if (window != null)
			{
				window.SortWindow();
			}
			
			_originalPanelLocalPosition = _panelRectTransform.localPosition;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRectTransform, data.position, data.pressEventCamera, out _originalLocalPointerPosition);
		}

		public void OnDrag(PointerEventData data)
		{
			if (_panelRectTransform == null || _parentRectTransform == null)
			{
				return;
			}

			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRectTransform, data.position, data.pressEventCamera, out var localPointerPosition))
			{
				Vector3 offsetToOriginal = localPointerPosition - _originalLocalPointerPosition;
				_panelRectTransform.localPosition = _originalPanelLocalPosition + offsetToOriginal;
			}
		
			ClampToWindow();
		}

		// Clamp panel to area of parent
		private void ClampToWindow()
		{
			var localPosition = _panelRectTransform.localPosition;
			Vector3 pos = localPosition;

			var rect = _parentRectTransform.rect;
			var rect1 = _panelRectTransform.rect;

			Vector3 minPosition = rect.min - rect1.min;
			Vector3 maxPosition = rect.max - rect1.max;
		
			pos.x = Mathf.Clamp(localPosition.x, minPosition.x, maxPosition.x);
			pos.y = Mathf.Clamp(localPosition.y, minPosition.y, maxPosition.y);
		
			localPosition = pos;
			_panelRectTransform.localPosition = localPosition;
		}
	}
}