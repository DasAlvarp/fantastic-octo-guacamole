using UnityEngine;

public class CameraBoss : MonoBehaviour {
    public Transform thisGuy;
    public Transform character;
    public Transform stage;
    bool init = false;

    // Update is called once per frame
    void Update()
    {
        if(!init)//putting things in OnStart and OnAwake doesn't work, so I do this stupid thing
        {
            stage = GameObject.Find("Stage(Clone)").transform;
        }
        transform.position = new Vector3(stage.position.x, stage.position.y, character.position.z - .9999f);//idk
        gameObject.GetComponent<Camera>().depth = stage.localScale.z * 10;
        gameObject.GetComponent<Camera>().orthographicSize = GreaterThan(stage.localScale.x * 5, stage.localScale.y * 5);
    }

    float GreaterThan(float x, float y)
    {
        if (x < y)
            return y;
        return x;
    }
}
