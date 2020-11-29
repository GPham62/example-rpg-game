using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Utils
{
    public class Recover : MonoBehaviour
    {
        [SerializeField] GameObject targetToRecover = null;
        // Start is called before the first frame update
        public void RecoverTarget()
        {
            targetToRecover.SetActive(true);
        }
    }
}

