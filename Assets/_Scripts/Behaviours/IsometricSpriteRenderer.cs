using System;
using System.Diagnostics.CodeAnalysis;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(SpriteRenderer))]
	public sealed class IsometricSpriteRenderer : BaseBehaviour
	{
		private const int IsometricRangePerYUnit = -10;
		private SpriteRenderer _spriteRenderer;

		[Tooltip("Will use this object to compute z-order")]
		public Transform target;

		[Tooltip("Use this to offset the object slightly in front or behind the Target object")]
		public int targetOffset;

		private float3 _position;
		private float3 _oldPosition;
		private float _sizeY;

		private void Start()
		{
			if (target == null)
			{
				target = transform;
			}

			_spriteRenderer = GetComponent<SpriteRenderer>();
			Assert.IsNotNull(_spriteRenderer, "_spriteRenderer is null");

			_sizeY = _spriteRenderer.bounds.size.y;
		}

		[SuppressMessage("ReSharper", "InvertIf")]
		private void LateUpdate()
		{
			_position = target.position;

			if (Math.Abs(_oldPosition.y - target.position.y) > 0.01f)
			{
				_spriteRenderer.sortingOrder = (int) ((_position.y - _sizeY / 2) * IsometricRangePerYUnit) + targetOffset;
				_oldPosition = _position;
			}
		}
	}
}