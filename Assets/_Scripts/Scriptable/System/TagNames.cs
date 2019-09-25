using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.System
{
	[CreateAssetMenu(fileName = "TagNames", menuName = "ScriptableObjects/System/Tag Names", order = 2)]
	public sealed class TagNames : SingletonScriptableObject<TagNames>
	{
		[SerializeField] private string player = "Player";
		[SerializeField] private string enemy = "Enemy";
		[SerializeField] private string items = "Items";
		[SerializeField] private string ui = "UI";
		[SerializeField] private string objects = "Objects";
		[SerializeField] private string barriers = "Barriers";
		[SerializeField] private string walls = "Walls";
		[SerializeField] private string floor = "Floor";
		[SerializeField] private string lighting = "Lighting";
		[SerializeField] private string npc = "NPC";

		internal string Player => player;
		internal string Enemy => enemy;
		internal string Items => items;
		internal string UI => ui;
		internal string Objects => objects;
		internal string Barriers => barriers;
		internal string Walls => walls;
		internal string Floor => floor;
		internal string Lighting => lighting;
		internal string NPC => npc;
	}
}
