using System.Collections.Generic;

namespace com.ArkAngelApps.TheAvarice._Scripts.Data.Structs
{
	public struct Credits
	{
		private Dictionary<string, string> _sprites;

		/// <summary>
		/// These descriptions, are for things like stat descriptions etc.
		/// </summary>
		private Dictionary<string, string> _descriptions;

		private Dictionary<string, string> _audio;

		// Start is called before the first frame update
		private void Start()
		{
			_sprites.Add("Character Base", "www.deviantart.com/rorysoh");
			_sprites.Add("Heroicons icon set for some elements", "http://www.steveschoger.com/2018/01/04/introducing-heroicons-ui/");
			_sprites.Add("Cursors - wiimote cursors", "https://www.deviantart.com/japanyoshi");
			
			_descriptions.Add("Stat descriptions", "https://en.wikipedia.org/wiki/Wikipedia:Copyrights");

			_audio.Add("BigFan1HzPulse.wav", "freesound.org/people/Frostfire");
		}
	}
}