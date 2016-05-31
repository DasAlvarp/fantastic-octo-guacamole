using UnityEngine;
using UnityEditor;
// CopyComponents - by Michael L. Croswell for Colorado Game Coders, LLC
// March 2010
//Modified by Kristian Helle Jespersen
//June 2011
//Modified by Connor Cadellin McKee for Excamedia
//April 2015
//Modified by Fernando Medina (fermmmm)
//April 2015
//yes, I copied this from unity forums.
//http://forum.unity3d.com/threads/replace-game-object-with-prefab.24311/
public class AddThing : ScriptableWizard
{
    public GameObject Prefab;
    public GameObject[] ObjectsToReplace;
    public bool KeepOriginalNames = true;
    [MenuItem("Custom/Replace GameObjects")]
    static void CreateWizard()
    {
        var replaceGameObjects = DisplayWizard<AddThing>("Replace GameObjects", "Replace");
        replaceGameObjects.ObjectsToReplace = Selection.gameObjects;
    }
    void OnWizardCreate()
    {
        foreach (GameObject go in ObjectsToReplace)
        {
            GameObject newObject;
            newObject = (GameObject)PrefabUtility.InstantiatePrefab(Prefab);
            newObject.transform.SetParent(go.transform.parent, true);
            newObject.transform.localPosition = go.transform.localPosition;
            newObject.transform.localRotation = go.transform.localRotation;
            newObject.transform.localScale = go.transform.localScale;
            if (KeepOriginalNames)
                newObject.transform.name = go.transform.name;
            DestroyImmediate(go);
        }
    }
}
