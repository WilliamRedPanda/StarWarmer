using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
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
        OnSelectUE?.Invoke();
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        OnDeselectUE?.Invoke();
    }
    #endregion


    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickUE?.Invoke();
    }
}