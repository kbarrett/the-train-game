using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    bool target = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().color= Color.black;
        }
	}

    public void OnClick()
    {
        target = !target;
    }
}
