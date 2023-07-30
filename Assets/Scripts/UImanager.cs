using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UImanager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Sprite[] _Livenum;
    [SerializeField]
    private Image LivesImg;
    [SerializeField]
    private Text _GameOver;
    [SerializeField]
    private Text _restart;
    private GameManager _gameManager;
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void ScoreDisplay(int pscore)
    {
        _scoreText.text = "Score: " + pscore;
    }
    public void UpdateLives(int Livesleft)
    {
        LivesImg.sprite = _Livenum[Livesleft];
    }
    public void TextApear()
    {
        _gameManager.GameOver();
        _restart.gameObject.SetActive(true);
        _GameOver.gameObject.SetActive(true);
        StartCoroutine(textFlicking());
    }
    
    IEnumerator textFlicking()
    {
        while (true)
        {
            _GameOver.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            _GameOver.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
