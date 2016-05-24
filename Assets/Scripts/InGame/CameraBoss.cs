using UnityEngine;

public class CameraBoss : MonoBehaviour {
    public Transform thisGuy;
    public Transform character;
    public Transform stage;
    bool init = false;

    // Update is called once per frame
    void Update()
    {
        if(!init)
        {
            stage = GameObject.Find("Stage(Clone)").transform;
        }
        thisGuy.position = new Vector3(stage.position.x, stage.position.y, character.position.z - .9999f);
        thisGuy.GetComponent<Camera>().depth = stage.localScale.z * 10;
        thisGuy.GetComponent<Camera>().orthographicSize = GreaterThan(stage.localScale.x * 5, stage.localScale.y * 5);
    }

    float GreaterThan(float x, float y)
    {
        if (x < y)
            return y;
        return x;
    }
}
