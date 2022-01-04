using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(WrappingObstacles.Wrap))]
public class WrapTypeEditor : Editor
{
    SerializedObject so;

    SerializedProperty propScreenLimit;
    SerializedProperty propXLimit;
    SerializedProperty propYLimit;

    //private void OnEnable()
    //{
    //    so = serializedObject;
    //    propScreenLimit = so.FindProperty("_haveScreenAsLimit");
    //    if (!propScreenLimit.boolValue)
    //    {
    //        propXLimit = so.FindProperty("XLimit");
    //        propYLimit = so.FindProperty("YLimit");
    //    }
    //    else
    //    {
    //        propXLimit = so.FindProperty("_xLimit");
    //        propYLimit = so.FindProperty("_yLimit");
    //    }
        
    //}

    //public override void OnInspectorGUI()
    //{
    //    so.Update();

    //    EditorGUILayout.PropertyField(propScreenLimit);
        
    //    EditorGUILayout.PropertyField(propXLimit);
    //    EditorGUILayout.PropertyField(propYLimit);
    //    so.ApplyModifiedProperties();
    //}
}
