using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    private float cameraStartY;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraStartY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pathmaker.SpawnedTiles.Count > 0)
        {
           PositionCamera();
        }
    }

    private void PositionCamera()
    {
        Vector3 positionTotal = new Vector3(0f, 0f, 0f);

        float maxX = 1;
        float maxZ = 1;
        float minX = 1;
        float minZ = 1;
        
        for (int i = 0; i < Pathmaker.SpawnedTiles.Count; i++)
        {
            positionTotal += Pathmaker.SpawnedTiles[i].position;
            
            if (Pathmaker.SpawnedTiles[i].position.x > maxX)
            {
                Debug.Log(("found maxX"));
                maxX = Pathmaker.SpawnedTiles[i].position.x;
            }
            if (Pathmaker.SpawnedTiles[i].position.x < minX)
            {
                Debug.Log(("found minX"));

                minX = Pathmaker.SpawnedTiles[i].position.x;
            }
            if (Pathmaker.SpawnedTiles[i].position.z > maxZ)
            {
                maxZ = Pathmaker.SpawnedTiles[i].position.z;
                Debug.Log(("found maxZ"));

            }
            if (Pathmaker.SpawnedTiles[i].position.z < minZ)
            {
                minZ = Pathmaker.SpawnedTiles[i].position.z;
                Debug.Log(("found minZ"));

            }
        }

        float width =  maxX - minX;

        float height = maxZ - minZ;

        Debug.Log("width: " + width);
        Debug.Log("height: " + height);

        float area = height * width;
        
        Debug.Log(("area: " + area));

        float amountToMoveY = cameraStartY + area / 120;
        

        Vector3 averagePostion = positionTotal / Pathmaker.SpawnedTiles.Count;

        transform.position = new Vector3(averagePostion.x, amountToMoveY, averagePostion.z);
    }
}
