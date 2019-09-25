using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Scenes
{
	[CreateAssetMenu(fileName = "NewArea", menuName = "ScriptableObjects/In-Game/Areas/Area", order = 1)]
	public sealed class AreaData : ScriptableObject
	{
		public SceneField[] scenesToLoad;

		public AudioClip backgoundMusic;
		public AudioClip[] randomSounds;

		[Header("Info")]
		public new string name;

		[TextArea(10, 40)]
		public string description;

		public int GetSceneCount() => scenesToLoad.Length;

		public void LoadScenes()
		{
			foreach (var scene in scenesToLoad)
			{
				SceneManager.LoadScene(scene, LoadSceneMode.Additive);
			}
		}
	}
}