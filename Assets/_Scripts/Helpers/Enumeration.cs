using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	public abstract class Enumeration : IComparable
	{
		private readonly int _value;
		private readonly string _displayName;

		protected Enumeration() { }

		protected Enumeration(int value, string displayName)
		{
			_value = value;
			_displayName = displayName;
		}

		public int Value => _value;

		public string DisplayName => _displayName;

		public override string ToString() => DisplayName;

		public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
		{
			var type = typeof(T);
			var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static |
			                            BindingFlags.DeclaredOnly);

			foreach (var info in fields)
			{
				var instance = new T();

				if (info.GetValue(instance) is T locatedValue)
				{
					yield return locatedValue;
				}
			}
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Enumeration otherValue))
			{
				return false;
			}

			var typeMatches = GetType() == obj.GetType();
			var valueMatches = _value.Equals(otherValue.Value);

			return typeMatches && valueMatches;
		}

		public override int GetHashCode() => _value.GetHashCode();

		public static T FromValue<T>(int value) where T : Enumeration, new()
		{
			var matchingItem =
				Parse<T, int>(value, "value", item => item.Value == value);
			return matchingItem;
		}

		public static T FromDisplayName<T>(string displayName)
			where T : Enumeration, new()
		{
			var matchingItem = Parse<T, string>(displayName, "display name",
			                                    item => item.DisplayName ==
			                                            displayName);
			return matchingItem;
		}

		[NotNull]
		private static T Parse<T, K>(K value, string description,
		                             [NotNull] Func<T, bool> predicate)
			where T : Enumeration, new()
		{
			var matchingItem = GetAll<T>().FirstOrDefault(predicate);

			if (matchingItem != null)
			{
				return matchingItem;
			}

			var message =
				$"'{value.ToString()}' is not a valid {description} in {typeof(T)}";
			throw new ApplicationException(message);
		}

		public int CompareTo(object other) => Value.CompareTo(((Enumeration) other).Value);
	}
}