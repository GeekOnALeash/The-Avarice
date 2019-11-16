using com.ArkAngelApps.TheAvarice.Handlers.Character;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Effects
{
	[CreateAssetMenu(fileName = "BoostHealthEffect", menuName = "Scriptable/Effects/Boost Health", order = 1)]
	public sealed class BoostHealthEffect : Effect
	{
		public int amount;

		public override void Apply([NotNull] GameObject target)
		{
			target.GetComponent<Health>().HealthHelper.IncreaseHealth(amount);
		}
	}
}
