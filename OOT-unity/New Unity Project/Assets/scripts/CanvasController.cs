using TMPro;
using UnityEngine;

public class CanvasController : Singleton<CanvasController>
{
    public GameObject interactionPrompt;
    public TextMeshProUGUI interactionPrompt_text;
    public Animator eyesAnim;

    protected override void Awake()
    {
        base.Awake();
        interactionPrompt.SetActive(false);
        eyesAnim = GetComponentInChildren<Animator>();
    }

    public void ToggleElement(GameObject el)
    {
        el.SetActive(!el.activeSelf);
    }

    public void FadeAnim(string anim)
    {
        eyesAnim.Play(anim);
    }
}