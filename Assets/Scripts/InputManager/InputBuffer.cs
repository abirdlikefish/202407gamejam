
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
        public float direction;
        public float jump;
        public float split;
        public float use;
        public float attack;
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
        UseGamePlayMap();

        inputTime.jump = -5;
        inputTime.split = -5;
        inputTime.direction = 0;
        inputTime.use = -5;
        inputTime.attack = -5;
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
        inputTime.direction = context.ReadValue<float>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
            inputTime.jump = Time.time;
        //Debug.Log("jummp");
    }
    public void OnSplit(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Canceled)
        {
            inputTime.split = -1;
        }
        if (context.phase == InputActionPhase.Started)
        {
            inputTime.split = Time.time;
        }
    }
    public void OnUse(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            inputTime.use = Time.time;
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            inputTime.attack= Time.time;
        }
    }


    #region outside request

    // 
    public float GetInputDirection()
    {
        return inputTime.direction;
    }

    public bool IsJump()
    {
        bool ans = Time.time - inputTime.jump < 0.1f;
        inputTime.jump = -1;
        return ans;
    }
    public bool IsUse()
    {
        bool ans = Time.time - inputTime.use < 0.1f;
        inputTime.use = -1;
        return ans;
    }
    public bool IsAttack()
    {
        bool ans = Time.time - inputTime.attack< 0.1f;
        inputTime.attack= -1;
        return ans;
    }
    public bool IsSplit()
    {
        float mid = Time.time - inputTime.split;
        if( 1 < mid && mid < 1.5 )
        {
            inputTime.split = -5;
            return true;
        }
        return false;
    }




    #endregion

}
