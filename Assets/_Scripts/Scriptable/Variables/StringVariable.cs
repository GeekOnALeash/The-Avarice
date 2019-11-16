using System;
using com.ArkAngelApps.TheAvarice.Scriptable.Interfaces;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Variables
{
    [CreateAssetMenu(fileName = "NewStringValue", menuName = "Scriptable/Variables/String", order = 3)]
    public sealed class StringVariable : GenericScriptableObject<string>, IWithApplyChange<string>
    {
        public bool ApplyChange(string amount) => SetValue(amount);

        protected override bool AreEqual(string first, string second) =>
            string.Compare(first, second, StringComparison.Ordinal) == 0;
    }
}