using System.Collections;
using System.Collections.Generic;
using GameDevTV.Inventories;
using GameDevTV.Saving;
using RPG.Utils;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Environment
{
    public class TreasureDropper : ItemDropper, ISaveable
    {
        [SerializeField] InventoryItem[] inventoryItems;
        [SerializeField] AnimatorController idleAnimatorController = null;
        [SerializeField] AnimatorController crashAnimatorController = null;
        [SerializeField] float scatterDistance = 1;

        const int ATTEMPTS = 30;

        GameObject starsParticles;

        GameObject box;

        GameObject brokenBox;

        Animator animator;

        private void Awake() {
            animator = GetComponent<Animator>();
            starsParticles = transform.GetChild(0).gameObject;
            box = transform.GetChild(1).gameObject;
            brokenBox = transform.GetChild(2).gameObject;
        }

        public void DropItems(){
            foreach (var item in inventoryItems)
            {
                DropItem(item, 1);
            }
        }

        public void DestroyBox(){
            
            if (crashAnimatorController != null)
            {
                animator.runtimeAnimatorController = crashAnimatorController;
            }
            starsParticles.SetActive(false);
            box.SetActive(false);
            brokenBox.SetActive(true);
        }

        protected override Vector3 GetDropLocation()
        {
            for (int i = 0; i < ATTEMPTS; i++)
            {
                Vector3 randomPoint = transform.position + Random.insideUnitSphere * scatterDistance;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, 0.1f, NavMesh.AllAreas))
                {
                    return hit.position;
                }
            }
            return transform.position;
        }

        private bool isTreasureOpen()
        {
            return box.activeInHierarchy;
        }

        object ISaveable.CaptureState()
        {
            return isTreasureOpen();
        }

        void ISaveable.RestoreState(object state)
        {
            bool shouldBeOpen = (bool)state;
            if (shouldBeOpen && !isTreasureOpen())
            {
                starsParticles.SetActive(true);
                box.SetActive(true);
                brokenBox.SetActive(false);
                animator.runtimeAnimatorController = idleAnimatorController;
            }
            if (!shouldBeOpen && isTreasureOpen())
            {
                starsParticles.SetActive(false);
                box.SetActive(false);
                brokenBox.SetActive(true);
                animator.runtimeAnimatorController = crashAnimatorController;
            }
        }

    }
}
