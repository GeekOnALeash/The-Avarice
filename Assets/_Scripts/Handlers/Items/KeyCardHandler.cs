using com.ArkAngelApps.MyDebug.Exceptions;
using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using com.ArkAngelApps.TheAvarice.Scriptable.Items;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Items
{
	public sealed class KeyCardHandler : MonoBehaviour
	{
		public KeyTypes keyType;

		internal void AddToKeyChain()
		{
			switch (keyType)
			{
				case KeyTypes.Blue:
					PlayerRuntimeData.Instance.itemContainer.keyChain.blueKey = true;
					break;
				case KeyTypes.Green:
					PlayerRuntimeData.Instance.itemContainer.keyChain.greenKey = true;
					break;
				case KeyTypes.Red:
					PlayerRuntimeData.Instance.itemContainer.keyChain.redKey = true;
					break;
				case KeyTypes.Yellow:
					PlayerRuntimeData.Instance.itemContainer.keyChain.yellowKey = true;
					break;
				default:
					// ReSharper disable once HeapView.ObjectAllocation.Evident
					// ReSharper disable once HeapView.BoxingAllocation
					// Disabled ReSharper inspections as this branch is never intended to be reached
					throw new UnexpectedEnumValueException(keyType);
			}
		}
	}
}