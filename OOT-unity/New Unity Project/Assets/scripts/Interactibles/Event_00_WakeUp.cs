using UnityEngine;
using UnityEngine.Events;

public class Event_00_WakeUp : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private UnityEvent onInteractEvent = default;
    
    public string InteractionPrompt => prompt;
    public UnityEvent OnInteract => onInteractEvent;

    public bool Interact(Interactor interactor)
    {
        PlayerScript.Instance.canMove = true;
        
        OnInteract.Invoke();

        return true;
    }
}