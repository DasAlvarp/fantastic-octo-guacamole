    using UnityEngine;
    using UnityEditor;
    using System.Collections;
    // CopyComponents - by Michael L. Croswell for Colorado Game Coders, LLC
    // March 2010
     
    //Modified by Kristian Helle Jespersen
    //June 2011
     
    public class ReplaceXwithY : ScriptableWizard
    {
    public GameObject useGameObject;

    [MenuItem("Custom/Replace GameObjects")]

    private static void NewMenuOption()
    {
        ScriptableWizard.DisplayWizard("Replace GameObjects", typeof(ReplaceXwithY), "Replace");
    }

    void OnWizardCreate()
    {
        foreach (Transform t in Selection.transforms)
        {
            GameObject newObject = PrefabUtility.InstantiatePrefab(useGameObject) as GameObject;
            Transform newT = newObject.transform;

            newT.position = t.position;
            newT.rotation = t.rotation;
            newT.localScale = t.localScale;
            newT.parent = t.parent;

        }

        foreach (GameObject go in Selection.gameObjects)
        {
            DestroyImmediate(go);
        }
    }
}
