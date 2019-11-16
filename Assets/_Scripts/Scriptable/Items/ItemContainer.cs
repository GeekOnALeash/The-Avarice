using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.MyDebug.Exceptions;
using com.ArkAngelApps.TheAvarice.Data.Structs;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Items
{
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	internal enum ContainerSize
	{
		// Underscores are used to avoid unexpected token error.
		_1x3 = 3,
		_2x3 = 6,
		_3x3 = 9,
		_4x3 = 12
	}

	public enum KeyTypes
	{
		Red,
		Blue,
		Green,
		Yellow
	}

	[CreateAssetMenu(fileName = "NewItemContainer", menuName = "Scriptable/Items/ItemContainer", order = 1)]
	public sealed class ItemContainer : ScriptableObject, ISerializationCallbackReceiver
	{
		[HelpBox("These values will not be update during runtime, use this to setup overall container size.", HelpBoxMessageType.Info)]
		[SerializeField]
		private ContainerSize containerSize;

		[HelpBox("These values will not be update during runtime, use this to setup initial items container will have.", HelpBoxMessageType.Info)]
		[SerializeField]
		private List<ItemData> itemList;

		public KeyChain keyChain;
		public Wallet wallet;
		public Resource resource;

		private int _runtimeContainerSize;
		private List<ItemData> _runtimeItemList;

		private void OnEnable()
		{
			itemList = new List<ItemData>((int) containerSize);
		}

		public void OnBeforeSerialize() { }

		public void OnAfterDeserialize()
		{
			_runtimeContainerSize = (int) containerSize;
			_runtimeItemList = itemList;
		}

		internal void AddItem(ItemData item)
		{
			if (_runtimeItemList.Count >= _runtimeContainerSize)
			{
				return;
			}

			_runtimeItemList.Add(item);
		}

		internal void RemoveItem(ItemData item)
		{
			if (!_runtimeItemList.Contains(item))
			{
				Debug.Log("Item not in container");
				return;
			}

			for (int id = _runtimeItemList.Count - 1; id >= 0; id--)
			{
				if (_runtimeItemList[id] == item)
				{
					_runtimeItemList[id] = null;
				}
			}
		}

		internal int GetContainterSize() => _runtimeContainerSize;

		internal int GetListItemCount() => _runtimeItemList.Count;

		internal List<ItemData> GetItemList() => _runtimeItemList;

		internal bool HasKey(KeyTypes keyType)
		{
			switch (keyType)
			{
				case KeyTypes.Blue:
					return keyChain.blueKey;
				case KeyTypes.Green:
					return keyChain.greenKey;
				case KeyTypes.Red:
					return keyChain.redKey;
				case KeyTypes.Yellow:
					return keyChain.yellowKey;
				default:
					// ReSharper disable once HeapView.ObjectAllocation.Evident
					// ReSharper disable once HeapView.BoxingAllocation
					// Disabled ReSharper inspections as this branch is never intended to be reached
					throw new UnexpectedEnumValueException(keyType);
			}
		}

		public bool IsInPlayerInventory(ItemData data)
		{
			// ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
			foreach (var item in GetItemList())
			{
				if (item != data)
				{
					continue;
				}

				return true;
			}

			return false;
		}
	}
}
