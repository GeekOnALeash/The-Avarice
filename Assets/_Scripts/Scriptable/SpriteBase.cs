using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable
{
	[CreateAssetMenu(fileName = "CharacterSprites", menuName = "Scriptable/Sprites/Base", order = 1)]
	public sealed class SpriteBase : ScriptableObject
	{
		[SerializeField] private Sprite sprite;
		[SerializeField] private Color color;
		[SerializeField] private bool isFlipped;

		public Sprite Sprite => sprite;
		public Color Color => color;
		public bool IsFlipped => isFlipped;

		internal void SetSpriteToRenderer([NotNull] SpriteRenderer spriteRenderer)
		{
			if (spriteRenderer.Equals(null))
			{
				Debug.Log("Null SpriteRenderer!");
				return;
			}

			if (sprite.Equals(null))
			{
				spriteRenderer.sprite = null;
				return;
			}

			spriteRenderer.sprite = Sprite;
			spriteRenderer.color = Color;
			spriteRenderer.flipX = IsFlipped;
		}
	}
}
