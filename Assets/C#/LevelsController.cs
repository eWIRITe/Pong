using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsController : MonoBehaviour
{
    public void Level(int level)
    {
        SceneManager.LoadScene(level);
    }
}
