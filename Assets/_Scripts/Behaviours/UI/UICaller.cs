using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Behaviours.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	[DisallowMultipleComponent]
	public class UICaller : BaseBehaviour
	{
		public CanvasGroup canvasGroup;

		internal bool uiShown;

		private void Reset()
		{
			canvasGroup = GetComponent<CanvasGroup>();

			if (!canvasGroup)
			{
				canvasGroup = gameObject.AddComponent<CanvasGroup>();
			}

			HideUI();
		}

		[SuppressMessage("ReSharper", "InvertIf")]
		private void Awake()
		{
			if (!canvasGroup)
			{
				canvasGroup = GetComponent<CanvasGroup>();
			}

			Assert.IsNotNull(canvasGroup, "canvasGroup is null");
		}

		public void ShowUI()
		{
			canvasGroup.alpha = 1f;
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
			uiShown = true;
		}

		public void HideUI()
		{
			canvasGroup.alpha = 0f;
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
			uiShown = false;
		}

		[UsedImplicitly]
		public void ToggleUI()
		{
			if (uiShown)
			{
				HideUI();
			} else
			{
				ShowUI();
			}
		}
	}
}