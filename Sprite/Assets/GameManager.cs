using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player _player;
    public GameObject playerPrefab;
    public static GameManager managerInstance;
    public Vector2 spawningPoint;
    public DialogueBox dialogBox;
    public GameOver gameover;
    [HideInInspector]public AudioManager audioManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (managerInstance == null)
        {
            managerInstance = this;
            _player = Instantiate(playerPrefab, spawningPoint, Quaternion.identity).GetComponent<Player>();
            audioManager = GetComponent<AudioManager>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
