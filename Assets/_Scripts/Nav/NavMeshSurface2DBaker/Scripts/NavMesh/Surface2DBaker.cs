using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace NavMeshSurface2DBaker
{
	/// <inheritdoc />
	/// <summary>
	/// Put instance of this class on same GameObject as NavMeshSurface to add ability to bake 2D colliders.
	/// </summary>
	public sealed class Surface2DBaker : MonoBehaviour
	{
		[Tooltip(
			"Add all objects that shall be searched for 2D colliders when baking.\n" +
			"Baker will automatically also search in children of added objects.")]
		public List<GameObject> objectsContainingObstacles =
			new List<GameObject>();

		[Tooltip("Bake BoxCollider2D objects?\n" +
		         "ATTENTION: Even if selected, won't bake a box collider if \"Used By Composite\" is true.")]
		public bool bakeBoxCollider2D = true;

		[Tooltip("Bake CircleCollider2D objects?")]
		public bool bakeCircleCollider2D = true;

		[Tooltip("Bake CompositeCollider2D objects?\n" +
		         "Also allows for baking of TilemapCollider2D as long as it's part of the composite collider.")]
		public bool bakeCompositeCollider2D = true;

		[Tooltip("Bake PollygonCollider2D objects?\n" +
		         "ATTENTION: Even if selected, won't bake a polygon collider if \"Used By Composite\" is true.")]
		public bool bakePolygonCollider2D = true;

		[Tooltip(
			"If enabled, MeshRenderer on this component will be enabled before baking.\n" +
			"Useful because MeshRenderer needs to be active while baking but you might want to hide it before and after.\n" +
			"Another solution would be a 100% transparent material.")]
		public bool enableMeshRendererBeforeBaking = true;

		[Tooltip(
			"If enabled, MeshRenderer on this component will be disabled after baking.\n" +
			"Useful because MeshRenderer needs to be active while baking but you might want to hide it before and after.\n" +
			"Another solution would be a 100% transparent material.")]
		public bool disableMeshRendererAfterBaking = true;

		private List<GameObject> _objectsToBeDeletedAfterBaking;

		private void Start()
		{
			//script shouldn't ever be enabled during runtime
			enabled = false;
		}

		/// <summary>
		/// Collects all 2D colliders that shall be considered when baking and creates corresponding 3D colliders.
		/// </summary>
		/// <returns></returns>
		[NotNull]
		public List<GameObject> CreateMeshes()
		{
			if (objectsContainingObstacles == null)
			{
				throw new
					ArgumentNullException(nameof(objectsContainingObstacles));
			}

			var createdGameObjects = new List<GameObject>();
			if (objectsContainingObstacles.Count == 0)
			{
				Debug.LogWarning($"No elements to search for 2D colliders set in field {nameof(objectsContainingObstacles)}. No 2D colliders will be baked.");
				return createdGameObjects;
			}

			foreach (var obj in objectsContainingObstacles)
			{
				if (obj == null)
				{
					Debug.LogWarning("Element in list of objects to be searched for colliders not set. Skipping entry");
					continue;
				}

				if (bakePolygonCollider2D)
				{
					createdGameObjects
						.AddRange(ProcessPolygonColliders(obj, transform));
				}

				if (bakeCompositeCollider2D)
				{
					createdGameObjects
						.AddRange(ProcessCompositeColliders(obj, transform));
				}

				if (bakeCircleCollider2D)
				{
					createdGameObjects
						.AddRange(ProcessCircleColliders(obj, transform));
				}

				if (bakeBoxCollider2D)
				{
					createdGameObjects
						.AddRange(ProcessBoxColliders(obj, transform));
				}
			}

			return createdGameObjects;
		}

		/// <summary>
		/// Finds all <see cref="PolygonCollider2D"/>s in <paramref name="objectContainingObstacles"/> (and its children)
		/// and creates corresponding 3D colliders.
		/// If a <see cref="PolygonCollider2D"/> instance is found but "usedByComposite" is set to true, the collider will be ignored by this function.
		/// </summary>
		/// <param name="objectContainingObstacles">Object to search for colliders in.</param>
		/// <param name="parentToAttachTemporaryObjectsTo">Object which will be made the parent of the created 3D colliders.</param>
		/// <returns></returns>
		[NotNull]
		private static IEnumerable<GameObject> ProcessPolygonColliders(
			[NotNull] GameObject objectContainingObstacles,
			Transform parentToAttachTemporaryObjectsTo)
		{
			var createdGameObjects = new List<GameObject>();
			var polyColliders = objectContainingObstacles
				.GetComponentsInChildren<PolygonCollider2D>();
			foreach (var col in polyColliders)
			{
				if (col.isTrigger)
				{
					break;
				}

				if (!col.usedByComposite)
				{
					createdGameObjects.Add(MeshFromPolygonCreator
						                       .CreateMesh(col.points,
						                                   col.transform,
						                                   parentToAttachTemporaryObjectsTo));
				}
			}

			return createdGameObjects;
		}

		/// <summary>
		/// Finds all <see cref="CompositeCollider2D"/>s in <paramref name="objectContainingObstacles"/> (and its children)
		/// and creates corresponding 3D colliders.
		/// </summary>
		/// <param name="objectContainingObstacles">Object to search for colliders in.</param>
		/// <param name="parentToAttachTemporaryObjectsTo">Object which will be made the parent of the created 3D colliders.</param>
		/// <returns></returns>
		[NotNull]
		private static IEnumerable<GameObject> ProcessCompositeColliders(
			[NotNull] GameObject objectContainingObstacles,
			Transform parentToAttachTemporaryObjectsTo)
		{
			var createdGameObjects = new List<GameObject>();
			var compositeColliders = objectContainingObstacles
				.GetComponentsInChildren<CompositeCollider2D>();

			foreach (var col in compositeColliders)
			{
				if (col.isTrigger)
				{
					break;
				}

				for (var i = 0; i < col.pathCount; i++)
				{
					var pathNodes = new Vector2[col.GetPathPointCount(i)];
					col.GetPath(i, pathNodes);
					createdGameObjects.Add(MeshFromPolygonCreator
						                       .CreateMesh(pathNodes,
						                                   col.transform,
						                                   parentToAttachTemporaryObjectsTo));
				}
			}

			return createdGameObjects;
		}

		/// <summary>
		/// Finds all <see cref="CircleCollider2D"/>s in <paramref name="objectContainingObstacles"/> (and its children)
		/// and creates corresponding 3D colliders.
		/// </summary>
		/// <param name="objectContainingObstacles">Object to search for colliders in.</param>
		/// <param name="parentToAttachTemporaryObjectsTo">Object which will be made the parent of the created 3D colliders.</param>
		/// <returns></returns>
		[NotNull]
		private static IEnumerable<GameObject> ProcessCircleColliders(
			[NotNull] GameObject objectContainingObstacles,
			Transform parentToAttachTemporaryObjectsTo)
		{
			var createdGameObjects = new List<GameObject>();
			var circleColliders = objectContainingObstacles
				.GetComponentsInChildren<CircleCollider2D>();

			foreach (var col in circleColliders)
			{
				if (col.isTrigger)
				{
					break;
				}

				var colliderTransform = col.transform;
				var colliderPosition = colliderTransform.position;
				var lossyColliderScale = colliderTransform.lossyScale;
				var colliderOffset = col.offset;

				var cylinder =
					GameObject.CreatePrimitive(PrimitiveType.Cylinder);
				var diameter = col.radius * 2;
				var capsuleCollider = cylinder.GetComponent<CapsuleCollider>();
				capsuleCollider.enabled =
					false; //disable just in case there are any other 3d colliders around that could be affected by this

				var scalingMultiplier =
					Mathf.Max(lossyColliderScale.x, lossyColliderScale.y);
				cylinder.transform.localScale =
					Vector3.Scale(new Vector3(diameter, 1, diameter),
					              new Vector3(scalingMultiplier, 1,
					                          scalingMultiplier));
				cylinder.transform.position =
					new
						Vector3(colliderPosition.x + colliderOffset.x * scalingMultiplier,
						        colliderPosition.y + colliderOffset.y *
						        scalingMultiplier, -capsuleCollider.height / 2);
				cylinder.transform.rotation = Quaternion.Euler(90, 0, 0);

				cylinder.transform.parent = parentToAttachTemporaryObjectsTo;

				createdGameObjects.Add(cylinder);
			}

			return createdGameObjects;
		}

		/// <summary>
		/// Finds all <see cref="BoxCollider2D"/>s in <paramref name="objectContainingObstacles"/> (and its children)
		/// and creates corresponding 3D colliders.
		/// If a <see cref="BoxCollider2D"/> instance is found but "usedByComposite" is set to true, the collider will be ignored by this function.
		/// </summary>
		/// <param name="objectContainingObstacles">Object to search for colliders in.</param>
		/// <param name="parentToAttachTemporaryObjectsTo">Object which will be made the parent of the created 3D colliders.</param>
		/// <returns></returns>
		[NotNull]
		private static IEnumerable<GameObject> ProcessBoxColliders(
			[NotNull] GameObject objectContainingObstacles,
			Transform parentToAttachTemporaryObjectsTo)
		{
			var createdGameObjects = new List<GameObject>();
			var boxColliders = objectContainingObstacles
				.GetComponentsInChildren<BoxCollider2D>();

			foreach (var col in boxColliders)
			{
				if (col.isTrigger)
				{
					break;
				}

				if (col.usedByComposite)
				{
					continue;
				}

				var colliderSize = col.size;
				var colliderTransform = col.transform;
				var colliderBoundsCenter = col.bounds.center;
				var lossyColliderScale = colliderTransform.lossyScale;

				var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				var cubeCollider = cube.GetComponent<BoxCollider>();
				cubeCollider.enabled =
					false; //disable just in case there are any other 3d colliders around that could be affected by this
				cube.transform.localScale =
					Vector3
						.Scale(new Vector3(colliderSize.x, colliderSize.y, 1),
						       new Vector3(lossyColliderScale.x,
						                   lossyColliderScale.y, 1));
				cube.transform.rotation = colliderTransform.rotation;
				cube.transform.position =
					new Vector3(colliderBoundsCenter.x,
					            colliderBoundsCenter.y,
					            -cube.transform.localScale.z / 2);

				cube.transform.parent = parentToAttachTemporaryObjectsTo;

				createdGameObjects.Add(cube);
			}

			return createdGameObjects;
		}
	}
}