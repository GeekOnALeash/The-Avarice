using com.ArkAngelApps.TheAvarice.Scriptable;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene.Objects
{
	public sealed class ObjectStyler : SpriteStyler
	{
		[SerializeField] private SpriteBase spriteBase;
		[SerializeField] private SpriteRenderer spriteRenderer;

		protected override void SetSprites()
		{
			SetSprite(spriteBase, spriteRenderer);
		}
	}
}