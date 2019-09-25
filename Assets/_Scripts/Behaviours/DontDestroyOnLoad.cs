using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	public class DontDestroyOnLoad : MonoBehaviour
	{
		private void Awake()
		{
			DontDestroyOnLoad(gameObject);
		}
	}
}