using System;
using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Rendering;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	[ExecuteInEditMode]
	public sealed class IsometricSpriteRenderer : BaseBehaviour
	{
		private const int IsometricRangePerYUnit = -10;
		public bool usesSortingGroup = true;

		[SerializeField]
		private SpriteRenderer spriteRenderer;

		[ShowWhen(nameof(usesSortingGroup), true)]
		[SerializeField]
		private SortingGroup sortingGroup;

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

			Assert.IsNotNull(spriteRenderer, "spriteRenderer != null");

			_sizeY = spriteRenderer.bounds.size.y;
		}

		[SuppressMessage("ReSharper", "InvertIf")]
		private void LateUpdate()
		{
			_position = target.position;

			if (Math.Abs(_oldPosition.y - target.position.y) > 0.01f)
			{
				int sortingOrder = (int) ((_position.y - _sizeY / 2) * IsometricRangePerYUnit) + targetOffset;

				if (usesSortingGroup)
				{
					sortingGroup.sortingOrder = sortingOrder;
				} else
				{
					spriteRenderer.sortingOrder = sortingOrder;
				}

				_oldPosition = _position;
			}
		}
	}
}