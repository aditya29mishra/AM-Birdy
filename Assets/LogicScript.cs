using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int score;
    public Text text;
    public GameObject gameScreen;
    public AudioSource collisionAudioSource;public PipeSpawnerScript pipeSpawner;
    public BirdScript bird;
    // List to hold all pipes that are spawned
    private List<PipeMovementScript> activePipes = new List<PipeMovementScript>();


    public void Score (){
       
        score = score + 1;
        text.text = score.ToString();
    }

    void saceScore(){
        string filePath = "highscore.txt";

        try{
            File.WriteAllText(filePath , score.ToString());
            Debug.Log("Score saved successfully.");
        }
        catch(System.Exception e){
            Debug.Log("Failed to save score: " + e.Message);
        }

        
    }

    public void ResetScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver(){
       if (collisionAudioSource != null && !collisionAudioSource.isPlaying)
        {
            collisionAudioSource.Play();
        }
         if (pipeSpawner != null)
        {
            pipeSpawner.StopSpawning();
        }

        // Stop all active pipes from moving
        foreach (var pipe in activePipes)
        {
            pipe.StopMovement();
        }

        // Disable bird movement
        if (bird != null)
        {
            bird.DisableMovement();
        }

        //StartCoroutine(ShowGameOverScreen());

        gameScreen.SetActive(true);
    }

    IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSeconds(2);
        gameScreen.SetActive(true);
    }
    
}
