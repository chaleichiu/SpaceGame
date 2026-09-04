using UnityEngine;
using System.Collections.Generic;
using System.Collections;
namespace Objects
{
    // First in, First out 
    // Line at store, DMV lineup, Soda machine, Cash register line
    public class QueueExample : MonoBehaviour
    {
        public GameObject testObj;
        public Queue<GameObject> testQueue = new Queue<GameObject>();
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        testQueue.Enqueue(testObj);
            testQueue.Dequeue();
    
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
