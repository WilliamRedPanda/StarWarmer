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
    bool pushed;

    private void Update()
    {
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetAxis("HorizontalStick") < -0.1f) && pushed == false)
        {
            pushed = true;
            Rotate(false);
        }
        else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetAxis("HorizontalStick") > 0.1f) && pushed == false)
        {
            pushed = true;
            Rotate(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S))
        {
            pushed = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            currentCombo.ChangeSkill();
        }
    }

    void StartRotationCheck()
    {
        if (corutineRotationCheck != null)
        {
            StopCoroutine(corutineRotationCheck);
        }
        corutineRotationCheck = CorutineRotationCheck();
        StartCoroutine(corutineRotationCheck);
    }

    IEnumerator corutineRotationCheck;
    IEnumerator CorutineRotationCheck()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        pushed = false;
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
            Vector3 newPos = ((Quaternion.Euler(0, 0, (delta * (float)i)) * (combos[0].transform.position - center.position)) + center.position);
            combos[i].transform.SetPositionAndRotation(newPos, (Quaternion.Euler(0, 0, (delta * (float)i))));
        }
        combos[index].button.Select();
        currentCombo = combos[0];
        currentCombo.ChangeCurrentView();
    }

    public void Rotate(bool _right)
    {
        StartRotationCheck();
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