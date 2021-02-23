using UnityAtoms;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	[RequireComponent(typeof(Animator))]
	[DisallowMultipleComponent]
	public class CharacterAnimation : MonoBehaviour
	{
		[SerializeField] private Vector2Variable moveAxis;
		[SerializeField] private int totalIdleAnims;

		private Animator _animator;
		private bool _switchIdle;

		private static readonly int __PosY = Animator.StringToHash("posY");
		private static readonly int __PosX = Animator.StringToHash("posX");
		private static readonly int __IdleID = Animator.StringToHash("idleID");

		private void Start()
		{
			_animator = GetComponent<Animator>();
			Assert.IsNotNull(_animator);
		}

		[SerializeField] private float timeBetweenIdles = 10.0f;

		void Update()
		{
			timeBetweenIdles -= Time.deltaTime;
			if (timeBetweenIdles < 0)
			{
				_switchIdle = true;
			}
		}

		private void FixedUpdate()
		{
			_animator.SetInteger(__PosY, (int) moveAxis.Value.y);
			_animator.SetInteger(__PosX, (int) moveAxis.Value.x);

			if (moveAxis.Value.x != 0 || moveAxis.Value.y != 0 || !_switchIdle)
			{
				return;
			}

			_switchIdle = false;
			_animator.SetInteger(__IdleID, Random.Range(0, totalIdleAnims));
		}
	}
}