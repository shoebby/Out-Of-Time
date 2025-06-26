using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event_04_Breakfast : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private UnityEvent onInteractEvent = default;
    [SerializeField] private AudioClip breakfastClip;

    public string InteractionPrompt => prompt;
    public UnityEvent OnInteract => onInteractEvent;

    public bool Interact(Interactor interactor)
    {
        gameObject.layer = 0;
        StartCoroutine(Sequence_Breakfast());

        return true;
    }

    private IEnumerator Sequence_Breakfast()
    {
        if (Random.Range(1,3) == 1)
        {
            CanvasController.Instance.FadeAnim("eyes_fadeToBlack");
            AudioManager.Instance.PlaySFX(breakfastClip);
            PlayerScript.Instance.canMove = false;
            yield return new WaitForSeconds(breakfastClip.length);
            CanvasController.Instance.FadeAnim("eyes_fadeToWhite");
            PlayerScript.Instance.canMove = true;
        } else
        {
            ConsoleLogger.Instance.MakeLog("could not find 'cerealbox' - reconnecting to different host client", LogType.Error);
        }
        
        OnInteract.Invoke();
    }
}