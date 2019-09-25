using com.ArkAngelApps.TheAvarice.Handlers.Scene;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	public sealed class RoomTransition : MonoBehaviour
	{
		public AreaHandler area1;
		public AreaHandler area2;

		public void ToggleAreas()
		{
			area1.gameObject.SetActive(!area1.gameObject.activeSelf);
			area2.gameObject.SetActive(!area2.gameObject.activeSelf);
		}
	}
}
