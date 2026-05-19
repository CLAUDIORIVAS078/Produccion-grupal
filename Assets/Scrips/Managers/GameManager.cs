using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    [SerializeField]
    private GameObject _derrota;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        { 
            Time.timeScale = 0;
            _derrota.SetActive(true);
        }
        else {Time.timeScale = 1; }
    }

    public void Reiniciar(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
