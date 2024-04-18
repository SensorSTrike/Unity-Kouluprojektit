using UnityEngine;
using UnityEngine.SceneManagement;

public class Backtomenubutton : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("PelinAlku");
    }
}
