using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace com.ArkAngelApps.TheAvarice.Handlers.System
{
	public class PointerDownHandler : MonoBehaviour, IPointerDownHandler
	{
		public UnityEvent pointerDownEvent;

		public void OnPointerDown(PointerEventData eventData)
		{
			PointerDownEvent();
		}

		private void PointerDownEvent()
		{
			pointerDownEvent.Invoke();
		}
	}
}
