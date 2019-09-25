using System;

namespace Helpers
{
	public static class FloatHelper
	{
		/// <summary>
		/// Convert the number to the nearest value of a given multiple.
		/// Function from StackOverflow response <see href="https://stackoverflow.com/a/34444056">HERE</see>
		/// </summary>
		/// <param name="number">Number to convert</param>
		/// <param name="multiple">Multiple for intervals</param>
		/// <param name="min">Min number to avoid wrong numbers</param>
		/// <param name="max">Max number to avoid wrong numbers</param>
		public static float NearestRound(this float number, float multiple, float? min = null, float? max = null)
		{
			float val = number;
			
			if (multiple == 0)
				return val;
			
			if (multiple < 1)
			{
				float i = (float) Math.Floor(number);
				float x2 = i;
				while ((x2 += multiple) < number){}
				float x1 = x2 - multiple;
				val = (Math.Abs(number - x1) < Math.Abs(number - x2)) ? x1 : x2;
			}
			else
			{
				val = (float) Math.Round(number / multiple, MidpointRounding.AwayFromZero) * multiple;
			}

			if (min != null && val < min)
				val += multiple;
			else if (max != null && val > max)
				val -= multiple;
			
			return val;
		}

		/// <summary>
		/// Convert the number to the nearest value of a given multiple adjusting the return precision
		/// </summary>
		/// <param name="number">Number to convert</param>
		/// <param name="min">Min number to avoid wrong numbers</param>
		/// <param name="max">Max number to avoid wrong numbers</param>
		/// <param name="multiple">Multiple for intervals</param>
		/// <param name="floatPrecision">Number of decimals</param>
		/// <param name="precisionMethod">Method to round the float</param>
		public static float AdjustIntervalAndPrecision(this float number, float multiple, float? min = null, float? max = null, float floatPrecision = 2,
			PrecisionMethod precisionMethod = PrecisionMethod.Round)
		{
			float val = number.NearestRound(multiple, min, max);
			double mult = Math.Pow(10, floatPrecision);
			if (precisionMethod == PrecisionMethod.Round)
				val = (float) (Math.Round(mult * val) / mult);
			else if (precisionMethod == PrecisionMethod.Truncate)
				val = (float) (Math.Truncate(mult * val) / mult);
			
			return val;
		}
	}
}