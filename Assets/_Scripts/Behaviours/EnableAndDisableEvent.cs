﻿using UnityEngine;
using UnityEngine.Events;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public sealed class EnableAndDisableEvent : MonoBehaviour
	{
		[SerializeField] private UnityEvent onEnable;
		[SerializeField] private UnityEvent onDisable;

		private void OnEnable()
		{
			onEnable.Invoke();
		}

		private void OnDisable()
		{
			onDisable.Invoke();
		}
	}
}
