using System;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.SimpleSpriteAnimator
{
	public sealed class SpriteAnimationHelper
	{
		internal SpriteAnimation CurrentAnimation { get; set; }
		internal SpriteAnimationHelper() { }
		public SpriteAnimationHelper(SpriteAnimation spriteAnimation) => CurrentAnimation = spriteAnimation;

		private float _animationTime;

		public SpriteAnimationFrame UpdateAnimation(float deltaTime)
		{
			if (!CurrentAnimation)
			{
				return null;
			}

			_animationTime += deltaTime * CurrentAnimation.FPS;
			return GetAnimationFrame();
		}

		internal void ChangeAnimation(SpriteAnimation spriteAnimation)
		{
			_animationTime = 0f;
			CurrentAnimation = spriteAnimation;
		}

		private SpriteAnimationFrame GetAnimationFrame()
		{
			int currentFrame;

			switch (CurrentAnimation.SpriteAnimationType)
			{
				case SpriteAnimationType.Looping:
					currentFrame = GetLoopingFrame();
					break;
				case SpriteAnimationType.PlayOnce:
					currentFrame = GetPlayOnceFrame();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			return CurrentAnimation.Frames[currentFrame];
		}

		private int GetLoopingFrame() => (int) _animationTime % CurrentAnimation.Frames.Count;

		private int GetPlayOnceFrame() => Mathf.Min((int) _animationTime, CurrentAnimation.Frames.Count - 1);
	}
}