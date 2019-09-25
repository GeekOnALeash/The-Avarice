using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.SimpleSpriteAnimator
{
	[Serializable]
	[CreateAssetMenu]
	public class SpriteAnimation : ScriptableObject
	{
		[SerializeField] private string animationName = "animation";

		public string Name
		{
			get => animationName;
			set => animationName = value;
		}

		[SerializeField] private int fps = 30;

		public int FPS
		{
			get => fps;
			set => fps = value;
		}

		[SerializeField] private List<SpriteAnimationFrame> frames = new List<SpriteAnimationFrame>();

		public List<SpriteAnimationFrame> Frames => frames;

		[SerializeField] private SpriteAnimationType spriteAnimationType = SpriteAnimationType.Looping;

		public SpriteAnimationType SpriteAnimationType
		{
			get => spriteAnimationType;
			set => spriteAnimationType = value;
		}

		internal bool animPlaying;

		internal SpriteAnimationFrame GetFrame(int frameID)
		{
			if (frameID >= Frames.Count)
			{
				animPlaying = false;
				return null;
			}

			if (frameID == Frames.Count - 1)
			{
				animPlaying = false;
			}

			animPlaying = true;

			return Frames[frameID];
		}
	}
}