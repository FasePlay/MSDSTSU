using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject GameUI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject player;

    private void Start()
    {
        GameOverUI.SetActive(false);
        GameUI.SetActive(true);
    }
    public void EndGame()
    {
        Debug.Log("Gaim ovr");
        Debug.Log(GameObject.FindGameObjectWithTag("GameOverUI"));
        player.SetActive(false);
        
    }
}
