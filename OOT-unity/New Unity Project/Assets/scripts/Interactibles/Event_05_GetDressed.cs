using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event_05_GetDressed : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private UnityEvent onInteractEvent = default;
    [SerializeField] private SkinnedMeshRenderer smr;
    private Material[] mats;
    [SerializeField] private Material pantsMat;
    [SerializeField] private Material shirtMat;

    public string InteractionPrompt => prompt;
    public UnityEvent OnInteract => onInteractEvent;
    private void Awake()
    {
        mats = smr.materials;
    }

    public bool Interact(Interactor interactor)
    {
        mats[0] = shirtMat;
        mats[1] = pantsMat;
        smr.materials = mats;
        Debug.LogError("Could not find 'tshirt.mat' in scene, are you missing an assembly reference?");

        OnInteract.Invoke();

        return true;
    }
}