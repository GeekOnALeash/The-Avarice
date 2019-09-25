using System.Collections;
using com.ArkAngelApps.TheAvarice.Behaviours.UI;
using com.ArkAngelApps.TheAvarice.Data.Structs;
using com.ArkAngelApps.TheAvarice.Scriptable.UI;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public sealed class ContextMessageUI : UICaller
	{
		public Text contextMessageText;

		private Color _defaultColor;

		private void OnEnable()
		{
			Assert.IsNotNull(contextMessageText, $"{contextMessageText} is null");
		}

		private void Start()
		{
			_defaultColor = contextMessageText.color;
		}

		internal void ShowMessage([NotNull] ContextMessageData data)
		{
			ShowMessage(data.GetContextMessage());
		}

		internal void ShowMessage(ContextMessage contextMessage)
		{
			ShowUI();
			contextMessageText.color = contextMessage.color;
			contextMessageText.text = contextMessage.message;

			if (contextMessage.hasTimer)
			{
				StartCoroutine(HideAfterTimer(contextMessage.timer));
			}
		}

		private IEnumerator HideAfterTimer(float time)
		{
			yield return new WaitForSeconds(time);

			HideMessage();
		}

		internal void HideMessage()
		{
			HideUI();
			contextMessageText.text = "";
			ResetColor();
		}

		private void ResetColor()
		{
			contextMessageText.color = _defaultColor;
		}
	}
}