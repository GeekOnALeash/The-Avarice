using System.Collections.Generic;
using com.ArkAngelApps.TheAvarice.Abstracts;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Nav
{
	public sealed class NPCSimplePatrol : CachedTransformBase
	{
		public float moveSpeed = 5;
		public float turnSpeed = 5;
		private Waypoint currentWayPoint;
		private int currentWayPointIndex;

		//Dictates whether the agent waits on each node.
		[SerializeField] private bool patrolWaiting;

		//The total time we wait at each node.
		[SerializeField] private float totalWaitTime = 3f;

		//The probability of switching direction.
		[SerializeField] private float switchProbability = 0.2f;

		//The list of all patrol nodes to visit.
		[SerializeField] private List<Waypoint> wayPoints;

		private int _currentPatrolIndex;
		private bool _travelling;
		private bool _waiting;
		private bool _patrolForward;
		private float _waitTimer;

		Vector3 direction;

		private void Awake()
		{
			if (wayPoints.Count > 0)
			{
				currentWayPoint = wayPoints[0];
				currentWayPointIndex = 0;
			} else
			{
				Debug.LogError("No waypoint assigned");
			}
		}

		private void Update()
		{
			direction = currentWayPoint.transform.position - transform.position;
			transform.Translate(Time.deltaTime * moveSpeed * direction);

			if (currentWayPoint.IsWaypointReached(transform.position))
			{
				NextWaypoint();
			}
		}

		/// <summary>
		/// Assign Next waypoint in the list.
		/// </summary>
		private void NextWaypoint()
		{
			currentWayPointIndex++; // try to increase the index
			if (currentWayPointIndex > wayPoints.Count - 1)
			{
				currentWayPointIndex =
					0; // if index is larger than list of waypoints, reset it to zero
			}

			currentWayPoint =
				wayPoints
					[currentWayPointIndex]; // assign current waypoint from the list
		}

		private void OnDrawGizmosSelected()
		{
			for (var i = 0; i < wayPoints.Count; i++)
			{
				if (i == 0)
				{
					Gizmos.color = new Color(0, 0.4f, 0);
				} else
				{
					Gizmos.color = new Color(0.6f, 1, 0.6f);
				}

				Gizmos.DrawSphere(wayPoints[i].transform.position, 0.2f);

				if (wayPoints.Count > 1)
				{
					Gizmos.color = Color.blue;
					if (i == 0)
					{
						Gizmos.DrawLine(wayPoints[0].transform.position,
						                wayPoints[1].transform.position);
					} else if (i == wayPoints.Count - 1)
					{
						Gizmos.DrawLine(wayPoints[i - 1].transform.position,
						                wayPoints[i].transform.position);
						Gizmos.color = Color.grey;
						Gizmos
							.DrawLine(wayPoints[wayPoints.Count - 1].transform.position,
							          wayPoints[0].transform.position);
					} else
					{
						Gizmos.color = Color.blue;
						Gizmos.DrawLine(wayPoints[i - 1].transform.position,
						                wayPoints[i].transform.position);
					}
				}
			}
		}
	}
}