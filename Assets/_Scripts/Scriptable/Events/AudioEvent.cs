using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Events
{
	public abstract class AudioEvent : ScriptableObject
	{
		public abstract void Play(AudioSource source);
		public abstract void SetupAudioSource(AudioSource source);
		public abstract AudioClip GetRandomClip();
	}
}