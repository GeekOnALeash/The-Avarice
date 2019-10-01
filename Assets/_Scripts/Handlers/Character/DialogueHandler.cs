using System;
using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Helpers.InputSystem;
using com.ArkAngelApps.TheAvarice.Managers;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using Fungus;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	public sealed class DialogueHandler : MonoBehaviour
	{
		private bool _withinTrigger;
		public string dialogBlockName;
		public int diaologBlockID = 1;
		private string _dialogBlock;
		private Block _block;
		private bool _dialogueDisplayed;

		[SerializeField] private Flowchart flowchart;

		private InputManager _input;

		private void OnEnable()
		{
			_input = new InputManager("Start Conversation", performed: OnStartConversation);
			_input.Enable();
		}

		public void OnDisable()
		{
			_input.Disable();
		}

		private void Start()
		{
			_block = flowchart.GetComponent<Block>();
			_dialogueDisplayed = GetBool("dialogueDisplayed");
			SetDialogBlock(diaologBlockID);
		}

		[SuppressMessage("ReSharper", "InvertIf")]
		private void LateUpdate()
		{
			if (_withinTrigger)
			{
				_input.Enable();
				_dialogueDisplayed = GetBool("dialogueDisplayed");
			} else
			{
				_input.Disable();
			}
		}

		private void OnStartConversation(InputAction.CallbackContext ctx)
		{
			if (_dialogueDisplayed)
			{
				return;
			}

			if (FindBlock())
			{
				CallBlock();
			}
		}

		private void NextDialogBlock()
		{
			diaologBlockID++;
			SetDialogBlock(diaologBlockID);
		}

		private void SetDialogBlock(int id)
		{
			_dialogBlock = $"{dialogBlockName}{id.ToString()}";
		}

		private bool FindBlock()
		{
			_block = flowchart.FindBlock(_dialogBlock);
			NextDialogBlock();

			return _block;
		}

		private bool GetBool(string variable) => flowchart.GetBooleanVariable(variable);

		private void CallBlock()
		{
			flowchart.SetBooleanVariable("dialogueDisplayed", false);
			_block.StartExecution();
		}

		public void TriggerEnter()
		{
			_withinTrigger = true;
		}

		public void TriggerExit()
		{
			_withinTrigger = false;
		}

		public bool DialogueDisplayed() => _dialogueDisplayed;
	}
}