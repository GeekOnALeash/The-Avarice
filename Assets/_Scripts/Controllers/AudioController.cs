using com.ArkAngelApps.UtilityLibraries;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Controllers
{
	public sealed class AudioController : GenericSingletonClass<AudioController>
	{
		internal static void SetVolume(float volume) => AudioListener.volume = volume;

		internal static float GetVolume() => AudioListener.volume;
	}
}