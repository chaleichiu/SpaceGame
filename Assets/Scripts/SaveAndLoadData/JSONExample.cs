using UnityEngine;

namespace Objects
{
    public class JSONExample : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // Serielizing data to JSON
            SampleData sample = new SampleData();
            sample.name = "Bob";
            sample.score = 10.0f;

            string data = JsonUtility.ToJson(sample);
            Debug.Log("Raw Json: " + data);

            string ExampleJSON = "{\n\t\"name\": \"Alice\",\n\t\"score\": 90.34\n}";
            Debug.Log(ExampleJSON);

            SampleData data2 = JsonUtility.FromJson<SampleData>(ExampleJSON);

            Debug.Log($"Deserialized {data2.name} - Score : {data2.score}");





        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
