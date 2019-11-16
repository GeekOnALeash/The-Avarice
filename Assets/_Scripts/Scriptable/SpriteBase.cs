using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable
{
	[CreateAssetMenu(fileName = "CharacterSprites", menuName = "Scriptable/Sprites/Base", order = 1)]
	public sealed class SpriteBase : ScriptableObject
	{
		[SerializeField] private Sprite sprite;
		[SerializeField] private Color color;

		private Sprite Sprite
		{
			get => sprite;
			set => sprite = value;
		}

		private Color Color
		{
			get => color;
			set => color = value;
		}

		internal void SetSpriteToRenderer([NotNull] SpriteRenderer spriteRenderer)
		{
			if (spriteRenderer.Equals(null))
			{
				Debug.Log("Null SpriteRenderer!");
				return;
			}

			if (sprite.Equals(null))
			{
				return;
			}

			spriteRenderer.sprite = Sprite;
			spriteRenderer.color = Color;
		}
	}
}
