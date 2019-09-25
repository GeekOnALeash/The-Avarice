using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Objects.Weapons
{
	[CreateAssetMenu(fileName = "NewParticleEffect", menuName = "ScriptableObjects/In-Game/ParticleEffect", order = 7)]
	public sealed class ParticleEffects : ScriptableObject
	{
		[SerializeField] private string effectName;

		// ReSharper disable once ConvertToAutoProperty
		internal string Name => effectName;

		[SerializeField] private string effectDescription;

		// ReSharper disable once ConvertToAutoProperty
		internal string Description => effectDescription;

		[SerializeField] private ParticleSystem particleSystem;


		private void InstantiateAtPosition(Vector2 position) =>
			Instantiate(particleSystem.gameObject, position, Quaternion.identity);

		internal void PlayAtPosition(Vector2 position)
		{
			InstantiateAtPosition(position);
			particleSystem.Play();
		}
	}
}
