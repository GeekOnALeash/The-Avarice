using UnityAtoms;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Variables.Int
{
	[CreateAssetMenu(fileName = "NewIntValue", menuName = "Scriptable/Variables/Int/Int", order = 1)]
	public class IntVariable : EquatableAtomVariable<int, IntEvent, IntIntEvent>, IWithApplyChange<int, IntEvent, IntIntEvent>
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

		public bool ApplyChange(EquatableAtomVariable<int, IntEvent, IntIntEvent> amount) => throw new NotImplementedException();
	}
}