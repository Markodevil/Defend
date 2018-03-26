using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour
{
    public void BackBtn(string menuLevel)
    {
        //when the Start button is hit - Start Game
        SceneManager.LoadScene(menuLevel);

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}