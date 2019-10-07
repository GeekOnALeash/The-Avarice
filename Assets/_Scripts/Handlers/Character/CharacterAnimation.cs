using System;
using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using com.ArkAngelApps.TheAvarice.SimpleSpriteAnimator;
using com.ArkAngelApps.UtilityLibraries.Extensions;
using JetBrains.Annotations;
using UnityAtoms;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(Animator))]
	public class CharacterAnimation : MonoBehaviour
	{
		[SerializeField] private Vector2Variable moveAxis;

		[SerializeField] private CharacterAnimations characterAnimations;

		private SpriteAnimation _currentAnim;
		private SpriteRenderer _spriteRenderer;
		private Animator _animator;

		private int _frameID;
		private int _lastFrameID;
		private static readonly int __Horizontal = Animator.StringToHash("horizontal");
		private static readonly int __Vertical = Animator.StringToHash("vertical");

		public enum Direction
		{
			Idle,
			Left,
			Right,
			Up,
			Down
		}

		private void Start()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_animator = GetComponent<Animator>();
		}

		private void LateUpdate()
		{
			_animator.SetFloat(__Horizontal, moveAxis.Value.x);
			_animator.SetFloat(__Vertical, moveAxis.Value.y);
		}

		[UsedImplicitly]
		public void SetAnimation(Direction direction)
		{
			_frameID = 0;

			switch (direction)
			{
				case Direction.Idle:
					_currentAnim = characterAnimations.idle.RandomItem();
					break;
				case Direction.Left:
					_currentAnim = characterAnimations.walkLeft;
					break;
				case Direction.Right:
					_currentAnim = characterAnimations.walkRight;
					break;
				case Direction.Up:
					_currentAnim = characterAnimations.walkUp;
					break;
				case Direction.Down:
					_currentAnim = characterAnimations.walkDown;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
			}

			_lastFrameID = _currentAnim.Frames.Count - 1;
		}

		[UsedImplicitly]
		public void GetNextFrame()
		{
			_frameID += 1;

			if (_frameID > _lastFrameID)
			{
				return;
			}

			SetAnimationFrameToRenderer(_frameID);
		}

		public void SetAnimationFrameToRenderer(int id)
		{
			if (_currentAnim == null)
			{
				Debug.Log($"{nameof(_currentAnim)} needs to be set within animation event before calling for frame.");
				return;
			}

			if (_currentAnim.Frames.Count < id)
			{
				Debug.Log($"{nameof(id)} is out of range for animation frame.");
				return;
			}

			_spriteRenderer.sprite = _currentAnim.Frames[id].Sprite;
		}
	}
}