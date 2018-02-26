using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public BlackjackDealer Dealer_Script;

	public string gameState;
	public int min;
	public int max;

	public PlayerScript player1_Script;
	public PlayerScript player2_Script;
	public PlayerScript player3_Script;

	public bool player1isPlaying;
	public bool player2isPlaying;
	public bool player3isPlaying;

	public Animator cameraAnimator;
	public bool toggleCamera;


	private void Awake()
	{
		min = 25;
		max = 5000;

		toggleCamera = false;

		player1isPlaying = true;
		player2isPlaying = true;
		player3isPlaying = true;

		player1_Script.playerNumber = "player1";
		player1_Script.playerType = "AI";
		player1_Script.playerPlayStyle = "Angressive";
		player1_Script.playerCoins = 1604523;
		player2_Script.playerNumber = "player2";
		player2_Script.playerType = "player";
		player2_Script.playerPlayStyle = "Player";
		player2_Script.playerCoins = 45450;
		player3_Script.playerNumber = "player3";
		player3_Script.playerType = "AI";
		player1_Script.playerPlayStyle = "Beginner";
		player3_Script.playerCoins = 597;
	}

	// Use this for initialization
	void Start () {
		
		StartCoroutine(StartBlackjackGame());
	}

		
	void Update () {
		
	}
	
	IEnumerator StartBlackjackGame() {
		while (true)
		{
			//Start Betting Phase
			gameState = "BettingChips";
			Dealer_Script.StartBettingPhase();
			while (gameState == "BettingChips")
			{
				yield return new WaitForSeconds(1.0f);
			}
			Debug.Log("Done Betting Phase");
			//End of Betting Phase

			//Start Dealing Phase
			gameState = "DealingCards";
			Dealer_Script.StartDealingPhase();
			while (gameState == "DealingCards")
			{
				yield return new WaitForSeconds(1.0f);
			}
			Debug.Log("Done Dealing Phase");
			//End of Dealing Phase

			//Start Hitting Phase
			gameState = "HittingPhase";
			Dealer_Script.StartHittingPhase();
			while (gameState == "HittingPhase")
			{
				yield return new WaitForSeconds(1.0f);
			}
			Debug.Log("Done Hitting Phase");
			//END Hitting Phase

			//Start Dealer Phase
			gameState = "DealerPhase";
			Dealer_Script.StartDealerPhase();
			while (gameState == "DealerPhase")
			{
				yield return new WaitForSeconds(1.0f);
			}
			Debug.Log("Done Dealer Phase");
			//END Dealer Phase

			yield return null;
			Dealer_Script.InitializeVariables();
			player1_Script.InitializeVariables();
			player2_Script.InitializeVariables();
			player3_Script.InitializeVariables();
		}
		
	}

	public void CameraToggle() {

		

	}

	public void MoveCameraBack() {

		cameraAnimator.Play("MoveFromTable");
	}

	public void MoveCameraHittingView()	{

		cameraAnimator.Play("MoveToTable");
	}

	public void MoveToP1()
	{

		cameraAnimator.Play("MoveToPlayer1");
	}


	public void MoveToP3()
	{

		cameraAnimator.Play("MoveToPlayer3");
	}

	public void MoveToD()
	{

		cameraAnimator.Play("DealerView");
	}
}
