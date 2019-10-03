using System;
using System.Collections.Generic;
using com.ArkAngelApps.TheAvarice.Helpers.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Prefs
{
	internal enum InputCommands
	{
		Primary,
		Secondary,
		Middle,
		Down,
		Interact,
		Left,
		Pause,
		Right,
		StartDialogue,
		Up
	}

	[CreateAssetMenu(fileName = "NewKeyBindings", menuName = "ScriptableObjects/Prefs/KeyBindings", order = 1)]
	public sealed class KeybindingsData : ScriptableObject
	{
		[Header("Mouse")]
		public InputBind primary = new InputBind("Primary Mouse Button",
		                                         InputType.Mouse,
		                                         MouseButton.Left,
		                                         InputPressType.Both);

		public InputBind secondary = new InputBind("Secondary Mouse Button",
		                                           InputType.Mouse,
		                                           MouseButton.Right,
		                                           InputPressType.Both);

		public InputBind middle = new InputBind("Middle Mouse Button",
		                                        InputType.Mouse,
		                                        MouseButton.Middle,
		                                        InputPressType.Both);

		[Header("Movement")]
		public InputBind left = new InputBind("Left Key",
		                                      InputType.Keyboard,
		                                      KeyCode.LeftArrow,
		                                      InputPressType.Both);

		public InputBind right = new InputBind("Right Key",
		                                       InputType.Keyboard,
		                                       KeyCode.RightArrow,
		                                       InputPressType.Both);

		public InputBind up = new InputBind("Up Key",
		                                    InputType.Keyboard,
		                                    KeyCode.UpArrow,
		                                    InputPressType.Both);

		public InputBind down = new InputBind("Down Key",
		                                      InputType.Keyboard,
		                                      KeyCode.DownArrow,
		                                      InputPressType.Both);

		[Header("Interaction")]
		public InputBind interact = new InputBind("Interact Key",
		                                          InputType.Keyboard,
		                                          KeyCode.Return,
		                                          InputPressType.Up);

		public InputBind startDialogue = new InputBind("Start Dialogue Key",
		                                               InputType.Keyboard,
		                                               KeyCode.C,
		                                               InputPressType.Up);

		[Header("Other")]
		public InputBind pause = new InputBind("Pause Key",
		                                       InputType.Keyboard,
		                                       KeyCode.Escape,
		                                       InputPressType.Down);

		internal Dictionary<InputCommands, string> commandToKeyDictionary;

		private void OnEnable()
		{
			GenerateDictionary();
		}

		/// <summary>
		/// Check input for Up.
		/// </summary>
		/// <returns>true if the a button associated for Up is pressed.</returns>
		internal bool Up() => up.CheckInput();

		/// <summary>
		/// Check input for Down.
		/// </summary>
		/// <returns>true if the a button associated for Down is pressed.</returns>
		internal bool Down() => down.CheckInput();

		/// <summary>
		/// Check input for Left.
		/// </summary>
		/// <returns>true if the a button associated for Left is pressed.</returns>
		internal bool Left() => left.CheckInput();

		/// <summary>
		/// Check input for Right.
		/// </summary>
		/// <returns>true if the a button associated for Right is pressed.</returns>
		internal bool Right() => right.CheckInput();

		/// <summary>
		/// Check input for Interact.
		/// </summary>
		/// <returns>true if the a button associated for Pause is pressed.</returns>
		internal bool Interact() => interact.CheckInput();

		/// <summary>
		/// Check input for starting conversation dialogue.
		/// </summary>
		/// <returns>true if the a button associated for StartDialogue is pressed.</returns>
		internal bool StartDialogue() => startDialogue.CheckInput();

		/// <summary>
		/// Check input for Pause.
		/// </summary>
		/// <returns>true if the a button associated for Pause is pressed.</returns>
		internal bool Pause() => pause.CheckInput();

		internal bool MouseDownPrimary() => primary.CheckInput();

		internal bool MouseDownSecondary() => secondary.CheckInput();

		internal bool MouseDownMiddle() => middle.CheckInput();

		private void GenerateDictionary()
		{
			commandToKeyDictionary = new Dictionary<InputCommands, string>(Enum.GetValues(typeof(InputCommands)).Length);

			foreach (InputCommands command in Enum.GetValues(typeof(InputCommands)))
			{
				switch (command)
				{
					case InputCommands.Down:
						commandToKeyDictionary.Add(command, down.GetInputName());
						break;
					case InputCommands.Interact:
						commandToKeyDictionary.Add(command, interact.GetKeyName());
						break;
					case InputCommands.Primary:
						commandToKeyDictionary.Add(command, primary.GetInputName());
						break;
					case InputCommands.Secondary:
						commandToKeyDictionary.Add(command, secondary.GetInputName());
						break;
					case InputCommands.Middle:
						commandToKeyDictionary.Add(command, middle.GetInputName());
						break;
					case InputCommands.Left:
						commandToKeyDictionary.Add(command, left.GetInputName());
						break;
					case InputCommands.Pause:
						commandToKeyDictionary.Add(command, pause.GetInputName());
						break;
					case InputCommands.Right:
						commandToKeyDictionary.Add(command, right.GetInputName());
						break;
					case InputCommands.StartDialogue:
						commandToKeyDictionary.Add(command, startDialogue.GetInputName());
						break;
					case InputCommands.Up:
						commandToKeyDictionary.Add(command, up.GetInputName());
						break;
					default:
						Debug.Log($"{command.ToString()} does not have a dictionary generation case");
						throw new ArgumentOutOfRangeException();
				}
			}
		}
	}
}