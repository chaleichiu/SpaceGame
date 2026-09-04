using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Objects
{

    /// <summary>
    /// Lists are similar to arrays but they are dynamic and can grow  in size at run time.
    /// </summary>
    public class ListExamples : MonoBehaviour
    {
        public GameObject testPrefab;

        public List<GameObject> listName; // List have to be instiatied , this errors.

        public List<GameObject> workingList = new List<GameObject>();

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            GameObject tempObject;
            tempObject = Instantiate(testPrefab);
            tempObject.transform.position = new Vector3(0, 0, 0);
            workingList.Add(tempObject);

            tempObject = Instantiate(testPrefab);
            tempObject.transform.position = new Vector3(1, 0, 0);
            workingList.Add(tempObject);

            workingList.RemoveAt(1);
            workingList.Clear();

            for (int i = 0; i <= workingList.Count; i++) // count can be used as the total number of indexs for a for loop
            {

            }


        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
