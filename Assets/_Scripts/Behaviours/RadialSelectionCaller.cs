using com.ArkAngelApps.TheAvarice.Controllers;
using com.ArkAngelApps.TheAvarice.Scriptable.UI;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	public sealed class RadialSelectionCaller : MonoBehaviour
	{
		public RadialSectionTaskData data;

		private Transform _thisTransform;

		// ReSharper disable once InconsistentNaming
		internal new Transform transform
		{
			get
			{
				if (_thisTransform == null)
				{
					_thisTransform = base.transform;
				}

				return _thisTransform;
			}
		}

		private void ShowUI()
		{
			Controller.UI.ShowRadialSelectionUI(this);
		}
	}
}
