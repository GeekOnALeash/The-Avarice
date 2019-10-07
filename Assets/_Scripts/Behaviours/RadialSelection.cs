using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Behaviours.UI;
using com.ArkAngelApps.TheAvarice.Controllers;
using com.ArkAngelApps.TheAvarice.Helpers;
using com.ArkAngelApps.TheAvarice.Scriptable.UI;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public sealed class RadialSelection : UICaller
	{
		public RadialSectionTaskData data;

		[SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
		internal RadialSection[] sections = new RadialSection[UIController.RadialSelectionUISize];

		public void SelectSection() { }

		internal void SetRadialPosition(Vector3 pos)
		{
			if (transform.position == pos)
			{
				HideUI();
				return;
			}

			Controller.UI.hoverText.SetHideText(true);
			transform.position = pos;
		}

		internal void SetupRadial(RadialSectionTaskData taskData)
		{
			data = taskData;
		}

		private void OnDestroy()
		{
			foreach (var section in sections)
			{
				section.enabled = false;
			}
		}
	}
}
