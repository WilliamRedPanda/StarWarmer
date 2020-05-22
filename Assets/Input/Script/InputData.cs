using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

[CreateAssetMenu()]
public class InputData : ScriptableObject
{
    public KeyCode key, XBoxKey;
    public Key keyboardKey;
    public GamepadButton gamepadButton;
    public Sprite keySprite, XboxSprite, PSSprite;

    Keyboard currentKeyboard;
    Gamepad currentGamepad;

    public bool CheckInputPressed()
    {
        currentKeyboard = Keyboard.current;
        currentGamepad = Gamepad.current;

        if (currentKeyboard != null)
        {
            if (currentKeyboard[keyboardKey].wasPressedThisFrame)
                return true;
        }

        if (currentGamepad != null)
        {
            if (currentGamepad[gamepadButton].wasPressedThisFrame)
                return true;
        }

        return false;
    }
}