using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactibleMask = 1 << 9;
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    private readonly Collider[] colliders = new Collider[3]; //can be raised if there are more interactibles in a single scene
    [SerializeField] private int numFound;

    private IInteractable interactible;

    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactibleMask);

        if (numFound > 0)
        {
            interactible = colliders[0].GetComponent<IInteractable>();

            if (interactible != null)
            {
                CanvasController.Instance.interactionPrompt_text.text = interactible.InteractionPrompt;
                if (!CanvasController.Instance.interactionPrompt.activeSelf)
                {
                    CanvasController.Instance.ToggleElement(CanvasController.Instance.interactionPrompt);
                }
                if (Input.GetKeyDown(interactKey))
                {
                    interactible.Interact(this);
                }
                    
            }
        }
        else
        {
            if (interactible != null)
            {
                CanvasController.Instance.ToggleElement(CanvasController.Instance.interactionPrompt);
                interactible = null;
            }
                
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
