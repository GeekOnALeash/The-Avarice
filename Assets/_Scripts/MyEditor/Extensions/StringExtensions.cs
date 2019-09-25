using System;
using System.Linq;
using UnityEngine;

// ReSharper disable CheckNamespace
namespace com.ArkAngelApps.UtilityLibraries.Extensions
{
	public static class StringExtensions
	{
		/// <summary>
		///     Tries to convert a string into an integer.
		/// </summary>
		/// <returns>Int returned from sting value.</returns>
		public static int ToInt(this string _string_)
		{
			if (int.TryParse(_string_, out var output_))
			{
				return output_;
			}

			Debug.LogWarning("Not convertible to int");
			return 0;
		}

		public static bool IsNullOrEmpty(this string input)
		{
			if (input == null)
			{
				return true;
			}

			return input.Length == 0;
		}

		public static bool StartsWithUpper(this string _str_)
		{
			if (string.IsNullOrWhiteSpace(_str_)) {
				return false;
			}

			_str_ = _str_[0].ToString();

			return _str_.Any(char.IsUpper);
		}

		public static string Capitalise(this string _str_)
		{
			if (string.IsNullOrEmpty(_str_)) {
				Debug.Log("Invalid String");
				return string.Empty;
			}
			
			char[] chars_ = _str_.ToCharArray();
			chars_[0] = char.ToUpper(chars_[0]);
			return new string(chars_);
		}

		//// str - the source string
		//// index- the start location to replace at (0-based)
		//// length - the number of characters to be removed before inserting
		//// replace - the string that is replacing characters
		public static string ReplaceAt(this string _str_, int _index_, int _length_, string _replace_)
		{
			return _str_.Remove(_index_, Math.Min(_length_, _str_.Length - _index_)).Insert(_index_, _replace_);
		}
	}
}