using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _GameOver = false;
    public void GameOver()
    {
        _GameOver = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _GameOver == true)
        {
            SceneManager.LoadScene(1);
        }
        if(Input.GetKeyDown(KeyCode.M) && _GameOver == true)
        {
            SceneManager.LoadScene(0);
        }
    }
}
