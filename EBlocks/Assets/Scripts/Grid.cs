using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Grid : MonoBehaviour
{
   
    /// <summary>
    /// The Container Prefab
    /// </summary>
    public GameObject containerPrefab;

    /// <summary>
    /// The Player Instance
    /// </summary>
    public GameObject player;


    /// <summary>
    /// An array containing all Containers in the Grid.
    /// </summary>
    private Container[,] containerArr;

    /// <summary>
    /// Width of the Grid
    /// </summary>
    private int boardWidth;

    /// <summary>
    /// Height of the Grid.
    /// </summary>
    private int boardHeight;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Returns all 4 neighboring Containers in the array from given position an array. Up, Right, Down, Left.
    /// </summary>
    /// <param name="x">x position to check for neighbors</param>
    /// <param name="y">y position to check for neighbors</param>
    /// <returns><see cref="Container"/> Array with Containers if found; Otherwise <c>null</c> will replace missing containers.</returns>
    public Container[] GetNeighbors(float x,float y)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Returns the container at given coordinates.
    /// </summary>
    /// <param name="x">x position</param>
    /// <param name="y">y position</param>
    /// <returns><see cref="Container"/> if found; Otherwise <c>null</c>.</returns>
    public Container GetContainerAt(float x,float y)
    {
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// Returns the container at given index.
    /// </summary>
    /// <param name="i">i index</param>
    /// <param name="j">j index</param>
    /// <returns><see cref="Container"/> if found; Otherwise <c>null</c>.</returns>
    public Container GetContainerAt(int i,int j)
    {
        throw new System.NotImplementedException();
    }

}
