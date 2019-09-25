using com.ArkAngelApps.TheAvarice.Behaviours;
using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(CharacterDataComponent))]
	public class CharacterHandler : MonoBehaviour
	{
		internal CharacterAnimation animator;
		internal Health health;
		internal CharacterData data;
		internal Experience experience;
		internal Movable movement;

		public virtual void Awake()
		{
			data = GetComponent<CharacterDataComponent>().data;
			Assert.IsNotNull(data, "data is null");
			health = GetComponent<Health>();
			Assert.IsNotNull(health, "health is null");

			animator = GetComponent<CharacterAnimation>();
			Assert.IsNotNull(animator, "animator is null");
			experience = GetComponent<Experience>();
			Assert.IsNotNull(experience, "experience is null");
			movement = GetComponent<Movable>();
			Assert.IsNotNull(movement, "movement is null");
		}
	}
}
