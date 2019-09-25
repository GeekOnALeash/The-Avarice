using System;
using com.ArkAngelApps.TheAvarice.Scriptable.Interfaces;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Variables
{
	[CreateAssetMenu(fileName = "NewFloatValue", menuName = "ScriptableObjects/Variables/Float", order = 2)]
	public sealed class MyFloatVariable : GenericScriptableObject<float>, IWithApplyChange<float>
	{
		public bool ApplyChange(float amount) => SetValue(RuntimeValue + amount);

		protected override bool AreEqual(float first, float second) => Math.Abs(first - second) < 0.01;
	}
}