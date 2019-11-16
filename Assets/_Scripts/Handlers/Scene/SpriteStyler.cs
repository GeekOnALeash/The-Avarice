using com.ArkAngelApps.TheAvarice.Scriptable;
using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene
{
	public class SpriteStyler : MonoBehaviour
	{
		public CharacterSpriteBase spriteData;

		internal static void SetSprite([CanBeNull] SpriteBase spriteBase,
		                               [CanBeNull] SpriteRenderer spriteRenderer)
		{
			if (ReferenceEquals(spriteRenderer, null))
			{
				return;
			}

			if (ReferenceEquals(spriteBase, null))
			{
				spriteRenderer.sprite = null;
				return;
			}

			spriteBase.SetSpriteToRenderer(spriteRenderer);
		}
	}
}