using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	[DisallowMultipleComponent]
	public sealed class Experience : MonoBehaviour
	{
		public SkillData skillData;

		/// <summary>
		/// Sets the value of the chosen SkillType
		/// </summary>
		/// <param name="skill">SkillType to be changed</param>
		/// <param name="value">value to be set</param>
		internal void SetSkillValue(SkillTypes skill, int value)
		{
			skillData.SetValue(skill, value);
		}

		/// <summary>
		/// Get the value of the specified SkillType.
		/// </summary>
		/// <param name="skill">SkillType to get the value of.</param>
		/// <returns>Returns an int for the value of the SkillType</returns>
		internal int GetSkillValue(SkillTypes skill) => skillData.GetValue(skill);

		/// <summary>
		/// Apply a value to the skill.
		/// </summary>
		/// <param name="skill">SkillType to apply the value.</param>
		/// <param name="value">Value to add/deduct to/from SkillType, for instance -1 will reduce the SkillType by 1</param>
		public void ApplyChange(SkillTypes skill, int value)
		{
			skillData.SetValue(skill, skillData.GetValue(skill) + value);
		}
	}
}