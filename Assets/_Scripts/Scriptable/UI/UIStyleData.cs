using UnityEngine;
using UnityEngine.UI;

namespace com.ArkAngelApps.TheAvarice.Scriptable.UI
{
	[CreateAssetMenu(fileName = "NewUIStyle", menuName = "ScriptableObjects/UI/Style/Style Data")]
	public class UIStyleData : ScriptableObject
	{
		[Header("Buttons")] public Sprite buttonSprite;

		public SpriteState buttonSpriteState;

		[Header("Close Button")] public Sprite closeImage;

		public SpriteState closeSpriteState;
		public Color defaultColor = new Color(255, 255, 255, 255);
		public Color defaultTextColor = new Color(255, 255, 255, 255);
		public Color disabledButtonColor = new Color(120, 120, 120, 255);
		public Color disabledTextColor = new Color(120, 120, 120, 255);

		public Color frameColor = new Color(120, 120, 120, 255);

		[Header("Window Frame")] public Sprite frameImage;
	}
}