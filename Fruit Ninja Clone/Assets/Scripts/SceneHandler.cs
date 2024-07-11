using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour
{
    [SerializeField] private PlayFruit playFruit;
    [SerializeField] private ExitBomb exitBomb;
    private void Start()
    {
        playFruit = GameObject.Find("PlayFruit").GetComponent<PlayFruit>();
        exitBomb = GameObject.Find("ExitBomb").GetComponent<ExitBomb>();
    }
    private void Update()
    {
        if (playFruit.gameStarted)
        {
            StartCoroutine(SceneSwapWithDelay());
        }

        if (exitBomb.gameExit)
        {
            StartCoroutine(GameQuit());
        }

    }

    IEnumerator SceneSwapWithDelay()
    {

        yield return new WaitForSeconds(2f);
        Debug.Log("Scene is loading...");
        SceneManager.LoadScene("Main");
    }

    IEnumerator GameQuit()
    {

        yield return new WaitForSeconds(2f);
        Debug.Log("Game quited");
        Application.Quit();
        
    }
}



