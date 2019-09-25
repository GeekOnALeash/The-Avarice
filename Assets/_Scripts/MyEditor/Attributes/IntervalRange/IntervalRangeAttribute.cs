// DONT PUT IN EDITOR FOLDER

using System;
using UnityEngine;

/// <summary>
///   <para>Attribute used to make a float or int variable in a script be restricted to a specific range with a interval change</para>
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public sealed class IntervalRangeAttribute : PropertyAttribute
{
	public readonly float min;
	public readonly string minString;
	public readonly float max;
	public readonly string maxString;
	public readonly float interval;
	public readonly string intervalString;
	public readonly float floatPrecision;
	public readonly PrecisionMethod precisionMethod;

	/// <summary>
	///   <para>Attribute used to make a float or int variable in a script be restricted to a specific range.</para>
	/// </summary>
	/// <param name="min">The minimum allowed value.</param>
	/// <param name="max">The maximum allowed value.</param>
	/// <param name="interval">The interval between two successive values.</param>
	/// <param name="floatPrecision">Number of decimals.</param>
	/// <param name="precisionMethod">Choose between round or truncate.</param>
	public IntervalRangeAttribute(float min, float max, float interval = 0, int floatPrecision = 2, PrecisionMethod precisionMethod = PrecisionMethod.Round)
	{
		this.min = min;
		this.max = max;
		this.interval = interval;
		this.floatPrecision = floatPrecision;
		this.precisionMethod = precisionMethod;
	}

	/// <summary>
	///   <para>Attribute used to make a float or int variable in a script be restricted to a specific range.</para>
	/// </summary>
	/// <param name="minString">The minimum allowed value.</param>
	/// <param name="max">The maximum allowed value.</param>
	/// <param name="interval">The interval between two successive values.</param>
	/// <param name="floatPrecision">Number of decimals.</param>
	/// <param name="precisionMethod">Choose between round or truncate.</param>
	public IntervalRangeAttribute(string minString, float max, float interval = 0, int floatPrecision = 2, PrecisionMethod precisionMethod = PrecisionMethod.Round)
	: this (0, max, interval, floatPrecision, precisionMethod)
	{
		this.minString = minString;
	}

	/// <summary>
	///   <para>Attribute used to make a float or int variable in a script be restricted to a specific range.</para>
	/// </summary>
	/// <param name="min">The minimum allowed value.</param>
	/// <param name="maxString">The maximum allowed value.</param>
	/// <param name="interval">The interval between two successive values.</param>
	/// <param name="floatPrecision">Number of decimals.</param>
	/// <param name="precisionMethod">Choose between round or truncate.</param>
	public IntervalRangeAttribute(float min, string maxString, float interval = 0, int floatPrecision = 2, PrecisionMethod precisionMethod = PrecisionMethod.Round)
		: this (min, 0, interval, floatPrecision, precisionMethod)
	{
		this.maxString = maxString;
	}

	/// <summary>
	///   <para>Attribute used to make a float or int variable in a script be restricted to a specific range.</para>
	/// </summary>
	/// <param name="min">The minimum allowed value.</param>
	/// <param name="max">The maximum allowed value.</param>
	/// <param name="intervalString">The interval between two successive values.</param>
	/// <param name="floatPrecision">Number of decimals.</param>
	/// <param name="precisionMethod">Choose between round or truncate.</param>
	public IntervalRangeAttribute(float min, float max, string intervalString, int floatPrecision = 2, PrecisionMethod precisionMethod = PrecisionMethod.Round)
		: this (min, max, 0, floatPrecision, precisionMethod)
	{
		this.intervalString = intervalString;
	}

	/// <summary>
	///   <para>Attribute used to make a float or int variable in a script be restricted to a specific range.</para>
	/// </summary>
	/// <param name="minString">The minimum allowed value.</param>
	/// <param name="maxString">The maximum allowed value.</param>
	/// <param name="interval">The interval between two successive values.</param>
	/// <param name="floatPrecision">Number of decimals.</param>
	/// <param name="precisionMethod">Choose between round or truncate.</param>
	public IntervalRangeAttribute(string minString, string maxString, float interval = 0, int floatPrecision = 2, PrecisionMethod precisionMethod = PrecisionMethod.Round)
		: this (0, 0, interval, floatPrecision, precisionMethod)
	{
		this.minString = minString;
		this.maxString = maxString;
	}

	/// <summary>
	///   <para>Attribute used to make a float or int variable in a script be restricted to a specific range.</para>
	/// </summary>
	/// <param name="min">The minimum allowed value.</param>
	/// <param name="maxString">The maximum allowed value.</param>
	/// <param name="intervalString">The interval between two successive values.</param>
	/// <param name="floatPrecision">Number of decimals.</param>
	/// <param name="precisionMethod">Choose between round or truncate.</param>
	public IntervalRangeAttribute(float min, string maxString, string intervalString, int floatPrecision = 2, PrecisionMethod precisionMethod = PrecisionMethod.Round)
		: this (min, 0, 0, floatPrecision, precisionMethod)
	{
		this.maxString = maxString;
		this.intervalString = intervalString;
	}

	/// <summary>
	///   <para>Attribute used to make a float or int variable in a script be restricted to a specific range.</para>
	/// </summary>
	/// <param name="minString">The minimum allowed value.</param>
	/// <param name="max">The maximum allowed value.</param>
	/// <param name="intervalString">The interval between two successive values.</param>
	/// <param name="floatPrecision">Number of decimals.</param>
	/// <param name="precisionMethod">Choose between round or truncate.</param>
	public IntervalRangeAttribute(string minString, float max, string intervalString, int floatPrecision = 2, PrecisionMethod precisionMethod = PrecisionMethod.Round)
		: this (0, max, 0, floatPrecision, precisionMethod)
	{
		this.minString = minString;
		this.intervalString = intervalString;
	}

	/// <summary>
	///   <para>Attribute used to make a float or int variable in a script be restricted to a specific range.</para>
	/// </summary>
	/// <param name="minString">The minimum allowed value.</param>
	/// <param name="maxString">The maximum allowed value.</param>
	/// <param name="intervalString">The interval between two successive values.</param>
	/// <param name="floatPrecision">Number of decimals.</param>
	/// <param name="precisionMethod">Choose between round or truncate.</param>
	public IntervalRangeAttribute(string minString, string maxString, string intervalString, int floatPrecision = 2, PrecisionMethod precisionMethod = PrecisionMethod.Round)
		: this (0, 0, 0, floatPrecision, precisionMethod)
	{
		this.minString = minString;
		this.maxString = maxString;
		this.intervalString = intervalString;
	}

}