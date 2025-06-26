using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event_08_Shower : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private UnityEvent onInteractEvent = default;
    [SerializeField] private SkinnedMeshRenderer smr;
    private Material[] mats;
    [SerializeField] private Material pyjamaPantsMat;
    [SerializeField] private Material pyjamaShirtMat;
    [SerializeField] private AudioClip showerSounds;

    public string InteractionPrompt => prompt;
    public UnityEvent OnInteract => onInteractEvent;

    private void Awake()
    {
        mats = smr.materials;
    }

    public bool Interact(Interactor interactor)
    {
        gameObject.layer = 0;
        StartCoroutine(Sequence_ToWork());

        return true;
    }

    private IEnumerator Sequence_ToWork()
    {
        CanvasController.Instance.FadeAnim("eyes_fadeToBlack");
        AudioManager.Instance.PlaySFX(showerSounds);
        PlayerScript.Instance.canMove = false;
        yield return new WaitForSeconds(showerSounds.length);
        mats[0] = pyjamaShirtMat;
        mats[1] = pyjamaPantsMat;
        smr.materials = mats;
        CanvasController.Instance.FadeAnim("eyes_fadeToWhite");
        PlayerScript.Instance.canMove = true;
        OnInteract.Invoke();
    }
}