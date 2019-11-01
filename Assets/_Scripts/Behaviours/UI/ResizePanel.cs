using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	public sealed class ResizePanel : MonoBehaviour, IPointerDownHandler, IDragHandler
	{
		public Vector2 minSize = new Vector2(100, 100);
		public Vector2 maxSize = new Vector2(400, 400);

		private RectTransform _panelRectTransform;
		private Vector2 _originalLocalPointerPosition;
		private Vector2 _originalSizeDelta;

		private void Awake()
		{
			_panelRectTransform = transform.parent.GetComponent<RectTransform>();
			Assert.IsNotNull(_panelRectTransform, "panelRectTransform is null");
		}

		public void OnPointerDown([NotNull] PointerEventData data)
		{
			_originalSizeDelta = _panelRectTransform.sizeDelta;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_panelRectTransform, data.position, data.pressEventCamera, out _originalLocalPointerPosition);
		}

		public void OnDrag(PointerEventData data)
		{
			if (_panelRectTransform == null)
			{
				return;
			}

			RectTransformUtility.ScreenPointToLocalPointInRectangle(_panelRectTransform, data.position, data.pressEventCamera, out var localPointerPosition);
			Vector3 offsetToOriginal = localPointerPosition - _originalLocalPointerPosition;

			Vector2 sizeDelta = _originalSizeDelta + new Vector2(offsetToOriginal.x, -offsetToOriginal.y);
			sizeDelta = new Vector2(
			                        Mathf.Clamp(sizeDelta.x, minSize.x, maxSize.x),
			                        Mathf.Clamp(sizeDelta.y, minSize.y, maxSize.y)
			                       );

			_panelRectTransform.sizeDelta = sizeDelta;
		}
	}
}