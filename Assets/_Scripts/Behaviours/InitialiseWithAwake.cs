using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	/// <summary>
	/// This is used to add an empty Awake method to ensure the script is available to Start methods
	/// </summary>
	public abstract class InitialiseWithAwake : MonoBehaviour
	{
		// Empty Awake method to ensure component is initialised before start
		// ReSharper disable once Unity.RedundantEventFunction
		protected virtual void Awake() { }
	}
}