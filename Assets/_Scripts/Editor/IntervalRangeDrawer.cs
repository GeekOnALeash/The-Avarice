// PUT IN EDITOR FOLDER

using UnityEditor;
using UnityEngine;
using Helpers;
// ReSharper disable SwitchStatementMissingSomeCases

[CustomPropertyDrawer(typeof(IntervalRangeAttribute))]
internal sealed class IntervalRangeDrawer : PropertyDrawer
{
    private bool error;
    private string errorMessage;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        IntervalRangeAttribute attribute = (IntervalRangeAttribute) this.attribute;

        error = false;
        errorMessage = "";

        // Check the Field type. Range only works with Float and Integer.
        if (property.propertyType == SerializedPropertyType.Float)
        {
            // We get the values passed to the attribute
            float minValue = attribute.min;
            float maxValue = attribute.max;
            float intervalValue = attribute.interval;

            // Or check and assign if the values are linked to other fields
            GetValue(ref minValue, property, attribute.minString);
            GetValue(ref maxValue, property, attribute.maxString);
            GetValue(ref intervalValue, property, attribute.intervalString);

            if (!error)
            {
                // Block to paint the slider
                label = EditorGUI.BeginProperty(position, label, property);
                EditorGUI.BeginChangeCheck();
                float num = EditorGUI.Slider(position, label, property.floatValue, minValue, maxValue);
                // VERY IMPORTANT LINE: We need to adjust the output to our interval
                num = num.AdjustIntervalAndPrecision(intervalValue, minValue, maxValue, attribute.floatPrecision, attribute.precisionMethod);
                if (EditorGUI.EndChangeCheck())
                    property.floatValue = num;
                EditorGUI.EndProperty();
            }
        }
        else if (property.propertyType == SerializedPropertyType.Integer)
        {
            // We get the values passed to the attribute
            int minValue = (int)attribute.min;
            int maxValue = (int)attribute.max;
            float intervalValue = attribute.interval;

            // Or check and assign if the values are linked to other fields
            GetValue(ref minValue, property, attribute.minString);
            GetValue(ref maxValue, property, attribute.maxString);
            GetValue(ref intervalValue, property, attribute.intervalString);

            if (!error)
            {
                // Block to paint the slider
                label = EditorGUI.BeginProperty(position, label, property);
                EditorGUI.BeginChangeCheck();
                int num = EditorGUI.IntSlider(position, label, property.intValue, minValue, maxValue);
                // VERY IMPORTANT LINE: We need to adjust the output to our interval
                num = num.NearestRound(intervalValue, minValue, maxValue);
                if (EditorGUI.EndChangeCheck())
                    property.intValue = num;
                EditorGUI.EndProperty();
            }
        }
        else
        {
            error = true;
            errorMessage = "Use Range with float or int.";
        }

        if (error)
            EditorGUI.LabelField(position, label.text, errorMessage);
    }

    /// <summary>
    /// Assign to val the value of the field named with propertyName if is valid
    /// </summary>
    private void GetValue(ref int val, SerializedProperty property, string propertyName)
    {
        if (propertyName == null)
            return;

        SerializedProperty p = property.serializedObject.FindProperty(propertyName);

        if (p != null)
        {
            switch (p.propertyType)
            {
                case SerializedPropertyType.Float:
                    error = true;
                    errorMessage = "Float property params not valid for int properties.";
                    break;
                case SerializedPropertyType.Integer:
                    val = p.intValue;
                    break;
                default:
                    error = true;
                    errorMessage = "Use Range with float or int param values.";
                    break;
            }
        }
        else
        {
            error = true;
            errorMessage = "Invalid param name or privated property.";
        }
    }
    
    /// <summary>
    /// Assign to val the value of the field named with propertyName if is valid
    /// </summary>
    private void GetValue(ref float val, SerializedProperty property, string propertyName)
    {
        if (propertyName == null)
            return;

        SerializedProperty p = property.serializedObject.FindProperty(propertyName);

        if (p != null)
        {
            switch (p.propertyType)
            {
                case SerializedPropertyType.Float:
                    val = p.floatValue;
                    break;
                case SerializedPropertyType.Integer:
                    val = p.intValue;
                    break;
                default:
                    error = true;
                    errorMessage = "Use Range with float or int param values.";
                    break;
            }
        }
        else
        {
            error = true;
            errorMessage = "Invalid param name or privated property.";
        }
    }
}