using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

namespace com.ArkAngelApps.TheAvarice.Handlers.System
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Animator))]
	public class AnimationHandler : MonoBehaviour
	{
		[Range(0, 60)]
		public int secondsBetweenIdles = 5;

		public bool displayRandomAnimations;

		[Tooltip("Total animations including blank/default")]
		[ShowWhen(nameof(displayRandomAnimations))]
		public int totalRandomAnimations;

		internal Animator animator;
		internal float timer;

		internal static readonly int _RandomID = Animator.StringToHash("RandomID");

		private void Awake()
		{
			animator = GetComponent<Animator>();
			Assert.IsNotNull(animator, "animator is null");

			timer = secondsBetweenIdles;
		}

		private void Start()
		{
			if (displayRandomAnimations)
			{
				DisplayRandomAnimation(totalRandomAnimations);
			}
		}

		[SuppressMessage("ReSharper", "InvertIf")]
		public virtual void Update()
		{
			timer -= Time.deltaTime;

			if (displayRandomAnimations && timer < 0)
			{
				DisplayRandomAnimation(totalRandomAnimations);
				timer = secondsBetweenIdles;
			}
		}

		protected void DisplayRandomAnimation(int randomAnimationAmount)
		{
			animator.SetInteger(_RandomID, Random.Range(1, randomAnimationAmount));
		}

		[SuppressMessage("ReSharper", "ConvertIfStatementToReturnStatement")]
		internal static bool IsIdlePlaying([NotNull] Animator animator)
		{
			if (animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
			{
				return true;
			}

			return false;
		}
	}
}
