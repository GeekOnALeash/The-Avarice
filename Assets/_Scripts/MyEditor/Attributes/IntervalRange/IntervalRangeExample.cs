using System.Diagnostics.CodeAnalysis;
using Helpers;
using UnityEngine;

public class IntervalRangeExample : MonoBehaviour
{
	[Header("Unity Range")]
	[SerializeField]
	[Range(0, 10)]
	private float valueFloat0To10;

	[SerializeField]
	[Range(10, 0)]
	private float valueFloat10To0;

	[SerializeField]
	[Range(0, 0)]
	private float valueFloat0To0;

	[SerializeField]
	[Range(0, 10)]
	private int valueInt0To10;

	[SerializeField]
	[Range(0, 10)]
	private string valueString0To10;

	[Header("Custom Interval Range")]
	[SerializeField]
	[IntervalRangeAttribute(0, 10)]
	private float valueIntervalFloat0To10;

	[SerializeField]
	[IntervalRangeAttribute(10, 0)]
	private float valueIntervalFloat10To0;

	[SerializeField]
	[IntervalRangeAttribute(0, 0)]
	private float valueIntervalFloat0To0;

	[SerializeField]
	[IntervalRangeAttribute(0, 10, 3)]
	private float valueIntervalFloat0To10Interval3;

	[SerializeField]
	[IntervalRangeAttribute(0, 10, 0.5f)]
	private float valueIntervalFloat0To10IntervalHalf;

	[SerializeField]
	[IntervalRangeAttribute(10, 0, 1f/3f)]
	private float valueIntervalFloat10To0Interval1Third;

	[SerializeField]
	[IntervalRangeAttribute(10, 0, 1f/3f, precisionMethod:PrecisionMethod.Truncate)]
	private float valueIntervalFloat10To0Interval1ThirdTruncate;

	[SerializeField]
	[IntervalRangeAttribute(10, 0, 1f/3f, 10)]
	private float valueIntervalFloat10To0Interval1Third10Precision;

	[SerializeField]
	[IntervalRangeAttribute(0, 10, 0.1f)]
	private float valueIntervalFloat0To10Interval1Tenth;

	[SerializeField]
	[IntervalRangeAttribute(0, 10, 0.1f, 10)]
	private float valueIntervalFloat0To10Interval1Tenth10Precision;

	[SerializeField]
	[IntervalRangeAttribute(0, 10)]
	private int valueIntervalInt0To10;

	[SerializeField]
	[IntervalRangeAttribute(0, 10, 3)]
	private int valueIntervalInt0To10Interval3;

	[SerializeField]
	[IntervalRangeAttribute(0, 10, 0.5f)]
	private int valueIntervalInt0To10IntervalHalf;

	[SerializeField]
	[IntervalRangeAttribute(0, 10)]
	private string valueIntervalString0To10;

	[Header("Custom Interval Range With Variables References")]
	[SerializeField]
	private float min;

	[SerializeField]
	private int max;

	[SerializeField]
	private float interval;

	private string varForError;

	[SerializeField]
	[IntervalRangeAttribute("min", "max", "interval")]
	private float valueWithVariableReferences;

	[SerializeField]
	[IntervalRangeAttribute(5, "max", 3)]
	private int valueWithMaxVariableReferencesMin5Interval3;

	[SerializeField]
	[IntervalRangeAttribute("varForError", "max", "interval")]
	private float valueWithVariableReferencesErrorType;

	[SerializeField]
	[IntervalRangeAttribute(5, "min", "interval")]
	private int valueWithVariableReferencesErrorTypeForInt;

	[SuppressMessage("ReSharper", "HeapView.BoxingAllocation")]
	private void Start()
	{
		Debug.Log("<color=red>Note: Only for Editor changes.</color>");
		Debug.Log("If we modify the values internally, they don't respect the interval property");
		Debug.Log("Example ------>");
		Debug.Log("What we expect:");
		Debug.Log("5.9 , 5.899999 , 3");
		Debug.Log("The real values:");
		valueIntervalFloat0To10Interval1Tenth = 5.94f;
		valueIntervalFloat0To10Interval1Tenth10Precision = 5.94f;
		valueIntervalInt0To10Interval3 = 2;
		Debug.Log(valueIntervalFloat0To10Interval1Tenth + " , " + valueIntervalFloat0To10Interval1Tenth10Precision+ " , " + valueIntervalInt0To10Interval3);
		Debug.Log("You can use the extension methods to archive de same behaviour:");
		valueIntervalFloat0To10Interval1Tenth = 5.94f.AdjustIntervalAndPrecision(0.1f);
		valueIntervalFloat0To10Interval1Tenth10Precision = 5.94f.AdjustIntervalAndPrecision(0.1f, floatPrecision:10);
		valueIntervalInt0To10Interval3 = 2.NearestRound(3);
		Debug.Log(valueIntervalFloat0To10Interval1Tenth + " , " + valueIntervalFloat0To10Interval1Tenth10Precision+ " , " + valueIntervalInt0To10Interval3);
	}
}