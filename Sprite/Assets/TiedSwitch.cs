using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiedSwitch : Switch
{
    public List<GameObject> switches;

    public override void Interact()
    {
        foreach(GameObject s in switches)
        {
            foreach (var ss in s.GetComponentsInChildren<Switch>())
            {
                ss.changeSwitch();
            }
        }

        GameManager.managerInstance.audioManager.PlaySwitchSound();
    }
}
