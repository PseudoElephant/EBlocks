using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Attributes
    /// <summary>
    /// Grid Prefab
    /// </summary>
    private GameObject grid;

    /// <summary>
    /// File Path for the stored level
    /// </summary>
    private string filePath;
    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Generates the level described by the given file (creates grid with contents)
    /// </summary>
    private void GenerateLevel()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// start running the current level
    /// </summary>
    private void StartLevel()
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
