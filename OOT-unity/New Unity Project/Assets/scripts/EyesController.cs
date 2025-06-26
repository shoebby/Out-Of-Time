using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyesController : MonoBehaviour
{
    private Image eyesImage;
    private Animator eyesAnim;

    private void Awake()
    {
        eyesImage = GetComponent<Image>();
        eyesAnim = GetComponent<Animator>();
    }

    public void Animate(string animName)
    {
        eyesAnim.Play(animName);
    }
}
