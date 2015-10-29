#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeCardList {
    [MenuItem("Assets/Create/CardList")]
    public static void CreateMyAsset()
    {
        CardList asset = ScriptableObject.CreateInstance<CardList>();

        AssetDatabase.CreateAsset(asset, "Assets/NewCardList.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

}
#endif