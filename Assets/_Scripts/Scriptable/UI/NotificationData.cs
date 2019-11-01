using com.ArkAngelApps.TheAvarice.Controllers;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.UI
{
	internal enum NotificationType
	{
		Achievment,
		System,
		Message
	}

	[CreateAssetMenu(fileName = "NewNotification", menuName = "ScriptableObjects/UI/Notification", order = 5)]
	public class NotificationData : UIDataBase
	{
		[SerializeField] private NotificationType notificationType;

		internal NotificationType NotificationType
		{
			get => notificationType;
			set => notificationType = value;
		}

		public void ShowNotification()
		{
			Controller.UI.ShowNotification(this);
		}
	}
}
