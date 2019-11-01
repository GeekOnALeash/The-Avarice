using System.Collections.Generic;
using com.ArkAngelApps.TheAvarice.Scriptable.Achievements;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Managers
{
	public sealed class AchievementsManager : MonoBehaviour
	{
		[SerializeField] private List<AchievementData> achievements;

		private int _id;

		private void LateUpdate()
		{
			for (_id = 0; _id < achievements.Count; _id++)
			{
				if (!achievements[_id].CheckAllProperties())
				{
					continue;
				}

				achievements[_id].Unlock();
				achievements.RemoveAt(_id);
			}
		}
	}
}
