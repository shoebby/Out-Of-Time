using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Event_06_GoToWork : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private UnityEvent onInteractEvent = default;
    [SerializeField] private AudioClip officeSounds;
    [SerializeField] private AudioClip eveningSong;
    [SerializeField] private MeshRenderer maincam_quad;
    [SerializeField] private Material maincam_evening;

    [SerializeField] private bool loop = false;

    public string InteractionPrompt => prompt;
    public UnityEvent OnInteract => onInteractEvent;

    public bool Interact(Interactor interactor)
    {
        gameObject.layer = 0;
        StartCoroutine(Sequence_ToWork());

        return true;
    }

    private IEnumerator Sequence_ToWork()
    {
        CanvasController.Instance.FadeAnim("eyes_fadeToBlack");
        AudioManager.Instance.src_music.Stop();
        AudioManager.Instance.PlaySFX(officeSounds);
        PlayerScript.Instance.canMove = false;
        yield return new WaitForSeconds(7f);
        maincam_quad.material = maincam_evening;
        CanvasController.Instance.FadeAnim("eyes_fadeToWhite");
        PlayerScript.Instance.canMove = true;
        AudioManager.Instance.src_music.loop = loop;
        AudioManager.Instance.PlayMusic(eveningSong);
        OnInteract.Invoke();
    }
}