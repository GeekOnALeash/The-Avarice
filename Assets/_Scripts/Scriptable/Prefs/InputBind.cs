using System;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Prefs
{
	public enum InputType
	{
		Keyboard,
		Mouse,
		Gamepad,
	}

	/// <summary>
	/// Mouse button numbers
	/// </summary>
	public enum MouseButton
	{
		// This order is set by the numbers assigned by unity
		None = -1,
		Left = 0,
		Right,
		Middle,
		Fourth,
		Fifth,
		Sixth,
		Seventh,
	}

	/// <summary>
	/// Used to determine which Input.Get... Method to use
	/// </summary>
	public enum InputPressType
	{
		Down,
		Up,
		Both
	}

	/// <summary>
	/// Setup a InputBind for keyboard/mouse/gamepad inputs
	/// </summary>
	[Serializable]
	public sealed class InputBind
	{
		[SerializeField] private string name;

		[SerializeField] private InputType inputType;

		[SerializeField]
		private KeyCode keyCode;

		[SerializeField]
		private MouseButton mouseButton;

		[SerializeField] private InputPressType reactOnPress;

		public InputBind(string name, InputType inputType, KeyCode keyCode, InputPressType reactOnPress)
		{
			this.name = name;
			this.inputType = inputType;
			this.keyCode = keyCode;
			mouseButton = MouseButton.None;
			this.reactOnPress = reactOnPress;
		}

		public InputBind(string name, InputType inputType, MouseButton mouseButton, InputPressType reactOnPress)
		{
			this.name = name;
			this.inputType = inputType;
			this.mouseButton = mouseButton;
			keyCode = KeyCode.None;
			this.reactOnPress = reactOnPress;
		}

		internal string GetInputName() => name;

		[NotNull]
		internal string GetKeyName()
		{
			switch (inputType)
			{
				case InputType.Keyboard:
					return keyCode.ToString();
				case InputType.Mouse:
					return mouseButton.ToString();
				case InputType.Gamepad:
					throw new NotImplementedException();
				default:
					return "Error: Key Not Set";
			}
		}

		internal bool CheckInput(InputPressType react)
		{
			reactOnPress = react;

			return CheckInput();
		}

		internal bool CheckInput()
		{
			switch (inputType)
			{
				case InputType.Keyboard:
					switch (reactOnPress)
					{
						case InputPressType.Both:
							return Input.GetKey(keyCode);
						case InputPressType.Down:
							return Input.GetKeyDown(keyCode);
						case InputPressType.Up:
							return Input.GetKeyUp(keyCode);
						default:
							return Input.GetKey(keyCode);
					}
				case InputType.Mouse:
					switch (reactOnPress)
					{
						case InputPressType.Both:
							return Input.GetMouseButton((int) mouseButton);
						case InputPressType.Down:
							return Input.GetMouseButtonDown((int) mouseButton);
						case InputPressType.Up:
							return Input.GetMouseButtonUp((int) mouseButton);
						default:
							return Input.GetMouseButton((int) mouseButton);
					}
				case InputType.Gamepad:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			return false;
		}
	}
}