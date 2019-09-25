using System.Collections.Generic;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Dialogue
{
	[CreateAssetMenu(fileName = "NewDialogue", menuName = "ScriptableObjects/In-Game/Dialogue", order = 4)]
	public class DialogueData : ScriptableObject
	{
		public Queue<string> dialogueQueue;
	}
}