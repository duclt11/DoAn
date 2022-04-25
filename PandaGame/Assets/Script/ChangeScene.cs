using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameScene;
    void Start()
    {
        //Debug.log();
        SceneManager.LoadScene(nameScene, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
