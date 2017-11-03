using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class HealthPowerUp : PowerUpBase
    {

        [SerializeField, Tooltip("Amount of health the power up gives.")]
        int _amount;

        

        public override void DoPowerUp(GameObject go)
        {
            go.GetComponent<Health>().IncreaseHealth(_amount);
        }
    }
}
