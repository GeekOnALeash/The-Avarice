using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.MyEditor.Extensions
{
	public static class LayerMaskExtensions
	{
		public static bool Contains(this LayerMask layers, GameObject go) => 0 != (layers.value & (1 << go.layer));
	}
}