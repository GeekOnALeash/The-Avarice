using com.ArkAngelApps.TheAvarice.Controllers;
using com.ArkAngelApps.TheAvarice.Scriptable.UI;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public sealed class RadialSelectionCaller : MonoBehaviour
	{
		public RadialSectionTaskData data;

		private void ShowUI()
		{
			Controller.UI.ShowRadialSelectionUI(this);
		}
	}
}
