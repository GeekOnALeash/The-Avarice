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
		public Vector2Variable moveAxis;

		protected bool movementEnabled = true;
		protected Vector2 movement;
		protected Vector2 pos;
		protected Rigidbody2D rb2D;

		protected virtual void Start()
		{
			rb2D = GetComponent<Rigidbody2D>();
			Assert.IsNotNull(rb2D, "_rb2D is null");
			Assert.IsNotNull(moveSpeed, "moveSpeed is null");

			if (moveAxis == null)
			{
				moveAxis = ScriptableObject.CreateInstance<Vector2Variable>();
			}
		}

		protected virtual void FixedUpdate()
		{
			DoMovement();
		}

		public abstract void DoMovement();

		public virtual void DisableMovement()
		{
			movementEnabled = false;
		}

		public virtual void EnableMovement()
		{
			movementEnabled = true;
		}
	}
}