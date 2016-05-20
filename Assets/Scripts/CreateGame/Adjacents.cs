using UnityEngine;

public class Adjacents : MonoBehaviour {
    public GameObject[] adjacents = new GameObject[4];

    //adjacent faces.
    public GameObject[] GetAdjacents()
    {
        return adjacents;
    }
}