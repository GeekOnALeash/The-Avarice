using com.ArkAngelApps.TheAvarice.Composites;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	[DisallowMultipleComponent]
	public sealed class Health : MonoBehaviour
	{
		[SerializeField] private HealthComposite healthComposite;

		// ReSharper disable once ConvertToAutoProperty
		internal HealthComposite HealthHelper
		{
			get => healthComposite;
			set => healthComposite = value;
		}
	}
}