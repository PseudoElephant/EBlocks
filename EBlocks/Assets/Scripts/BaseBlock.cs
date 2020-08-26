using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlock : MonoBehaviour
{
    //TODO: Add smoother movement on move

    /// <summary>
    /// Describes whether the block is pushable or not
    /// </summary>
    public bool isPushable { get; }

    /// <summary>
    /// Describes whether the block can be picked up or not
    /// </summary>
    public bool isPickable { get; }
    
    /// <summary>
    /// Describes wether it is possible to go through the object
    /// </summary>
    public bool actAsWall { get; }

    /// <summary>
    /// Item that corresponds to the block.
    /// </summary>
    public GameObject itemPrefab { get; }

    /// <summary>
    /// Container in which the block is held
    /// </summary>
    public Container currentContainer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Retrieves the container where the block is placed in space
    /// </summary>
    /// <returns><see cref="Container"/></returns>
    private Container GetContainer()
    {
        return currentContainer;
    }

    /// <summary>
    /// Tries to move the block in the specified direction <see cref="Grid.Direction"/>
    /// <param name="direction">The Direction where the block should try and move</param>
    /// </summary>
    public void Move(Grid.Direction direction)
    {
        if(currentContainer.TransferItemHeld(direction))
        {
            Vector3 pos = transform.position;
            switch (direction)
            {
                case Grid.Direction.UP:
                    transform.position = new Vector3(pos.x, pos.y+Grid.gridScale, pos.z);
                    break;

                case Grid.Direction.RIGHT:
                    transform.position = new Vector3(pos.x + Grid.gridScale, pos.y, pos.z);
                    break;

                case Grid.Direction.DOWN:
                    transform.position = new Vector3(pos.x, pos.y - Grid.gridScale, pos.z);
                    break;

                case Grid.Direction.LEFT:
                    transform.position = new Vector3(pos.x - Grid.gridScale, pos.y, pos.z);
                    break;
            }
        }
    }

    /// <summary>
    /// Callback when the <see cref="Player"/> collides with the block.
    /// </summary>
    private void OnPlayerCollision()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Callback, get called when <see cref="Player"/> tries to interact (if possible) 
    /// </summary>
    private void OnInteract()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Creates an Item of the current block, and destroys this intane.
    /// </summary>
    /// <returns><see cref="BaseItem"/></returns>
    public BaseItem ConvertToItem()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Destroys the instance.
    /// </summary>
    public void DestroySelf()
    {
        throw new System.NotImplementedException();
    }
}