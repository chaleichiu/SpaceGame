using UnityEngine;

namespace Objects
{
    /// <summary>
    /// Arrays are a set length, where as a list is a dynamic length
    /// </summary>
    public class ArrayExample : MonoBehaviour
    {
        public GameObject testObject;
        public GameObject[] testArray; // non initialized and its length is 0 - and it wont cause a crash.

        public GameObject[] array = new GameObject[2]; // arrays start at 0   0-1


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            array[0] = Instantiate(testObject, transform);
            array[0].transform.position = new Vector2(0, 0);

            array[1] = Instantiate(testObject, transform);
            array[1].transform.position = new Vector2(1, 0);

           // array[2] = Instantiate(testObject, transform);     // This will cause an error. In memeory, where index 2 would be, it may already be taken up the slot. 
                                                                 // So arrays are a fixed length at run time once they are set, and cannot expand for that reason. 
           // array[2].transform.position = new Vector2(1, 0);

        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
