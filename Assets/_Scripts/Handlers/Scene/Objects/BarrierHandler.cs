using com.ArkAngelApps.MyDebug.Exceptions;
using com.ArkAngelApps.TheAvarice.Scriptable.Items;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene.Objects
{
	public enum BarrierType
	{
		Door,
		LaserField,
		TripWire,
		ForceField
	}

	public enum LockType
	{
		Code,
		Key,
		Remote,
		Permanent
	}

	[RequireComponent(typeof(Animator))]
	public class BarrierHandler : MonoBehaviour
	{
		public BarrierType barrierType;

		public InteractionType interactionType;

		[ShowWhen(nameof(interactionType), InteractionType.Locked)]
		public LockType lockType;

		[ShowWhen(nameof(lockType), LockType.Key)]
		public KeyTypes keyType;

		public bool hasWallShadow;
		public GameObject shadowDoorsOpen;

		[ShowWhen(nameof(hasWallShadow))]
		public GameObject shadowDoorsClosed;

		private Animator _barrierAnimation;

		protected bool withinTrigger;
		private static readonly int __OpenBarrier = Animator.StringToHash("OpenBarrier");

		internal new Collider2D collider;
		internal bool barrierOpen;

		// ReSharper disable once InconsistentNaming
		internal BarrierInteractionType _barrierInteractionType;

		public virtual void Awake()
		{
			switch (interactionType)
			{
				case InteractionType.Trigger:
					_barrierInteractionType = BarrierInteractionType.Trigger;
					break;
				case InteractionType.Interaction:
					_barrierInteractionType = BarrierInteractionType.Interaction;
					break;
				case InteractionType.Locked:
					_barrierInteractionType = BarrierInteractionType.Locked;
					break;
				case InteractionType.Disabled:
					_barrierInteractionType = BarrierInteractionType.Disabled;
					break;
				default:
					// ReSharper disable once HeapView.ObjectAllocation.Evident
					// ReSharper disable once HeapView.BoxingAllocation
					// Disabled ReSharper inspections as this branch is never intended to be reached
					throw new UnexpectedEnumValueException(interactionType);
			}
		}

		public virtual void Start()
		{
			_barrierAnimation = GetComponent<Animator>();
			Assert.IsNotNull(_barrierAnimation, "_barrierAnimation is null");

			ToggleBarrierWallShadows();

			collider = GetComponent<Collider2D>();
			Assert.IsNotNull(collider, "collider is null");
		}

		public virtual void OpenBarrier()
		{
			barrierOpen = true;
			_barrierAnimation.SetBool(__OpenBarrier, true);
			gameObject.layer = LayerMask.NameToLayer("Deactivated Obstacles");

			ToggleBarrierWallShadows();
		}

		public virtual void CloseBarrier()
		{
			barrierOpen = false;
			_barrierAnimation.SetBool(__OpenBarrier, false);
			gameObject.layer = LayerMask.NameToLayer("Obstacle");

			ToggleBarrierWallShadows();
		}

		protected void ToggleBarrierWallShadows()
		{
			shadowDoorsOpen.SetActive(hasWallShadow && barrierOpen);
			shadowDoorsClosed.SetActive(hasWallShadow && !barrierOpen);
		}

		[UsedImplicitly]
		protected void EnableCollider() => collider.enabled = true;

		[UsedImplicitly]
		protected void DisableCollider() => collider.enabled = false;
	}
}