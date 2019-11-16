// Tooltip descriptions taken from: https://en.wikipedia.org/wiki/Attribute_(role-playing_games)

using com.ArkAngelApps.MyDebug.Exceptions;
using com.ArkAngelApps.TheAvarice.Scriptable.Variables.Int;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Characters
{
	public enum SkillTypes
	{
		Strength,
		Stamina,
		Fortitude,
		Dexterity,
		Intelligence,
		Charisma,
		Wisdom,
		Willpower,
		Perception,
		Luck
	}

	[CreateAssetMenu(fileName = "NewItem", menuName = "Scriptable/Character/Skills", order = 3)]
	public sealed class SkillData : ScriptableObject
	{
		/// <summary>
		/// IntVariable for strength SkillType
		/// </summary>
		[Tooltip("A measure of how physically strong a character is. Strength often controls the maximum weight the character can carry, melee attack and/or damage, and sometimes hit points. Armor and weapons might also have a Strength requirement.")]
		public IntVariable strength;

		/// <summary>
		/// IntVariable for stamina SkillType
		/// </summary>
		[Tooltip("A measure of how sturdy a character is. Constitution often influences hit points, resistances for special types of damage (poisons, illness, heat etc.) and fatigue.")]
		public IntVariable stamina;

		/// <summary>
		/// IntVariable for fortitude SkillType
		/// </summary>
		[Tooltip("A measure of how resilient a character is. Defense usually decreases taken damage by either a percentage or a fixed amount per hit. Occasionally combined with Constitution.")]
		public IntVariable fortitude;

		/// <summary>
		/// IntVariable for dexterity SkillType
		/// </summary>
		[Tooltip("A measure of how agile a character is. Dexterity controls attack and movement speed and accuracy, as well as evading an opponent's attack.")]
		public IntVariable dexterity;

		/// <summary>
		/// IntVariable for intelligence SkillType
		/// </summary>
		[Tooltip("A measure of a character's problem-solving ability. Intelligence often controls a character's ability to comprehend foreign languages and their skill in magic. In some cases, intelligence controls how many skill points the character gets at  'level up'. In some games, it controls the rate at which experience points are earned, or the amount needed to level up. Under certain circumstances, this skill can also negate combat actions between players and NPC enemies. This is sometimes combined with wisdom and/or willpower.")]
		public IntVariable intelligence;

		/// <summary>
		/// IntVariable for charisma SkillType
		/// </summary>
		[Tooltip("A measure of a character's social skills, and sometimes their physical appearance. Charisma generally influences prices while trading and NPC reactions. Under certain circumstances, this skill can negate combat actions between players and NPC enemies.")]
		public IntVariable charisma;

		/// <summary>
		/// IntVariable for wisdom SkillType
		/// </summary>
		[Tooltip("A measure of a character's common sense and/or spirituality. Wisdom often controls a character's ability to cast certain spells, communicate to mystical entities, or discern other characters' motives or feelings.")]
		public IntVariable wisdom;

		/// <summary>
		/// IntVariable for willpower SkillType
		/// </summary>
		[Tooltip("A measure of the character's mental resistance (against pain, fear etc.) when falling victim to mind-altering magic, torture, or insanity. Many games combine willpower and wisdom.")]
		public IntVariable willpower;

		/// <summary>
		/// IntVariable for perception SkillType
		/// </summary>
		[Tooltip("A measure of a character's openness to their surroundings. Perception controls the chance to detect vital clues, traps or hiding enemies, and might influence combat sequence or the accuracy of ranged attacks. Perception-type attributes are more common in more modern games. Note that this skill is usually understood only to apply to what a character can perceive with their established senses (i.e. sight, sound, smell, etc), and does not usually include extrasensory perception or other forms of mental telepathy or telekinesis in the given game unless the character's specific attributes expressly include such abilities (such as the Force in Star Wars). Sometimes combined with wisdom.")]
		public IntVariable perception;

		/// <summary>
		/// IntVariable for luck SkillType
		/// </summary>
		[Tooltip("A measure of a character's luck. Luck might influence anything, but mostly random items, encounters and outstanding successes/failures (such as critical hits).")]
		public IntVariable luck;

		/// <summary>
		/// Get InVariable ScriptableObject for the SkillType
		/// </summary>
		/// <param name="skillType">SkillType to get IntVariable of</param>
		/// <returns>Returns an IntVariable for specified SkillType</returns>
		/// <exception cref="UnexpectedEnumValueException">Throws an Exception if there is an Unexpected Enum for SkillType</exception>
		private IntVariable GetIntVariableForSkillType(SkillTypes skillType)
		{
			switch (skillType)
			{
				case SkillTypes.Charisma:
					return charisma;
				case SkillTypes.Dexterity:
					return dexterity;
				case SkillTypes.Strength:
					return strength;
				case SkillTypes.Stamina:
					return stamina;
				case SkillTypes.Fortitude:
					return fortitude;
				case SkillTypes.Intelligence:
					return intelligence;
				case SkillTypes.Wisdom:
					return wisdom;
				case SkillTypes.Willpower:
					return willpower;
				case SkillTypes.Perception:
					return perception;
				case SkillTypes.Luck:
					return luck;
				default:
					// ReSharper disable once HeapView.ObjectAllocation.Evident
					// ReSharper disable once HeapView.BoxingAllocation
					// Disabled ReSharper inspections as this branch is never intended to be reached
					throw new UnexpectedEnumValueException(skillType);
			}
		}

		/// <summary>
		/// Get the value for the SkillType
		/// </summary>
		/// <param name="skill">SkillType to get the value of</param>
		/// <returns>Returns an int for the specified SkillType</returns>
		internal int GetValue(SkillTypes skill) => GetIntVariableForSkillType(skill).Value;

		/// <summary>
		/// Set the value for the SkillType
		/// </summary>
		/// <param name="skill">SkillType to set the value of</param>
		/// <param name="value">Sets an int to the specified SkillType</param>
		internal void SetValue(SkillTypes skill, int value) => GetIntVariableForSkillType(skill).SetValue(value);
	}
}