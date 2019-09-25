using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Managers;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using Fungus;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	public sealed class DialogueHandler : MonoBehaviour
	{
		private bool _withinDialogueTrigger;
		public string dialogBlockName;
		public int diaologBlockID = 1;
		private string _dialogBlock;
		private Block _block;
		private bool _dialogueDisplayed;

		[SerializeField] private Flowchart flowchart;

		private void Start()
		{
			_block = flowchart.GetComponent<Block>();
			_dialogueDisplayed = GetBool("dialogueDisplayed");
			SetDialogBlock(diaologBlockID);
		}

		[SuppressMessage("ReSharper", "InvertIf")]
		private void LateUpdate()
		{
			if (_withinDialogueTrigger)
			{
				_dialogueDisplayed = GetBool("dialogueDisplayed");
				if (SystemVariables.Instance.keybinds.Interact() && !_dialogueDisplayed)
				{
					if (FindBlock())
					{
						CallBlock();
					}
				}
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
			_withinDialogueTrigger = true;
		}

		public void TriggerExit()
		{
			_withinDialogueTrigger = false;
		}

		public bool DialogueDisplayed() => _dialogueDisplayed;
	}
}