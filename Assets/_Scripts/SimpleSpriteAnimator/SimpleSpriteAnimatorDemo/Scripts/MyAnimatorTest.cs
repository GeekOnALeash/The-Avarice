using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.SimpleSpriteAnimator.SimpleSpriteAnimatorDemo
{
	public sealed class MyAnimatorTest : MonoBehaviour
	{
		private SpriteAnimator _spriteAnimator;

		private void Start()
		{
			_spriteAnimator = GetComponent<SpriteAnimator>();
		}

		private void Update()
		{
			if (Input.GetKey(KeyCode.Q))
			{
				_spriteAnimator.Play("WalkRight");
			}
		}
	}
}