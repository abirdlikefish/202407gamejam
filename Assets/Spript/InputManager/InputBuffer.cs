using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class InputBuffer : MonoBehaviour , InputSystem.IUIActions , InputSystem.IGamePlayActions
{
    public static InputBuffer Instance { get; set; }
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        Init();
        UseGamePlayMap();
    }

    struct InputTime
    {
        public Vector2 direction;
    }
    InputTime inputTime;

    private static InputSystem _inputSystem;
    private void Init()
    {
        inputTime = new InputTime();
        if(_inputSystem == null)
        {
            _inputSystem = new InputSystem();
        }
        _inputSystem.GamePlay.SetCallbacks(this);
        _inputSystem.UI.SetCallbacks(this);
    }

    public void UseGamePlayMap()
    {
        _inputSystem.GamePlay.Enable();
        _inputSystem.UI.Disable();
    }
    public void UseUIMap()
    {
        _inputSystem.UI.Enable();
        _inputSystem.GamePlay.Disable();
    }
 
    public void OnNewaction(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputTime.direction = context.ReadValue<Vector2>();
    }


    #region outside request

    // 
    public Vector2 GetInputDirection()
    {
        return inputTime.direction;
    }

    #endregion

}
