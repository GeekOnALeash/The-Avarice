using com.ArkAngelApps.TheAvarice.Controllers;
using UnityEngine;
using UnityEngine.Events;

namespace com.ArkAngelApps.TheAvarice.Scriptable.UI
{
	[CreateAssetMenu(fileName = "NewItem", menuName = "Scriptable/UI/RadialSectionTask", order = 4)]
	public class RadialSectionTaskData : ScriptableObject
	{
		public UnityEvent[] sectionEvents = new UnityEvent[UIController.RadialSelectionUISize];
	}
}