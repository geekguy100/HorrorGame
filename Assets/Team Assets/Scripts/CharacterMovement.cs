/*****************************************************************************
// File Name :         CharacterMovement.cs
// Author :            Kyle Grenier
// Creation Date :     03/10/2021
//
// Brief Description : Controls the actual movement of the character.
*****************************************************************************/
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [Tooltip("The character's movement speed.")]
    [SerializeField] private float speed;

    [Tooltip("The amount of gravity the affects this character.")]
    [SerializeField] private float gravity = -9.81f;
    
    // The CharacterController component.
    private CharacterController characterController;

    // The velocity of the character.
    private Vector3 characterVelocity;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    /// <summary>
    /// Moves the character with the provided movement direction.
    /// </summary>
    /// <param name="dir">The direction of the character's movement.</param>
    public void Move(Vector3 dir)
    {
        // Make sure we set our y-velocity to 0 if we're grounded so we don't
        // build up momentum over time.
        if (characterController.isGrounded && characterVelocity.y < 0f)
            characterVelocity.y = 0;

        characterController.Move(dir * speed * Time.deltaTime);

        characterVelocity.y += gravity * Time.deltaTime;
        characterController.Move(characterVelocity * Time.deltaTime);
    }
}
