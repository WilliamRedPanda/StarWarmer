using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SelectableComboManager : MonoBehaviour
{
    [SerializeField] SelectableCombo firstCombo;
    [SerializeField] SelectableCombo[] combos;
    [SerializeField] Transform center;
    [SerializeField] float rotationSpeed;
    [SerializeField] bool inverseRotation;

    [HideInInspector] public SelectableCombo currentCombo;

    float delta;
    int index;

    bool b;
    Vector3 positionFirstCombo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetAxis("HorizontalStick") < -0.1f)
        {
            Rotate(false);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetAxis("HorizontalStick") > 0.1f)
        {
            Rotate(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentCombo.ChangeSkill();
        }
    }

    public void Reposition()
    {
        center.rotation = Quaternion.identity;
        if (b == false)
        {
            b = true;
            positionFirstCombo = firstCombo.transform.position;
        }
        combos[0].transform.position = positionFirstCombo;
        index = 0;
        int l = combos.Length;
        delta = 360f / (float)l;
        for (int i = 1; i < l; i++)
        {
            Vector3 newPos = ((Quaternion.Euler(0, 0, (delta * (float)i)) * combos[0].transform.localPosition) + center.position);
            combos[i].transform.SetPositionAndRotation(newPos, (Quaternion.Euler(0, 0, (delta * (float)i))));
        }
        combos[index].button.Select();
        currentCombo = combos[0];
        currentCombo.ChangeCurrentView();
    }

    public void Rotate(bool _right)
    {
        if (!inverseRotation)
        {
            ChangeSKillView(!_right);
            StartCoroutine(RotateCorutine(_right));
        }
        else
        {
            ChangeSKillView(_right);
            StartCoroutine(RotateCorutine(!_right));
        }
    }

    IEnumerator RotateCorutine(bool _right)
    {
        float f = 0;
        while (true)
        {
            if (f + rotationSpeed > delta)
            {
                if (_right)
                    center.Rotate(Vector3.forward * (delta - f), Space.Self);
                else
                    center.Rotate(-Vector3.forward * (delta - f), Space.Self);
                break;
            }

            f += rotationSpeed;

            if (_right)
            {
                center.Rotate(Vector3.forward * rotationSpeed, Space.Self);
            }
            else
            {
                center.Rotate(-Vector3.forward * rotationSpeed, Space.Self);
            }

            yield return null;
        }
        yield return null;
    }

    void ChangeSKillView(bool _right)
    {
        if (_right)
        {
            index++;
            if (index >= combos.Length)
                index = 0;
        }
        else
        {
            index--;
            if (index < 0)
                index = combos.Length - 1;
        }

        combos[index].button.Select();
        currentCombo = combos[index];
        currentCombo.ChangeCurrentView();
    }

    public void ResetSet()
    {
        Reposition();
    }
}