using System.Collections.Generic;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Dialogue
{
	[CreateAssetMenu(fileName = "NewDialogue", menuName = "Scriptable/Character/Dialogue", order = 4)]
	public class DialogueData : ScriptableObject
	{
		public Queue<string> dialogueQueue;
	}
}