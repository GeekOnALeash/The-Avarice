using System;
using com.ArkAngelApps.TheAvarice.Helpers;
using com.ArkAngelApps.TheAvarice.Scriptable.Events;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	public enum AudioClipType
	{
		Walking,
		Hurt,
		Death
	}

	[DisallowMultipleComponent]
	public sealed class CharacterAudio : Audio
	{
		[Serializable]
		public struct AudioEvents
		{
			public string name;
			public AudioClipType clipType;
			public SimpleAudioEvent audioEvent;
		}

		public AudioEvents[] audioEvents;

		public void Play(AudioClipType audioClipType)
		{
			foreach (var a in audioEvents)
			{
				if (a.clipType == audioClipType)
				{
					Play(a.audioEvent);
				}
			}
		}
	}
}