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
            // NTHU View Cells
            case 1:
                return;
            case 3:
                return;
            case 6:
                return;
            case 8:
                return;
            case 9:
                return;
            case 11:
                return;
            case 13:
                return;
            case 14:
                return;
            case 16:
                return;
            case 18:
                return;
            case 19:
                return;
            case 21:
                return;
            case 23:
                return;
            case 24:
                return;
            case 26:
                return;
            case 27:
                return;
            case 29:
                return;
            case 31:
                return;
            case 32:
                return;
            case 34:
                return;
            case 37:
                return;
            case 39:
                return;
            
            // Fate Cells
            case 7:
            case 22:
            case 36:
                SceneManager.LoadScene("Fate");
                return;
        }
        return;
    }

    public void GoRolling()
    {
        SceneManager.LoadScene("Rolling");
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
