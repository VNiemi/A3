using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public abstract class PowerUpBase : MonoBehaviour
    {

        [SerializeField, Tooltip("Speed the power up moves.")]
        private float _speed;

        [SerializeField, Tooltip("Power up lifetime.")]
        private float _lifetime;


        // Update is called once per frame
        void Update()
        {

            transform.Translate(Vector3.down * _speed * Time.deltaTime);

            // Limited lifetime specified in the assignment, redundant since the power ups leave the screen anyway.
            _lifetime -= Time.deltaTime;
            if(_lifetime < 0)
            {
                Destroy(gameObject);
            }
            
        }

        void OnTriggerEnter2D(Collider2D collision)
        {

            // If player spaceship hit do power up.
            if(collision.gameObject.GetComponent<PlayerSpaceShip>() != null)
            {
                Debug.Log("Power up collected.");
                DoPowerUp(collision.gameObject);
                Destroy(gameObject);
            }

            // Destroy power up once it reaches the destroyer. This should actually be redundant, if Physics2D setup works.
            if(collision.gameObject.GetComponent<Destroyer>() != null)
            {
                Destroy(gameObject);
            }
        }

        // 
        public abstract void DoPowerUp(GameObject go);
        
    }
}
