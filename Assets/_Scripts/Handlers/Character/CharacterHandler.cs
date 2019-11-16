using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	[DisallowMultipleComponent]
	public class CharacterHandler : MonoBehaviour
	{
		[SerializeField] private CharacterData data;

		internal Health health;
		internal Experience experience;

		public virtual void Awake()
		{
			health = GetComponent<Health>();
			Assert.IsNotNull(health, "health is null");

			experience = GetComponent<Experience>();
			Assert.IsNotNull(experience, "experience is null");
		}
	}
}
