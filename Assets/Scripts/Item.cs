using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Item ReferenceItem;
    [SerializeField] private TextMeshProUGUI pointsText;

    private static int points = 0;

    public bool IsDiscovered { get; private set; }

    private void Awake()
    {
        if (ReferenceItem == null)
        {
            ReferenceItem = this.GetComponent<Item>();
        }
    }

    public bool Interact()
    {
        if (!IsDiscovered)
        {
            return IsThisTheSameAsOriginal();
        }
        else
        {
            Debug.Log("This item has already been checked");
            return false;
        }
    }

    public bool IsThisTheSameAsOriginal()
    {
        if (ReferenceItem.transform.position == this.transform.position &&
            ReferenceItem.transform.rotation == this.transform.rotation &&
            ReferenceItem.GetComponent<Renderer>()?.sharedMaterial == GetComponent<Renderer>()?.sharedMaterial)
        {
            Debug.Log("This item is same as original.");
            IsDiscovered = true;
            points--;
            pointsText.text = $"points: {points}";
            return true;
        }
        else
        {
            Debug.Log("You found a difference!");
            FixWrongItem();
            return false;
        }
    }

    public void FixWrongItem()
    {
        this.transform.position = ReferenceItem.transform.position;
        this.transform.rotation = ReferenceItem.transform.rotation;
        this.GetComponent<Renderer>().sharedMaterial = ReferenceItem.GetComponent<Renderer>().sharedMaterial;
        points++;
        pointsText.text = $"points: {points}";
    }
}
