using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Characters
{
	[CreateAssetMenu(fileName = "AnimSprites", menuName = "Scriptable/Sprites/Character/Anim", order = 2)]
	public sealed class AnimSpriteBase : ScriptableObject
	{
		[SerializeField] private SpriteBase bodySprite;
		[SerializeField] private SpriteBase hairSprite;
		[SerializeField] private SpriteBase eyeLashesSprite;
		[SerializeField] private SpriteBase eyesSprite;
		[SerializeField] private SpriteBase eyeBaseSprite;
		[SerializeField] private SpriteBase eyeMaskSprite;

		[SerializeField] private SpriteBase hatSprite;
		[SerializeField] private SpriteBase shirtSprite;
		[SerializeField] private SpriteBase trousersSprite;
		[SerializeField] private SpriteBase shoesSprite;

		internal void SetAnimSprites([NotNull] Dictionary<SpriteName, SpriteRenderer> spriteRenderers)
		{
			Debug.Log(spriteRenderers);
			SetSpriteBaseToRenderer(bodySprite, spriteRenderers[SpriteName.Body]);
			SetSpriteBaseToRenderer(hairSprite, spriteRenderers[SpriteName.Hair]);
			SetSpriteBaseToRenderer(eyeLashesSprite, spriteRenderers[SpriteName.EyeLashes]);
			SetSpriteBaseToRenderer(eyesSprite, spriteRenderers[SpriteName.Eyes]);
			SetSpriteBaseToRenderer(eyeBaseSprite, spriteRenderers[SpriteName.EyeBase]);
			SetSpriteBaseToRenderer(eyeMaskSprite, spriteRenderers[SpriteName.EyeMask]);
			SetSpriteBaseToRenderer(hatSprite, spriteRenderers[SpriteName.Hat]);
			SetSpriteBaseToRenderer(shirtSprite, spriteRenderers[SpriteName.Shirt]);
			SetSpriteBaseToRenderer(trousersSprite, spriteRenderers[SpriteName.Trousers]);
			SetSpriteBaseToRenderer(shoesSprite, spriteRenderers[SpriteName.Shoes]);
		}

		private static void SetSpriteBaseToRenderer([CanBeNull] SpriteBase spriteBase, [NotNull] SpriteRenderer renderer)
		{
			// ReSharper disable once UseNullPropagation
			if (ReferenceEquals(spriteBase, null))
			{
				renderer.sprite = null;
				return;
			}

			spriteBase.SetSpriteToRenderer(renderer);
		}
	}
}