using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject hero;
    [SerializeField] GameObject GridManager;
    private GameObject EndTile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGrid() {
        SceneManager.LoadScene("MainScene");
    }

    public void StartGame()
    {
        EndTile = GameObject.FindWithTag("End");
        var gridw = GridManager.GetComponent<GridManager>().width;
        var gridh = GridManager.GetComponent<GridManager>().height;
        GridManager.GetComponent<GridManager>().Path.Add(((gridw-1, gridh-1), EndTile));
        Debug.Log(GridManager.GetComponent<GridManager>().Path.Last());

        hero.SetActive(true);
        Time.timeScale = 1;
    }
}
