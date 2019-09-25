using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.SimpleSpriteAnimator
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class SpriteAnimator : SpriteAnimatorBase
    {
        [SerializeField]
        private List<SpriteAnimation> spriteAnimations;

        [CanBeNull]
        private SpriteAnimation DefaultAnimation => spriteAnimations.Count > 0 ? spriteAnimations[0] : null;

        private void Start()
        {
            if (playAutomatically)
            {
                Play(DefaultAnimation);
            }
        }

        public override void Play()
        {
            if (CurrentAnimation == null)
            {
                spriteAnimationHelper.ChangeAnimation(DefaultAnimation);
            }

            Play(CurrentAnimation);
        }

        public void Play(string animationName)
        {
            Play(GetAnimationByName(animationName));
        }

        [CanBeNull]
        private SpriteAnimation GetAnimationByName(string spriteAnimation)
        {
            foreach (var anim in spriteAnimations)
            {
                if (anim.Name == spriteAnimation)
                {
                    return anim;
                }
            }

            return null;
        }
    }
}
