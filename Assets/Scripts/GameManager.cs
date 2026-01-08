using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject win;
    
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameOver.SetActive(false);
        win.SetActive(false);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }
    public void Win()
    {
        win.SetActive(true);
    }
}
