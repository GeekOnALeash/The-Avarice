using UnityEngine;

// ReSharper disable CheckNamespace
namespace com.ArkAngelApps.UtilityLibraries.Extensions
{
	internal static class FloatExtensions
	{
		/// <summary>
		///     Determines if a float is an Integer
		/// </summary>
		/// <param name="val">Float to test</param>
		/// <returns>True if float is a whole number</returns>
		public static bool IsAnInteger(this float val) => Mathf.Approximately(val - Mathf.Round(val), 0);

		public static bool IsDivisibleBy(this float a, float b) => IsAnInteger(a / b);

		public static bool IsEqual(this float a, float b) => a >= b - Mathf.Epsilon && a <= b + Mathf.Epsilon;
	}
}