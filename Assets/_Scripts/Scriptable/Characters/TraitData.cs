using System;
using EasyButtons;
using UnityEngine;
using UnityEngine.Events;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Characters
{
	[CreateAssetMenu(fileName = "NewTrait", menuName = "Scriptable/Character/Trait", order = 4)]
	public sealed class TraitData : ScriptableObject
	{
		[Serializable]
		public struct StatEffect
		{
			public string name;
			public SkillTypes skillToEffect;
			public int amountToEffect;
		}

		[SerializeField]
		private StatEffect[] statEffects;

		// ReSharper disable once ReturnTypeCanBeEnumerable.Global
		// ReSharper disable once ConvertToAutoProperty
		internal StatEffect[] StatEffects => statEffects;


		[SerializeField]
		private UnityEvent traitAddedEvents;

		[SerializeField]
		private UnityEvent traitRemovedEvents;

		[Button("Trait Add Events")]
		public void TraitAddAction()
		{
			traitAddedEvents.Invoke();
		}

		[Button("Trait Remove Events")]
		public void TraitRemoveAction()
		{
			traitRemovedEvents.Invoke();
		}
	}
}
