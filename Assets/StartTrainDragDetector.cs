using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Node))]
public class StartTrainDragDetector : MonoBehaviour {

    public float TimeToActivate;

    bool IsPressing;
    bool isDragging;
    float TimeHeldDown;

    TrainRoute route;

	// Use this for initialization
	void Start () {
        IsPressing = false;
        isDragging = false;
        TimeHeldDown = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if(isDragging)
        {
            //if(activeTouch.)
                
        }
	    else if(IsPressing)
        {
            TimeHeldDown += Time.deltaTime;
            if(TimeHeldDown > TimeToActivate)
            {
                BeginDrag();
            }
        }
	}

    public void OnHoldDown()
    {
        TimeHeldDown = 0.0f;
        IsPressing = true;
    }

    public void OnRelease()
    {
        if(isDragging)
        {
            print(route.ToString());
            route.GetRouteEnd().ApplyToAdjacentNodes((Node x) => { x.SetHighlight(false); });
            route.EndRoute();
        }
        IsPressing = false;
        isDragging = false;
    }


    void BeginDrag()
    {
        if (!isDragging)
        {
            print("Begin drag");
            Node currentNode = GetComponent<Node>();
            currentNode.SetSelected(true);

            route = new TrainRoute(currentNode);

            currentNode.ApplyToAdjacentNodes((Node adjacentNode) =>
            {
                adjacentNode.SetHighlight(true); adjacentNode.SetCurrentRoute(route); adjacentNode.OnAddedToRoute += OnAddedToRoute;
            });
            isDragging = true;

            
        }
    }

    void OnAddedToRoute(Node n)
    {
        Node currentNode = GetComponent<Node>();
        currentNode.ApplyToAdjacentNodes((Node adjacentNode) => { adjacentNode.SetHighlight(false); });
    }


    /**/
}
