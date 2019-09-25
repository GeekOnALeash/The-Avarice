using System;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.SimpleSpriteAnimator
{
    [Serializable]
    public class SpriteAnimationFrame
    {
        [SerializeField]
        private Sprite sprite;

        public Sprite Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }
    }
}