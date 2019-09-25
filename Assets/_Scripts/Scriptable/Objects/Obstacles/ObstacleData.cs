using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Objects.Obstacles
{
	public enum ObstacleType
	{
		Door,
		TripWire,
		LaserBarrier,
		ForceField
	}

	[CreateAssetMenu(fileName = "NewObstacle", menuName = "ScriptableObjects/In-Game/Obstacle", order = 5)]
	public class ObstacleData : ScriptableObject
	{
		public string animationName;
		public bool hasAnimation;
		public bool isLocked;
		public ObstacleType obstacleType;
	}
}