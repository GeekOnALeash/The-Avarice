using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using com.ArkAngelApps.TheAvarice.SimpleSpriteAnimator;
using JetBrains.Annotations;
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

		[CanBeNull]
		public SpriteAnimation GetDefaultIdle() => anims.idle.Length > 0 ? anims.idle[0] : null;

		public override void Play()
		{
			throw new NotImplementedException();
		}
	}
}