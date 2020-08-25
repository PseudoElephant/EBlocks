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
    public GameObject containerPrefab;

    private Container[,] containerArray;


    // Start is called before the first frame update
    void Start()
    {
        containerArray = new Container[widthBoard,heightBoard]; //2D Array

        Camera mainCamera = Camera.main;
        float sizeOfProjection = (0.5466F*Mathf.Max(widthBoard,heightBoard)) + 1.7007F; // Regression line gathered from data y = 0.5466x + 1.700
        mainCamera.orthographicSize = sizeOfProjection;
        mainCamera.transform.position = new Vector3(widthBoard/2+0.5f, heightBoard/2+0.5f, -10);
            
        
        // Intantiate Grid Could be built from a layout
        for(int i = 0;i<widthBoard;i++){
            if (i != 0) //Removes first row
            {
                GameObject lRendererRef = Instantiate(linePrefabUp, new Vector3(i, 0, 1), Quaternion.identity);
                lRendererRef.transform.localScale = new Vector3(1, heightBoard, 1);
            }

            for(int j = 0;j<heightBoard;j++){
                if (j != 0) //Removes first col
                {
                    GameObject lRendererRef2 = Instantiate(linePrefabHor, new Vector3(0, j, 1), Quaternion.identity);
                    lRendererRef2.transform.localScale = new Vector3(widthBoard, 1, 1);
                }

                GameObject container = Instantiate(containerPrefab, new Vector3(i+0.5f, j+0.5f, 1), Quaternion.identity); //Adding Containers to Array
                containerArray[i, j] = container.GetComponent<Container>();
                container.GetComponent<Container>().positionInArray = new Vector2(i, j); //Passing position to container
                container.GetComponent<Container>().containerArray = containerArray; //Passing container Array
            }
        }
    }

    
    // Update is called once per frame
    void Update()
    {

    }

    //Getter Method
    public Container[,] getContainerArray()
    {
        return containerArray;
    }

}
