using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    //TODO: Sprites might get fucked if we scale grid to more than one unit per square (AKA: If (gridSize>1): fucked = true)
   
    /// <summary>
    /// The Container Prefab
    /// </summary>
    public GameObject containerPrefab;

    /// <summary>
    /// The Player Instance
    /// </summary>
    public GameObject player;

    /// <summary>
    /// Horizontal grid line prefab
    /// </summary>
    public GameObject horizontalLinePrefab;

    /// <summary>
    /// Vertical grid line prefab
    /// </summary>
    public GameObject verticalLinePrefab;

    /// <summary>
    /// An array containing all Containers in the Grid.
    /// </summary>
    private Container[,] containerArr;

    /// <summary>
    /// Width of the Grid
    /// </summary>
    private int gridWidth { get; set; }

    /// <summary>
    /// Height of the Grid.
    /// </summary>
    private int gridHeight { get; set; }

    public static float gridScale = 1;

    /// <summary>
    /// Enum that determines the direction.
    /// </summary>
    public enum Direction
    {
        UP = 0,
        RIGHT = 1,
        DOWN = 2,
        LEFT = 3
    }

    private void Awake()
    {
        gridHeight = 5;
        gridWidth = 7;
    }

    // Start is called before the first frame update
    void Start()
    {

        InitializeVisualGuidesToGrid();
        InitializeContainersToGrid();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if(Input.GetMouseButtonDown(0))
        //{
        //    Container[] conts = GetNeighbors(pos.x, pos.y);

        //    foreach(Container cont in conts)
        //    {
        //        Debug.Log(cont);
        //    }
        //}
    }

    private void InitializePlayer(int i, int j)
    {
        Mathf.Clamp(i, 0, gridWidth - 1);
        Mathf.Clamp(j, 0, gridHeight - 1);

        GameObject thePlayer = Instantiate(player, new Vector3(i * gridScale + 0.5f * gridScale, j * gridScale + 0.5f * gridScale, 1), Quaternion.identity);
        thePlayer.transform.localScale = new Vector3(gridScale, gridScale, 1); //Scale image to fit grid size
        thePlayer.GetComponent<Player>().grid = this; //Passing grid reference
    }

    /// <summary>
    /// Adds all of the containers to the grid and initializes containerArr
    /// </summary>
    public void InitializeContainersToGrid()
    {
        containerArr = new Container[gridWidth, gridHeight]; //Initializing Array

        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                GameObject container = Instantiate(containerPrefab, new Vector3(i*gridScale + 0.5f * gridScale, j*gridScale + 0.5f * gridScale, 1), Quaternion.identity);
                container.transform.localScale = new Vector3(gridScale, gridScale, 1); //Scale image to fit grid size

                Container currentCont = container.GetComponent<Container>();
                containerArr[i, j] = currentCont; //Adding Containers to Array
                currentCont.i = i; //Passing position to container
                currentCont.j = j;
                currentCont.grid = this; //Passing grid reference
            }
        }
    }

    /// <summary>
    /// Adds all the grid lines to the grid
    /// </summary>
    public void InitializeVisualGuidesToGrid()
    {
        for (int i = 1; i < gridWidth; i++)
        {
            GameObject lRendererRef = Instantiate(verticalLinePrefab, new Vector3(i * gridScale, 0, 1), Quaternion.identity);
            lRendererRef.transform.localScale = new Vector3(gridScale, gridHeight * gridScale, 1);

            for (int j = 1; j < gridHeight; j++)
            {
                GameObject lRendererRef2 = Instantiate(horizontalLinePrefab, new Vector3(0, j * gridScale, 1), Quaternion.identity);
                lRendererRef2.transform.localScale = new Vector3(gridWidth * gridScale, gridScale, 1);
            }
        }
    }

    /// <summary>
    /// Returns all 4 neighboring Containers in the array if found; Otherwise null. If position is outside array range array is full of null.
    /// </summary>
    /// <param name="x">x position to check for neighbors</param>
    /// <param name="y">y position to check for neighbors</param>
    /// <returns><see cref="Container"/> Array with Containers if found; Otherwise null will replace missing containers.</returns>
    public Container[] GetNeighbors(float x,float y)
    {
        int xPos = Mathf.FloorToInt(x/gridScale);
        int yPos = Mathf.FloorToInt(y/gridScale);

        //Check if the position is inside the grid, otherwise returns a null array
        if ((xPos >= gridWidth) || (yPos >= gridHeight) || (xPos < 0) || (yPos < 0))
        {
            Container[] nullArr = { null, null, null, null };
            return nullArr;
        }

        //Initialize array
        Container[] neighbors = new Container[4];

        for (int i = 0; i < neighbors.Length; i++)
        {
            switch (i)
            {
                case 0: //Up
                    if(yPos+1 >= gridHeight)
                    {
                        neighbors[(int)Direction.UP] = null;
                    } else
                    {
                        neighbors[(int)Direction.UP] = containerArr[xPos, yPos + 1];
                    }

                    break;

                case 1: //Right
                    if (xPos + 1 >= gridWidth)
                    {
                        neighbors[(int)Direction.RIGHT] = null;
                    }
                    else
                    {
                        neighbors[(int)Direction.RIGHT] = containerArr[xPos + 1, yPos];
                    }

                    break;

                case 2: //Down
                    if (yPos - 1 < 0)
                    {
                        neighbors[(int)Direction.DOWN] = null;
                    }
                    else
                    {
                        neighbors[(int)Direction.DOWN] = containerArr[xPos, yPos-1];
                    }

                    break;

                case 3: //Left
                    if (xPos - 1 < 0)
                    {
                        neighbors[(int)Direction.LEFT] = null;
                    }
                    else
                    {
                        neighbors[(int)Direction.LEFT] = containerArr[xPos - 1, yPos];
                    }

                    break;
            }
        }

        return neighbors;
    }

    /// <summary>
    /// Returns all 4 neighboring Containers in the array if found; Otherwise null. If position is outside array range array is full of null.
    /// </summary>
    /// <param name="x">x position to check for neighbors</param>
    /// <param name="y">y position to check for neighbors</param>
    /// <returns><see cref="Container"/> Array with Containers if found; Otherwise <c>null</c> will replace missing containers.</returns>
    public Container[] GetNeighbors(int i, int j)
    {
        //Check if the position is inside the grid, otherwise returns a null array
        if ((i >= gridWidth) || (j >= gridHeight) || (i < 0) || (j < 0))
        {
            Container[] nullArr = { null, null, null, null };
            return nullArr;
        }

        //Initialize array
        Container[] neighbors = new Container[4];

        for (int x = 0; x < neighbors.Length; x++)
        {
            switch (x)
            {
                case 0: //Up
                    if (j + 1 >= gridHeight)
                    {
                        neighbors[(int)Direction.UP] = null;
                    }
                    else
                    {
                        neighbors[(int)Direction.UP] = containerArr[i, j + 1];
                    }

                    break;

                case 1: //Right
                    if (i + 1 >= gridWidth)
                    {
                        neighbors[(int)Direction.RIGHT] = null;
                    }
                    else
                    {
                        neighbors[(int)Direction.RIGHT] = containerArr[i + 1, j];
                    }

                    break;

                case 2: //Down
                    if (j - 1 < 0)
                    {
                        neighbors[(int)Direction.DOWN] = null;
                    }
                    else
                    {
                        neighbors[(int)Direction.DOWN] = containerArr[i, j - 1];
                    }

                    break;

                case 3: //Left
                    if (i - 1 < 0)
                    {
                        neighbors[(int)Direction.LEFT] = null;
                    }
                    else
                    {
                        neighbors[(int)Direction.LEFT] = containerArr[i - 1, j];
                    }

                    break;
            }
        }

        return neighbors;
    }

    /// <summary>
    /// Returns the container at given coordinates if found; Otherwise returns null.
    /// </summary>
    /// <param name="x">x position</param>
    /// <param name="y">y position</param>
    /// <returns><see cref="Container"/> if found; Otherwise null.</returns>
    public Container GetContainerAt(float x,float y)
    {
        int xPos = Mathf.FloorToInt(x / gridScale);
        int yPos = Mathf.FloorToInt(y / gridScale);

        if ((xPos >= gridWidth) || (yPos >= gridHeight) || (xPos < 0) || (yPos < 0))
        {
            return null;
        }

        return containerArr[xPos, yPos];
    }

    /// <summary>
    /// Returns the container at given index.
    /// </summary>
    /// <param name="i">i index</param>
    /// <param name="j">j index</param>
    /// <returns><see cref="Container"/> if found; Otherwise null.</returns>
    public Container GetContainerAt(int i,int j)
    {
        if ((i >= gridWidth) || (j >= gridHeight) || (i < 0) || (j < 0))
        {
            return null;
        }

        return containerArr[i, j];
    }

    public Vector2 GetGridSize()
    {
        return new Vector2(gridWidth,gridHeight);
    }
}