using UnityEngine;

// ReSharper disable CheckNamespace
namespace com.ArkAngelApps.UtilityLibraries.Extensions
{
	public static class ColorExtensions
	{
		public static Color WithAlpha(this Color _color_, float _alpha_)
		{
			return new Color(_color_.r, _color_.g, _color_.b, _alpha_);
		}

		public static Color RandomColor(this Color _color_)
		{
			return new Color(Random.Range(0.0f, 0.9f), Random.Range(0.0f, 0.9f), Random.Range(0.0f, 0.9f));
		}

		public static Color ConvertColor(int _r_, int _g_, int _b_, int _a_)
		{
			return new Color(_r_ / 255.0f, _g_ / 255.0f, _b_ / 255.0f, _a_ / 255.0f);
		}
	}
}