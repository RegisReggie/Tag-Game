using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Put Players in the scene in a list
    public List<GameObject> players = new List<GameObject>();

    // Used to randomly Select player from list
    public int playerSelector;

    //checks when game has started
    public bool startGame = false;

    // checks to see if game is over
    public bool gameOver = false;

    // check to see if timer is running
    public bool isTimerRunning;

    //timer count
    public float timer;

    //delay start of game
    public float startDelay = 5f;


    // Start is called before the first frame update
    void Start()
    {
        //Start game after some time has passed
        StartCoroutine(StartGame(startDelay));

        //Starts timer at the beginning
        isTimerRunning = true;
        
        //Gameover is false at start
        gameOver = false;

        //Find gameobjects with the tag "TagSystem" in the scene
        GameObject[] findPlayers = GameObject.FindGameObjectsWithTag("Player");

        //Create players tag to "Runner" then put them into the list
        foreach (GameObject player in findPlayers)
        {
            player.tag = "Runner";
            players.Add(player);

        }

        // Generates a random number from 0 to the size of the list 
        playerSelector = Random.Range(0, players.Count);

        //Picks who is "It" at star of the game
        //players[playerSelector].tag = "It";

        //sets timer
        timer = 30;
    }

    // Update is called once per frame
    void Update()
    {
        //if game hasnt started, do nothing
        if (!startGame)
        {
            return;
        }

        //if timer is running then decrease it every second, if its not then the time is 0
        if (isTimerRunning)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
        }

        //if timer is less then 0 (Dont want it to be zero because going to use this variable to show time) Destroy whoever is it and select new player to be it
        if (timer < 0)
        {
            DestroyPlayerAndNewTagger();
        }
        
        // if only 1 player is in list then the game is over
        if(players.Count == 1)
        {
            gameOver = true;
        }

        if (gameOver)
        {
            GameOver();
        }
    }

    //Destroys player from list and game and selects a name player to be it
    public void DestroyPlayerAndNewTagger()
    {
        // removes whoever is it from the list
        players.Remove(GameObject.FindGameObjectWithTag("It"));

        //removes whoever is it from the scene
        Destroy(GameObject.FindGameObjectWithTag("It"));

        //generates a new number
        playerSelector = Random.Range(0, players.Count);

        //selects who is it now
        players[playerSelector].tag = "It";

        //resets timer
        ResetTimer();
    }

    // Resets timer
    public void ResetTimer()
    {
        timer = 30;
    }

    //What happens when game is over
    public void GameOver()
    {
        Debug.Log(players[0].name  + " Has Won!");

        //Stop timer
        isTimerRunning = false;
    }

    //Delays the start of the game
    IEnumerator StartGame(float delayTimer)
    {
        yield return new WaitForSeconds(delayTimer);
        startGame = true;
    }
}
