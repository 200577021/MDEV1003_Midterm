using UnityEngine;
using UnityEngine.SceneManagement;


public class StartController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void BackBtnClicked()
    {
        //Load Level 1
        SceneManager.LoadScene("Main Menu");
    }

    // Update is called once per frame
    
}
