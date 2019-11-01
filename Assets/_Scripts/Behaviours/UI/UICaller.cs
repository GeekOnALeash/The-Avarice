using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Behaviours.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	[DisallowMultipleComponent]
	public class UICaller : BaseBehaviour
	{
		[SerializeField] private CanvasGroup canvasGroup;

		private bool _uiShown;

		private void Reset()
		{
			GetOrAddCanvasGroupComponent();
		}

		private void Awake()
		{
			GetOrAddCanvasGroupComponent();
		}

		private void GetOrAddCanvasGroupComponent()
		{
			if (canvasGroup)
			{
				return;
			}

			canvasGroup = GetComponent<CanvasGroup>();

			if (canvasGroup)
			{
				return;
			}

			canvasGroup = gameObject.AddComponent<CanvasGroup>();

			Assert.IsNotNull(canvasGroup, "canvasGroup is null");
		}

		public void ShowUI()
		{
			canvasGroup.alpha = 1f;
			SetInteractable(true);
			_uiShown = true;
		}

		public void HideUI()
		{
			canvasGroup.alpha = 0f;
			SetInteractable(false);
			_uiShown = false;
		}

		public virtual IEnumerator HideAfterTimer(float time)
		{
			yield return new WaitForSeconds(time);

			HideUI();
		}

		private void SetInteractable(bool interactable)
		{
			canvasGroup.interactable = interactable;
			canvasGroup.blocksRaycasts = interactable;
		}

		public virtual void ToggleUI()
		{
			if (_uiShown)
			{
				HideUI();
			} else
			{
				ShowUI();
			}
		}
	}
}