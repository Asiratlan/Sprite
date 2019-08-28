using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
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
        }
    }
}
