using com.ArkAngelApps.TheAvarice.Behaviours;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Camera))]
	public sealed class CameraHandler : BaseBehaviour
	{
		//Private variable to store the offset distance between the player and camera
		[SerializeField] private float3 offset;

		//Public variable to store a reference to the player game object
		[SerializeField] private GuidReference followTargetGUID;

		[SerializeField] private float cameraZ = -10;

		[SerializeField] private SpriteRenderer background;

		internal new Camera camera;

		private GameObject _followTargetObject;

		private void Awake()
		{
			camera = GetComponent<Camera>();
			Assert.IsNotNull(camera, "_camera is null");
			SystemVariables.Instance.mainCamera = this;
		}

		private void Start()
		{
			if (followTargetGUID.gameObject == null)
			{
				Debug.Log("No target set.");
			} else
			{
				_followTargetObject = followTargetGUID.gameObject;
			}

			FollowTarget();
		}

#if UNITY_EDITOR
		private void FixedUpdate()
		{
			if (!Application.isPlaying)
			{
				FollowTarget();
			}
		}
#endif

		internal void FollowTarget()
		{
			// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
			var position = _followTargetObject.transform.position;
			float3 pos = new float3(position.x + offset.x, position.y + offset.y, cameraZ);
			transform.position = pos;
		}

		internal bool IsVisibleToCamera([NotNull] Transform t)
		{
			Vector3 visTest = camera.WorldToViewportPoint(t.position);
			return visTest.x >= 0 && visTest.y >= 0 && visTest.x <= 1 &&
			       visTest.y <= 1 && visTest.z >= 0;
		}

		internal void EnableBackground(bool value)
		{
			Color currentColor = background.color;
			background.color = new Color(currentColor.r,
			                             currentColor.g,
			                             currentColor.b,
			                             value ? 1.0f : 0.0f);
		}
	}
}