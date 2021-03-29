/*****************************************************************************
// File Name :         MouseLookInteraction.cs
// Author :            Kyle Grenier
// Creation Date :     03/26/2021
//
// Brief Description : Enables interacting with objects via raycasts. Typically used for
                       assigning interactables via mouse look.
*****************************************************************************/
using UnityEngine;

[RequireComponent(typeof(IInteractor))]
public class RaycastInteraction : MonoBehaviour
{
    private IInteractor interactor = null;
    private IInteractable interactable = null;


    [Tooltip("The layer(s) used for raycasting IInteractables.")]
    [SerializeField] private LayerMask whatIsInteractable;

    [Tooltip("The Transform that will serve as the origin of the raycast. If null, " +
        "the Transform this component is attached to will be used.")]
    [SerializeField] private Transform origin;

    [Tooltip("The length of the ray that will be cast.")]
    [SerializeField] private float rayLength = 2f;

    private void Awake()
    {
        interactor = GetComponent<IInteractor>();
        if (origin == null)
            origin = transform;
    }

    private void Update()
    {
        CheckForInteractables();
    }

    private void CheckForInteractables()
    {
        // Check to see if we hit an IInteractable.
        if (Physics.Raycast(origin.transform.position, origin.transform.forward, out RaycastHit hit, rayLength, whatIsInteractable))
        {
            interactable = hit.collider.gameObject.GetComponent<IInteractable>();
            if (interactable != null && interactor.GetInteractable() != interactable)       // Only assign the IInteractable if it is new.
                interactor.SetInteractable(interactable);
            else if (interactable == null)
                Debug.Log("Why is " + hit.collider.gameObject.name + " on the Interactable layer? No IInteractable component is present...");
        }
        // If we have an interactable assigned but we're not looking at it, unassign it.
        else if (interactable != null && interactable == interactor.GetInteractable())
        {
            interactor.UnassignInteractable();
        }
    }
}
