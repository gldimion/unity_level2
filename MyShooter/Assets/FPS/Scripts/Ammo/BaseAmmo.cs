using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{ 
    public abstract class BaseAmmo : BaseSceneObject, IPoolable
    {
        [SerializeField]
        protected float selfDestroyTime = 3f;
        [SerializeField]
        protected float damage = 20f;

        public abstract string PoolID { get; }
        public abstract int ObjectsCount { get; }

        private void OnEnable()
        {
            Invoke("Disable", selfDestroyTime);
        }

        //protected override void Awake()
        //{
        //    base.Awake();
        //    Invoke("Disable", selfDestroyTime);
        //    //Destroy(GameObject, selfDestroyTime);
        //}

        public abstract void Initialize(float force, Transform firepoint);    

        protected virtual void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}