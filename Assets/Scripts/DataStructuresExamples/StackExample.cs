using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Objects
{
    // LastIn, First Out
    //Plates at a buffet

    // Generally you want to call a try method first, if you dont know if the stack has indexs
    public class StackExample : MonoBehaviour
    {
        public GameObject testPrefab;
        public Stack<GameObject> stack = new Stack<GameObject>();
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            GameObject tempObj = Instantiate(testPrefab);
            tempObj.transform.position = new Vector3(0, 0, 0);

            stack.Push(tempObj); // Adds to the top of the stack

            GameObject peekObj = stack.Peek(); // This will NOT remove the item, but let us look at the top
             stack.Pop(); // REMOVES it from the index, and so every other index is shuffled up.
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
