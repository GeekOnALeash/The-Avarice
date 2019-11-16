using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace com.ArkAngelApps.TheAvarice.Nav
{
	public class NPCSimplePatrol : MonoBehaviour
	{
		//Dictates whether the agent waits on each node.
		[SerializeField] private bool patrolWaiting;

		//The total time we wait at each node.
		[SerializeField] private float totalWaitTime = 3f;

		//The probability of switching direction.
		[SerializeField] private float switchProbability = 0.2f;

		//The list of all patrol nodes to visit.
		[SerializeField] private List<Waypoint> patrolPoints;

		//Private variables for base behaviour.
		private NavMeshAgent _navMeshAgent;
		private int _currentPatrolIndex;
		private bool _travelling;
		private bool _waiting;
		private bool _patrolForward;
		private float _waitTimer;

		// Use this for initialization
		public void Start()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
			_navMeshAgent.updateUpAxis = false;

			if (_navMeshAgent == null)
			{
				Debug.LogError("The nav mesh agent component is not attached to " +
				               gameObject.name);
			} else
			{
				if (patrolPoints != null && patrolPoints.Count >= 2)
				{
					_currentPatrolIndex = 0;
					SetDestination();
				} else
				{
					Debug.Log("Insufficient patrol points for basic patrolling behaviour.");
				}
			}
		}

		public void Update()
		{
			//Check if we're close to the destination.
			if (_travelling && _navMeshAgent.remainingDistance <= 1.0f)
			{
				_travelling = false;

				//If we're going to wait, then wait.
				if (patrolWaiting)
				{
					_waiting = true;
					_waitTimer = 0f;
				} else
				{
					ChangePatrolPoint();
					SetDestination();
				}
			}

			//Instead if we're waiting.
			if (_waiting)
			{
				_waitTimer += Time.deltaTime;
				if (_waitTimer >= totalWaitTime)
				{
					_waiting = false;

					ChangePatrolPoint();
					SetDestination();
				}
			}
		}

		private void SetDestination()
		{
			if (patrolPoints != null)
			{
				var targetVector =
					patrolPoints[_currentPatrolIndex].transform.position;

				_navMeshAgent.SetDestination(targetVector);
				_travelling = true;
			}
		}

		/// <summary>
		/// Selects a new patrol point in the available list, but
		/// also with a small probability allows for us to move forward or backwards.
		/// </summary>
		private void ChangePatrolPoint()
		{
			if (Random.Range(0f, 1f) <= switchProbability)
			{
				_patrolForward = !_patrolForward;
			}

			if (_patrolForward)
			{
				_currentPatrolIndex =
					(_currentPatrolIndex + 1) % patrolPoints.Count;
			} else
			{
				if (--_currentPatrolIndex < 0)
				{
					_currentPatrolIndex = patrolPoints.Count - 1;
				}
			}
		}
	}
}