using System;
using System.Collections.Generic;
using System.Linq;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowWhenAttribute))]
// ReSharper disable once CheckNamespace
public class ShowWhenDrawer : PropertyDrawer
{
	private bool _showField = true;

	public override void OnGUI(Rect _position_, SerializedProperty _property_, GUIContent _label_)
	{
		var attribute_ = (ShowWhenAttribute) attribute;
		var conditionField_ = _property_.serializedObject.FindProperty(attribute_.conditionFieldName);

		// We check that exist a Field with the parameter name
		if (conditionField_ == null) {
			ShowError(_position_, _label_, "Error getting the condition Field. Check the name.");
			return;
		}

		switch (conditionField_.propertyType) {
			case SerializedPropertyType.Boolean:
				try {
					var comparationValue_ = attribute_.comparationValue == null || (bool) attribute_.comparationValue;
					_showField = conditionField_.boolValue == comparationValue_;
				}
				catch {
					ShowError(_position_, _label_, "Invalid comparation Value Type");
					return;
				}

				break;
			case SerializedPropertyType.Enum:
				var paramEnum_ = attribute_.comparationValue;
				var paramEnumArray_ = attribute_.comparationValueArray;

				if (paramEnum_ == null && paramEnumArray_ == null) {
					ShowError(_position_, _label_, "The comparation enum value is null");
					return;
				} else if (IsEnum(paramEnum_)) {
					if (paramEnum_ != null && !CheckSameEnumType(new[] {paramEnum_.GetType()},
					                                             _property_.serializedObject.targetObject.GetType(), conditionField_.name)) {
						ShowError(_position_, _label_, "Enum Types doesn't match");
						return;
					}

					if (paramEnum_ != null) {
						var enumValue_ = Enum.GetValues(paramEnum_.GetType()).GetValue(conditionField_.enumValueIndex)
						                     .ToString();
						_showField = paramEnum_.ToString() == enumValue_;
					}
				} else if (IsEnum(paramEnumArray_)) {
					if (!CheckSameEnumType(paramEnumArray_.Select(_x_ => _x_.GetType()),
					                       _property_.serializedObject.targetObject.GetType(), conditionField_.name)) {
						ShowError(_position_, _label_, "Enum Types doesn't match");
						return;
					}

					var enumValue_ = Enum.GetValues(paramEnumArray_[0].GetType()).GetValue(conditionField_.enumValueIndex)
					                    .ToString();
					_showField = paramEnumArray_.Any(_x_ => _x_.ToString() == enumValue_);
				} else {
					ShowError(_position_, _label_, "The comparation enum value is not an enum");
					return;
				}

				break;
			case SerializedPropertyType.Integer:
			case SerializedPropertyType.Float:
				string stringValue_;
				var error_ = false;

				float conditionValue_ = 0;
				// ReSharper disable once SwitchStatementMissingSomeCases
				switch (conditionField_.propertyType) {
					case SerializedPropertyType.Integer:
						conditionValue_ = conditionField_.intValue;
						break;
					case SerializedPropertyType.Float:
						conditionValue_ = conditionField_.floatValue;
						break;
				}

				try {
					stringValue_ = (string) attribute_.comparationValue;
				}
				catch {
					ShowError(_position_, _label_, "Invalid comparation Value Type");
					return;
				}

				if (stringValue_.StartsWith("==")) {
					var value_ = GetValue(stringValue_, "==");
					if (value_ == null) {
						error_ = true;
					} else {
						_showField = conditionValue_ == value_;
					}
				} else if (stringValue_.StartsWith("!=")) {
					var value_ = GetValue(stringValue_, "!=");
					if (value_ == null) {
						error_ = true;
					} else {
						_showField = conditionValue_ != value_;
					}
				} else if (stringValue_.StartsWith("<=")) {
					var value_ = GetValue(stringValue_, "<=");
					if (value_ == null) {
						error_ = true;
					} else {
						_showField = conditionValue_ <= value_;
					}
				} else if (stringValue_.StartsWith(">=")) {
					var value_ = GetValue(stringValue_, ">=");
					if (value_ == null) {
						error_ = true;
					} else {
						_showField = conditionValue_ >= value_;
					}
				} else if (stringValue_.StartsWith("<")) {
					var value_ = GetValue(stringValue_, "<");
					if (value_ == null) {
						error_ = true;
					} else {
						_showField = conditionValue_ < value_;
					}
				} else if (stringValue_.StartsWith(">")) {
					var value_ = GetValue(stringValue_, ">");
					if (value_ == null) {
						error_ = true;
					} else {
						_showField = conditionValue_ > value_;
					}
				}

				if (error_) {
					ShowError(_position_, _label_, "Invalid comparation instruction for Int or float value");
					return;
				}

				break;
			case SerializedPropertyType.Generic:
				break;
			case SerializedPropertyType.String:
				break;
			case SerializedPropertyType.Color:
				break;
			case SerializedPropertyType.ObjectReference:
				break;
			case SerializedPropertyType.LayerMask:
				break;
			case SerializedPropertyType.Vector2:
				break;
			case SerializedPropertyType.Vector3:
				break;
			case SerializedPropertyType.Vector4:
				break;
			case SerializedPropertyType.Rect:
				break;
			case SerializedPropertyType.ArraySize:
				break;
			case SerializedPropertyType.Character:
				break;
			case SerializedPropertyType.AnimationCurve:
				break;
			case SerializedPropertyType.Bounds:
				break;
			case SerializedPropertyType.Gradient:
				break;
			case SerializedPropertyType.Quaternion:
				break;
			case SerializedPropertyType.ExposedReference:
				break;
			case SerializedPropertyType.FixedBufferSize:
				break;
			case SerializedPropertyType.Vector2Int:
				break;
			case SerializedPropertyType.Vector3Int:
				break;
			case SerializedPropertyType.RectInt:
				break;
			case SerializedPropertyType.BoundsInt:
				break;
			default:
				ShowError(_position_, _label_, "This type has not supported.");
				return;
		}

		if (_showField) {
			EditorGUI.PropertyField(_position_, _property_, true);
		}
	}

