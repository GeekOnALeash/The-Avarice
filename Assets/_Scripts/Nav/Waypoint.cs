using System;
using com.ArkAngelApps.TheAvarice.Abstracts;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Nav
{
	[Serializable]
	public sealed class Waypoint : CachedTransformBase
	{
		internal bool IsWaypointReached(Vector3 movingObject, float deadZone = 0.3f) =>
			Vector3.Distance(movingObject, transform.position) < deadZone;
	}
}