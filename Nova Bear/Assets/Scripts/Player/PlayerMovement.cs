using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : MonoBehaviour
{
    // Only needed if not attached to player ship. In that case, set this to the
    // player ship object.
    [SerializeField] private GameObject _playerShip;
    // Controls used for ship.
    [SerializeField] private InputActionAsset _playerControls;
    // Helper to get the Player actions.
    private InputAction _moveShipAction;
    // How fast thie ship moves.
    [SerializeField] private float _shipMoveRate = 10f;
    // Helps move without creating new Vector3 every frame to help with efficiency and clarity.
    private Vector3 _shipMovePosition;
    private Vector3 _clampedPosition;
    [SerializeField] private float _xClamp = 10f;
    [SerializeField] private float _yClamp = 10f;
    [SerializeField] private float _rollFactor = 20f;
    [SerializeField] private float _rotationRate = 5.0f;
    [SerializeField] private float _pitchFactor = 10f;
    //[SerializeField] private float pitchRate = 5.0f;

    private void Awake()
    {
        _playerControls.Enable();
        _moveShipAction = _playerControls.FindActionMap("Player")["Move"];
        _shipMovePosition = Vector3.zero;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateRotation();
        //Debug.Log("Ship transform: " + transform.localPosition.ToString());
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

    private void UpdateMovement()
    {
        _shipMovePosition.x = _shipMoveRate * _moveShipAction.ReadValue<Vector2>().x * Time.deltaTime;
        _shipMovePosition.y = _shipMoveRate * _moveShipAction.ReadValue<Vector2>().y * Time.deltaTime;
        transform.localPosition += _shipMovePosition;
        _clampedPosition = transform.localPosition;
        _clampedPosition.x = Mathf.Clamp(_clampedPosition.x, -_xClamp, _xClamp);
        _clampedPosition.y = Mathf.Clamp(_clampedPosition.y, -_yClamp, _yClamp);
        transform.localPosition = _clampedPosition;
    }

    private void UpdateRotation()
    {
        Quaternion targetRot = Quaternion.Euler(_pitchFactor * _moveShipAction.ReadValue<Vector2>().y,
                                                0f, 
                                                -_rollFactor * _moveShipAction.ReadValue<Vector2>().x);
        targetRot = Quaternion.Lerp(transform.localRotation, targetRot, _rotationRate * Time.deltaTime);
        //    Quaternion.Euler(0f, 0f, -rollFactor * _moveShipAction.ReadValue<Vector2>().x);
        // Always make sure local for this, transform.rotation rotates
        // in world space and won't give desired results KEKW
        transform.localRotation = targetRot;
    }
}
