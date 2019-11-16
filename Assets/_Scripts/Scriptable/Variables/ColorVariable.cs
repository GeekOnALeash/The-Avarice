using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Scriptable.Interfaces;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Variables
{
	[CreateAssetMenu(fileName = "NewColorVariable", menuName = "Scriptable/Variables/Color", order = 4)]
	public sealed class ColorVariable : GenericScriptableObject<Color>, IWithApplyChange<Color>
	{
		public bool ApplyChange(Color amount) => SetValue(amount);

		[SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
		protected override bool AreEqual(Color first, Color second) =>
			first.r == second.r && first.g == second.g && first.b == second.b && first.a == second.a;
	}
}
