using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public GameObject gameover;
    public void RestartGame() {
        SceneManager.LoadScene("Gameplay");
        gameover.GetComponent<RectTransform>().position = new Vector3(0, -1000, 0);
        Debug.Log("buttomClicked");
    }
    
    
}
