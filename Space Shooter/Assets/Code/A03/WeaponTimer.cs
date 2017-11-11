using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class WeaponTimer : MonoBehaviour
    {

        private GameObject _playerShip;
        private TMPro.TMP_Text _textMesh;
        private GameObject _weapon, _secondWeapon;
        private float _time;
        private Vector3 _original, _doubleA, _doubleB;

        // Use this for initialization
        void Start()
        {
            _playerShip = FindObjectOfType<PlayerSpaceShip>().gameObject;
            _textMesh = gameObject.GetComponent<TMPro.TMP_Text>();
            _weapon = _playerShip.GetComponentInChildren<Weapon>().gameObject;

            // Sets the weapon positions.
            // Probably should use something editable via editor, but no real point for an assignment.
            // Nobody is going to need to actually USE this code. Although writing this comment probably took longer... 
            _original = _doubleA = _doubleB = _weapon.transform.localPosition;
            _doubleA.x = - 0.06f;
            _doubleB.x = 0.06f;

        }

        // Update is called once per frame
        void Update()
        {
            // Player and his weapons were destroyed. No more power up.
            if(_secondWeapon == null)
            {
                _time = 0;
                _textMesh.text = "";

            }

            // Basic timer countdown.
            if (_time > 0) { _time -= Time.deltaTime; }

            // Time runs out. Text cleared, boost removed, time set to 0 as a flag.
            if (_time < 0)
            {
                _time = 0;
                UnDoubleWeapon();
                _textMesh.text = "";
            }

            // Handles displaying the time remaining.
            if (_time > 0)
            {
                _textMesh.text = "WEAPON " + Mathf.Round(_time) + "s";
                if (Input.GetButton(PlayerSpaceShip.FireButtonName))
                {
                    _secondWeapon.GetComponent<Weapon>().Shoot();
                }
            }
        }

        // This adds time to the timer. Which I guess was obvious.
        public void Add(float time)
        {
            if (_time == 0)
            {
                DoubleWeapon();
            }

            _time += time;

        }

        private void DoubleWeapon()
        {
            // Reacquire the objects.
            _playerShip = FindObjectOfType<PlayerSpaceShip>().gameObject;
            _weapon = _playerShip.GetComponentInChildren<Weapon>().gameObject;
            _secondWeapon = Instantiate(_weapon, _playerShip.transform);
            _secondWeapon.GetComponent<Weapon>().Init(_playerShip.GetComponent<PlayerSpaceShip>());

            // Sets the weapon positions.
            // Probably should use something editable via editor, but no real point for an assignment.
            // Nobody is going to need to actually USE this code. Although writing this comment probably took longer... 
            _original = _doubleA = _doubleB = _weapon.transform.localPosition;
            _doubleA.x = -0.06f;
            _doubleB.x = 0.06f;

            _weapon.transform.localPosition = _doubleA;
            _secondWeapon.transform.localPosition = _doubleB;
            

        }

        private void UnDoubleWeapon()
        {
            _weapon.transform.localPosition = _original;
            Destroy(_secondWeapon);
        }
    }
}