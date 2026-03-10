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
    private Vector3 clampedPosition;
    [SerializeField] private float xClamp = 10f;
    [SerializeField] private float yClamp = 10f;
    [SerializeField] private float rollFactor = 20f;
    [SerializeField] private float rotationRate = 5.0f;
    [SerializeField] private float pitchFactor = 10f;
    //[SerializeField] private float pitchRate = 5.0f;

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
        shipMovePosition.x = _shipMoveRate * _moveShipAction.ReadValue<Vector2>().x * Time.deltaTime;
        shipMovePosition.y = _shipMoveRate * _moveShipAction.ReadValue<Vector2>().y * Time.deltaTime;
        transform.localPosition += shipMovePosition;
        clampedPosition = transform.localPosition;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -xClamp, xClamp);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -yClamp, yClamp);
        transform.localPosition = clampedPosition;
    }

    private void UpdateRotation()
    {
        Quaternion targetRot = Quaternion.Euler(pitchFactor * _moveShipAction.ReadValue<Vector2>().y,
                                                0f, 
                                                -rollFactor * _moveShipAction.ReadValue<Vector2>().x);
        targetRot = Quaternion.Lerp(transform.localRotation, targetRot, rotationRate * Time.deltaTime);
        //    Quaternion.Euler(0f, 0f, -rollFactor * _moveShipAction.ReadValue<Vector2>().x);
        // Always make sure local for this, transform.rotation rotates
        // in world space and won't give desired results KEKW
        transform.localRotation = targetRot;
    }
}
