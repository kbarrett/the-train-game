using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public float boardWidth;
    public float boardHeight;
    public int numberOfHorizontalNodes;
    public int numberOfVerticalNodes;
    public GameObject objectType;
    public Transform canvas;

    Node[,] board;
     
	// Use this for initialization
	void Start () {
        float boardWidthExtent = boardWidth/ 2f;
        float horizontalGapBetweenNodes = boardWidth / (numberOfHorizontalNodes - 1);
        print(horizontalGapBetweenNodes);
        float boardHeightExtent = boardHeight / 2f;
        float verticalGapBetweenNodes = boardHeight/ (numberOfVerticalNodes - 1);
        print(verticalGapBetweenNodes);

        board = new Node[numberOfHorizontalNodes, numberOfVerticalNodes];

        int xIndex = 0;
        int yIndex = 0;

        for (float i = -boardWidthExtent; i <= boardWidthExtent; i += horizontalGapBetweenNodes)
        {
            for (float j = -boardHeightExtent; j <= boardHeightExtent; j += verticalGapBetweenNodes)
            {
                GameObject obj = (GameObject)  Instantiate(objectType);
                obj.transform.SetParent(canvas);
                obj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);   
                obj.transform.localPosition = new Vector2(i, j);

                Node newNode = obj.GetComponent<Node>();
                board[xIndex, yIndex] = newNode;
                newNode.setCoordinate(xIndex, yIndex);
                newNode.board = this;
                ++yIndex;

            }
            yIndex = 0;
            ++xIndex;
        }
	}

    public Node getNode(int xIndex, int yIndex)
    {
        if (xIndex >= 0 && xIndex < numberOfHorizontalNodes
            && yIndex >= 0 && yIndex < numberOfVerticalNodes)
        {
            return board[xIndex, yIndex];
        }
        else
        {
            return null;
        }
    }
	
}
