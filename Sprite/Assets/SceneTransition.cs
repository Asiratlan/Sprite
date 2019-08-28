using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string SceneName;
    public Vector2 PlayerPositionOnScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            collision.GetComponent<Player>().isPaused = true;
            
            SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single).completed += ev =>
            {
                if (!ev.isDone) return;
                
                Time.timeScale = 1;
                collision.GetComponent<Player>().isPaused = false;
                GameManager.managerInstance.audioManager.PlayMusic(SceneName);
                collision.transform.position = PlayerPositionOnScene;
            };
        }
    }
}
