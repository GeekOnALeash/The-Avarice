using com.ArkAngelApps.TheAvarice.Composites;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Behaviours.UI
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public sealed class SliderSetter : MonoBehaviour
	{
		[SerializeField] private SliderComposite sliderComposite;

		private SliderComposite SliderHelper
		{
			get => sliderComposite;
			set => sliderComposite = value;
		}

		[UsedImplicitly]
		public void UpdateSliderValue() => SliderHelper.UpdateSlider();

		public void UpdateSliderValue(int value) => SliderHelper.UpdateSlider(value);
	}
}