using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CakeSizeSelector : MonoBehaviour
{
    public Slider cakeSizeSlider;      // Reference to the slider
    public Text sizeText;              // Reference to the Text element displaying the size
    public Slider cakeHeightSlider;      // Reference to the slider
    public Text heightText;              // Reference to the Text element displaying the size
    public GameObject cake;            // Reference to the cake object in the scene

    // Define cake sizes corresponding to each slider step
    private readonly int[] cakeSizes = { 6, 8, 10, 12, 14 };
    private readonly int[] cakeHeights = { 1, 2, 3, 4, 5, 6 };

    private void Start()
    {
        // Set up the slider to call UpdateCakeSize every time it's changed
        cakeSizeSlider.onValueChanged.AddListener(delegate { UpdateCakeSize(); });
        cakeHeightSlider.onValueChanged.AddListener(delegate { UpdateCakeSize(); });

        // Initialize the cake size
        UpdateCakeSize();
    }

    private void UpdateCakeSize()
    {
        // Get the integer slider value (0 to 3) and map it to a cake size
        int xsliderValue = (int)cakeSizeSlider.value;
        int cakeDiameter = cakeSizes[xsliderValue];
        int ysliderValue = (int)cakeHeightSlider.value;
        int cakeHeight = cakeHeights[ysliderValue];
        // Update the text to show the selected cake size
        sizeText.text = "Cake Size: " + cakeDiameter + "\"";
        heightText.text = "Cake layers: " + cakeHeight;

        // Adjust the scale of the cake based on the selected size
        float xscaleFactor = cakeDiameter / 5.0f; // Adjust scale factor as needed
        float yscaleFactor = cakeHeight / 5.0f; // Adjust scale factor as needed

        cake.transform.localScale = new Vector3(xscaleFactor, yscaleFactor, xscaleFactor);
    }

}


