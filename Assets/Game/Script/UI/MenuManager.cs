using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MenuManager : MonoBehaviour
    {
        //start new game
        public void NewGame()
        {
            Debug.Log("clicked");
            SceneManager.LoadScene(1);
        }
 
        //Quit Game
        public void ExitGame()
        {
            Debug.Log("clicked");
            Application.Quit();
        }
    }
}