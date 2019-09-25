using System.Collections.Generic;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene
{
	public sealed class LightGroupHandler : MonoBehaviour
	{
		[ReadOnly]
		public List<LightHandler> lightsInGroup;

		private void Start()
		{
			enabled = false;
		}

		private void OnTriggerEnter2D([NotNull] Collider2D other)
		{
			if (!other.CompareTag(SystemVariables.Instance.tagNames.Player))
			{
				return;
			}

			EnableLightsInGroup(true);
		}

		private void OnTriggerExit2D([NotNull] Collider2D other)
		{
			if (!other.CompareTag(SystemVariables.Instance.tagNames.Player))
			{
				return;
			}
			
			EnableLightsInGroup(false);
		}

		private void EnableLightsInGroup(bool turnOn)
		{
			foreach (var lightHandler in lightsInGroup)
			{
				lightHandler.lightObject.enabled = turnOn;
			}
			
			enabled = turnOn;
		}
	}
}