using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Sprite[] _Livenum;
    [SerializeField]
    private Image LivesImg;

    void Start()
    {
        _scoreText.text = "Score: " + 0;
    }
    public void ScoreDisplay(int pscore)
    {
        _scoreText.text = "Score: " + pscore;
    }
    public void UpdateLives(int Livesleft)
    {
        LivesImg.sprite = _Livenum[Livesleft];
    }
    

    
       
   
}
