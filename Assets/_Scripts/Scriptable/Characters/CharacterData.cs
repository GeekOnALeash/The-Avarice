using System;
using com.ArkAngelApps.TheAvarice.Composites;
using com.ArkAngelApps.TheAvarice.Scriptable.Variables.Int;
using EasyButtons;
using UnityEngine;
using Random = System.Random;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Characters
{
	[CreateAssetMenu(fileName = "NewCharacter", menuName = "Scriptable/Character/Data", order = 1)]
	public sealed class CharacterData : ScriptableObject, ISerializationCallbackReceiver
	{
		[TextArea(10, 40)] public string description;
		public new string name;
		public Sprite image;

		[SerializeField] private SpriteBase spriteBase;

		public enum ObjectType
		{
			Player,
			EnemyNPC,
			FriendlyNPC
		}

		public string characterName;
		public ObjectType characterType;

		[Header("Stats")]
		public IntVariable healthPoints;

		public int maximumHealthPoints;
		[NonSerialized] public int runtime_maximumHealthPoints;

		public int shieldPoints;
		[NonSerialized] public int runtime_shieldPoints;

		public int armourPoints;
		[NonSerialized] public int runtime_armourPoints;

		public int attackPoints;
		[NonSerialized] public int runtime_attackPoints;

		[Header("UI Styling")] [Tooltip("Generally taken from light eye color shade of sprite")]
		public Color uiTextColor;

		[Tooltip("Generally taken from light hair color shade of sprite")]
		public Color uiBorderColor;

		private void Awake()
		{
			GenerateName();
		}

		public void OnAfterDeserialize()
		{
			runtime_maximumHealthPoints = maximumHealthPoints;
			runtime_shieldPoints = shieldPoints;
			runtime_armourPoints = armourPoints;
			runtime_attackPoints = attackPoints;
		}

		public void OnBeforeSerialize() { }

		[Button]
		public void GenerateMaleName()
		{
			GenerateName();
		}

		[Button]
		public void GenerateFemaleName()
		{
			GenerateName(Gender.Female);
		}

		public void GenerateName(Gender sex = Gender.Male)
		{
			Random rand = new Random(DateTime.Now.Second);
			RandomName nameGen = new RandomName(rand);

			name = nameGen.Generate(sex);
		}
	}
}