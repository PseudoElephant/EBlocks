using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseItem : MonoBehaviour
{

/// <summary>
/// Name of the Item
/// </summary>
    public string itemName;

    /// <summary>
    /// Prefab of the matching block in respect of to item.
    /// </summary>
    public GameObject prefabBaseBlock;

    /// <summary>
    /// Icon of the item (maybe use sprite renderer?)
    /// </summary>
    public Image iconItem;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// Destroys current item and creates a block with the prefab.
    /// </summary>
    /// <returns><see cref="bool"/></returns>
    public bool ConvertToBaseBlock()
    {
        throw new System.NotImplementedException();
    }


    /// <summary>
    /// Creates a block with the current prefab, (it does not delete current item instance)
    /// </summary>
    /// <returns><see cref="bool"/></returns>
    public bool CreateBlock()
    {
        throw new System.NotImplementedException();
    }
}