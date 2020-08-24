<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
=======
﻿using UnityEngine;
using UnityEditor;
using System.IO;

[RequireComponent(typeof(MeshFilter))]
public class Grid : MonoBehaviour
{

    // Public Properties 

    public int widthBoard;
    public int heightBoard;

    public GameObject background;

    public GameObject blockPrefab;


    public TextAsset textAsset;
    
 [MenuItem("Tools/Write file")]
    static void WriteString()
    {
        string path = "Assets/Resources/test.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Test");
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path); 
        TextAsset asset = (TextAsset) Resources.Load("test");

        //Print the text from the file
        Debug.Log(asset.text);
    }

    [MenuItem("Tools/Read file")]
    static void ReadString()
    {
        string path = "Assets/Resources/test.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path); 
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
    // Start is called before the first frame update
    void Start()
    {
    
    Camera mainCamera = Camera.main;
    float sizeOfProjection = (0.5466F*Mathf.Max(widthBoard,heightBoard)) + 1.7007F; // Regression line gathered from data y = 0.5466x + 1.7007

        mainCamera.orthographicSize = sizeOfProjection;
     
        mainCamera.transform.position = new Vector3(widthBoard/2, heightBoard/2, -10);
        
    

    // Intantiate Grid Could be built from a layout

    for(int i = 0;i<widthBoard;i++){
        for(int j = 0;j<heightBoard;j++){
            Instantiate(blockPrefab, new Vector3(i, j, 0), Quaternion.identity);
        }
    }
    }

    
    // Update is called once per frame
    void Update()
    {

    }

    
>>>>>>> 64eee906655a14488020621cbc617546d808ffcd
}
