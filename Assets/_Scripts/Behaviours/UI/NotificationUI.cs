using com.ArkAngelApps.TheAvarice.Scriptable.UI;
using UnityEngine;
using UnityEngine.UI;

namespace com.ArkAngelApps.TheAvarice.Behaviours.UI
{
	public sealed class NotificationUI : UICaller
	{
		[Header("UI")]
		[SerializeField]
		private Image iconObject;

		[SerializeField] private Text notificationTypeObject;
		[SerializeField] private Text titleObject;
		[SerializeField] private Text descriptionObejct;

		[SerializeField] private int displayTime = 5;

		internal void ShowNotification(NotificationData notification)
		{
			ShowUI();

			if (notificationTypeObject)
			{
				notificationTypeObject.text = notification.NotificationType.ToString();
			}

			if (titleObject)
			{
				titleObject.text = notification.Title;
			}

			if (descriptionObejct)
			{
				descriptionObejct.text = notification.Content;
			}

			StartCoroutine(HideAfterTimer(displayTime));
		}
	}
}
