using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class UIStyleInstance : Editor
{
	[MenuItem("GameObject/UI Style/Button", priority = 0)]
	public static void AddButton()
	{
		Create("Button");
	}

	private static GameObject _clickedObject;

	private static GameObject Create(string _objectName)
	{
		GameObject instance = Instantiate(Resources.Load<GameObject>(_objectName));
		if (instance == null)
		{
			return null;
		}

		instance.name = _objectName;
		_clickedObject = Selection.activeObject as GameObject;
		if (_clickedObject != null)
		{
			instance.transform.SetParent(_clickedObject.transform, false);
		}

		return instance;
	}
}
