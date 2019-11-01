using System.Collections;
using com.ArkAngelApps.TheAvarice.Data.Structs;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace com.ArkAngelApps.TheAvarice.Behaviours.UI
{
	public sealed class ContextMessageUI : UICaller
	{
		[SerializeField] private Text contextMessageText;

		private void OnEnable()
		{
			Assert.IsNotNull(contextMessageText, $"{contextMessageText} is null");
		}

		internal void ShowMessage(ContextMessage contextMessage)
		{
			ShowUI();
			contextMessageText.color = contextMessage.Color;
			contextMessageText.text = contextMessage.Message;

			if (contextMessage.HasTimer)
			{
				StartCoroutine(HideAfterTimer(contextMessage.Timer));
			}
		}
	}
}