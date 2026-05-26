using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class StartButton : MonoBehaviour
{
    public void Game1Start(string gameName)
    {
        string path = Environment.CurrentDirectory + gameName;
        Application.OpenURL(path);
    }
}
