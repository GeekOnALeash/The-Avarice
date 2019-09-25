using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Controllers;
using com.ArkAngelApps.TheAvarice.Scriptable.System;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene.Objects
{
	public sealed class KeypadHandler : ComputerTerminalHandler
	{
		public int code;

		private bool _keypadDisplayed;
		private bool _codeCorrect;

		[SuppressMessage("ReSharper", "InvertIf")]
		private void Update()
		{
			if (withinTrigger)
			{
				if (SystemVariables.Instance.keybinds.Interact())
				{
					DisplayKeypad();
				}
			}
		}

		private void DisplayKeypad()
		{
			if (_keypadDisplayed)
			{
				return;
			}

			Controller.UI.window.EnableKeypad(code, this);
			_keypadDisplayed = true;
		}

		public void CodeCorrect()
		{
			OnEvent(onEnableEvent);
		}
	}
}
