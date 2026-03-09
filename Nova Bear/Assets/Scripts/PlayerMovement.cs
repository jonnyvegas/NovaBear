using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : MonoBehaviour
{
    // Only needed if not attached to player ship. In that case, set this to the
    // player ship object.
    [SerializeField] private GameObject PlayerShip;
    // Controls used for ship.
    [SerializeField] private InputActionAsset PlayerControls;
    // Helper to get the Player actions.
    private InputAction _moveShipAction;
    // How fast thie ship moves.
    [SerializeField] private float _shipMoveRate = 10f;
    // Helps move without creating new Vector3 every frame to help with efficiency and clarity.
    private Vector3 shipMovePosition;
    private void Awake()
    {
        PlayerControls.Enable();
        _moveShipAction = PlayerControls.FindActionMap("Player")["Move"];
        shipMovePosition = Vector3.zero;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shipMovePosition.x = _shipMoveRate * _moveShipAction.ReadValue<Vector2>().x * Time.deltaTime;
        shipMovePosition.y = _shipMoveRate * _moveShipAction.ReadValue<Vector2>().y * Time.deltaTime;
        transform.localPosition += shipMovePosition;
    }
    
    // Current move rate of the ship.
    public float GetMoveRate()
    {
        return _shipMoveRate;
    }

    // Set new move rate of the ship (power ups? power downs?)
    public void SetMoveRate(float newRate)
    {
        _shipMoveRate = newRate;
    }

}
