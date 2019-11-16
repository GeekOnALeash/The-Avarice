using System;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Characters
{
	[CreateAssetMenu(fileName = "AnimationStates", menuName = "Scriptable/Character/Animation States", order = 6)]
	public sealed class Anim : ScriptableObject
	{
		public float timebetweenFrames;

		[SerializeField]
		private Sprite[] sprites;

		[Serializable]
		public struct AnimPieces
		{
			public Sprite body;
			public Sprite clothing;
			public Sprite weapon;
		}

		[NonSerialized] internal bool animationRunning;

		internal Sprite GetFrame(int index)
		{
			if (index >= sprites.Length)
			{
				return null;
			}

			animationRunning = true;
			return sprites[index];
		}
	}
}