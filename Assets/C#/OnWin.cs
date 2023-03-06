using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnWin : MonoBehaviour
{
    public GameObject WinCanv;
    public GameObject atherCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Win();
            Destroy(collision.gameObject);
        }
    }

    void Win()
    {
        WinCanv.SetActive(true);
        atherCanvas.SetActive(false);
    }

    public void OnTryAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(1);
    }
}
