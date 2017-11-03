using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class HealthDisplay : MonoBehaviour
    {
        private Health _health;

        private TMPro.TMP_Text _textMesh;

        // Use this for initialization
        void Start()
        {

            _textMesh = gameObject.GetComponent<TMPro.TMP_Text>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_health == null)
            {
                // Turns out that referencing an object something can destroy at anytime from update is bad!
                if (FindObjectOfType<PlayerSpaceShip>() != null)
                {
                    _health = FindObjectOfType<PlayerSpaceShip>().gameObject.GetComponent<Health>();
                
                }
            }
            else
            {
                _textMesh.text = "HEALTH " + _health.CurrentHealth;
            }
        }


    }
}
