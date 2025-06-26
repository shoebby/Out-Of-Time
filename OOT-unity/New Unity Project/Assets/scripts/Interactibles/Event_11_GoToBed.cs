using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Event_11_GoToBed : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private UnityEvent onInteractEvent = default;

    public string InteractionPrompt => prompt;
    public UnityEvent OnInteract => onInteractEvent;

    public bool Interact(Interactor interactor)
    {
        OnInteract.Invoke();
        StartCoroutine(Sequence_ToBed());

        return true;
    }

    private IEnumerator Sequence_ToBed()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}