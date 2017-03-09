﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackFox
{
    public class Wave : MonoBehaviour
    {

        public float velocity;
        public float force;

        void Start()
        {

        }


        void FixedUpdate()
        {
            MoveForward();
        }

        void MoveForward()
        {
            transform.Translate(Vector3.forward * velocity);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Agent>() != null || other.GetComponent<ExternalAgent>() != null)
            {
                other.GetComponent<Rigidbody>().AddForce(transform.forward * force);
            }

        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Wall")
            {
                Debug.Log("kill");
                //Destroy(gameObject);
            }

        }
    }
}