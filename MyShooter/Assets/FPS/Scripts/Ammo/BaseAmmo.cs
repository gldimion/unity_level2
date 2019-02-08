using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{ 
    public abstract class BaseAmmo : BaseSceneObject
    {
        [SerializeField]
        protected float selfDestroyTime = 3f;
        [SerializeField]
        protected float damage = 20f;

        protected override void Awake()
        {
            base.Awake();
            Destroy(GameObject, selfDestroyTime);
        }

        public abstract void Initialize(float force, Transform firepoint);    
    }
}