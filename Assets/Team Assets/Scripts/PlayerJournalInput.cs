/*****************************************************************************
// File Name :         PlayerJournalInput.cs
// Author :            Kyle Grenier
// Creation Date :     03/29/2021
//
// Brief Description : Handles getting input to open and close the journal.
*****************************************************************************/
using UnityEngine;

public class PlayerJournalInput : MonoBehaviour
{
    [SerializeField] private Journal journal;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !journal.isOpen)
            journal.OpenWindow();
        else if (Input.GetKeyDown(KeyCode.J))
            journal.CloseWindow();
        
    }
}
