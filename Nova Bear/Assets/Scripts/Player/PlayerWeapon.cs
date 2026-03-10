using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _weaponParticleSystems;
    // Controls used for ship.
    [SerializeField] private InputActionAsset _playerControls;
    private InputAction _fireAction;
    private bool _isFiring = false;

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
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_fireAction.IsPressed())
        {
            // acts as a do-once.
            if(!_isFiring)
            {
                _isFiring = true;
                FireWeapon(_isFiring);
            }
        }
        else
        {
            if(_isFiring)
            {
                _isFiring = false;
                FireWeapon(_isFiring);
            }
        }
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
}
