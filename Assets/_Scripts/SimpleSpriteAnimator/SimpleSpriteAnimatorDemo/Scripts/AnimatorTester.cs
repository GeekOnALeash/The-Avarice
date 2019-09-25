using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.SimpleSpriteAnimator.SimpleSpriteAnimatorDemo
{
	public sealed class AnimatorTester : MonoBehaviour
	{
		private SpriteAnimator _spriteAnimator;

		private void Start()
		{
			_spriteAnimator = GetComponent<SpriteAnimator>();
		}

		private void OnGUI()
		{
			if (GUI.Button(new Rect(10, 10, 150, 30), "Play Walk Animation"))
			{
				_spriteAnimator.Play("Walk");
			}

			if (GUI.Button(new Rect(10, 50, 150, 30), "Play Climb Animation"))
			{
				_spriteAnimator.Play("Climb");
			}
		}
	}
}