using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Effects
{
	public class EffectsArray : Effect
	{
		[SerializeField] private Effect[] effects;

		public override void Apply(GameObject target)
		{
			foreach (var effect in effects)
			{
				effect.Apply(target);
			}
		}
	}
}
