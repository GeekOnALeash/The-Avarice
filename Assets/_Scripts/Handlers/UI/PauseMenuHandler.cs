using com.ArkAngelApps.TheAvarice.Controllers;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.UI
{
	public sealed class PauseMenuHandler : MonoBehaviour
	{
		private void OnEnable()
		{
			GameController.PauseGame();
		}

		private void OnDisable()
		{
			GameController.UnPauseGame();
		}

		public void OnSave()
		{
			Debug.Log("Save button pressed");
		}

		public void OnLoad()
		{
			Debug.Log("Load button pressed");
		}

		public void OnSettings()
		{
			Debug.Log("Settings button pressed");
		}

		public void OnQuit()
		{
			GameController.Quit();
		}
	}
}
