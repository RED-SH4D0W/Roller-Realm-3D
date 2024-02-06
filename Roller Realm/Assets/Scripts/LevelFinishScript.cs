using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishScript : MonoBehaviour
{

    public GameObject gameFinishedUI;

    public void gameOver()
    {
        gameFinishedUI.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered the game completion checkpoint");
        Destroy(other.gameObject);
        gameOver();
    }
}
