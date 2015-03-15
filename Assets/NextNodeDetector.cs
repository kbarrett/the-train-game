using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class NextNodeDetector : MonoBehaviour {

    TrainRoute activeRoute;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onEnter()
    {
        if(GetComponent<Node>().GetIsHighlighted())
        {
            GetComponent<Node>().SetHighlight(false);
            GetComponent<Node>().SetSelected(true);
            GetComponent<Node>().ApplyToAdjacentNodes((x) => 
            { 
                x.SetHighlight(true); 
                x.SetCurrentRoute(activeRoute);
                x.OnAddedToRoute += OnAddedToRoute;
            });
            print("OnEnter");
            Handheld.Vibrate(); // only works on ipHone 
        }
    }

    void OnAddedToRoute(Node n)
    {
        GetComponent<Node>().ApplyToAdjacentNodes((x) =>
        {
            x.SetHighlight(false);
            x.OnAddedToRoute -= OnAddedToRoute;
        });

    }

    public void onLeave()
    {
    }


    public void SetCurrentRoute(TrainRoute route)
    {
        activeRoute = route;
    }
}
