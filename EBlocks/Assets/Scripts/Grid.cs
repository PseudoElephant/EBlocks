using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    //Attributes
    public GameObject containerPrefab;
    public GameObject player;

    private Container[,] containerArr;
    private int boardWidth;
    private int boardHeight;

    enum Direction
    {
        UP = 0,
        RIGHT = 1,
        DOWN = 2,
        LEFT = 3
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
