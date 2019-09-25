using com.ArkAngelApps.UtilityLibraries;

namespace com.ArkAngelApps.TheAvarice.Controllers
{
	public sealed class Controller : GenericSingletonClass<Controller>
	{
		internal static AudioController Audio { get; private set; }
		internal static GameController Game { get; private set; }
		internal static SceneController Scene { get; private set; }
		internal static UIController UI { get; private set; }

		public void Awake()
		{
			Audio = AudioController.Instance;
			Game = GameController.Instance;
			Scene = SceneController.Instance;
			UI = UIController.Instance;
		}
	}
}