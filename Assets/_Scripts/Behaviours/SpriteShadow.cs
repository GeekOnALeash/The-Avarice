using System;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(SpriteRenderer))]
	public sealed class SpriteShadow : MonoBehaviour
	{
		public float minFlipped = 90f;
		public float maxFlipped = 270f;

		public bool flipBetweenAngles = false;

		[Range(0, 359f)] public float angle;

		public Color tint = new Color(0, 0, 0, .66f);

		public Vector2 size = new Vector2(1f, 1f);

		public Vector2 offset = Vector2.zero;

		public bool useParentsSprite = true;

		public Sprite replacementSprite;

		private SpriteRenderer _spriteRenderer;

		private SpriteRenderer _parentSpriteRenderer;
		private bool enableShadow;
		private Vector3 lightPosition;

		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();

			if (useParentsSprite)
			{
				_parentSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
			}

			_spriteRenderer.color = Color.black;
		}

		private void Update()
		{
			if (enableShadow)
			{
				SetSprite();

				_spriteRenderer.color = tint;

				Vector3 moveDirection = gameObject.transform.position - lightPosition;
				if (moveDirection != Vector3.zero)
				{
					float lightAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
					transform.rotation = Quaternion.AngleAxis(-lightAngle, -Vector3.forward);
				}

				transform.localPosition = offset;

				if (transform.rotation.eulerAngles.z > minFlipped && transform.rotation.eulerAngles.z < maxFlipped)
				{
					transform.localScale = new Vector3(-1 * size.x, size.y, transform.localScale.z);
				} else
				{
					transform.localScale = new Vector3(size.x, size.y, transform.localScale.z);
				}
			} else
			{
				_spriteRenderer.enabled = false;
			}
		}

		private void SetSprite()
		{
			_spriteRenderer.enabled = true;
			_spriteRenderer.sprite = useParentsSprite ? _parentSpriteRenderer.sprite : replacementSprite;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!other.CompareTag(TagNames.Instance.Lighting))
			{
				return;
			}

			lightPosition = other.transform.position;
			enableShadow = true;
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.CompareTag(TagNames.Instance.Lighting))
			{
				enableShadow = false;
			}
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			if (!other.CompareTag(TagNames.Instance.Lighting))
			{
				return;
			}

			lightPosition = other.transform.position;
			enableShadow = true;
		}
	}
}