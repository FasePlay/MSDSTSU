using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject GameUI;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject player;

    private void Start()
    {
        GameOverUI.SetActive(false);
        GameUI.SetActive(true);
    }
    public void EndGame()
    {
        print("Gaim ovr");
        print(GameObject.FindGameObjectWithTag("GameOverUI"));
        
        player.SetActive(false);
        //replace this ^ with an animation
    }
}
