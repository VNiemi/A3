using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter {

// This class allows configuring power up spawning as a component.
// The tooltips and such probably make the code self explaining?
public class SetPowerUp : MonoBehaviour {

        [SerializeField, Tooltip("Prefab for the Health Power Up to be spawned.")]
        private GameObject _healthPrefab;

        [SerializeField, Tooltip("Prefab for the Weapon Power Up to be spawned.")]
        private GameObject _weaponPrefab;

        [SerializeField, Tooltip("Chance a Power Up is spawned when the game object is destroyed 0..100."), Range(0, 100)]
        private int _spawnChance = 25;

        [SerializeField, Tooltip("Chance the Power Up is a Weapon Power Up 0..100."), Range(0, 100)]
        private int _weaponChance = 25;

        [SerializeField, Tooltip("The display prefab")]
        GameObject _displayPrefab;

        private static GameObject _displayGO;

        private void Awake()
        {
            if (_displayPrefab != null && _displayGO == null)
            {
                _displayGO = Instantiate(_displayPrefab);
            }
        }

        // This triggers when the attached game object is destroyed.
        // Note that this includes at scene change, but checking for being dead should suffice?
        private void OnDestroy()
        {
            if (_spawnChance > Random.Range(0, 100) && gameObject.GetComponent<Health>().IsDead )
            {
                Debug.Log("Power Up spawned.");
                GameObject go;
                if (_weaponChance > Random.Range(0, 100))
                {
                    go = Instantiate(_weaponPrefab);
                }
                else
                {
                    go = Instantiate(_healthPrefab);
                }
                go.GetComponent<Transform>().position = gameObject.GetComponent<Transform>().position;
            }

           
        }

        

    }
}
