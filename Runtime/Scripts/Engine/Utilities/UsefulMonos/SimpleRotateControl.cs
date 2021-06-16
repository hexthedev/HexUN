using HexUN.Framework;
using HexUN.Framework.Input;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexUN.Engine.Utilities.UsefulMonos
{
    public class SimpleRotateControl : MonoBehaviour
    {
        [SerializeField]
        private float Speed = 50.0f;

        private IInput _input => NgHexServices.Instance.Input;

        // Update is called once per frame
        void Update()
        {
            Vector3 euler = new Vector3(
                _input.GetKeyDown(KeyCode.W) ? -1 : _input.GetKeyDown(KeyCode.S) ? 1 : 0,
                _input.GetKeyDown(KeyCode.A) ? 1 : _input.GetKeyDown(KeyCode.D) ? -1 : 0,
                0
            );

            if(euler.sqrMagnitude != 0)
            {
                transform.rotation *= Quaternion.Euler(euler * Speed * Time.deltaTime);
            }
        }
    }
}