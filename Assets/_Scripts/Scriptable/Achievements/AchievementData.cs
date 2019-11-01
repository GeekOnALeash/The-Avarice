using System.Collections.Generic;
using com.ArkAngelApps.TheAvarice.Scriptable.UI;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Achievements
{
	[CreateAssetMenu(fileName = "NewAchievement", menuName = "ScriptableObjects/Achievements/Achievement", order = 2)]
	public sealed class AchievementData : NotificationData, ISerializationCallbackReceiver
	{
		[SerializeField] private List<Property> properties;

		public List<Property> Properties => properties;

		internal void Unlock()
		{
			ShowNotification();
		}

		public bool CheckAllProperties()
		{
			foreach (var property in Properties)
			{
				if (property.CheckValue() == false)
				{
					return false;
				}
			}

			return true;
		}

		public void OnBeforeSerialize() { }

		public void OnAfterDeserialize()
		{
			NotificationType = NotificationType.Achievment;
		}
	}
}