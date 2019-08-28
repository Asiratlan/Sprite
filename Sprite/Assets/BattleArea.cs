using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleArea : MonoBehaviour
{
    public GameObject enemyPool;
    public GameObject obstaclePool;

    public GameObject rewardObstacle;

    private Enemy[] _enemies;
    private bool _inBattle;

    // Start is called before the first frame update
    void Start()
    {
        StopBattle();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inBattle)
        {
            if (_enemies.All(e => !e))
            {
                StopBattle();
                if(rewardObstacle != null)
                {
                    rewardObstacle.gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            StartBattle();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            StopBattle();
        }
    }

    public void StartBattle()
    {
        _inBattle = true;
        _enemies = enemyPool.GetComponentsInChildren<Enemy>();
        GameManager.managerInstance.audioManager.PlayCombatMusic();
        foreach (var enemy in _enemies)
        {
            enemy.controller.aiPath.enabled = true;
            enemy.controller.aiActive = true;
        }

        obstaclePool.SetActive(true);
    }

    public void StopBattle()
    {
        _inBattle = false;
        GameManager.managerInstance.audioManager.PlayMusic(SceneManager.GetActiveScene().name);
        foreach (var enemy in enemyPool.GetComponentsInChildren<Enemy>())
        {
            enemy.controller.aiPath.enabled = false;
            enemy.controller.aiActive = false;
            enemy.transform.position = enemy.originalPosition;
        }

        obstaclePool.SetActive(false);
    }
}
