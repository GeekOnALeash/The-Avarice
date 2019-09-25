using com.ArkAngelApps.UtilityLibraries.Extensions;
using JetBrains.Annotations;
using MyBox;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Events
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Events/Audio Events/Simple")]
	public sealed class SimpleAudioEvent : AudioEvent
	{
		public AudioClip[] clips;

		public RangedFloat volume;

		[MinMaxRange(0.1f, 2)] public RangedFloat pitch;

		public bool isLooping;
		public bool playOnAwake;

		public override void Play([NotNull] AudioSource source)
		{
			if (source.isPlaying)
			{
				return;
			}

			SetupAudioSource(source);

			source.Play();
		}

		public override void SetupAudioSource(AudioSource source)
		{
			if (clips.Length == 0)
			{
				return;
			}

			source.clip = GetRandomClip();
			source.volume = Random.Range(volume.Min, volume.Max);
			source.pitch = Random.Range(pitch.Min, pitch.Max);
			source.loop = isLooping;
			source.playOnAwake = playOnAwake;
		}

		public override AudioClip GetRandomClip() => clips.RandomItem();
	}
}