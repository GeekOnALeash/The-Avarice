using com.ArkAngelApps.UtilityLibraries.Attributes;
using Unity.Mathematics;
using UnityAtoms;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Rigidbody2D))]
	public abstract class Movable : BaseBehaviour
	{
		public FloatReference moveSpeed;

		[Header("Read only info fields")]
		[ReadOnly]
		public bool isMoving;

		[ReadOnly] public float horizontal;

		[ReadOnly] public float vertical;

		protected bool movementEnabled = true;
		protected float2 movement;
		protected float2 pos;
		protected Rigidbody2D rb2D;

		protected virtual void Start()
		{
			rb2D = GetComponent<Rigidbody2D>();
			Assert.IsNotNull(rb2D, "_rb2D is null");
			Assert.IsNotNull(moveSpeed, "moveSpeed is null");
		}

		protected void FixedUpdate()
		{
			if (isMoving)
			{
				DoMovement();
			}
		}

		public abstract void DoMovement();

		public void DisableMovement()
		{
			movementEnabled = false;
		}

		public void EnableMovement()
		{
			movementEnabled = true;
		}
	}
}