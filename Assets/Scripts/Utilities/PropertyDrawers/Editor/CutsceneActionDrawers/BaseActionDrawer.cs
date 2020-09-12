using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(BaseCutsceneAction))]
public class BaseActionDrawer : PropertyDrawer {
    private static Dictionary<Type, PropertyDrawer> _polyPropertyDrawers;

    public BaseActionDrawer() {
        if (_polyPropertyDrawers == null) {
            _polyPropertyDrawers = new Dictionary<Type, PropertyDrawer>();

            _polyPropertyDrawers.Add(typeof(SwitchSceneCutsceneAction), new SwitchSceneActionDrawer());
            _polyPropertyDrawers.Add(typeof(DialogueCutsceneAction), new DialogueActionDrawer());
            _polyPropertyDrawers.Add(typeof(PassTimeCutsceneAction), new PassTimeActionDrawer());
        }
    }

    public PropertyDrawer GetPolyPropertyDrawer(SerializedProperty property) {
        PropertyDrawer drawer;
        return _polyPropertyDrawers.TryGetValue(property.objectReferenceValue.GetType(), out drawer) ? drawer : null;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        PropertyDrawer polyDrawer = GetPolyPropertyDrawer(property);
        return polyDrawer == null ? base.GetPropertyHeight(property, label) : polyDrawer.GetPropertyHeight(property, label);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        PropertyDrawer polyDrawer = GetPolyPropertyDrawer(property);
        if (polyDrawer == null) {
            EditorGUI.HelpBox(position, "Cannot find drawer for type " + property.objectReferenceValue.GetType(), MessageType.Error);
        } else {
            polyDrawer.OnGUI(position, property, label);
        }
    }
}