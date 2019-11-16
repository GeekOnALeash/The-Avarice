using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Characters
{
	public enum CharacterType
	{
		Male,
		Female,
		Android
	}

	[CreateAssetMenu(fileName = "CharacterSprites", menuName = "Scriptable/Sprites/Character/Body", order = 1)]
	public sealed class CharacterSpriteBase : ScriptableObject
	{
		public CharacterType characterType;

		public SpriteBase bodySprite;
		public SpriteBase hairSprite;

		public SpriteBase eyeLashesSprite;
		public SpriteBase eyesSprite;
		public SpriteBase eyeBaseSprite;
		public SpriteBase eyeMaskSprite;

		[ShowWhen(nameof(characterType), CharacterType.Male)]
		public SpriteBase beardSprite;

		public SpriteBase hatSprite;
		public SpriteBase shirtSprite;
		public SpriteBase beltSprite;
		public SpriteBase trousersSprite;
		public SpriteBase shoesSprite;
	}
}
