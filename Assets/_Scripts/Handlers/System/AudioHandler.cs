using com.ArkAngelApps.TheAvarice.Helpers;
using com.ArkAngelApps.TheAvarice.Scriptable.Events;

namespace com.ArkAngelApps.TheAvarice.Handlers.System
{
	public sealed class AudioHandler : Audio
	{
		public SimpleAudioEvent audioEvent;

		protected override void Start()
		{
			base.Start();

			if (audioEvent.playOnAwake)
			{
				Play(audioEvent);
			}
		}
	}
}