using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public float OwnershipThreshold = 5f;

    bool target = false;

    bool highlighted;
    bool selected;

    public float RedScore = 0.0f;
    public float BlueScore = 0.0f;

    UnityEngine.UI.Image texture;

    int xPos;
    int yPos;

    public Spawner board;


	// Use this for initialization
	void Start () {
        texture = gameObject.GetComponent<UnityEngine.UI.Image>();

        highlighted = false;
        selected = false;
	}
	
	// Update is called once per frame
	void Update () {
        texture.color= ComputeNodeColor(RedScore, BlueScore);
	}

    public void SetHighlight(bool isHighlighted)
    {
        highlighted = isHighlighted;
    }

    public void SetSelected(bool isSelected)
    {
        if (isSelected && !selected)
        {
            if (OnAddedToRoute != null)
            {
                OnAddedToRoute(this);
            }
        }
        selected = isSelected;
    }

    public bool GetIsSelected()
    {
        return selected;
    }

    public bool GetIsHighlighted()
    {
        return highlighted;
    }
    Color ComputeNodeColor(float RedScore, float BlueScore)
    {
        if(RedScore > BlueScore && RedScore > OwnershipThreshold)
        {
            if(selected)
            {
                return new Color(1.0f, 0.4f, 0.4f);
            }
            else if(highlighted)
            {
                return new Color(1.0f, 0.2f, 0.2f);
            }
            else
            {
                return Color.red;
            }
        }
        else if(BlueScore > RedScore && BlueScore > OwnershipThreshold)
        {
            if (selected)
            {
                return new Color(0.4f, 0.4f, 1.0f);
            }
            else if(highlighted)
            {
                return new Color(0.2f, 0.2f, 1.0f);
            }
            else
            {
                return Color.blue;
            }
        }
        else
        {
            if (selected)
            {
                return new Color(0.9f, 0.9f, 0.9f);
            }
            else if(highlighted)
            {
                return new Color(0.7f, 0.7f, 0.7f);
            }
            else
            {
                return Color.grey;
            }
        }
    }

    public void OnClick()
    {
        target = !target;
    }

    public delegate void AddedEvent(Node n);

    public event AddedEvent OnAddedToRoute;

    public void setCoordinate(int xIndex, int yIndex)
    {
        xPos = xIndex;
        yPos = yIndex;
    }

    public delegate void NodeFunction(Node x);

    public void ApplyToAdjacentNodes(NodeFunction x)
    {
        foreach (int diff in new int[] { -1, 1 })
        {

            Node adjacentNode = board.getNode(xPos + diff, yPos);
            if (adjacentNode)
            {
                x.Invoke(adjacentNode);
            }

            adjacentNode = board.getNode(xPos, yPos + diff);
            if (adjacentNode)
            {
                x.Invoke(adjacentNode);
            }
        }
        
    }


    public Node GetRightNode()
    {
        return board.getNode(xPos + 1, yPos);
    }

    public Node GetLeftNode()
    {
        return board.getNode(xPos + 1, yPos);
    }

    public Node GetUpNode()
    {
        return board.getNode(xPos, yPos + 1);

    }

    public Node GetDownNode()
    {
        return board.getNode(xPos, yPos -1);
    }


    public void SetCurrentRoute(TrainRoute route)
    {
        OnAddedToRoute += (n) => { route.AddNode(this); };
        GetComponent<NextNodeDetector>().SetCurrentRoute(route);
    }

    public override string ToString()
    {
        return "Node {" + xPos + ", " + yPos + "}";
    }
}
