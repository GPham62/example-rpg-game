
using RPG.Control;
using UnityEngine;
using UnityEngine.Events;

namespace RPG.Environment
{
    public class ClickableTreasure : MonoBehaviour, IRaycastable
    {
        [SerializeField] UnityEvent onClick;

        public CursorType GetCursorType()
        {
            return CursorType.Pickup;
        }

        public bool HandleRaycast(PlayerController callingController)
        {
            if (Input.GetMouseButtonDown(0))
            {
                onClick.Invoke();
            }
            return true;
        }
    }

}