using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarScript : MonoBehaviour {
    private float fillAmount;   // How full the healthbar is ( valid values are between 0 and 1)
    private int health;         // Player's current hp
    private int healthMax;      // Player's maximum hp
    private bool gameOver;      // Whether the player has lost

    [SerializeField]
    private Image content;

	// Use this for initialization
	void Start () {
        gameOver = false;
        fillAmount = 1;
        healthMax = 5;
        health = healthMax;
    }
	
	// Update is called once per frame
	void Update () {
        HandleBar();
        if (health <= 0)
            EndGame();

        if (!gameOver && Input.GetKeyDown(KeyCode.Backspace))
            DamagePlayer();


		if ( gameOver && (Input.GetKeyDown(KeyCode.Return) || Cardboard.SDK.Triggered) )
            Restart();
	}

    private void HandleBar()
    {
        if (fillAmount > (float)health / healthMax)
            fillAmount = fillAmount - ( 0.005f + .05f * ( fillAmount - (float)health / healthMax) );
        content.fillAmount = fillAmount;
    }
    public void DamagePlayer()
    {
        health--;
    }

    public void EndGame()
    {
        gameOver = true;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
