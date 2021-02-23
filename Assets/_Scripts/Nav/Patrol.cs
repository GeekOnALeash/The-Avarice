using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Nav
{
	[ExecuteInEditMode]
	public sealed class Patrol : MonoBehaviour
	{
		public List<Waypoint> waypoints;

		[SerializeField] private float debugDrawRadius = 0.08F;
		[SerializeField] private Color color = Color.red;
		private Waypoint _currentWaypoint;

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = color;
			waypoints = new List<Waypoint>();
			foreach (Transform child in transform)
			{
				_currentWaypoint = child.GetComponent<Waypoint>();

				if (_currentWaypoint != null)
				{
					waypoints.Add(_currentWaypoint);
				}
			}

			for (int id = 0; id < waypoints.Count; id++)
			{
				var newPosition = waypoints[id].transform.position;
				Handles.Label(newPosition, $"{id.ToString()}");
				Gizmos.DrawWireSphere(newPosition, debugDrawRadius);
			}
		}
	}
}
