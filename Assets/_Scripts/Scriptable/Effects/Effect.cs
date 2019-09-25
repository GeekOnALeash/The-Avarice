using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Effects
{
	public abstract class Effect : ScriptableObject
	{
		public abstract void Apply(GameObject target);
	}
}
