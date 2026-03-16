using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : Movement
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

    private float deltaTime = 0f;

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
        // parse it once.
        deltaTime = Time.deltaTime;
        UpdateMovement(deltaTime);
        UpdateRotation(deltaTime);
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

    public override void UpdateMovement(float deltaTime)
    {
        _shipMovePosition.x = _shipMoveRate * _moveShipAction.ReadValue<Vector2>().x * deltaTime;
        _shipMovePosition.y = _shipMoveRate * _moveShipAction.ReadValue<Vector2>().y * deltaTime;
        _playerShip.transform.localPosition += _shipMovePosition;
        _clampedPosition = _playerShip.transform.localPosition;
        _clampedPosition.x = Mathf.Clamp(_clampedPosition.x, -_xClamp, _xClamp);
        _clampedPosition.y = Mathf.Clamp(_clampedPosition.y, -_yClamp, _yClamp);
        _playerShip.transform.localPosition = _clampedPosition;
    }

    private void UpdateRotation(float deltaTime)
    {
        Quaternion targetRot = Quaternion.Euler(_pitchFactor * _moveShipAction.ReadValue<Vector2>().y,
                                                0f, 
                                                -_rollFactor * _moveShipAction.ReadValue<Vector2>().x);
        targetRot = Quaternion.Lerp(_playerShip.transform.localRotation, targetRot, _rotationRate * deltaTime);
        //    Quaternion.Euler(0f, 0f, -rollFactor * _moveShipAction.ReadValue<Vector2>().x);
        // Always make sure local for this, transform.rotation rotates
        // in world space and won't give desired results KEKW
        _playerShip.transform.localRotation = targetRot;
    }
}
