namespace Helpers
{
	public static class IntHelper
	{

		/// <summary>
		/// Convert the number to the nearest value of a given multiple.
		/// Function from StackOverflow response <see href="https://stackoverflow.com/a/34444056">HERE</see>
		/// </summary>
		/// <param name="number">Number to convert</param>
		/// <param name="multiple">Multiple</param>
		/// <param name="min">Min number to avoid wrong numbers</param>
		/// <param name="max">Max number to avoid wrong numbers</param>
		public static int NearestRound(this int number, float multiple, float? min = null, float? max = null)
		{
			return (int)((float) number).NearestRound(multiple, min, max);
		}
	}
}