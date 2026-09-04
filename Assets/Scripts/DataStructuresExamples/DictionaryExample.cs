using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Objects
{
    public class DictionaryExample : MonoBehaviour
    {
        public Dictionary<string, int> myDictionary= new Dictionary<string, int>();
        public string checkKey = "Gems";

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // setting indexs to values of 0
            myDictionary.Add("Gems", 0);
            myDictionary.Add("Coins", 0);
            myDictionary.Add("Bullets", 0);
            myDictionary.Add("BottleCaps", 0);
        }

        
        void AddGems()
        {
            if (myDictionary.ContainsKey(checkKey))
            {
                myDictionary[checkKey]++;
            }
        }

        void CheckKey()
        {
            bool hasKey = myDictionary.TryGetValue(checkKey, out int value);
            Debug.Log(checkKey + value);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
