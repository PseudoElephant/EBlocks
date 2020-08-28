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

    /// <summary>
    /// Returns the equivalent baseblock of the item
    /// </summary>
    /// <returns><see cref="GameObject"/>Prefab of equivalent Base Block</returns>
    public GameObject EquivalentBaseBlock()
    {
        return prefabBaseBlock;
    }
}