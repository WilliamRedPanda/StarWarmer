using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonExtention : Selectable , IPointerClickHandler
{
    [SerializeField] UnityEvent OnClickUE;
    [SerializeField] UnityEvent OnPointerEnterUE;
    [SerializeField] UnityEvent OnPointerExitUE;
    [SerializeField] UnityEvent OnPointerDownUE;
    [SerializeField] UnityEvent OnPointerUpUE;
    [SerializeField] UnityEvent OnSelectUE;
    [SerializeField] UnityEvent OnDeselectUE;

    bool onSelect;

    private void Update()
    {
        Keyboard k = Keyboard.current;
        if (k != null)
            if (k.spaceKey.wasPressedThisFrame)
                if (onSelect)
                    OnClickUE?.Invoke();

        Gamepad g = Gamepad.current;
        if (g != null)
            if (g.buttonSouth.wasPressedThisFrame)
                if (onSelect)
                    OnClickUE?.Invoke();
    }

    #region Interface
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickUE?.Invoke();
    }
    #endregion

    #region Override
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        OnPointerEnterUE?.Invoke();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        OnPointerExitUE?.Invoke();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        OnPointerDownUE?.Invoke();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        OnPointerUpUE?.Invoke();
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        onSelect = true;
        OnSelectUE?.Invoke();
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        onSelect = false;
        OnDeselectUE?.Invoke();
    }
    #endregion
}