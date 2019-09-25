using com.ArkAngelApps.TheAvarice.Scriptable.Events;
using UnityEditor;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice._Scripts.Editor
{
	[CustomEditor(typeof(GameEvent))]
	public sealed class EventEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			GUI.enabled = Application.isPlaying;

			GameEvent e = target as GameEvent;

			if (GUILayout.Button("Raise"))
			{
				e.Raise();
			}
		}
	}
}