using com.ArkAngelApps.TheAvarice.Behaviours;
using com.ArkAngelApps.TheAvarice.Behaviours.UI;
using com.ArkAngelApps.TheAvarice.Managers;
using com.ArkAngelApps.TheAvarice.Scriptable.Achievements;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using com.ArkAngelApps.TheAvarice.Scriptable.UI;
using com.ArkAngelApps.UtilityLibraries;
using EasyButtons;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Controllers
{
	public enum RadialSectionNumber
	{
		Section1,
		Section2,
		Section3,
		Section4,
		Section5,
		Section6,
		Section7,
		Section8
	}

	[RequireComponent(typeof(WindowManager))]
	public sealed class UIController : GenericSingletonClass<UIController>
	{
		[Header("UI Elements")]
		[SerializeField]
		private HUDFPS fpsObject;

		public RadialSelection radialSelectionUI;
		public HoverText hoverText;
		public ContextMessageUI contextMessageUI;

		[SerializeField] private NotificationUI notificationUI;

		[Header("Other")]
		[Tooltip("UI elements to hide on scene load.")]
		public UICaller[] hideUIOnLoad;

		[SerializeField] private ColorOverlay colorOverlay;

		internal const int RadialSelectionUISize = 8;
		internal WindowManager window;

		private bool _showFPSCurrentBool;

		private void OnEnable()
		{
			Assert.IsNotNull(fpsObject, $"{fpsObject} is null");
			Assert.IsNotNull(radialSelectionUI, $"{radialSelectionUI} is null");
			Assert.IsNotNull(hoverText, $"{hoverText} is null");
		}

		private void Awake()
		{
			window = GetComponent<WindowManager>();
			Assert.IsNotNull(window, "WindowManager Component missing");
		}

		internal void ShowRadialSelectionUI(RadialSelectionCaller caller)
		{
			radialSelectionUI.ShowUI();

			radialSelectionUI.SetupRadial(caller.data);
			radialSelectionUI.SetRadialPosition(caller.transform.position);
		}

		internal void ShowNotification(NotificationData notification)
		{
			notificationUI.ShowNotification(notification);
		}

		[Button]
		[UsedImplicitly]
		public void ToggleFPS()
		{
			SystemVariables.Instance.settings.ui.showFPSEvent.Raise();
		}
	}
}