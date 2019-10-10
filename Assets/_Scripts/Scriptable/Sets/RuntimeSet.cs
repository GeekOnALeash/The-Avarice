using System.Collections.Generic;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Sets
{
	public abstract class RuntimeSet<T> : ScriptableObject, ISerializationCallbackReceiver
	{
		[SerializeField] private List<T> items = new List<T>();

		internal List<T> runtimeItems = new List<T>();

		internal int Count => runtimeItems.Count;

		internal int LastIndex => Count - 1;

		internal void Add(T item)
		{
			if (!runtimeItems.Contains(item))
			{
				runtimeItems.Add(item);
			}
		}

		internal void Remove(T item)
		{
			if (runtimeItems.Contains(item))
			{
				runtimeItems.Remove(item);
			}
		}

		internal void RemoveAt(int index)
		{
			runtimeItems.RemoveAt(index);
		}

		internal void Clear()
		{
			runtimeItems = items;
		}

		internal void Insert(int index, T item)
		{
			if (!runtimeItems.Contains(item))
			{
				runtimeItems.Insert(index, item);
			}
		}

		internal T GetItemUsingIndex(int index) => runtimeItems[index];

		internal T GetFirstItem() => GetItemUsingIndex(0);

		internal T GetLastItem() => GetItemUsingIndex(LastIndex);

		public void OnBeforeSerialize() { }

		public void OnAfterDeserialize()
		{
			runtimeItems = items;
		}
	}
}