/*****************************************************************************
// File Name :         Journal.cs
// Author :            Kyle Grenier
// Creation Date :     #CREATIONDATE#
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;

public class Journal : UIWindow
{
    [SerializeField] private Image[] entrySpots;

    private Sprite[] documentSprites;
    [SerializeField] private Image documentArea;

    private bool journalOpen = false;
    public bool isOpen { get { return journalOpen; } }


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

    public override void OpenWindow()
    {
        base.OpenWindow();

        journalOpen = true;

        GetComponent<CanvasGroup>().alpha = 1;

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public override void CloseWindow()
    {
        print("JOURNAL CLOSING");
        base.CloseWindow();

        journalOpen = false;

        GetComponent<CanvasGroup>().alpha = 0;

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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