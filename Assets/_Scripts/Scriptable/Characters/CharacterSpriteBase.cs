using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Characters
{
	public enum CharacterType
	{
		Male,
		Female,
		Android
	}

	internal enum CharacterAnim
	{
		FrontIdle,
		FrontWalk,
		RearIdle,
		RearWalk,
		LeftIdle,
		LeftWalk,
		RightIdle,
		RightWalk
	}

	internal enum SpriteName
	{
		Body,
		Hair,
		EyeLashes,
		Eyes,
		EyeBase,
		EyeMask,
		Hat,
		Shirt,
		Trousers,
		Shoes
	}

	[CreateAssetMenu(fileName = "CharacterSprites", menuName = "Scriptable/Sprites/Character/Body", order = 1)]
	public sealed class CharacterSpriteBase : ScriptableObject
	{
		public CharacterType characterType;

		public AnimSpriteBase frontIdle;
		public AnimSpriteBase frontWalk;
		public AnimSpriteBase rearIdle;
		public AnimSpriteBase rearWalk;
		public AnimSpriteBase leftIdle;
		public AnimSpriteBase leftWalk;
		public AnimSpriteBase rightIdle;
		public AnimSpriteBase rightWalk;

		internal void SetAnimSpriteToRenderer(CharacterAnim characterAnim,
		                                      [NotNull] Dictionary<SpriteName, SpriteRenderer> spriteRenderers)
		{
			switch (characterAnim)
			{
				case CharacterAnim.FrontIdle:
					frontIdle.SetAnimSprites(spriteRenderers);
					break;
				case CharacterAnim.FrontWalk:
					frontWalk.SetAnimSprites(spriteRenderers);
					break;
				case CharacterAnim.RearIdle:
					rearIdle.SetAnimSprites(spriteRenderers);
					break;
				case CharacterAnim.RearWalk:
					rearWalk.SetAnimSprites(spriteRenderers);
					break;
				case CharacterAnim.LeftIdle:
					leftIdle.SetAnimSprites(spriteRenderers);
					break;
				case CharacterAnim.LeftWalk:
					leftWalk.SetAnimSprites(spriteRenderers);
					break;
				case CharacterAnim.RightIdle:
					rightIdle.SetAnimSprites(spriteRenderers);
					break;
				case CharacterAnim.RightWalk:
					rightWalk.SetAnimSprites(spriteRenderers);
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(characterAnim), characterAnim, null);
			}
		}
	}
}
