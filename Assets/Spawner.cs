﻿using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public float boardWidth;
    public float boardHeight;
    public int numberOfNodes;
    public GameObject objectType;
    public Transform canvas;

	// Use this for initialization
	void Start () {
        float boardWidthExtent = boardWidth/ 2f;
        float horizontalGapBetweenNodes = boardWidthExtent / (numberOfNodes - 1);

        float boardHeightExtent = boardHeight / 2f;
        float verticalGapBetweenNodes = boardHeightExtent / (numberOfNodes - 1);

        
        for (float i = -boardWidthExtent; i <= boardWidthExtent; i += horizontalGapBetweenNodes)
        {
            for (float j = -boardHeightExtent; j <= boardHeightExtent; j += verticalGapBetweenNodes)
            {
                GameObject obj = (GameObject)  Instantiate(objectType);
                obj.transform.SetParent(canvas);
                obj.transform.localPosition = new Vector2(i, j);

            }
        }
	}
	
}