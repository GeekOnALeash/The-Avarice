using System;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityAtoms;
using UnityEngine;
using IntVariable = com.ArkAngelApps.TheAvarice.Scriptable.Variables.Int.IntVariable;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Achievements
{
	public enum VariableType
	{
		Bool,
		Int,
		Float,
	}

	[CreateAssetMenu(fileName = "NewProperty", menuName = "Scriptable/Achievements/Prototype", order = 1)]
	public sealed class Property : ScriptableObject
	{
		public enum ActiveIf
		{
			GreaterThan,
			LessThan,
			GreaterThanOrEqualTo,
			LessThanOrEqualTo,
			EqualTo,
			NotEqualTo
		}

		public VariableType variableType;

		[ShowWhen(nameof(variableType), VariableType.Bool)]
		public BoolVariable boolVariable;

		[ShowWhen(nameof(variableType), VariableType.Bool)]
		public bool boolActivationValue;

		[ShowWhen(nameof(variableType), VariableType.Int)]
		public IntVariable intVariable;

		[ShowWhen(nameof(variableType), VariableType.Int)]
		public int intActivationValue;

		[ShowWhen(nameof(variableType), VariableType.Float)]
		public FloatVariable floatVariable;

		[ShowWhen(nameof(variableType), VariableType.Float)]
		public float floatActivationValue;

		public ActiveIf isActiveIf;

		public bool CheckValue()
		{
			bool aRet;
			float value;
			float activationValue;

			switch (variableType)
			{
				case VariableType.Float:
					value = floatVariable.Value;
					activationValue = floatActivationValue;
					break;
				case VariableType.Int:
					value = intVariable.Value;
					activationValue = intActivationValue;
					break;
				case VariableType.Bool:
					// ReSharper disable once ConvertIfStatementToSwitchStatement
					if (isActiveIf == ActiveIf.EqualTo)
					{
						return boolVariable.Value == boolActivationValue;
					} else if (isActiveIf == ActiveIf.NotEqualTo)
					{
						return boolVariable.Value != boolActivationValue;
					}

					throw new Exception("Bool must have equal or not equal activation value");
				default:
					throw new ArgumentOutOfRangeException();
			}

			// ReSharper disable once ConvertSwitchStatementToSwitchExpression
			switch (isActiveIf)
			{
				case ActiveIf.GreaterThan:
					aRet = value > activationValue;
					break;
				case ActiveIf.LessThan:
					aRet = value < activationValue;
					break;
				case ActiveIf.EqualTo:
					aRet = Math.Abs(value - activationValue) < 0.01;
					break;
				case ActiveIf.NotEqualTo:
					aRet = Math.Abs(value - activationValue) > 0.01;
					break;
				case ActiveIf.GreaterThanOrEqualTo:
					aRet = value >= activationValue;
					break;
				case ActiveIf.LessThanOrEqualTo:
					aRet = value <= activationValue;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			return aRet;
		}
	}
}