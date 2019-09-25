using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Tilemaps;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	public sealed class SortingHelper : MonoBehaviour
	{
		public string alternateSortingLayerName;
		public int sortingOrder;

		private TilemapRenderer _tilemap;
		private string _originalLayerName;

		[SuppressMessage("ReSharper", "InvertIf")]
		private void Start()
		{
			_tilemap = GetComponent<TilemapRenderer>();
			Assert.IsNotNull(_tilemap, "_tilemap is null");

			if (_tilemap)
			{
				_tilemap.sortingOrder = sortingOrder;

				_originalLayerName = _tilemap.sortingLayerName;
			}
		}

		public void SwitchToAlternateLayer()
		{
			_tilemap.sortingLayerName = alternateSortingLayerName;
		}

		public void SwitchToOriginalLayer()
		{
			_tilemap.sortingLayerName = _originalLayerName;
		}
	}
}