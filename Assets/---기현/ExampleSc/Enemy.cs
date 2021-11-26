using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class Enemy : MonoBehaviour, IHP
    {
        public float HP 
        {
            get => _currentHP;
            set => _currentHP = Mathf.Clamp(value, MinHP, MaxHP); 
        }
        private float _currentHP;

        public float MaxHP => 100f;
        public float MinHP => 0f;

        public Vector3 UIPosition => uiPivot.position;

        private Transform uiPivot;

        private void Start()
        {
            uiPivot = this.transform.Find("UIPivot");
        }
    }
}