using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    
    /// <summary>
    /// Item that is being held by the container, could be <c>null</c>
    /// </summary>
    public BaseBlock blockHeld { get; set; }

    /// <summary>
    /// The <see cref="Grid"/> that is currently being used in the level.
    /// </summary>
    public Grid grid { get; set; }

    /// <summary>
    /// Row index position in the grid space.
    /// </summary>
    public int i { get; set; }
    
    /// <summary>
    /// Column index position in the grid space.
    /// </summary>
    public int j { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Checks if the <see cref="Container"/> contains an <see cref="BaseItem"/>
    /// </summary>
    /// <returns><see cref="bool"/></returns>
    public bool IsEmpty()
    {
        return blockHeld == null;   
    }
    
    /// <summary>
    /// Transfers the current item to another <see cref="Container"/> if possible.
    /// </summary>
    /// <param name="container">The contaienr to which the item is being transfered</param>
    public bool TransferItemHeld(Grid.Direction direction)
    {
<<<<<<< HEAD
        throw new System.NotImplementedException();
    }
=======
        // TODO: Chain Items
        Container container = GetNeighbor(direction);

        if (container?.IsEmpty() ?? true)
        {
            container.AddBlockHeld(blockHeld);
            return true;
        }
        return false;
    }
    
>>>>>>> 6c0b030ce652f0cb8872038171d8a8142a25e727

    /// <summary>
    /// Removes the item being held at the moment
    /// </summary>
    /// <returns><see cref="BaseBlock"/></returns>
    public BaseBlock RemoveBlockHeld()
    {
        BaseBlock block = blockHeld;
        blockHeld = null;
        return blockHeld;
        
    }

    /// <summary>
    /// Adds an item for the conteiner to hold
    /// </summary>
    /// <param name="block">Block that will be added</param>
    public void AddBlockHeld(BaseBlock block)
    {
       if (IsEmpty())
        {
            blockHeld = block;
        }
    }    
    
    /// <summary>
    /// Replaces an item for the conteiner to hold
    /// </summary>
    /// <param name="block">Block that will be added</param>
    public void ReplaceBlockHeld(BaseBlock block)
    {
        // TODO: Should Destroy?
        RemoveBlockHeld();
        blockHeld = block;
    }

    /// <summary>
    /// Gets the neighbor Containers 
    /// </summary>
    /// <param name="direction"> Direction which the neighbor container should be fetched.</param>
    /// <returns><see cref="Container"/></returns>
    public Container GetNeighbor(Grid.Direction direction)
    {
       return grid.GetNeighbors(i, j)[(int)direction];
        
    }

    /// <summary>
    /// Gets all of the available neighbor containers.
    /// </summary>
    /// <returns>All of the neighbors <see cref="Container"/></returns>
    public Container[] GetNeighbors()
    {
        return grid.GetNeighbors(i, j);   
    }
}