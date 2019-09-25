// ReSharper disable CheckNamespace

namespace com.ArkAngelApps.UtilityLibraries.Extensions
{
	public static class IntExtensions
	{
		public static int GetNearestMultiple(this int _value_, int _multiple_)
		{
			var rem_ = _value_ % _multiple_;
			var result_ = _value_ - rem_;
			if (rem_ > _multiple_ / 2) {
				result_ += _multiple_;
			}

			return result_;
		}
	}
}