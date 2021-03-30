/*****************************************************************************
// File Name :         NotePickup.cs
// Author :            Kyle Grenier
// Creation Date :     #CREATIONDATE#
//
// Brief Description : Defines behaviour for interacting with the in game notes.
*****************************************************************************/
using UnityEngine;

public struct JournalPage
{
    public JournalPage(int id, Sprite documentSprite, Sprite iconSprite)
    {
        this.id = id;
        this.documentSprite = documentSprite;
        this.iconSprite = iconSprite;
    }

    public int id { get; private set; }
    public Sprite documentSprite { get; private set; }
    public Sprite iconSprite { get; private set; }
}

public class NotePickup : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject noteOutline;

    [SerializeField] private int id;
    [SerializeField] private Sprite documentSprite;
    [SerializeField] private Sprite iconSprite;

    public void InRangeAction(GameObject interactor)
    {
        noteOutline.SetActive(true);
    }

    public void Interact(GameObject interactor)
    {
        print("Note pickup");
        JournalPage page = new JournalPage(id, documentSprite, iconSprite);
        EventManager.PagePickup(page);
        gameObject.SetActive(false);
    }

    public void OutOfRangeAction(GameObject interactor)
    {
        if (gameObject.activeInHierarchy)
            noteOutline.SetActive(false);
        else
            Destroy(gameObject);
    }
}
