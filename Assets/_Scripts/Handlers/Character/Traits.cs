using System.Collections.Generic;
using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	[DisallowMultipleComponent]
	public sealed class Traits : MonoBehaviour
	{
		public TraitData[] traits;

		private Experience _experience;

		[Header("Read only info fields")]
		[ReadOnly]
		[SerializeField]
		private List<TraitData> activeTraits;

		private void Start()
		{
			_experience = GetComponent<Experience>();

			if (_experience)
			{
				ApplyTraitStats();
			}
		}

		private void ApplyTraitStats()
		{
			for (int index = traits.Length - 1; index >= 0; index--)
			{
				foreach (var statEffect in traits[index].StatEffects)
				{
					_experience.ApplyChange(statEffect.skillToEffect, statEffect.amountToEffect);
				}

				activeTraits.Add(traits[index]);
			}
		}
	}
}
