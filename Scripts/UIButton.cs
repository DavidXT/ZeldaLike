using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public void retryButton()
    {
        Scene scene = SceneManager.GetActiveScene(); //Récupère la map
        SceneManager.LoadScene(scene.name); //Recharge la map
    }

    public void exitButton()
    {
        Application.Quit();//Quitte l'application
    }
}
