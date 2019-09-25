using com.ArkAngelApps.TheAvarice.SimpleSpriteAnimator;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Characters
{
	[CreateAssetMenu(fileName = "CharacterAnimations", menuName = "ScriptableObjects/In-Game/Characters/CharacterAnimations", order = 5)]
	public sealed class CharacterAnimations : ScriptableObject
	{
		public SpriteAnimation[] idle;
		public SpriteAnimation walkRight;
		public SpriteAnimation walkLeft;
		public SpriteAnimation walkUp;
		public SpriteAnimation walkDown;
	}
}