using com.ArkAngelApps.TheAvarice.SimpleSpriteAnimator;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Characters
{
	[CreateAssetMenu(fileName = "CharacterAnimations", menuName = "Scriptable/Character/Animations", order = 5)]
	public sealed class CharacterAnimations : ScriptableObject
	{
		public SpriteAnimation[] idle;
		public SpriteAnimation walkRight;
		public SpriteAnimation walkLeft;
		public SpriteAnimation walkUp;
		public SpriteAnimation walkDown;
	}
}