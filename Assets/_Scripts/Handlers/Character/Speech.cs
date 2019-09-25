using System;
using System.Diagnostics.CodeAnalysis;
using com.ArkAngelApps.TheAvarice.Interfaces;
using com.ArkAngelApps.MyDebug.Exceptions;
using com.ArkAngelApps.UtilityLibraries.Extensions;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	internal enum SpeechType
	{
		Triggered,
		Constant,
		Idle,
		Disabled
	}

	public sealed class Speech : MonoBehaviour, ITrigger
	{
		[SerializeField] private SpeechType speechType;

		[SerializeField] private GameObject speechBubble;
		[SerializeField] private Text text;

		[SerializeField] [IntervalRange(1, 30, 1)]
		private float timeBetweenMessages;

		[SerializeField] private string[] speechArray;

		private float _timeLeft;
		private int _timerSeed;
		private bool _withinTrigger;
		private Animator _animator;
		private bool _speechEnabled;
		private DialogueHandler _dialogue;
		private bool _dialogueDisplayed;

		private void Awake()
		{
			StartTimerWithRandomSeed();
		}

		private void Start()
		{
			_dialogue = GetComponent<DialogueHandler>();

			if (speechType == SpeechType.Disabled)
			{
				DisableSpeech();
			} else
			{
				Assert.IsNotNull(_dialogue, "_dialogue is null");
				_speechEnabled = true;
			}
		}

		[SuppressMessage("ReSharper", "InvertIf")]
		private void Update()
		{
			_timeLeft -= Time.deltaTime;

			if (_speechEnabled)
			{
				if (IsDialogueDisplayed())
				{
					HideSpeech();
				} else
				{
					EnableSpeech();
					DoSpeech();
				}
			}
		}

		private bool IsDialogueDisplayed()
		{
			return _dialogueDisplayed = _dialogue.DialogueDisplayed();
		}

		private void StartTimerWithRandomSeed(int seedMax = 10)
		{
			_timerSeed = Random.Range(0, seedMax);
			_timeLeft = timeBetweenMessages + _timerSeed;
		}

		private string RandomStringFromArray() => speechArray.RandomItem();

		private void EnableSpeech()
		{
			if (_speechEnabled)
			{
				return;
			}
			
			StartTimerWithRandomSeed();
			_speechEnabled = true;
		}

		private void DisableSpeech()
		{
			_speechEnabled = false;
			HideSpeech();
		}

		private void DoSpeech()
		{
			switch (speechType)
			{
				case SpeechType.Triggered:
					if (_withinTrigger)
					{
						CheckSpeech();
					} else
					{
						HideSpeech();
					}

					break;
				case SpeechType.Idle:
/*					if (AnimationHandler.IsIdlePlaying(_animator))
					{
						CheckSpeech();
					} else
					{
						HideSpeech();
					}

						// ADD CODE FOR CHECKING IF ANIMATIONS ARE IDLE !!!!
					*/

					break;
				case SpeechType.Constant:
					CheckSpeech();
					break;
				case SpeechType.Disabled:
					DisableSpeech();
					break;
				default:
					// ReSharper disable once HeapView.ObjectAllocation.Evident
					// ReSharper disable once HeapView.BoxingAllocation
					// Disabled ReSharper inspections as this branch is never intended to be reached
					throw new UnexpectedEnumValueException(speechType);
			}
		}

		private void CheckSpeech()
		{
			if (_timeLeft < 0)
			{
				DisplaySpeech(RandomStringFromArray());

				StartTimerWithRandomSeed();
			} else if (_timeLeft <= timeBetweenMessages / 2)
			{
				HideSpeech();
			}
		}

		private void DisplaySpeech(string speech)
		{
			speechBubble.SetActive(true);
			text.text = speech;
		}

		private void HideSpeech()
		{
			speechBubble.SetActive(false);
		}

		public void TriggerEnter()
		{
			_withinTrigger = true;
		}

		public void TriggerStay()
		{
			throw new NotImplementedException();
		}

		public void TriggerExit()
		{
			_withinTrigger = false;
		}
	}
}