	public override float GetPropertyHeight(SerializedProperty _property_, GUIContent _label_)
	{
		if (_showField) {
			return EditorGUI.GetPropertyHeight(_property_);
		}

		return -EditorGUIUtility.standardVerticalSpacing;
	}

	/// <summary>
	///     Return if the object is enum and not null
	/// </summary>
	private static bool IsEnum(object _obj_) => _obj_ != null && _obj_.GetType().IsEnum;

	/// <summary>
	///     Return if all the objects are enums and not null
	/// </summary>
	private static bool IsEnum(object[] _obj_)
	{
		return _obj_ != null && _obj_.All(_o_ => _o_.GetType().IsEnum);
	}

	/// <summary>
	///     Check if the field with name "fieldName" has the same class as the "checkTypes" classes through reflection
	/// </summary>
	private static bool CheckSameEnumType(IEnumerable<Type> _checkTypes_, Type _classType_, string _fieldName_)
	{
		var memberInfo_ = _classType_.GetField(_fieldName_);

		return memberInfo_ != null && _checkTypes_.All(_x_ => _x_ == memberInfo_.FieldType);
	}

	private void ShowError(Rect _position_, GUIContent _label_, string _errorText_)
	{
		EditorGUI.LabelField(_position_, _label_, new GUIContent(_errorText_));
		_showField = true;
	}

	/// <summary>
	///     Return the float value in the content string removing the remove string
	/// </summary>
	private static float? GetValue(string _content_, string _remove_)
	{
		var removed_ = _content_.Replace(_remove_, "");
		try {
			return float.Parse(removed_);
		}
		catch {
			return null;
		}
	}
}