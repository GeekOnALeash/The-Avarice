using System;
using System.Collections.Generic;
using com.ArkAngelApps.TheAvarice.Handlers.Scene;
using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using EasyButtons;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public sealed class CharacterStyler : SpriteStyler
	{
		[SerializeField] private CharacterSpriteBase spriteData;

		[Serializable]
		public struct Body
		{
			public SpriteRenderer bodyRenderer;
			public SpriteRenderer hairRenderer;

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
			public SpriteRenderer trousersRenderer;
			public SpriteRenderer shoesRenderer;
		}

		[SerializeField] private Body body;
		[SerializeField] private Clothes clothes;

		private Dictionary<SpriteName, SpriteRenderer> _spriteRenderers;

		protected override void Start()
		{
			_spriteRenderers = new Dictionary<SpriteName, SpriteRenderer>
			                   {
				                   {SpriteName.Body, body.bodyRenderer},
				                   {SpriteName.Hair, body.hairRenderer},
				                   {SpriteName.EyeLashes, body.eyes.eyeLashesRenderer},
				                   {SpriteName.Eyes, body.eyes.eyesRenderer},
				                   {SpriteName.EyeBase, body.eyes.eyeBaseRenderer},
				                   {SpriteName.EyeMask, body.eyes.eyeMaskRenderer},
				                   {SpriteName.Hat, clothes.hatRenderer},
				                   {SpriteName.Shirt, clothes.shirtRenderer},
				                   {SpriteName.Trousers, clothes.trousersRenderer},
				                   {SpriteName.Shoes, clothes.shoesRenderer}
			                   };

			base.Start();
		}

		[Button]
		protected override void SetSprites()
		{
			spriteData.SetAnimSpriteToRenderer(CharacterAnim.FrontIdle, _spriteRenderers);
		}
	}
}
