using com.ArkAngelApps.TheAvarice.Controllers;
using UnityEngine;
using UnityEngine.Events;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	public sealed class RadialSection : MonoBehaviour
	{
		public bool sectionEnabled = true;
		public RadialSectionNumber sectionNumber;
		public UnityEvent sectionEvent;

		private void Start()
		{
			if (sectionEnabled)
			{
				Controller.UI.radialSelectionUI.sections[(int) sectionNumber] = this;
			}
		}

		public void OnSection(int test)
		{
			sectionEvent.Invoke();

			Debug.Log($"Button number {test.ToString()} pressed");
		}
	}
}