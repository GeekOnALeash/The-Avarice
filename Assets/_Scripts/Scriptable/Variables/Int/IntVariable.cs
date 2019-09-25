using com.ArkAngelApps.TheAvarice.Scriptable.Interfaces;
using UnityAtoms;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Variables.Int
{
	[CreateAssetMenu(fileName = "NewIntValue", menuName = "ScriptableObjects/Variables/Int/Int", order = 1)]
	public class IntVariable : EquatableScriptableObjectVariable<int, IntEvent, IntIntEvent>, IWithApplyChange<int, IntEvent, IntIntEvent>
	{
		[SerializeField] protected int maxValue;

		public int MaxValue
		{
			get => maxValue;
			set => maxValue = value;
		}

		[SerializeField] protected IntEvent changed;

		public bool ApplyChange(int amount)
		{
			int total = Value + amount;

			if (total > MaxValue)
			{
				total = MaxValue;
			} else if (total < 0)
			{
				total = 0;
			}

			return SetValue(total);
		}

		public bool ApplyChange(EquatableScriptableObjectVariable<int, IntEvent, IntIntEvent> amount) => throw new NotImplementedException();

		protected override bool AreEqual(int first, int second) => first == second;
	}
}