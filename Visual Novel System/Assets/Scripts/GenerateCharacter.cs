using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;

/* TODO: Create a script that, when given phrases such as "mad" and "pose1",
 * will assemble the correct sprite for the specified character and place them
 * in the inspector.
 */


[ExecuteInEditMode]
public class GenerateCharacter : MonoBehaviour
{
    // Create variables here.
    public new string name = "";
    public new string pose = "";
    public new string face = "";
    private const string filePathFrag = "Assets/Characters/";

    List<string> files = new List<string>();

    private GameObject character;
    private SpriteRenderer sprite;

	// Use this for initialization
	void Start()
    {
        //character = new GameObject(name);
    }
	
	// Update is called once per frame
	void Update()
    {
        
        // Fill the list with all the .png files, if any.
        try
        {
            files = new List<string>(Directory.GetFiles(filePathFrag + name).Where(str => !str.EndsWith(".meta")));
        }
        catch { }

        // Generate a game object and give it a SpriteRenderer.
    }
}
