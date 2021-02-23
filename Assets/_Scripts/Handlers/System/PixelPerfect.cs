using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.System
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	public sealed class PixelPerfect : MonoBehaviour
	{
		[SerializeField] private bool setOrthographicSize = true;
		[SerializeField] private int pixelHeight = 720;
		[SerializeField] private int pixelsPerUnit = 64;
		[SerializeField] private int pixelsPerUnitScale = 2;

		private Camera _camera;

		private void Start()
		{
			_camera = GetComponent<Camera>();

			// ReSharper disable once InvertIf
			if (!Application.isEditor && setOrthographicSize)
			{
				SetOrthographicSize();
			}
		}

#if UNITY_EDITOR
		private void Update()
		{
			if (setOrthographicSize)
			{
				SetOrthographicSize();
			}
		}
#endif

		private void SetOrthographicSize()
		{
			if (!_camera.orthographic)
			{
				Debug.Log("Camera is not set to orthographic");
				return;
			}

			float scaledPPU = pixelsPerUnitScale * pixelsPerUnit;
			float verticalUnitCount = pixelHeight / scaledPPU;
			_camera.orthographicSize = verticalUnitCount * 0.5f;
		}
	}
}
