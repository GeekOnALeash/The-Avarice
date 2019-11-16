using com.ArkAngelApps.TheAvarice.Data.Structs;
using com.ArkAngelApps.TheAvarice.Scriptable.Prefs;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.UI
{
	[CreateAssetMenu(fileName = "NewContextMessage", menuName = "Scriptable/UI/ContextMessage", order = 4)]
	public sealed class ContextMessageData : ScriptableObject, ISerializationCallbackReceiver
	{
		private const string KeyReplacementPattern = "***Key***";

		[HelpBox("If using a key/input in the message use " + KeyReplacementPattern + " to indicate in the message where to replace the key name", HelpBoxMessageType.Info)]
		[SerializeField]
		private bool hasKeyCommand;

		[ShowWhen(nameof(hasKeyCommand))]
		[SerializeField]
		private InputCommands command;

		[SerializeField] private ContextMessage contextMessage;

		private InputCommands _runtimeCommand;
		private ContextMessage _runtimeMessage;

		public void OnBeforeSerialize() { }

		public void OnAfterDeserialize()
		{
			_runtimeCommand = command;
			_runtimeMessage = contextMessage;
		}

		public string GetMessage() => _runtimeMessage.Message;

		internal void SetMessage(string text) => _runtimeMessage.Message = text;

		internal ContextMessage GetContextMessage() => FormatMessage();

		private ContextMessage FormatMessage()
		{
			if (hasKeyCommand)
			{
				_runtimeMessage.Message = contextMessage.Message.Replace(KeyReplacementPattern,
				                                                         SystemVariables.Instance.keybinds
				                                                                        .commandToKeyDictionary[_runtimeCommand]);
			}

			return _runtimeMessage;
		}
	}
}