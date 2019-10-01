using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.SimpleSpriteAnimator
{
	public abstract class SpriteAnimatorBase : MonoBehaviour
	{
		public bool playAutomatically = true;

		public bool Playing => state == SpriteAnimationState.Playing;
		public bool Paused => state == SpriteAnimationState.Paused;

		protected SpriteAnimation CurrentAnimation => spriteAnimationHelper.CurrentAnimation;
		protected SpriteRenderer spriteRenderer;

		protected SpriteAnimationHelper spriteAnimationHelper;

		protected SpriteAnimationState state = SpriteAnimationState.Stopped;

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();

			spriteAnimationHelper = new SpriteAnimationHelper();
		}

		private void LateUpdate()
		{
			if (Playing)
			{
				SpriteAnimationFrame currentFrame = spriteAnimationHelper.UpdateAnimation(Time.deltaTime);

				if (currentFrame != null)
				{
					spriteRenderer.sprite = currentFrame.Sprite;
				}
			}
		}



		public abstract void Play();

		public void Play([CanBeNull] SpriteAnimation spriteAnimation)
		{
			if (ReferenceEquals(spriteAnimation, null))
			{
				Debug.Log("SpriteAnimation is null");
				state = SpriteAnimationState.Stopped;
				return;
			}

			state = SpriteAnimationState.Playing;
			spriteAnimationHelper.ChangeAnimation(spriteAnimation);
		}

		/// <summary>
		/// Flip the sprite on the X axis
		/// </summary>
		private void FlipSpriteX(bool flip)
		{
			spriteRenderer.flipX = flip;
		}

		/// <summary>
		/// Flip the sprite on the Y axis
		/// </summary>
		private void FlipSpriteY(bool flip)
		{
			spriteRenderer.flipY = flip;
		}
	}
}