using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadGame(int index)
    {
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
