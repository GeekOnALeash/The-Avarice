using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Behaviours;
using com.ArkAngelApps.TheAvarice.Interfaces;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	public sealed class NPCMovement : Movable, IMovement
	{
		public Transform target;
		public float minDistance = 1f;
		public float maxDistance = 3f;

		private float _currentDistance;

		[SuppressMessage("ReSharper", "InvertIf")]
		private void Update()
		{
			if (movementEnabled)
			{
				_currentDistance = Vector2.Distance(transform.position, target.position);
				if (_currentDistance >= minDistance && _currentDistance <= maxDistance)
				{
					isMoving = true;
				} else
				{
					isMoving = false;
				}
			}
		}

		public override void DoMovement()
		{
			transform.position = Vector2.MoveTowards(transform.position, target.position,
			                                         moveSpeed.Value * Time.deltaTime);
		}
	}
}