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
        throw new System.NotImplementedException();
    }
    
    /// <summary>
    /// Transfers the current item to another <see cref="Container"/> if possible.
    /// </summary>
    /// <param name="container">The contaienr to which the item is being transfered</param>
    public bool TransferItemHeld(Grid.Direction direction)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Removes the item being held at the moment
    /// </summary>
    /// <returns><see cref="BaseBlock"/></returns>
    public BaseBlock RemoveItemHeld()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Adds an item for the conteiner to hold
    /// </summary>
    public void AddItemHeld()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Gets the neighbor Containers 
    /// </summary>
    /// <param name="direction"> Direction which the neighbor container should be fetched.</param>
    /// <returns><see cref="Container"/></returns>
    public Container GetNeighbor(Grid.Direction direction)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Gets all of the available neighbor containers.
    /// </summary>
    /// <returns>All of the neighbors <see cref="Container"/></returns>
    public Container[] GetNeighbors()
    {
        throw new System.NotImplementedException();
    }
}