using NUnit.Framework;
using UnityAtoms;
using UnityEngine;
using IntVariable = com.ArkAngelApps.TheAvarice.Scriptable.Variables.Int.IntVariable;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Achievements.Editor.Test
{
	[TestFixture]
	[Parallelizable(ParallelScope.Fixtures)]
	public sealed class PropertyTest
	{
		private Property _property;
		private IntVariable _intVariable;
		private FloatVariable _floatVariable;
		private BoolVariable _boolVariable;

		[OneTimeSetUp]
		public void SetUp()
		{
			_property = ScriptableObject.CreateInstance<Property>();
			_intVariable = ScriptableObject.CreateInstance<IntVariable>();
			_floatVariable = ScriptableObject.CreateInstance<FloatVariable>();
			_boolVariable = ScriptableObject.CreateInstance<BoolVariable>();
		}

		/// <summary>
		/// Setup for IntVariable using GreaterThanOrEqualTo
		/// </summary>
		private void IntSetup(int activationValue,
		                      int currentValue,
		                      Property.ActiveIf activeIf = Property.ActiveIf.GreaterThanOrEqualTo)
		{
			_property.variableType = VariableType.Int;
			_property.isActiveIf = activeIf;

			_intVariable.Value = currentValue;
			_property.intVariable = _intVariable;
			_property.intActivationValue = activationValue;
		}

		/// <summary>
		/// Setup for FloatVariable
		/// </summary>
		private void FloatSetup(float activationValue,
		                        float currentValue,
		                        Property.ActiveIf activeIf = Property.ActiveIf.GreaterThanOrEqualTo)
		{
			_property.variableType = VariableType.Float;
			_property.isActiveIf = activeIf;

			_floatVariable.Value = currentValue;
			_property.floatVariable = _floatVariable;
			_property.floatActivationValue = activationValue;
		}

		/// <summary>
		/// Setup for BoolVariable
		/// </summary>
		private void BoolSetup(bool activationValue,
		                       bool currentValue,
		                       Property.ActiveIf activeIf = Property.ActiveIf.EqualTo)
		{
			_property.variableType = VariableType.Bool;
			_property.isActiveIf = activeIf;

			_boolVariable.Value = currentValue;
			_property.boolVariable = _boolVariable;
			_property.boolActivationValue = activationValue;
		}

		[TestCase(10, 10)]
		public void IntHasReachedActivationValue(int activationValue, int currentValue)
		{
			IntSetup(activationValue, currentValue);
			Assert.IsTrue(_property.CheckValue());
		}

		[TestCase(10, 8)]
		public void IntHasNotReachedActivationValue(int activationValue, int currentValue)
		{
			IntSetup(activationValue, currentValue);
			Assert.IsFalse(_property.CheckValue());
		}

		[TestCase(10, 8)]
		public void IntHasReachedActivationValueWhenNotEqual(int activationValue, int currentValue)
		{
			IntSetup(activationValue, currentValue, Property.ActiveIf.NotEqualTo);
			Assert.IsTrue(_property.CheckValue());
		}

		[TestCase(10, 8)]
		public void IntHasReachedActivationValueWhenLessThan(int activationValue, int currentValue)
		{
			IntSetup(activationValue, currentValue, Property.ActiveIf.LessThan);
			Assert.IsTrue(_property.CheckValue());
		}

		[TestCase(10, 10)]
		[TestCase(10.1f, 12.5f)]
		public void FloatHasReachedActivationValue(float activationValue, float currentValue)
		{
			FloatSetup(activationValue, currentValue);
			Assert.IsTrue(_property.CheckValue());
		}

		[TestCase(10, 8)]
		[TestCase(10.1f, 10)]
		public void FloatHasNotReachedActivationValue(float activationValue, float currentValue)
		{
			FloatSetup(activationValue, currentValue);
			Assert.IsFalse(_property.CheckValue());
		}

		[TestCase(true, true)]
		public void BoolHasReachedActivationValueWhenEqual(bool activationValue, bool currentValue)
		{
			BoolSetup(activationValue, currentValue);
			Assert.IsTrue(_property.CheckValue());
		}

		[TestCase(true, false)]
		public void BoolHasReachedActivationValueWhenNotEqual(bool activationValue, bool currentValue)
		{
			BoolSetup(activationValue, currentValue, Property.ActiveIf.NotEqualTo);
			Assert.IsTrue(_property.CheckValue());
		}

		[TestCase(false, true)]
		public void BoolHasNotReachedActivationValue(bool activationValue, bool currentValue)
		{
			BoolSetup(activationValue, currentValue);
			Assert.IsFalse(_property.CheckValue());
		}
	}
}
