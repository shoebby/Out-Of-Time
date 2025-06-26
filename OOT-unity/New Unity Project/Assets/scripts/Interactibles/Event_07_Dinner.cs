using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event_07_Dinner : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private UnityEvent onInteractEvent = default;
    [SerializeField] private AudioClip dinnerClip;

    public string InteractionPrompt => prompt;
    public UnityEvent OnInteract => onInteractEvent;

    public bool Interact(Interactor interactor)
    {
        gameObject.layer = 0;
        StartCoroutine(Sequence_Dinner());

        return true;
    }

    private IEnumerator Sequence_Dinner()
    {
        CanvasController.Instance.FadeAnim("eyes_fadeToBlack");
        AudioManager.Instance.PlaySFX(dinnerClip);
        PlayerScript.Instance.canMove = false;
        yield return new WaitForSeconds(dinnerClip.length);
        CanvasController.Instance.FadeAnim("eyes_fadeToWhite");
        PlayerScript.Instance.canMove = true;
        OnInteract.Invoke();
    }
}