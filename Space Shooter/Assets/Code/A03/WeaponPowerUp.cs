using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class WeaponPowerUp : PowerUpBase
    {

        [SerializeField, Tooltip("Amount of time the power up gives double weapons.")]
        float _time;

        [SerializeField, Tooltip("Prefab for weapon timer.")]
        GameObject _weaponTimerPrefab;

        static GameObject _weaponTimer;

        public override void DoPowerUp(GameObject go)
        {
            if (_weaponTimer == null)
            {
                _weaponTimer = Instantiate(_weaponTimerPrefab);
            }

            _weaponTimer.GetComponent<WeaponTimer>().Add(_time);
        }
    }
}
