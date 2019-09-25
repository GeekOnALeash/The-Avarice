using System;
using JetBrains.Annotations;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace com.ArkAngelApps.UtilityLibraries.Attributes
{
	/// <summary>
	///     Attribute used to show or hide the Field depending on certain conditions
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class ShowWhenAttribute : PropertyAttribute
	{
		public readonly object comparationValue;
		public readonly object[] comparationValueArray;
		public readonly string conditionFieldName;

		/// <summary>
		///     Attribute used to show or hide the Field depending on certain conditions
		/// </summary>
		/// <param name="_conditionFieldName_">Name of the bool condition Field</param>
		public ShowWhenAttribute(string _conditionFieldName_) => conditionFieldName = _conditionFieldName_;

		/// <summary>
		///     Attribute used to show or hide the Field depending on certain conditions
		/// </summary>
		/// <param name="_conditionFieldName_">Name of the Field to compare (bool, enum, int or float)</param>
		/// <param name="_comparationValue_">Value to compare</param>
		public ShowWhenAttribute(string _conditionFieldName_, object _comparationValue_ = null)
		{
			conditionFieldName = _conditionFieldName_;
			comparationValue = _comparationValue_;
		}

		/// <summary>
		///     Attribute used to show or hide the Field depending on certain conditions
		/// </summary>
		/// <param name="_conditionFieldName_">Name of the Field to compare (bool, enum, int or float)</param>
		/// <param name="_comparationValueArray_">Array of values to compare (only for enums)</param>
		[UsedImplicitly]
		public ShowWhenAttribute(string _conditionFieldName_, object[] _comparationValueArray_ = null)
		{
			conditionFieldName = _conditionFieldName_;
			comparationValueArray = _comparationValueArray_;
		}
	}
}