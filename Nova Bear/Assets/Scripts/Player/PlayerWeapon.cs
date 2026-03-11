using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _weaponParticleSystems;
    // Controls used for ship.
    [SerializeField] private InputActionAsset _playerControls;
    private InputAction _fireAction;
    private bool _isFiring = false;

    [SerializeField] private RectTransform _crosshairTransform;

    [SerializeField] private GameObject _crosshairTarget;
    private Vector3 _crosshairPosCache;
    [SerializeField] private float _targetDistance;

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
                FireWeapon(_isFiring);
            }
        }
        else
        {
            if (_isFiring)
            {
                _isFiring = false;
                FireWeapon(_isFiring);
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
}
