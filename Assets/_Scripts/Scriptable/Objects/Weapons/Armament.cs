using com.ArkAngelApps.UtilityLibraries.Attributes;
using com.ArkAngelApps.UtilityLibraries.Extensions;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Objects.Weapons
{
	public enum AreaOfEffect
	{
		SingleTarget,
		SingleTargetOverTime,
		Area,
		AreaOverTime
	}

	public enum ArmamentType
	{
		Impact,
		Energy,
		Heat,
		Cold,
		Explosive,
		Poison
	}

	[CreateAssetMenu(fileName = "NewArmament", menuName = "Scriptable/Objects/Weapons/Armament", order = 7)]
	public sealed class Armament : ScriptableObject
	{
		public ArmamentType armamentType;
		public AreaOfEffect areaOfEffect;

		[Header("Damage")] public int damageAmount;
		public int duration;

		[Header("UI Info")]
		public string effectName;

		internal string EffectName => effectName;

		[TextArea] public string effectDescription;
		internal string EffectDescription => effectDescription;

		public Sprite effectSprite;
		internal Sprite EffectSprite => effectSprite;

		[Header("Other")]
		public bool canBeBlocked;

		public float cooldown;
		public bool knocksBackPlayer;

		[Header("Particle Systems")]
		[SerializeField] private bool randomParticleEffects;

		[ShowWhen(nameof(randomParticleEffects), false)]
		public ParticleEffects particleEffects;

		[ShowWhen(nameof(randomParticleEffects), true)]
		public ParticleEffects[] particleEffectsArray;

		private ParticleEffects ParticleEffect => randomParticleEffects
			                                          ? particleEffectsArray.RandomItem()
			                                          : particleEffects;

		internal void FireParticlesAtPosition(Vector3 position)
		{
			if (!ParticleEffect)
			{
				return;
			}

			ParticleEffect.PlayAtPosition(position);
		}

		public void FireParticleAroundCharacter([NotNull] GameObject go)
		{
			FireParticlesAtPosition(go.transform.position);
		}
	}
}
