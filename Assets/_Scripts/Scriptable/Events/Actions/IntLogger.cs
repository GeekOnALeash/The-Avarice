using UnityAtoms;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Events.Actions
{
	[CreateAssetMenu(fileName = "IntLogger", menuName = "Scriptable/Events/Actions/Loggers/Int", order = 1)]
	public sealed class IntLogger : IntAction
	{
		public override void Do(int value)
		{
			Debug.Log($"IntLogger: {value.ToString()}");
		}
	}
}
