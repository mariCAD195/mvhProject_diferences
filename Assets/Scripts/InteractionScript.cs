using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _crosshair;

    [SerializeField] private LayerMask _mask;

    private Item _lastInteraction;
    private bool allowInteractions = true;

    public bool AllowInteractions
    {
        get => allowInteractions;
        set => allowInteractions = value;
    }

    public void OnInteractionPressed(InputAction.CallbackContext ctx)
    {
        if (allowInteractions)
        {
            if (!ctx.performed)
            {
                return;
            }

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit info, 5f,
                    _mask))
            {
                if (info.transform.TryGetComponent(out Item gameItem))
                {
                    gameItem.Interact();
                }
            }

            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 5f, Color.red, 1f);
        }
    }

    public void Update()
    {
        if (allowInteractions)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit info, 5f,
                    _mask))
            {
                if (info.transform.TryGetComponent(out Item gameItem))
                {
                    _crosshair.color = Color.chartreuse;

                    _lastInteraction = gameItem;
                }
                else
                {
                    _crosshair.color = Color.white;

                    if (_lastInteraction != null)
                    {
                        _lastInteraction = null;
                    }
                }

                return;
            }

            _crosshair.color = Color.white;

            if (_lastInteraction != null)
            {
                _lastInteraction = null;
            }
        }
    }
}
