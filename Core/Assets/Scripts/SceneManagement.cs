using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadStart()
    {
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }
    
    public void LoadScene01()
    {
        SceneManager.LoadScene("Scene_01", LoadSceneMode.Single);
    }
    
    public void LoadScene02()
    {
        SceneManager.LoadScene("Scene_02", LoadSceneMode.Single);
    }
    
    public void LoadScene03()
    {
        SceneManager.LoadScene("Scene_03", LoadSceneMode.Single);
    }
}
