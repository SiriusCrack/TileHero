using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject hero;
    [SerializeField] GameObject gridManager;
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
        SceneManager.LoadScene("Level0");
    }

    public void StartGame()
    {
        EndTile = GameObject.FindWithTag("End");
        var gridW = gridManager.GetComponent<GridManager>().width;
        var gridH = gridManager.GetComponent<GridManager>().height;
        gridManager.GetComponent<GridManager>().validPath.Add(((gridW-1, gridH-1), EndTile));
        Debug.Log(gridManager.GetComponent<GridManager>().validPath.Last());

        hero.SetActive(true);
        Time.timeScale = 1;
    }
}
