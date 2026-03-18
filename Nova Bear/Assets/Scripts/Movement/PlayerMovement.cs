using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : Movement
{
    // Only needed if not attached to player ship. In that case, set this to the
    // player ship object.
    [SerializeField] private GameObject playerShip;
    // Controls used for ship.
    [SerializeField] private InputActionAsset playerControls;
    // Helper to get the Player actions.
    private InputAction moveShipAction;
    // How fast thie ship moves.
    [SerializeField] private float shipMoveRate = 10f;
    // Helps move without creating new Vector3 every frame to help with efficiency and clarity.
    private Vector3 shipMovePosition;
    private Vector3 clampedPosition;
    [SerializeField] private float xClamp = 10f;
    [SerializeField] private float yClamp = 10f;
    [SerializeField] private float rollFactor = 20f;
    [SerializeField] private float rotationRate = 5.0f;
    [SerializeField] private float pitchFactor = 10f;
    [SerializeField] private float cameraOffset = 5f;
    //[SerializeField] private float pitchRate = 5.0f;

    private float deltaTime = 0f;

    private void Awake()
    {
        playerControls.Enable();
        moveShipAction = playerControls.FindActionMap("Player")["Move"];
        shipMovePosition = Vector3.zero;
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
        return shipMoveRate;
    }

    // Set new move rate of the ship (power ups? power downs?)
    public void SetMoveRate(float newRate)
    {
        shipMoveRate = newRate;
    }

    public override void UpdateMovement(float deltaTime)
    {
        shipMovePosition.x = shipMoveRate * moveShipAction.ReadValue<Vector2>().x * deltaTime;
        shipMovePosition.y = shipMoveRate * moveShipAction.ReadValue<Vector2>().y * deltaTime;
        playerShip.transform.localPosition += shipMovePosition;
        clampedPosition = playerShip.transform.localPosition;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -xClamp, xClamp);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -yClamp + cameraOffset, yClamp);
        playerShip.transform.localPosition = clampedPosition;
    }

    private void UpdateRotation(float deltaTime)
    {
        Quaternion targetRot = Quaternion.Euler(pitchFactor * moveShipAction.ReadValue<Vector2>().y,
                                                0f, 
                                                -rollFactor * moveShipAction.ReadValue<Vector2>().x);
        targetRot = Quaternion.Lerp(playerShip.transform.localRotation, targetRot, rotationRate * deltaTime);
        //    Quaternion.Euler(0f, 0f, -rollFactor * _moveShipAction.ReadValue<Vector2>().x);
        // Always make sure local for this, transform.rotation rotates
        // in world space and won't give desired results KEKW
        playerShip.transform.localRotation = targetRot;
    }
}
