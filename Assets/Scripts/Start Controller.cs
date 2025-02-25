using UnityEngine;
using UnityEngine.SceneManagement;


public class StartController : MonoBehaviour
{
    public void BackBtnClicked()
    {
        //Load Main Menu
        SceneManager.LoadScene("Main Menu");
    }

    public void ResetBtnClicked()
    {
        //Load Start
        SceneManager.LoadScene("Start");
    }

    
}
