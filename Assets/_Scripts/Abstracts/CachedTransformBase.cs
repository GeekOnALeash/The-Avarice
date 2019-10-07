using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Abstracts
{
	public class CachedTransformBase : MonoBehaviour
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