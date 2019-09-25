using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using com.ArkAngelApps.TheAvarice.Scriptable.Scenes;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using com.ArkAngelApps.UtilityLibraries;
using EasyButtons;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace com.ArkAngelApps.TheAvarice.Controllers
{
	public sealed class SceneController : GenericSingletonClass<SceneController>
	{
		[Header("Loading UI")]
		public bool showLoading;

		[ShowWhen(nameof(showLoading))]
		public Slider loadingBar;

		[ShowWhen(nameof(showLoading))]
		public Text loadingText;

		[Header("Scene to Load")]
		[Scene]
		public string nextSceneToLoad;

		public bool loadSceneAtStart;

		[ShowWhen(nameof(loadSceneAtStart), false)]
		public bool loadNextSceneAfterTimer;

		[ShowWhen(nameof(loadNextSceneAfterTimer))]
		public float timeTillLoadNextScene;

		public bool sceneActivationAfterLoad;

		[Header("Area To Load")]
		public bool hasAreaScenes;

		[ShowWhen(nameof(hasAreaScenes))]
		public AreaData areaToLoad;

		[Header("Events")] public UnityEvent sceneLoadedEvent;

		private string _currentScene;
		private AsyncOperation _async;
		private bool _timerActivated;
		private float _timer;
		private float _progress;
		private bool _activateScene;

		private void Awake()
		{
			_currentScene = SceneManager.GetActiveScene().name;

			if (nextSceneToLoad == "")
			{
				Debug.Log($"{nameof(nextSceneToLoad)} not set");
			}
		}

		private void Start()
		{
			if (loadSceneAtStart)
			{
				StartAsync(nextSceneToLoad);
			}
		}

		[SuppressMessage("ReSharper", "InvertIf")]
		private void Update()
		{
			if (loadNextSceneAfterTimer && _timerActivated)
			{
				_timer -= Time.deltaTime;
				if (_timer <= 0)
				{
					_timer = timeTillLoadNextScene;
					_timerActivated = false;

					StartAsync(nextSceneToLoad);
				}
			}
		}

		[UsedImplicitly]
		[Button]
		public void StartTimerToLoadScene()
		{
			_timer = timeTillLoadNextScene;
			_timerActivated = true;
		}

		[Button]
		[UsedImplicitly]
		public void LoadNextScene()
		{
			if (nextSceneToLoad == null)
			{
				Debug.Log("No scenes to load");
				return;
			}

			StartAsync(nextSceneToLoad);
		}

		[Button]
		[UsedImplicitly]
		public void ReloadCurrentScene()
		{
			SceneManager.LoadScene(_currentScene);
		}

		private void StartAsync(string sceneToLoad)
		{
			if (showLoading)
			{
				loadingBar.gameObject.SetActive(true);
				loadingText.gameObject.SetActive(true);
			}
			
			StartCoroutine(LoadLevelWithBar(sceneToLoad));
		}

		private IEnumerator LoadLevelWithBar(string sceneToLoad)
		{
			yield return null;

			_async = SceneManager.LoadSceneAsync(sceneToLoad);
			_async.allowSceneActivation = sceneActivationAfterLoad;

			while (_progress < 1f)
			{
				_progress = Mathf.Clamp01(_async.progress / 0.9f);

				if (showLoading)
				{
					loadingBar.value = _async.progress;
					loadingText.text = $"Loading progress.. {(_progress * 100f).ToString(CultureInfo.CurrentCulture)}%";
				}

				yield return null;
			}

			if (!sceneActivationAfterLoad)
			{
				//Change the Text to show the Scene is ready
				loadingText.text = "Press any key to continue";
				loadingBar.gameObject.SetActive(false);

				while (!_activateScene)
				{
					if (Input.anyKeyDown)
					{
						_activateScene = true;
					}

					yield return null;
				}
			}

			_async.allowSceneActivation = true;

			if (!hasAreaScenes)
			{
				yield break;
			}

			foreach (var scene in areaToLoad.scenesToLoad)
			{
				_async = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
			}
		}

		public void ActivateScene(bool value) => _activateScene = value;
	}
}
