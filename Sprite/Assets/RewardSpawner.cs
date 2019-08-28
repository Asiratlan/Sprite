using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    public GameObject reward;

    private void OnDestroy()
    {
        reward.SetActive(true);
    }
}
