using UnityEngine;
using UnityEngine.SceneManagement;

public class inGameSettingsButton : MonoBehaviour
{
    public void LoadGameStartMenu()
    {
        SceneManager.LoadScene("PelinAlku");
    }
}
