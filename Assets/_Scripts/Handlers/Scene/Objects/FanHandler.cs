using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene.Objects
{
	[RequireComponent(typeof(Animator))]
	public sealed class FanHandler : MonoBehaviour
	{
		private Animator _animator;
		private SimpleAnimation _simpleAnimation;

		[Range(1, 10)]
		public byte fanSpeed = 1;

		public bool randomizeFanSpeed;

		[Range(1, 10)]
		public byte maxRandomFanSpeed;

		private void Start()
		{
			_animator = GetComponent<Animator>();
			Assert.IsNotNull(_animator, "_animator is null");
			_simpleAnimation = GetComponent<SimpleAnimation>();

			SetFanSpeed((byte) (randomizeFanSpeed ? Random.Range(1, maxRandomFanSpeed) : fanSpeed));
		}

		public void SetFanSpeed(byte speed)
		{
			_animator.speed = speed;
		}

		public void ResetFanSpeed()
		{
			SetFanSpeed((byte) (randomizeFanSpeed ? Random.Range(1, maxRandomFanSpeed) : fanSpeed));
		}

		public void StopFan()
		{
			SetFanSpeed(0);
		}
	}
}