using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public float cornerCoord = 0.45f;
    public float edgeCoord = 0.325f;
    public int edgeCellCount = 9;
    public Vector2[] cells;
    public GameObject player;

    void Start()
    {
        cells = new Vector2[(edgeCellCount+1)*4];
        for(int e = 0; e < 4; e++)
        {
            int xsign = (e == 2 || e == 3) ? -1 : 1;
            int zsign = (e == 1 || e == 2) ? -1 : 1;
            cells[e*(edgeCellCount+1)] = new Vector2(cornerCoord * xsign, cornerCoord * zsign);
            for(int i = 0; i < edgeCellCount; i++)
            {
                if(e%2 == 0)
                {
                    cells[e*(edgeCellCount+1) + i + 1] = new Vector2(
                        cornerCoord * (1-e),
                        (edgeCoord - i*(edgeCoord*2 / (edgeCellCount-1))) * (1-e)
                    );
                }
                else
                {
                    cells[e*(edgeCellCount+1) + i + 1] = new Vector2(
                        (edgeCoord - i*(edgeCoord*2 / (edgeCellCount-1))) * (2-e),
                        cornerCoord * (e-2)
                    );
                }
            }
        }

        int playerPosition = PlayerPrefs.GetInt("Position");
        MovePlayerToCell(playerPosition);

        StartCoroutine(SimulatePlayer());
    }

    public void MovePlayerToCell(int cellPosition)
    {
        player.transform.localPosition = new Vector3(
            cells[cellPosition].x,
            player.transform.localPosition.y,
            cells[cellPosition].y
        );
        PlayerPrefs.SetInt("Position", cellPosition);
    }

    public void TriggerCellAt(int cellPosition)
    {
        switch(cellPosition)
        {
            case 0:
                SceneManager.LoadScene("End");
                return;

            // NTHU View Cells
            case 1:
                SceneManager.LoadScene("Door");
                return;
            case 2:
                SceneManager.LoadScene("Playground");
                return;
            case 4:
                SceneManager.LoadScene("Chemical");
                return;
            case 5:
                SceneManager.LoadScene("Lake");
                return;
            case 7:
                SceneManager.LoadScene("Club");
                return;
            case 9:
                SceneManager.LoadScene("Administration");
                return;
            case 11:
                SceneManager.LoadScene("Physics");
                return;
            case 12:
                SceneManager.LoadScene("Library");
                return;
            case 14:
                SceneManager.LoadScene("Grass");
                return;
            case 15:
                SceneManager.LoadScene("Police");
                return;
            case 17:
                SceneManager.LoadScene("Lake");
                return;
            case 19:
                SceneManager.LoadScene("Chemical");
                return;
            case 20:
                SceneManager.LoadScene("Lake");
                return;
            case 21:
                SceneManager.LoadScene("Library");
                return;
            case 22:
                SceneManager.LoadScene("Administration");
                return;
            case 25:
                SceneManager.LoadScene("Physics");
                return;
            case 26:
                SceneManager.LoadScene("Club");
                return;
            case 29:
                SceneManager.LoadScene("Playground");
                return;
            case 31:
                SceneManager.LoadScene("Chemical");
                return;

            // Fate Cells
            case 18:
            case 28:
                SceneManager.LoadScene("Fate");
                return;
        }
        return;
    }

    public void GoRolling()
    {
        SceneManager.LoadScene("Rolling");
    }

    public void GoLottery()
    {
        SceneManager.LoadScene("Lottery");
    }

    IEnumerator SimulatePlayer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            int rollingResult = PlayerPrefs.GetInt("Rolling");
            if(rollingResult > 0)
            {
                int playerPosition = PlayerPrefs.GetInt("Position");
                for(int i = 0; i < rollingResult; i++)
                {
                    playerPosition = (playerPosition+1) % cells.Length;
                    MovePlayerToCell(playerPosition);
                    yield return new WaitForSeconds(0.5f);
                }
                PlayerPrefs.SetInt("Rolling", 0);
                yield return new WaitForSeconds(1f);
                TriggerCellAt(playerPosition);
            }
        }
    }
}
