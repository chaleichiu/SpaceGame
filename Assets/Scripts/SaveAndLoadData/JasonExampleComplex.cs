using System.Net;
using UnityEngine;

namespace Objects
{
    public class JasonExampleComplex : MonoBehaviour
    {
        void Start()
        {
            //Serializing a data object
            SampleDataComplex sample = new SampleDataComplex();

            sample.name = "Indi";

            sample.address = new Address();
            sample.address.unit = 1;
            sample.address.road = "2nd avenue";
            sample.address.city = "New York";

            sample.books = new book[2]; //creating the array
            sample.books[0] = new book(); //creating an object to add to the array
            sample.books[0].name = "Intro to Game Dev";
            sample.books[0].isDigital = true;
            sample.books[0].author = "John Doe";

            sample.books[1] = new book();
            sample.books[1].name = "Hatty Porrer";
            sample.books[1].isDigital = false;
            sample.books[1].author = "Just Kidding Rolling";


            string dataToJson = JsonUtility.ToJson(sample);
            Debug.Log(dataToJson); // SAVED TO LOCAL FOLDERS ON PC OR DEVICE OR APP FOLDER if webased

            //Deserializing the same, use an example as before


            //When you start the game the 2ed time after the save AKA LOAD from the JSON
            SampleDataComplex dataFromJson = JsonUtility.FromJson<SampleDataComplex>(dataToJson);

            Debug.Log(dataFromJson.name); 

        }
    }
}
