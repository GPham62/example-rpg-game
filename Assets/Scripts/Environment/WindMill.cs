using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Environment
{
    public class WindMill : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(0, 0, 20 * Time.deltaTime);
        }
    }

}