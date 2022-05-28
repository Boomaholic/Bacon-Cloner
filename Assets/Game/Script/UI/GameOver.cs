using System.Collections;
using UnityEngine;

namespace Control

{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] GameObject gameOverUI;
        private bool isGameOver = false;

        private void OnDestroy()
        {
            GameOverHappened();
        }

        public void GameOverHappened()
        {
            Cursor.lockState = CursorLockMode.None;
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
            isGameOver = true;
        }

        public bool IsGameOver() { return isGameOver; }
    }
}