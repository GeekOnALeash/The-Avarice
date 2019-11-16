using System;
using com.ArkAngelApps.TheAvarice.Handlers.Scene;
using com.ArkAngelApps.TheAvarice.Scriptable.Events;
using com.ArkAngelApps.TheAvarice.Scriptable.Prefs;
using com.ArkAngelApps.TheAvarice.Scriptable.UI;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.System
{
	[CreateAssetMenu(fileName = "_SystemVariables", menuName = "Scriptable/System/SystemVariables", order = 1)]
	public sealed class SystemVariables : SingletonScriptableObject<SystemVariables>
	{
		public KeybindingsData keybinds;
		public MouseCursorData cursors;
		public TagNames tagNames;
		internal CameraHandler mainCamera;

		[Serializable]
		public struct Settings
		{
			[Serializable]
			public struct UI
			{
				public GameEvent showFPSEvent;
			}

			public UI ui;

			[Serializable]
			public struct Debug
			{
				public bool debug;
			}

			public Debug debug;
		}

		public Settings settings;
	}
}