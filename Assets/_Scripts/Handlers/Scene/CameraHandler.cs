using com.ArkAngelApps.TheAvarice.Abstracts;
using com.ArkAngelApps.TheAvarice.Scriptable.System;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene
{
	using com.ArkAngelApps.UtilityLibraries.Attributes;
	using global::System;

	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Camera))]
	public sealed class CameraHandler : CachedTransformBase
	{
		//Private variable to store the offset distance between the player and camera
		[SerializeField] private float3 offset;

		//Public variable to store a reference to the player game object
		[SerializeField] private GuidReference followTargetGUID;

		public float interpVelocity;
		public float minDistance;
		public float followDistance;

		[SerializeField] private float cameraZ = -10;

		[SerializeField] private SpriteRenderer background;

		internal new Camera camera;

		private GameObject _followTargetObject;
		private float3 _targetPos;

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

		private void LateUpdate()
		{
			FollowTarget();
		}

		private void FollowTarget()
		{
			// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
			var position = _followTargetObject.transform.position;
			//float3 pos = new float3(position.x + offset.x, position.y + offset.y, cameraZ);
			//transform.position = pos;

			var position1 = transform.position;
			Vector3 posNoZ = position1;
			posNoZ.z = position.z;

			Vector3 targetDirection = (position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			_targetPos = position1 + (targetDirection.normalized * (interpVelocity * Time.deltaTime));

			position1 = Vector3.Lerp(position1, _targetPos + offset, 0.25f);
			transform.position = position1;
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