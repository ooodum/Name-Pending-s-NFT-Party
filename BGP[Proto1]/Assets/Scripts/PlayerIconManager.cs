using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIconManager : MonoBehaviour
{
    //Reference the player icon prefab
    [SerializeField] private GameObject playerIcon;

    //Reference the different icons
    [SerializeField] private Sprite icon1;
    [SerializeField] private Sprite icon2;
    [SerializeField] private Sprite icon3;
    [SerializeField] private Sprite icon4;

    //Reference to the player spawner because it stores the number of players
    [SerializeField] private PlayerSpawn playerSpawn;
    
    //A variable to store the width of the container for the player icons
    private float width;

    //Creates a list to store the player icons created
    private List<GameObject> playerIconList = new List<GameObject>();
    void Start() {
        width = gameObject.GetComponent<RectTransform>().sizeDelta.x;

        // A for loop that repeats itself depending on however many players there are
        for (int i = 0; i < playerSpawn.numberOfPlayers; i++) {
            //A variable that will center the player icons no matter how many there are
            float centering = ((i) * (width / (playerSpawn.numberOfPlayers))) - (width / (2)) + (width / (2 * playerSpawn.numberOfPlayers));
            //Just a special case for 2 players because the spacing between the icons is too much
            if (playerSpawn.numberOfPlayers == 2) centering = ((i+1) * (width / (playerSpawn.numberOfPlayers+2))) - (width / (2)) + (width / (2 * (playerSpawn.numberOfPlayers+2)));

            //Create and place the player icon accordingly
            playerIconList.Add(transform.GetChild(i).gameObject);
            playerIconList[i].SetActive(true);
            playerIconList[i].GetComponent<RectTransform>().localPosition = new Vector2(centering,0);
            playerIconList[i].name = $"Player {i+1} Icon";

            switch (i) {
                case 0:
                    playerIconList[i].transform.GetChild(1).GetComponent<Image>().sprite = icon1;
                    break;
                case 1:
                    playerIconList[i].transform.GetChild(1).GetComponent<Image>().sprite = icon2;
                    break;
                case 2:
                    playerIconList[i].transform.GetChild(1).GetComponent<Image>().sprite = icon3;
                    break;
                case 3:
                    playerIconList[i].transform.GetChild(1).GetComponent<Image>().sprite = icon4;
                    break;
            }
        }
    }

    void Update() {
        
    }
}
