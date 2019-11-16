using System;
using com.ArkAngelApps.TheAvarice.Handlers.Scene;
using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using EasyButtons;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	[ExecuteInEditMode]
	public sealed class CharacterStyler : SpriteStyler
	{
		[Serializable]
		public struct Body
		{
			public SpriteRenderer bodyRenderer;

			[Serializable]
			public struct Hair
			{
				public SpriteRenderer hairRenderer;
				public SpriteRenderer beardRenderer;
			}

			[Space(2)]
			public Hair hair;

			[Serializable]
			public struct Eyes
			{
				public SpriteRenderer eyeLashesRenderer;
				public SpriteRenderer eyesRenderer;
				public SpriteRenderer eyeBaseRenderer;
				public SpriteRenderer eyeMaskRenderer;
			}

			[Space(2)]
			public Eyes eyes;
		}

		[Serializable]
		public struct Clothes
		{
			public SpriteRenderer hatRenderer;
			public SpriteRenderer shirtRenderer;
			public SpriteRenderer beltRenderer;
			public SpriteRenderer trousersRenderer;
			public SpriteRenderer shoesRenderer;
		}

		[SerializeField] private Body body;
		[SerializeField] private Clothes clothes;

		private void Start()
		{
			SetSprites();
		}

		private void LateUpdate()
		{
			if (!Application.isPlaying)
			{
				SetSprites();
			}
		}

		[Button]
		private void SetSprites()
		{
			// This is called direct as requires a body sprite at all times.
			spriteData.bodySprite.SetSpriteToRenderer(body.bodyRenderer);

			SetSprite(spriteData.hairSprite, body.hair.hairRenderer);

			if (spriteData.characterType == CharacterType.Male)
			{
				SetSprite(spriteData.beardSprite, body.hair.beardRenderer);
			}

			SetSprite(spriteData.eyeLashesSprite, body.eyes.eyeLashesRenderer);
			SetSprite(spriteData.eyesSprite, body.eyes.eyesRenderer);
			SetSprite(spriteData.eyeBaseSprite, body.eyes.eyeBaseRenderer);
			SetSprite(spriteData.eyeMaskSprite, body.eyes.eyeMaskRenderer);
			SetSprite(spriteData.hatSprite, clothes.hatRenderer);
			SetSprite(spriteData.shirtSprite, clothes.shirtRenderer);
			SetSprite(spriteData.beltSprite, clothes.beltRenderer);
			SetSprite(spriteData.trousersSprite, clothes.trousersRenderer);
			SetSprite(spriteData.shoesSprite, clothes.shoesRenderer);
		}
	}
}
