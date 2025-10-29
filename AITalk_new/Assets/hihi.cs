using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
public class hihi : MonoBehaviour
{
    FlowerSystem fs;
    // Start is called before the first frame update
    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);
        fs.ReadTextFromResource("Intro");
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            fs.Next();
    }
}
