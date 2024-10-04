using System;
using UnityEngine;
public class InputMannager : MonoBehaviour
{
    public static InputMannager instance;
    private PlayerControllerInputs playerControllerInputs;
    public Action interactAction;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnEnable()
    {
        playerControllerInputs = new PlayerControllerInputs();
        playerControllerInputs?.Enable();
        playerControllerInputs.Player.Interact.performed += Shoot_performed;
    }
    private void OnDisable()
    {
        playerControllerInputs.Player.Interact.performed -= Shoot_performed;
        playerControllerInputs?.Disable();
        playerControllerInputs = null;
    }
    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        interactAction?.Invoke();
        print("Hola soy la funcion de performed");
    }
    public Vector2 GetMovementPj()
    {
        return playerControllerInputs.Player.Move.ReadValue<Vector2>();
    }
}
