using com.ArkAngelApps.UtilityLibraries.ENUMS;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.UI
{
	[CreateAssetMenu(fileName = "NewWindowData", menuName = "ScriptableObjects/UI/Window/Data")]
	public class UIWindowData : ScriptableObject
	{
		[ShowWhen(nameof(hasDescription))]
		public string description;

		public bool hasDescription;

		public bool hasImage;

		public bool hasTitle;

		[ShowWhen(nameof(hasTitle))]
		public string title;

		public WindowType uiType;

		[ShowWhen(nameof(hasImage))]
		public Sprite windowImage;
	}
}