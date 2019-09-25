using UnityEngine;

// ReSharper disable once CheckNamespace
public static class Constants
{
	public static class Vector
	{
		public static readonly Vector3 _Up = new Vector3(0, 1, 0);
		public static readonly Vector3 _Down = new Vector3(0, -1, 0);
		public static readonly Vector3 _Left = new Vector3(-1, 0, 0);
		public static readonly Vector3 _Right = new Vector3(1, 0, 0);
		public static readonly Vector3 _UpRight = new Vector3(1, 1, 0);
		public static readonly Vector3 _DownRight = new Vector3(1, -1, 0);
		public static readonly Vector3 _UpLeft = new Vector3(-1, 1, 0);
		public static readonly Vector3 _DownLeft = new Vector3(-1, -1, 0);
		public static readonly Vector3 _Zero = new Vector3(0, 0, 0);
		public static readonly Vector3 _One = new Vector3(1, 1, 1);
	}
}
