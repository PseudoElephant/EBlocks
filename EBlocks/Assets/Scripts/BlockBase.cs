using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBase : MonoBehaviour
{
    public bool isPushable;
    public bool isPickable;
    public bool isWall;
    public Container container = null; //Where the block is stored

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space)))
        {
            pushBlock(Container.NeighborContainerEnum.RIGHT);
            Debug.Log("WAZAAAAA");
        }
    }

    public bool pushBlock(Container.NeighborContainerEnum direction) //returns true if pushed
    {
        if (canPush(direction))
        {
            Container cont = container.GetNeighbor(direction);
            if (cont != null)
            {
                container.TransferLastObjectData(cont);
                moveBlock(direction);
                return true;
            } else
            {
                return false;
            }
        }
        return false;
    }

    private void moveBlock(Container.NeighborContainerEnum direction)
    {
        transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
    }

    private bool canPush(Container.NeighborContainerEnum direction)
    {
        if (container!=null)
        {
            Container[] arrContainers = container.GetNeighborContainers();

            //RIGHT
            if (direction == Container.NeighborContainerEnum.RIGHT) //Going right
            {
                try
                {
                    GameObject[] items = arrContainers[(int)Container.NeighborContainerEnum.RIGHT].GetItemsHeld();

                    foreach (GameObject item in items)
                    {
                        if (!item.GetComponent<BlockBase>().isPushable)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            //LEFT
            if (direction == Container.NeighborContainerEnum.LEFT) //Going left
            {
                try
                {
                    GameObject[] items = arrContainers[(int)Container.NeighborContainerEnum.LEFT].GetItemsHeld();

                    foreach (GameObject item in items)
                    {
                        if (!item.GetComponent<BlockBase>().isPushable)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            //DOWN
            if (direction == Container.NeighborContainerEnum.DOWN) //Going down
            {
                try
                {
                    GameObject[] items = arrContainers[(int)Container.NeighborContainerEnum.DOWN].GetItemsHeld();

                    foreach (GameObject item in items)
                    {
                        if (!item.GetComponent<BlockBase>().isPushable)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            //UP
            if (direction == Container.NeighborContainerEnum.UP) //Going up
            {
                try
                {
                    GameObject[] items = arrContainers[(int)Container.NeighborContainerEnum.UP].GetItemsHeld();

                    foreach (GameObject item in items)
                    {
                        if (!item.GetComponent<BlockBase>().isPushable)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }

        return false;
    }
}
