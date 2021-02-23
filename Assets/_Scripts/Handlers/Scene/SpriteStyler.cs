using com.ArkAngelApps.TheAvarice.Scriptable;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene
{
	[ExecuteInEditMode]
	public abstract class SpriteStyler : MonoBehaviour
	{
		protected virtual void Start()
		{
			SetSprites();
		}

		protected virtual void LateUpdate()
		{
			if (!Application.isPlaying)
			{
				SetSprites();
			}
		}

		protected abstract void SetSprites();

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