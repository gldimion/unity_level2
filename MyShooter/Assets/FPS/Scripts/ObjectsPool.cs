using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class ObjectsPool : MonoBehaviour
    {
        public static ObjectsPool Instance { get; private set; }

        [SerializeField]
        private GameObject[] objects;
        private Dictionary<string, Queue<IPoolable>> objectsDict = new Dictionary<string, Queue<IPoolable>>();

        private void Awake()
        {
            if (Instance) DestroyImmediate(gameObject);
            else Instance = this;
        }

        private void Start()
        {
            foreach (GameObject o in objects)
            {
                var poolObj = o.GetComponent<IPoolable>();
                if (poolObj == null) continue;

                if(objectsDict.ContainsKey(poolObj.PoolID))
                {
                    Debug.LogWarning($"Pool already contains object with ID: {poolObj.PoolID}");
                    continue;
                }

                var queue = new Queue<IPoolable>();
                for(int i = 0; i < poolObj.ObjectsCount; i++)
                {
                    GameObject go = Instantiate(o);
                    go.transform.parent = transform;
                    go.SetActive(false);
                    queue.Enqueue(go.GetComponent<IPoolable>());
                }
                objectsDict.Add(poolObj.PoolID, queue);
            }
        }

        public IPoolable GetObject(string poolID)
        {
            if (string.IsNullOrEmpty(poolID)) return null;
            if (!objectsDict.ContainsKey(poolID)) return null;

            IPoolable p = objectsDict[poolID].Dequeue();
            objectsDict[poolID].Enqueue(p);

            return p;
        }
    }
}