using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeToMainScene(int sceneIndex)
    {
        SceneManager.LoadScene(0);
    }
    public void ChangeToSceneRed(int sceneIndex)
    {
        SceneManager.LoadScene(1);        
    }
    public void ChangeToSceneGreen(int sceneIndex)
    {
        SceneManager.LoadScene(2);
    }

}
