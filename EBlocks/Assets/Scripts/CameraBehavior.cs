using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Camera mainCamera;

    public Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        float gridScale = Grid.gridScale;
        Vector2 WidthAndHeight = grid.GetGridSize();
        int widthBoard = (int)WidthAndHeight.x;
        int heightBoard = (int)WidthAndHeight.y;
        float xPos = (widthBoard * gridScale) / 2;
        float yPos = (heightBoard * gridScale) / 2;

        float sizeOfProjection = (0.5168F * Mathf.Max(widthBoard, heightBoard)) * gridScale + 0.506F * gridScale; // Regression line gathered from data y = 0.5168x + 0.506

        mainCamera.orthographicSize = sizeOfProjection;
        mainCamera.transform.position = new Vector3(xPos, yPos, -10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
