using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip menuSound;
    public void PlayGame()
    {
        AudioSource.PlayClipAtPoint(menuSound, new Vector3(0, 0, 0), 1f);
        SceneManager.LoadSceneAsync(1);
    }
    public void Tutorial()
    {
        AudioSource.PlayClipAtPoint(menuSound, new Vector3(0, 0, 0), 1f);
        SceneManager.LoadSceneAsync(2);
    }
    public void Mainmenu()
    {
        AudioSource.PlayClipAtPoint(menuSound, new Vector3(0, 0, 0), 1f);
        SceneManager.LoadSceneAsync(0);
    }
    public void PlaySound()
    {
        AudioSource.PlayClipAtPoint(menuSound, new Vector3(0, 0, 0), 1f);
    }
}
