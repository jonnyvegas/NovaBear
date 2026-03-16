using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : Weapon
{
    // Freakin' laser beams!
    [SerializeField] private ParticleSystem[] _weaponParticleSystems;
    // Controls used for ship.
    [SerializeField] private InputActionAsset _playerControls;
    // Helper for the actual firing action.
    private InputAction _fireAction;
    // Helper for firing.
    private bool _isFiring = false;

    // Crosshair transform on 2D canvas.
    [SerializeField] private RectTransform _crosshairTransform;

    // Where the crosshair and lasers will point.
    [SerializeField] private GameObject _crosshairTarget;

    // Helper for target position.
    private Vector3 _crosshairPosCache;
    
    // How far in front do we want to aim?
    [SerializeField] private float _targetDistance;

    // Helpers for the results of looking at the target w/ the lasers.
    private Vector3 _targetLookAtResult;
    private Quaternion _targetLookAtRot;

    private void Awake()
    {
        _isFiring = false;
        // singleton style KEKW, only works if there's 1 particle system though,
        // which is why we serialized the field to be set.
        //_weaponParticleSystems = GetComponents<ParticleSystem>();
        foreach (ParticleSystem particleSys in _weaponParticleSystems)
        {
            particleSys.Stop();
        }
        if(_playerControls )
        {
            if (!_playerControls.enabled)
            {
                _playerControls.Enable(); 
            }
            _fireAction = _playerControls.FindActionMap("Player")["Fire"];
        }
        _crosshairPosCache = Vector3.zero;
        _crosshairPosCache.z = _targetDistance;
        _targetLookAtResult = Vector3.zero;
        _targetLookAtRot = Quaternion.identity;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFire();
        UpdateCrosshair();
        AimLasers();
    }
    
    // Fires or stops firing the weapon.
    void FireWeapon(bool fire)
    {

        if (fire)
        {
            foreach (ParticleSystem particleSys in _weaponParticleSystems)
            {
                particleSys.Play();
            }
        }
        else
        {
            foreach (ParticleSystem particleSys in _weaponParticleSystems)
            {
                particleSys.Stop();
            }
        }

    }

    private void UpdateFire()
    {
        if (_fireAction.IsPressed())
        {
            // acts as a do-once.
            if (!_isFiring)
            {
                _isFiring = true;
                UseWeapon(_isFiring);
            }
        }
        else
        {
            if (_isFiring)
            {
                _isFiring = false;
                UseWeapon(_isFiring);
            }
        }
    }

    private void UpdateCrosshair()
    {
        if (_crosshairTransform && _crosshairTarget)
        {
            _crosshairPosCache.x = Mouse.current.position.ReadValue().x;
            _crosshairPosCache.y = Mouse.current.position.ReadValue().y;
            _crosshairTarget.transform.position = Camera.main.ScreenToWorldPoint(_crosshairPosCache);
            _crosshairTransform.position = Mouse.current.position.ReadValue();
        }
    }

    private void AimLasers()
    {
        foreach (ParticleSystem particleSys in _weaponParticleSystems)
        {
            _targetLookAtResult = (_crosshairTarget.transform.position - particleSys.transform.position).normalized;
            _targetLookAtRot = Quaternion.LookRotation(_targetLookAtResult);
            particleSys.transform.rotation = _targetLookAtRot;
        }
    }

    public override void UseWeapon(bool bFire)
    {
        FireWeapon(bFire);
    }
}
