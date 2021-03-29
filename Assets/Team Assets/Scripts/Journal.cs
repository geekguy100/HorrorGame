/*****************************************************************************
// File Name :         Journal.cs
// Author :            Kyle Grenier
// Creation Date :     #CREATIONDATE#
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{
    [SerializeField] private Image[] entrySpots;

    private Sprite[] documentSprites;
    [SerializeField] private Image documentArea;

    private bool journalOpen = false;


    private void OnEnable()
    {
        EventManager.OnPagePickup += AddPage;
    }

    private void OnDisable()
    {
        EventManager.OnPagePickup -= AddPage;
    }

    private void Start()
    {
        documentSprites = new Sprite[entrySpots.Length];
    }

    public void OpenJournal()
    {
        journalOpen = !journalOpen;

        GetComponent<CanvasGroup>().alpha = System.Convert.ToInt16(journalOpen);

        if (journalOpen)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void DisplayPage(int id)
    {
        documentArea.sprite = documentSprites[id - 1];
        documentArea.enabled = true;
    }

    private void AddPage(JournalPage page)
    {
        print("ADDED PAGE");
        entrySpots[page.id - 1].sprite = page.iconSprite;
        documentSprites[page.id - 1] = page.documentSprite;
        entrySpots[page.id - 1].enabled = true;
    }
}