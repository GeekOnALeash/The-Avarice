using System;
using JetBrains.Annotations;
using Random = UnityEngine.Random;

// ReSharper disable CheckNamespace
namespace com.ArkAngelApps.UtilityLibraries.Extensions
{
	public static class EnumExtensions
	{
		/// <summary>
		///     Returns a random value from an Enum
		/// </summary>
		/// <returns>Value from enum.</returns>
		[UsedImplicitly]
		public static T RandomItem<T>(this T _enum_) where T : IConvertible
		{
			var enumValues = Enum.GetValues(typeof(T));
			return (T) enumValues.GetValue(Random.Range(0, enumValues.Length));
		}
	}
}