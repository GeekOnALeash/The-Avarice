using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Abstracts;
using com.ArkAngelApps.TheAvarice.Controllers;
using com.ArkAngelApps.UtilityLibraries.ENUMS;
using com.ArkAngelApps.TheAvarice.Managers;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.UI.Windows
{
	/// <summary>
	/// Parent class for all windows inheriting from this class to provide basic control of windows.
	/// </summary>
	[DisallowMultipleComponent]
	public class WindowHandler : CachedTransformBase
	{
		public WindowType windowType; // Window Type that can be used by classes inheriting
		public bool haltGamePlay;
		internal int windowIndex; // Index for the windows position in windows List.

		private WindowManager _windowManager; // Direct link to manager used to control windows, which is under UI Controller.
		private bool _hasStartRan; // Used to ensure that OnEnable and Start don't both try to create the same window.

		[SuppressMessage("ReSharper", "InvertIf")]
		protected virtual void Start()
		{
			_windowManager = Controller.UI.window;

			if (!_hasStartRan)
			{
				OpenNewWindow();

				_hasStartRan = true;
			}
		}

		private void OnEnable()
		{
			if (_hasStartRan)
			{
				OpenNewWindow();
			}
		}

		private void OnDisable()
		{
			if (!GameController.isQuiting && windowIndex >= 0)
			{
				DoClose();
			}
		}

		[UsedImplicitly]
		public void DoClose()
		{
			_windowManager.CloseWindow(windowIndex);
		}

		private void OpenNewWindow()
		{
			windowIndex = _windowManager.OpenWindow(this);
			BringToFront();
		}

		private void BringToFront()
		{
			transform.SetAsLastSibling();
		}

		internal void SortWindow()
		{
			_windowManager.SortWindows(windowIndex);
			BringToFront();
		}

		internal void UpdateIndex(int index)
		{
			windowIndex = index;
		}
	}
}
