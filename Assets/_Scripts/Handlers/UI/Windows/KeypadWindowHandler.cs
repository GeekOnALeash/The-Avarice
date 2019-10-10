using com.ArkAngelApps.TheAvarice.Handlers.Scene.Objects;
using com.ArkAngelApps.UtilityLibraries.Extensions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace com.ArkAngelApps.TheAvarice.Handlers.UI.Windows
{
	public sealed class KeypadWindowHandler : WindowHandler
	{
		[SerializeField] private Text displayText;

		internal int keypadCode;
		internal ComputerTerminalHandler calledBy;

		private string _textToDisplay;
		private int _keysPressedCount;
		private Animator _animator;

		private const int CodeLength = 4;
		private const string DisplayPadding = "_";

		private static readonly int __Shake = Animator.StringToHash("Shake");

		protected override void Start()
		{
			base.Start();

			ResetKeypad();
			_animator = GetComponent<Animator>();
			Assert.IsNotNull(_animator, "_animator is null");
		}

		private void OnDisable()
		{
			ResetKeypad();
		}

		private void PadDisplayWithDashes()
		{
			_textToDisplay = "";

			for (int i = 1; i <= CodeLength; i++)
			{
				_textToDisplay = $"{_textToDisplay}{DisplayPadding}";
			}

			UpdateDisplay(_textToDisplay);
		}

		[UsedImplicitly]
		public void OnButtonPressed()
		{
			_keysPressedCount += 1;
			ReplaceCharAtPos(EventSystem.current.currentSelectedGameObject.name);

			if (_keysPressedCount < CodeLength)
			{
				return;
			}

			if (CheckCode())
			{
				ResetKeypad();
				calledBy.CodeCorrect();
				calledBy = null;
				return;
			}

			_animator.SetTrigger(__Shake);
		}

		private void ReplaceCharAtPos(string newString)
		{
			_textToDisplay = _textToDisplay.ReplaceAt(_keysPressedCount - 1, 1, newString);
			UpdateDisplay(_textToDisplay);
		}

		private void UpdateDisplay(string newString)
		{
			displayText.text = newString;
		}

		private void ResetKeypad()
		{
			PadDisplayWithDashes();
			_keysPressedCount = 0;
		}

		private bool CheckCode() => keypadCode == int.Parse(_textToDisplay);
	}
}
