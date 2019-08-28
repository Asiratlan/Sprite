using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI text;
    float _originalTimeScale;

    public void ShowDialogue(string message)
    {
        text.text = message;
        gameObject.SetActive(true);
    }

    public void HideDialogue()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _originalTimeScale = Time.timeScale;
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isPaused = true;
    }

    private void Update()
    {
        if (Input.GetButtonUp("Submit"))
        {
            Time.timeScale = _originalTimeScale;
            gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isPaused = false;
            SceneManager.LoadSceneAsync("Overworld", LoadSceneMode.Single).completed += ev =>
            {
                if (!ev.isDone) return;

                Time.timeScale = 1;
                var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                player.GetComponent<Player>().isPaused = false;
                GameManager.managerInstance.audioManager.PlayMusic("Overworld");
                player.transform.position = new Vector2(-9, 15);
                player.health = player.maxHealth;
                player.state = PlayerState.Moving;
            };
        }
    }
}
