using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Diagnostics;

public class ParameterCollector : MonoBehaviour
{
    public Dropdown numPointsDropdown;
    public Slider outerRadiusSlider;
    public Slider innerRadiusSlider;
    public Slider cakeDiameterSlider;
    private readonly int[] cakeSizes = { 6, 8, 10, 12, 14 };

    [System.Serializable]
    public class ParameterDictionary<TKey, TValue>
    {
        public List<TKey> keysList = new List<TKey>();
        public List<TValue> valuesList = new List<TValue>();


    }

    public void SaveParameters()
    {
        int cakeDiameter = cakeSizes[(int)cakeDiameterSlider.value];

        try
        {
            // Create a dictionary to hold the parameters
            var parameters = new ParameterDictionary<string, int>();
            parameters.keysList.Add("num_points"); parameters.valuesList.Add((int)numPointsDropdown.value);
            parameters.keysList.Add("outer_radius"); parameters.valuesList.Add((int)outerRadiusSlider.value);
            parameters.keysList.Add("inner_radius"); parameters.valuesList.Add((int)innerRadiusSlider.value);
            parameters.keysList.Add("cake_radius"); parameters.valuesList.Add(cakeDiameter);


            // Convert the dictionary to JSON format
            string json = JsonUtility.ToJson(parameters);

            if (File.Exists("C:/Users/tshad/Documents/PROJECTS/final_year_project/pipingPy/parameters.json"))
            {
                // File exists!
                File.Delete("C:/Users/tshad/Documents/PROJECTS/final_year_project/pipingPy/parameters.json");
            }
            else
            {
                // File does not exist.
                //
                // This could mean it was deleted or has not been created yet.
            }
            // Define the file path
            string parametersFile = "C:/Users/tshad/Documents/PROJECTS/final_year_project/pipingPy/parameters.json";

            // Write JSON to a file
            File.WriteAllText(parametersFile, json);
            UnityEngine.Debug.Log("Parameters saved to " + parametersFile);

            // Call the Python script
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogError("Error saving parameters: " + e.Message);
        }
    }

}
