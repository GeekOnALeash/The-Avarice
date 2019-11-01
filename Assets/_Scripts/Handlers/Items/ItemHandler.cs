using System;
using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice._Scripts.Data.Structs;
using com.ArkAngelApps.TheAvarice.Data.Structs;
using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using com.ArkAngelApps.TheAvarice.Scriptable.Items;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace com.ArkAngelApps.TheAvarice.Handlers.Items
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(SpriteRenderer))]
	public sealed class ItemHandler : MonoBehaviour
	{
		public ItemData data;

		[Serializable]
		public struct Events
		{
			public UnityEvent onPickUp;
			public UnityEvent onUse;
		}

		public Events itemEvents;

		public SpriteRenderer spriteRenderer;

		private ContextMessage _contextMessage;

		private bool _isPickedUp;

		private void Awake()
		{
			Assert.IsNotNull(spriteRenderer, "sprite is null");
		}

		private void Start()
		{
			UpdateItemSprite();
		}

#if UNITY_EDITOR
		[SuppressMessage("ReSharper", "InvertIf")]
		private void LateUpdate()
		{
			if (!Application.isPlaying)
			{
				if (data.objectChanged)
				{
					Assert.IsNotNull(data, "data is null");
					UpdateItemSprite();
				}
			}
		}
#endif

		private void UpdateItemSprite()
		{
			spriteRenderer.color = data.color;
		}

		private void OnTriggerEnter2D([NotNull] Collider2D other)
		{
			if (other.isTrigger || !other.CompareTag(TagNames.Instance.Player))
			{
				return;
			}

			if (_isPickedUp)
			{
				DestroySelf();
				return;
			}

			if (data.CanPickup())
			{
				PickUpItem();
			}
		}

		private void PickUpItem()
		{
			if (data.useOnPickup)
			{
				UseItem();
				return;
			}

			PlayerRuntimeData.Instance.character.itemContainer.AddItem(this);

			itemEvents.onPickUp.Invoke();
			_isPickedUp = true;
		}

		private void UseItem()
		{
			itemEvents.onUse.Invoke();

			if (data.destroyAfterUse)
			{
				DestroySelfWithDelay(data.destroyAfterUseDelay);
			}
		}

		internal void DestroySelf()
		{
			Destroy(gameObject);
		}

		private void DestroySelfWithDelay(float delay)
		{
			Destroy(gameObject, delay);
		}
	}
}