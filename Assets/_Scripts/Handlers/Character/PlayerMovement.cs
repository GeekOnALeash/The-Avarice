using System.Collections.Generic;
using com.ArkAngelApps.TheAvarice.Behaviours;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using JetBrains.Annotations;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	public sealed class PlayerMovement : Movable
	{
		private NavMeshAgent _navMeshAgent;

		protected override void Start()
		{
			base.Start();

			_navMeshAgent = GetComponent<NavMeshAgent>();
			Assert.IsNotNull(_navMeshAgent, "_navMeshAgent != null");

			_navMeshAgent.updateUpAxis = false;
			_navMeshAgent.updateRotation = false;
		}

		private void Update()
		{
			isMoving = Input.GetMouseButtonDown(0);
			moveAxis.Value = _navMeshAgent.velocity.normalized;
		}

		private void MoveToClickPoint(Vector2 point)
		{
			_navMeshAgent.destination = point;

			DebugDrawPath(_navMeshAgent.path.corners);
		}

		private static void DebugDrawPath([NotNull] IReadOnlyList<Vector3> corners)
		{
			if (corners.Count < 2)
			{
				return;
			}

			var i = 0;
			for (; i < corners.Count - 1; i++)
			{
				Debug.DrawLine(corners[i], corners[i + 1], Color.blue);
			}

			Debug.DrawLine(corners[0], corners[1], Color.red);
		}

		[Il2CppSetOption(Option.NullChecks, false)]
		public override void DoMovement()
		{
			if (!moveSpeed.UseConstant && moveSpeed.Variable == null)
			{
				return;
			}

			isMoving = true;

			Vector2 target = SystemVariables.Instance.mainCamera.camera.ScreenToWorldPoint(Input.mousePosition);

			MoveToClickPoint(target);
		}
	}
}