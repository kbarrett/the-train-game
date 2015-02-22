using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public float OwnershipThreshold = 5f;

    bool target = false;


    public float RedScore = 0.0f;
    public float BlueScore = 0.0f;

    UnityEngine.UI.Image texture;
	// Use this for initialization
	void Start () {
        texture = gameObject.GetComponent<UnityEngine.UI.Image>();
	}
	
	// Update is called once per frame
	void Update () {
        texture.color= ComputeNodeColor(RedScore, BlueScore);
	}

    Color ComputeNodeColor(float RedScore, float BlueScore)
    {
        if(RedScore > BlueScore && RedScore > OwnershipThreshold)
        {
            return Color.red;
        }
        else if(BlueScore > RedScore && BlueScore > OwnershipThreshold)
        {
            return Color.blue;
        }
        else
        {
            return Color.grey;
        }
    }

    public void OnClick()
    {
        target = !target;
    }
}
