using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace com.ArkAngelApps.TheAvarice.Composites
{
	public enum Gender
	{
		Male,
		Female
	}

	/// <summary>
	/// RandomName class, used to generate a random name.
	/// </summary>
	internal sealed class RandomName
	{
		/// <summary>
		/// Class for holding the lists of names from names.json
		/// </summary>
		private sealed class NameList
		{
			public string[] Boys { get; }
			public string[] Girls { get; }
			public string[] Last { get; }

			public NameList()
			{
				Boys = new string[] { };
				Girls = new string[] { };
				Last = new string[] { };
			}
		}

		private readonly Random _rand;
		private readonly List<string> _male;
		private readonly List<string> _female;
		private readonly List<string> _last;

		/// <summary>
		/// Initialises a new instance of the RandomName class.
		/// </summary>
		/// <param name="rand">A Random that is used to pick names</param>
		public RandomName(Random rand)
		{
			_rand = rand;

			JsonSerializer serializer = new JsonSerializer();
			StreamReader reader = new StreamReader("names.json");
			JsonReader jreader = new JsonTextReader(reader);

			NameList l = serializer.Deserialize<NameList>(jreader);

			_male = new List<string>(l.Boys);
			_female = new List<string>(l.Girls);
			_last = new List<string>(l.Last);
		}

		/// <summary>
		/// Returns a new random name
		/// </summary>
		/// <param name="sex">The sex of the person to be named. true for male, false for female</param>
		/// <param name="middle">How many middle names do generate</param>
		/// <param name="isInitial">Should the middle names be initials or not?</param>
		/// <returns>The random name as a string</returns>
		[NotNull]
		public string Generate(Gender sex, int middle = 0, bool isInitial = false)
		{
			// determines if we should select a name from male or female, and randomly picks
			var first = sex == Gender.Male ? _male[_rand.Next(_male.Count)] : _female[_rand.Next(_female.Count)];

			var last = _last[_rand.Next(_last.Count)];

			var middles = new List<string>();

			for (var i = 0; i < middle; i++)
			{
				if (isInitial)
				{
					// randomly selects an uppercase letter to use as the initial and appends a dot
					middles.Add("ABCDEFGHIJKLMNOPQRSTUVWXYZ"[_rand.Next(0, 25)].ToString() + ".");
				} else
				{
					middles.Add(sex == Gender.Male
						            ? _male[_rand.Next(_male.Count)]
						            : _female
							            [_rand.Next(_female.Count)]);
				}
			}

			var b = new StringBuilder();
			b.Append(first + " ");
			foreach (var m in middles)
			{
				b.Append(m + " ");
			}

			b.Append(last);

			return b.ToString();
		}
	}
}