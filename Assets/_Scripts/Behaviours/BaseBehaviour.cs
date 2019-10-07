using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public class BaseBehaviour : MonoBehaviour
	{
		private Transform _thisTransform;

		// ReSharper disable once InconsistentNaming
		protected new Transform transform
		{
			get
			{
				if (_thisTransform == null)
				{
					_thisTransform = base.transform;
				}

				return _thisTransform;
			}
		}
	}
}