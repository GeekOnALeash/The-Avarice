using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.UI
{
	[CreateAssetMenu(fileName = "NewUIStyleTMP", menuName = "ScriptableObjects/UI/Style/Style TMP Data")]
	public class UIStyleTMPData : ScriptableObject
	{
		//[ShowWhen("useGradient", ShowWhenAttribute.Condition.Equals, true)]
		//[Tooltip("TextMesh Pro color gradient asset")]
		//public TMP_ColorGradient colorGradient;

		[Space(10)]
		[Tooltip("Default color when not using a gradient")]
		[ColorUsage(true, false)]
		[ShowWhen(nameof(useGradient), false)]
		public Color defaultTextColor;

		[Tooltip("Color used for disabled text color")] [ColorUsage(true, false)]
		public Color disabledTextColor;

		[ShowWhen(nameof(useGradient))] [Tooltip("Used to tint gradients")]
		public Color gradientTintColor;

	//	[Tooltip("Used for showing values over limits, negative resources, etc.")]
	//	[ShowWhen("useGradient", ShowWhenAttribute.Condition.Equals, true)]
	//	public TMP_ColorGradient negativeGradient;

		[Space(15)] [Tooltip("Use a TextMesh Pro gradient")]
		public bool useGradient;
	}
}