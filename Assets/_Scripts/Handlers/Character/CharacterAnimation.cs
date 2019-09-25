using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using com.ArkAngelApps.TheAvarice.SimpleSpriteAnimator;
using NotImplementedException = System.NotImplementedException;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	public class CharacterAnimation : SpriteAnimatorBase
	{
		public CharacterAnimations anims;

		public void Start()
		{
			if (playAutomatically)
			{
				Play(GetDefaultIdle());
			}
		}

		public SpriteAnimation GetDefaultIdle() => anims.idle.Length > 0 ? anims.idle[0] : null;

/*		protected virtual void DoIdle()
		{
			timer -= Time.deltaTime;

			if (IsIdlePlaying(animator))
			{
				return;
			}

			if (timer < 0.0f)
			{
				animator.SetInteger(_RandomID, Random.Range(1, totalIdleAnimations));
				timer = secondsBetweenIdles;

				return;
			}

			animator.SetInteger(_RandomID, 0);
		}*/

		public override void Play()
		{
			throw new NotImplementedException();
		}
	}
}