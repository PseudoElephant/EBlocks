using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    //Attributes
    private Stack<GameObject> objectsHeld = new Stack<GameObject>();
    private int itemsInStack = 0;
    public Vector2 positionInArray;
    public Container[,] containerArray;

    public enum NeighborContainerEnum
    {
        UP,
        RIGHT,
        DOWN,
        LEFT
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Some Mothods
    public Container[] GetNeighborContainers()
    {
        Container[] neighbors = new Container[4]; //UP, RIGHT, DOWN, LEFT this is the order in which the neighbors are given
        int x = (int)positionInArray.x;
        int y = (int)positionInArray.y;

        //Neighbor Top
        try
        {
            neighbors[(int)NeighborContainerEnum.UP] = containerArray[x,y + 1];
        }
        catch (System.IndexOutOfRangeException exception)
        {
            neighbors[(int)NeighborContainerEnum.UP] = null;
        }

        //Neighbor Right
        try
        {
            neighbors[(int)NeighborContainerEnum.RIGHT] = containerArray[x + 1, y];
        }
        catch (System.IndexOutOfRangeException exception)
        {
            neighbors[(int)NeighborContainerEnum.RIGHT] = null;
        }

        //Neighbor Down
        try
        {
            neighbors[(int)NeighborContainerEnum.DOWN] = containerArray[x, y - 1];
        }
        catch (System.IndexOutOfRangeException exception)
        {
            neighbors[(int)NeighborContainerEnum.DOWN] = null;
        }

        //Neighbor Left
        try
        {
            neighbors[(int)NeighborContainerEnum.LEFT] = containerArray[x - 1, y];
        }
        catch (System.IndexOutOfRangeException exception)
        {
            neighbors[(int)NeighborContainerEnum.LEFT] = null;
        }

        return neighbors;
    }

    public Container GetNeighbor(NeighborContainerEnum direction)
    {
        if (NeighborContainerEnum.UP == direction)
        {
            //Neighbor Top
            try
            {
                return containerArray[(int)positionInArray.x, (int)positionInArray.y + 1];
            }
            catch (System.IndexOutOfRangeException exception)
            {
                return null;
            }
        }

        if (NeighborContainerEnum.RIGHT == direction)
        {
            //Neighbor Top
            try
            {
                return containerArray[(int)positionInArray.x+1, (int)positionInArray.y];
            }
            catch (System.IndexOutOfRangeException exception)
            {
                return null;
            }
        }

        if (NeighborContainerEnum.LEFT == direction)
        {
            //Neighbor Top
            try
            {
                return containerArray[(int)positionInArray.x-1, (int)positionInArray.y];
            }
            catch (System.IndexOutOfRangeException exception)
            {
                return null;
            }
        }

        if (NeighborContainerEnum.DOWN == direction)
        {
            //Neighbor Top
            try
            {
                return containerArray[(int)positionInArray.x, (int)positionInArray.y - 1];
            }
            catch (System.IndexOutOfRangeException exception)
            {
                return null;
            }
        }

        return null;
    }

    public GameObject[] GetItemsHeld()
    {
        GameObject[] copyOfStack = new GameObject[itemsInStack];
        objectsHeld.CopyTo(copyOfStack, 0);
        return copyOfStack;
    }

    public GameObject GetTopItemHeld()
    {
        return objectsHeld.Peek();
    }

    public void AddItemToHold(GameObject item) 
    {
        itemsInStack++;
        item.GetComponent<BlockBase>().container = this; //Passing reference to Block
        objectsHeld.Push(item);
    }

    public void TransferLastObjectData(Container container)
    {
        container.AddItemToHold(objectsHeld.Pop());
        itemsInStack--;
    }

    public GameObject RemoveItemFromHold()
    {
        itemsInStack--;
        GameObject item = objectsHeld.Pop();
        item.GetComponent<BlockBase>().container = null; //Has no parent container
        return item;
    }
}
