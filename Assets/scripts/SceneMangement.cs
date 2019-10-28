using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMangement : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset()
    {
        Pathmaker.GlobalTileCount = 0;
        Pathmaker.drugsCounter = 0;
        Pathmaker.SpawnedTiles.Clear();
        SceneManager.LoadScene(0);
        Debug.Log("reload");
    }
}
