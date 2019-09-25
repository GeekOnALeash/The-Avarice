using com.ArkAngelApps.TheAvarice.Scriptable.System;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Helpers
{
	public sealed class LayerMasking : MonoBehaviour
	{
		private Camera _camera;

		private void Start()
		{
			SystemVariables.Instance.mainCamera.camera.cullingMask &= ~(1 << LayerMask.NameToLayer("Ground"));
		}
	}
}