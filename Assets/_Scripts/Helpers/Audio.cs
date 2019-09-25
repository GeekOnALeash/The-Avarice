using com.ArkAngelApps.TheAvarice.Abstracts;
using com.ArkAngelApps.TheAvarice.Scriptable.Events;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	[RequireComponent(typeof(AudioSource))]
	public abstract class Audio : InitialiseWithAwake
	{
		private AudioSource _audioSource;

		protected virtual void Start()
		{
			_audioSource = GetComponent<AudioSource>();
			Assert.IsNotNull(_audioSource, "_audioSource is null");
		}

		// ReSharper disable once MemberCanBeProtected.Global
		public void Play([NotNull] SimpleAudioEvent audioEvent)
		{
			audioEvent.Play(_audioSource);
		}

		public void Stop()
		{
			_audioSource.Stop();
		}

		public void SetupAudioSource([NotNull] SimpleAudioEvent audioEvent)
		{
			audioEvent.SetupAudioSource(_audioSource);
		}
	}
}
