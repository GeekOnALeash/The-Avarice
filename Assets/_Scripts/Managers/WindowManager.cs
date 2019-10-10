using System;
using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Handlers.Scene.Objects;
using com.ArkAngelApps.TheAvarice.Handlers.UI.Windows;
using com.ArkAngelApps.TheAvarice.Scriptable.Sets;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Managers
{
	public sealed class WindowManager : MonoBehaviour
	{
		public WindowsRuntimeSet windowList;
		public int maxOpenWindows = 4;
		public GameObject dragableWindowArea;
		public KeypadWindowHandler keypadWindow;
		public Canvas windowsCanvas;

		private void Start()
		{
			windowsCanvas.enabled = WindowCount() != 0;
		}

		internal int OpenWindow([NotNull] WindowHandler windowHandler)
		{
			if (!windowsCanvas.enabled)
			{
				windowsCanvas.enabled = true;
			}

			// Enable window object so it is visible.
			if (!windowHandler.gameObject.activeSelf)
			{
				windowHandler.gameObject.SetActive(true);
			}

			// Check if the window is currently open, if so return its index.
			if (IsWindowOpen(windowHandler))
			{
				return GetWindowIndex(windowHandler);
			}

			var nextIndex = windowList.Count;

			if (nextIndex == maxOpenWindows)
			{
				CloseFurthestWindow();
				nextIndex = windowList.Count;
			}

			windowList.Insert(nextIndex, windowHandler);
			return nextIndex;
		}

		internal void CloseWindow(int index)
		{
			var window = windowList.GetItemUsingIndex(index);

			// Negative number used to indicate to the handler its removed.
			windowList.GetItemUsingIndex(index).WindowIndex = -1;
			windowList.RemoveAt(index);

			window.gameObject.SetActive(false);
			UpdateAllIndices();

			if (WindowCount() == 0)
			{
				windowsCanvas.enabled = false;
			}
		}

		private void CloseAllWindows()
		{
			foreach (var window in windowList.runtimeItems)
			{
				window.gameObject.SetActive(false);
			}

			windowList.Clear();
		}

		public void CloseFurthestWindow()
		{
			CloseWindow(0);
		}

		internal void CloseNearestWindow()
		{
			CloseWindow(LastIndex());
		}

		private void UpdateAllIndices()
		{
			if (!AreWindowsDisplayed())
			{
				return;
			}

			foreach (var window in windowList.runtimeItems)
			{
				window.WindowIndex = GetWindowIndex(window);
			}
		}

		private int GetWindowIndex(WindowHandler windowHandler) => windowList.runtimeItems.IndexOf(windowHandler);

		private bool IsWindowOpen(WindowHandler windowHandler)
		{
			if (windowList.Count == 0)
			{
				return false;
			}

			foreach (var window in windowList.runtimeItems)
			{
				if (ReferenceEquals(window, windowHandler))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Check if there is any windows displayed.
		/// </summary>
		/// <returns>True if windows displayed, false if not.</returns>
		internal bool AreWindowsDisplayed() => WindowCount() != 0;

		/// <summary>
		/// The amount of windows displayed
		/// </summary>
		/// <returns>Returns total amount of windows.</returns>
		private int WindowCount() => windowList.Count;

		/// <summary>
		/// Get index of last item.
		/// </summary>
		/// <returns>returns an int value for last item</returns>
		private int LastIndex()
		{
			var count = WindowCount();

			if (count == 0)
			{
				throw new Exception("Count is 0");
			}

			return WindowCount() - 1;
		}

		/// <summary>
		/// Instantiate window and add to window list.
		/// </summary>
		/// <param name="windowHandler">Prefab with windowHandler attached</param>
		[SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
		private void CreateWindow(WindowHandler windowHandler)
		{
			Instantiate(windowHandler.gameObject, dragableWindowArea.transform);
		}

		internal void SortWindows(int currentIndex)
		{
			if (!AreWindowsDisplayed())
			{
				throw new Exception("List count is 0");
			}

			if (currentIndex >= WindowCount() || currentIndex < 0)
			{
				throw new Exception("currentIndex is out of range");
			}

			var item = windowList.GetItemUsingIndex(currentIndex);
			windowList.RemoveAt(currentIndex);
			windowList.Add(item);
			UpdateAllIndices();
		}

		internal void EnableKeypad(int code, ComputerTerminalHandler terminal)
		{
			OpenWindow(keypadWindow);
			keypadWindow.keypadCode = code;
			keypadWindow.calledBy = terminal;
		}
	}
}