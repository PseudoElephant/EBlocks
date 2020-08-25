using UnityEngine;
using UnityEditor;
using System.IO;

public class Grid : MonoBehaviour
{

    // Public Properties 

    public int widthBoard;
    public int heightBoard;
 
    public GameObject linePrefabUp;
    public GameObject linePrefabHor;

    public GameObject blockPrefab;


    // Start is called before the first frame update
    void Start()
    {
    
        Camera mainCamera = Camera.main;
        float sizeOfProjection = (0.5466F*Mathf.Max(widthBoard,heightBoard)) + 1.7007F; // Regression line gathered from data y = 0.5466x + 1.7007

            mainCamera.orthographicSize = sizeOfProjection;
        
            mainCamera.transform.position = new Vector3(widthBoard/2, heightBoard/2, -10);
            
        

        // Intantiate Grid Could be built from a layout
        for(int i = 1;i<widthBoard;i++){
            GameObject lRendererRef= Instantiate(linePrefabUp,new Vector3(i,0,1),Quaternion.identity);
            lRendererRef.transform.localScale = new Vector3(1,heightBoard,1);
      


            
            for(int j = 1;j<heightBoard;j++){
                GameObject lRendererRef2 = Instantiate(linePrefabHor,new Vector3(0,j,1),Quaternion.identity);
            lRendererRef2.transform.localScale = new Vector3(widthBoard,1,1);
            }
        }
    }

    
    // Update is called once per frame
    void Update()
    {

    }


}
