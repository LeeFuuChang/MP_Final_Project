using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    public float cornerCoord = 0.45f;
    public float edgeCoord = 0.325f;
    public int edgeCellCount = 9;
    public Vector2[] cells;
    public GameObject map;

    public int balanceToLottery = 10000;

    public TextMeshProUGUI balanceText;

    public GameObject defaultCharactorPrefab;
    public GameObject maleCharactorPrefab;
    public GameObject femaleCharactorPrefab;

    private GameObject camera;
    private GameObject player;

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

        camera = GameObject.Find("Camera");

        switch(PlayerPrefs.GetString("Charactor", "N"))
        {
            case "M":
                player = (GameObject)Instantiate(maleCharactorPrefab, Vector3.zero, Quaternion.identity, map.transform);
                break;
            case "F":
                player = (GameObject)Instantiate(femaleCharactorPrefab, Vector3.zero, Quaternion.identity, map.transform);
                break;
            default:
                player = (GameObject)Instantiate(defaultCharactorPrefab, Vector3.zero, Quaternion.identity, map.transform);
                break;
        }
        player.name = "Player";

        int playerPosition = PlayerPrefs.GetInt("Position", 0);
        MovePlayerToCell(playerPosition);

        SetBalance(PlayerPrefs.GetInt("Balance", 0));

        StartCoroutine(SimulatePlayer());
    }

    public void MovePlayerToCell(int cellPosition)
    {
        Vector3 curtCellPosition = new Vector3(
            cells[cellPosition].x,
            player.transform.localPosition.y,
            cells[cellPosition].y
        );
        Vector3 nextCellPosition = new Vector3(
            cells[(cellPosition+1) % cells.Length].x,
            player.transform.localPosition.y,
            cells[(cellPosition+1) % cells.Length].y
        );
        Vector3 deltaVector = (nextCellPosition - curtCellPosition).normalized;
        player.transform.localPosition = curtCellPosition;
        player.transform.LookAt(player.transform.position + deltaVector);
        PlayerPrefs.SetInt("Position", cellPosition);
        camera.transform.localPosition = new Vector3(
            player.transform.localPosition.x - (deltaVector.z + deltaVector.x)*0.1f,
            player.transform.localPosition.y + 6f,
            player.transform.localPosition.z - (deltaVector.z - deltaVector.x)*0.1f
        );
        camera.transform.LookAt(player.transform.position);
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
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Door");
                return;
            case 2:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Playground");
                return;
            case 4:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Chemical");
                return;
            case 5:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Lake");
                return;
            case 7:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Club");
                return;
            case 9:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Administration");
                return;
            case 11:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Physics");
                return;
            case 12:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Library");
                return;
            case 14:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Grass");
                return;
            case 15:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Police");
                return;
            case 17:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Lake");
                return;
            case 19:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Chemical");
                return;
            case 20:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Lake");
                return;
            case 21:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Library");
                return;
            case 22:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Administration");
                return;
            case 25:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Physics");
                return;
            case 26:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Club");
                return;
            case 29:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Playground");
                return;
            case 31:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) + 500);
                SceneManager.LoadScene("Chemical");
                return;

            // Event Cells
            case 3:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) - 200);
                return;
            case 6:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) - 200);
                return;
            case 10:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) - 200);
                return;
            case 13:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) - 500);
                return;
            case 23:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) - 300);
                return;
            case 27:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) - 200);
                return;
            case 30:
                SetBalance(PlayerPrefs.GetInt("Balance", 0) - 200);
                return;

            // Fate Cells
            case 18:
            case 28:
                SceneManager.LoadScene("Fate");
                return;
        }
        return;
    }

    public void SetBalance(int bal)
    {
        int newbal = Mathf.Max(0, bal);
        PlayerPrefs.SetInt("Balance", newbal);
        balanceText.text = $"${newbal}";
    }

    public void GoRolling()
    {
        SceneManager.LoadScene("Rolling");
    }

    public void GoLottery()
    {
        if(PlayerPrefs.GetInt("Balance", 0) >= balanceToLottery)
        {
            SetBalance(PlayerPrefs.GetInt("Balance", 0) - balanceToLottery);
            SceneManager.LoadScene("Lottery");
        }
    }

    IEnumerator SimulatePlayer()
    {
        // while(true)
        // {
        //     yield return new WaitForSeconds(1f);
        //     int rollingResult = PlayerPrefs.GetInt("Rolling");
        //     if(rollingResult > 0)
        //     {
        //         int playerPosition = PlayerPrefs.GetInt("Position");
        //         for(int i = 0; i < rollingResult; i++)
        //         {
        //             playerPosition = (playerPosition+1) % cells.Length;
        //             MovePlayerToCell(playerPosition);
        //             yield return new WaitForSeconds(0.5f);
        //         }
        //         PlayerPrefs.SetInt("Rolling", 0);
        //         yield return new WaitForSeconds(1f);
        //         TriggerCellAt(playerPosition);
        //     }
        // }
        int playerPosition = PlayerPrefs.GetInt("Position");
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            MovePlayerToCell(playerPosition);
            playerPosition = (playerPosition+1) % cells.Length;
        }
    }
}
