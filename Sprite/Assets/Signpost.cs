using UnityEngine;
using UnityEditor;

public class Signpost : Interactable
{
    public string text;

    public override void Interact()
    {
        GameManager.managerInstance.audioManager.PlayInteractSound();
        GameManager.managerInstance.dialogBox.ShowDialogue(text);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.managerInstance.dialogBox.HideDialogue();
    }
}