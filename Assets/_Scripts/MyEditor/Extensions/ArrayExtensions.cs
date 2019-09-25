using JetBrains.Annotations;
using UnityEngine;

// ReSharper disable CheckNamespace
namespace com.ArkAngelApps.UtilityLibraries.Extensions
{
	internal static class ArrayExtensions
	{
		/// <summary>
		///     Returns a random element from an array of any type
		/// </summary>
		/// <returns>Element from the array picked at random.</returns>
		internal static T RandomItem<T>([CanBeNull] this T[] array)
		{
			if (array == null || array.Length <= 0)
			{
				return default;
			}

			return array.Length == 1 ? array[0] : array[Random.Range(0, array.Length)];
		}
	}
}