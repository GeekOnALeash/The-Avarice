// ----------------------------------------------------------------------------
// Author: Richard Fine
// Source: https://bitbucket.org/richardfine/scriptableobjectdemo
// ----------------------------------------------------------------------------

using System;
using UnityEngine;

namespace MyBox
{
	public sealed class MinMaxRangeAttribute : Attribute
	{
		public MinMaxRangeAttribute(float min, float max)
		{
			Min = min;
			Max = max;
		}

		public readonly float Min;
		public readonly float Max;
	}

	[Serializable]
	public struct RangedFloat
	{
		public float Min;
		public float Max;
	}

	[Serializable]
	public struct RangedInt
	{
		public int Min;
		public int Max;
	}

	public static class RangedExtensions
	{
		public static float LerpFromRange(this RangedFloat ranged, float t)
		{
			return Mathf.Lerp(ranged.Min, ranged.Max, t);
		}

		public static float LerpFromRangeUnclamped(this RangedFloat ranged, float t)
		{
			return Mathf.LerpUnclamped(ranged.Min, ranged.Max, t);
		}

		public static float LerpFromRange(this RangedInt ranged, float t)
		{
			return Mathf.Lerp(ranged.Min, ranged.Max, t);
		}

		public static float LerpFromRangeUnclamped(this RangedInt ranged, float t)
		{
			return Mathf.LerpUnclamped(ranged.Min, ranged.Max, t);
		}
	}
}