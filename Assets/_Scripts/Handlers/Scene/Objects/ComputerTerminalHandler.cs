using com.ArkAngelApps.TheAvarice.Controllers;
using com.ArkAngelApps.TheAvarice.Scriptable.UI;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene.Objects
{
	public class ComputerTerminalHandler : MonoBehaviour
	{
		public ContextMessageData contextMessage;

		public UnityEvent onEnableEvent;
		protected bool withinTrigger;

		protected static void OnEvent([NotNull] UnityEvent unityEvent)
		{
			unityEvent.Invoke();
		}

		[UsedImplicitly]
		public void TriggerEnter()
		{
			if (!enabled)
			{
				return;
			}

			withinTrigger = true;
			Controller.UI.contextMessageUI.ShowMessage(contextMessage);
		}

		[UsedImplicitly]
		public void TriggerExit()
		{
			withinTrigger = false;
			Controller.UI.contextMessageUI.HideMessage();
		}
	}
}