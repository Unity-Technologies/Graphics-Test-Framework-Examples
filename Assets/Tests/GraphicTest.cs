using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Graphics;

public class GraphicTestFramework
{
    [PrebuildSetup("SetupGraphicsTestCases")] // This will call the "Setup" function in SetupGraphicsTestCases.cs
    [UseGraphicsTestCases] // Tells TestRunner that the following function is a test. (it inherits from UnityTest)
    public static IEnumerator GraphicTest( GraphicsTestCase testCase )
    {
        SceneManager.LoadScene(testCase.ScenePath);

        // Arbitrary wait for 5 frames for the scene to load, and other stuff to happen (like Realtime GI to appear ...)
        for (int i=0 ; i<5 ; ++i)
            yield return null;
        
        // Load the test settings
        var settings = GameObject.FindObjectOfType<GraphicsTestSettings>();
        if (settings == null)
        {
            Assert.Fail("Missing test settings for graphic tests.");
        }
        
        // Get the test camera
        var camera = settings.gameObject.GetComponent<Camera>();
        
        if (camera == null) camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (camera == null) camera = GameObject.FindObjectOfType<Camera>();
        if (camera == null)
        {
            Assert.Fail("Missing camera for graphic tests.");
        }
        
        // Do the image comparison test
        ImageAssert.AreEqual(testCase.ReferenceImage, camera, (settings != null)?settings.ImageComparisonSettings:null);
        
        yield return null;
    }
    
#if UNITY_EDITOR
    // This step is needed to save the result images in the project.
    
    [TearDown]
    public void DumpImagesInEditor()
    {
        UnityEditor.TestTools.Graphics.ResultsUtility.ExtractImagesFromTestProperties(TestContext.CurrentContext.Test);
    }
#endif
}
