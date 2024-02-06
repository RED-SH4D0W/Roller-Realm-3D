using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Called when we click the "Play" button.
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    // Called when we click the "Quit" button.
    public void OnQuitButton()
    {
        //if (Application.isEditor)
        //{
        //    Debug.Log("is Editor");
        //    UnityEditor.EditorApplication.isPlaying = false;
        //}
        //Debug.Log("Application");
        //Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }
}
