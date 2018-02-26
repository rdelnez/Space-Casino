using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public string playerNumber;
	public string playerType;
	public bool hasSplit;
	public bool hasNoSplitBet;
	public bool hasSplit1Bet;
	public bool hasSplit2Bet;



	//Start for Hitting
	public string playerPlayStyle;
	public int playerTotalCardValue;
	public int playerTotalCardValueSplit1;
	public int playerTotalCardValueSplit2;
	public string hittingResponse;
	public string playerStatus;
	public int hasAceNumber;
	public int hasAceNumberSplit1;
	public int hasAceNumberSplit2;

	public int card1CharValue;
	public int card2CharValue;

	public int tempStandCheck;

	public string whichCardSet;     // values: NoSplit,Split1,Split2
									//END for Hitting

	//Start for Payment
	public GameObject playerPaymentDisplay;
	public Text playerPaymentDisplay_Text;
	//END for Payment


	//Start for Chat
	public GameObject speechBubble;

	public Sprite hitSpeech;
	public Sprite standSpeech;
	public Sprite doubleSpeech;
	public Sprite splitSpeech;
	public Sprite shooSpeech;
	public Sprite jackarooSpeech;
	//END for Chat

	public int playerCoins;
	public Text playerCoinsText;
	public int bet;
	public Text betText;


	BlackjackDealer Dealer_Script;
	GameManager GM_Script;
	public int min;
	public int max;
	
	public Transform chipsPanel_Transform;
	public GameObject betButton;

	private void Awake()
	{

		hasNoSplitBet = false;
		hasSplit1Bet = false;
		hasSplit2Bet = false;



	}

	// Use this for initialization
	void Start () {

		Dealer_Script = GameObject.FindGameObjectWithTag("Dealer").gameObject.GetComponent<BlackjackDealer>();
		GM_Script = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<GameManager>();

		InitializeVariables();


		min = GM_Script.min;
		max = GM_Script.max;


		bet = min;
		UpdateCoinDisplay();
		UpdateBetDisplayTextOnly();




	}

	public void InitializeVariables() {

		

		hasNoSplitBet = false;
		hasSplit1Bet = false;
		hasSplit2Bet = false;
		hasSplit = false;

		playerTotalCardValue = 0;
		playerTotalCardValueSplit1 = 0;
		playerTotalCardValueSplit2 = 0;
		hittingResponse = "stand";
		playerStatus = "idle";
		hasAceNumber = 0;
		hasAceNumberSplit1 = 0;
		hasAceNumberSplit2 = 0;

		
		whichCardSet = "NoSplit";


		min = GM_Script.min;
		max = GM_Script.max;


		bet = min;


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ConfirmStandBetAI() {

		StartCoroutine(AIDelayStandBet());
		
	}

	IEnumerator AIDelayStandBet() {
		float tempDelay = Random.Range(2.0f, 4.0f);
		yield return new WaitForSeconds(tempDelay);
		hittingResponse = "stand";
		playerStatus = "isHitting";

		//if (Dealer_Script.dealerTotalCardValue ) {

		if (hasSplit == false) {    //this value is changed in the Dealer Script
			CheckSplitStandHit(playerTotalCardValue);
		}
		else if (hasSplit == true)
		{
			if (whichCardSet == "Split1")
			{
				CheckSplitStandHit(playerTotalCardValueSplit1);
			}
			else {
				CheckSplitStandHit(playerTotalCardValueSplit2);
			}

		}
		
	}

	public void CheckSplitStandHit(int tempPlayerTotalCardValue) {
		tempStandCheck = 16;

		if ((card1CharValue == card2CharValue || (card1CharValue >= 10 && card2CharValue >= 10)) && whichCardSet == "NoSplit") {
		//if (whichCardSet == "NoSplit"){
			StartCoroutine(EnableChatObject(speechBubble, splitSpeech));
			ConfirmStandBet("split");

		}
		else if (tempPlayerTotalCardValue >= tempStandCheck) //16 //21
		{
			StartCoroutine(EnableChatObject(speechBubble, standSpeech));
			ConfirmStandBet("stand");
		}
		else if (tempPlayerTotalCardValue < 16) //16 //2
		{
			StartCoroutine(EnableChatObject(speechBubble, hitSpeech));
			ConfirmStandBet("hit");
		}
		
	}

	public void PlayerHit() {
		StartCoroutine(EnableChatObject(speechBubble, hitSpeech));
		ConfirmStandBet("hit");
	}

	public void PlayerStand() {
		StartCoroutine(EnableChatObject(speechBubble, standSpeech));
		ConfirmStandBet("stand");
	}

	public void PlayerSplit() {
		StartCoroutine(EnableChatObject(speechBubble, splitSpeech));
		ConfirmStandBet("split");

	}



	public void ConfirmStandBet(string tempHittingResponse) {

		hittingResponse = tempHittingResponse;
		playerStatus = "doneHitting";

		if (playerNumber == "player1")
			Dealer_Script.player1Betting = false;
		if (playerNumber == "player2")
			Dealer_Script.player2Betting = false;
		if (playerNumber == "player3")
			Dealer_Script.player3Betting = false;
	}

	public void UpdateBetDisplayTextOnly() {
		betText.text = "$" + bet.ToString();
	}

	public void UpdateCoinDisplay() {

	
		float tempPlayerCoins = playerCoins;
		if (tempPlayerCoins > 1000000000) {
			tempPlayerCoins /= 1000000000;
			playerCoinsText.text = string.Format("{0:$###.###B}", tempPlayerCoins) + "";
		}
		else if (tempPlayerCoins > 1000000)
		{
			tempPlayerCoins /= 1000000;
			playerCoinsText.text = string.Format("{0:$###.###M}", tempPlayerCoins) + "";
		}
		else
		{
			
			playerCoinsText.text = string.Format("{0:$###,###}", tempPlayerCoins) + "";
		}

	}

	public void UpdatePaymentDisplay(int tempPayment, string tempString)
	{


		float tempPlayerCoins = tempPayment;
		if (tempPlayerCoins > 999999999)
		{
			tempPlayerCoins /= 1000000000;
			playerPaymentDisplay_Text.text = string.Format("{0:" + tempString + "$###.#B}", tempPlayerCoins) + "";
		}
		else if (tempPlayerCoins > 999999)
		{
			tempPlayerCoins /= 1000000;
			playerPaymentDisplay_Text.text = string.Format("{0:" + tempString + "$###.#M}", tempPlayerCoins) + "";
		}
		else if (tempPlayerCoins > 999)
		{
			tempPlayerCoins /= 1000;
			playerPaymentDisplay_Text.text = string.Format("{0:" + tempString + "$###.#K}", tempPlayerCoins) + "";
		}
		else
		{
			playerPaymentDisplay_Text.text = string.Format("{0:" + tempString + "$###}", tempPlayerCoins) + "";
		}

	}

	public void UpdateBetDisplay(int tempPayment, string tempStartString)
	{


		float tempPlayerCoins = tempPayment;
		if (tempPlayerCoins > 1000000000)
		{
			tempPlayerCoins /= 1000000000;
			playerPaymentDisplay_Text.text = tempStartString + " " + string.Format("{0:$###.###B}", tempPlayerCoins) + "";
		}
		else if (tempPlayerCoins > 1000000)
		{
			tempPlayerCoins /= 1000000;
			playerPaymentDisplay_Text.text = tempStartString + " " + string.Format("{0:$###.###M}", tempPlayerCoins) + "";
		}
		else
		{

			playerPaymentDisplay_Text.text = tempStartString + " " + string.Format("{0:$###,###}", tempPlayerCoins) + "";
		}

	}

	//Start AI code		-----------------------------------------------------------------------------------------------------------//

	public void StartBettingAI() {
		StartCoroutine(BettingAI());
	}
	
	IEnumerator BettingAI() {
		float tempDelay = Random.Range(2.0f, 4.5f); //delay before betting
		int tempRandNum = Random.Range(0,4);
		int tempBet;
		if (tempRandNum == 3)
		{
			if(playerCoins < max)
			tempBet = Random.Range(playerCoins/5, playerCoins/2);
			else
			tempBet = Random.Range(max / 5, max / 2);
		}
		else if (tempRandNum == 2)
		{
			if (playerCoins < max)
				tempBet = Random.Range(playerCoins / 10, playerCoins / 5);
			else
				tempBet = Random.Range(max / 10, max / 5);
		}
		else
		{
			if (playerCoins < min)
				tempBet = playerCoins;
			else
				tempBet = min;
		}
		bet = tempBet;
		yield return new WaitForSeconds(tempDelay);
		yield return null;
		UpdateBetDisplayTextOnly();
		ChipsConfirm();
		
	}

	//END AI code		-----------------------------------------------------------------------------------------------------------//
	public void BetButton() {
		StartCoroutine(EnableChipsPanel());
		betButton.SetActive(false);
	}

	public void ChipsBackButton()
	{
		StartCoroutine(DisableChipsPanel());
		betButton.SetActive(true);
	}

	public void ChipsBet(string betAmount) {

		bet += int.Parse(betAmount);
		if(bet > max) {
			bet = max;
		}
		betText.text = "$" + bet.ToString();
		
	}

	public void ChipsReset() {
		bet = min;
		betText.text = "$"+min.ToString();
	}


	public void ChipsConfirm()
	{
		StartCoroutine(StartChipsConfirm());
	}

		IEnumerator StartChipsConfirm() {
		if (playerType == "player") {
			betButton.SetActive(true);
			StartCoroutine(DisableChipsPanel());
		}
		hasNoSplitBet = true;
		hasSplit1Bet = false;
		hasSplit2Bet = false;

		Dealer_Script.ReceiveBet(bet,playerNumber);
		playerCoins -= bet;
		UpdateCoinDisplay();
		UpdatePaymentDisplay(bet, "+");      //what to display on the disappearing payment bar
		playerPaymentDisplay.SetActive(true);
		playerPaymentDisplay.GetComponent<Animator>().Play("AddBetDisplay");
		yield return new WaitForSeconds(2.0f);
		playerPaymentDisplay.SetActive(false);

		if (playerNumber == "player1")
			Dealer_Script.player1Betting = false;
		if (playerNumber == "player2")
			Dealer_Script.player2Betting = false;
		if (playerNumber == "player3")
			Dealer_Script.player3Betting = false;
	}

	public void SplitCardValues() {
		if (card1CharValue == 1) {
			playerTotalCardValueSplit2 = 11;
			hasAceNumberSplit2 = 1;
		}
		else if (card1CharValue > 10) {
			playerTotalCardValueSplit2 = 10;
		}
		else{
			playerTotalCardValueSplit2 = card1CharValue;
		}

		if (card2CharValue == 1)
		{
			playerTotalCardValueSplit1 = 11;
			hasAceNumberSplit1 = 1;
		}
		else if (card2CharValue > 10)
		{
			playerTotalCardValueSplit1 = 10;
		}
		else
		{
			playerTotalCardValueSplit1 = card2CharValue;
		}

	}

	public void IncrementCardIndex(string tempPlayer) {
		if (tempPlayer == "player1") {
			Dealer_Script.player1tempCardIndex++;
		}
		else if (tempPlayer == "player2")
		{
			Dealer_Script.player2tempCardIndex++;
		}
		else if (tempPlayer == "player3")
		{
			Dealer_Script.player3tempCardIndex++;
		}



	}

	public void CallAddToBet() {
		StartCoroutine(AddToBet());
	}

	IEnumerator AddToBet() {


		//UpdateBetDisplay(bet, "Bet +");

		UpdatePaymentDisplay(bet, "+");
		playerPaymentDisplay.SetActive(true);
		playerPaymentDisplay.GetComponent<Animator>().Play("AddBetDisplay");
		yield return new WaitForSeconds(2.0f);
		playerPaymentDisplay.SetActive(false);

		playerCoins -= bet;
		bet = bet * 2;
		
		UpdateBetDisplayTextOnly();
		UpdateCoinDisplay();

		hasNoSplitBet = false;
		hasSplit1Bet = true;
		hasSplit2Bet = true;

		yield return null;

	}

	public void CallHalfBet() {
		StartCoroutine(HalfBet());
	}

	IEnumerator HalfBet() {
		int tempBetDeduction;
		if (hasSplit1Bet == true && hasSplit2Bet == true) {
			tempBetDeduction = bet / 2;
			if (whichCardSet == "Split1") {
				hasSplit1Bet = false;
			}
			else if (whichCardSet == "Split2") {
				hasSplit2Bet = false;
			}
		}
		else{
			tempBetDeduction = bet;
			
		}
		bet -= tempBetDeduction;

		UpdatePaymentDisplay(tempBetDeduction, "-");
		UpdateBetDisplayTextOnly();
		if (GM_Script.gameState != "DealerPhase") {
			playerPaymentDisplay.SetActive(true);
			playerPaymentDisplay.GetComponent<Animator>().Play("HalfBetDisplay");
			yield return new WaitForSeconds(1.0f);
			playerPaymentDisplay.SetActive(false);
		}
		

		//	yield return null;
	}

	public void CallBlackjackBet()
	{
		StartCoroutine(StartCallBlackjackBet());
	}

	IEnumerator StartCallBlackjackBet()
	{

		int tempBetDeduction = bet;
		bet -= tempBetDeduction;
		UpdateBetDisplay(tempBetDeduction*2, "+");
		playerPaymentDisplay.SetActive(true);
		playerPaymentDisplay.GetComponent<Animator>().Play("DisplayDisplay");
		yield return new WaitForSeconds(2.0f);
		playerPaymentDisplay.SetActive(false);
		//playerCoins = +tempBetDeduction * 2;


		UpdateBetDisplayTextOnly();
	}


	public void CallEnablePaymentDisplay() {
		StartCoroutine(EnablePaymentDisplay());
	}

	IEnumerator EnablePaymentDisplay() {
		int tempHalfBet = 0;

		if (GM_Script.gameState == "DealerPhase" && (hasSplit1Bet == true && hasSplit2Bet == true))
		{
		
			tempHalfBet = bet;                      //cause half the splitBet + dealer payment = split1bet + plit2bet
		
			
		}
		else{

			tempHalfBet = bet*2;
		
		}

			UpdatePaymentDisplay(tempHalfBet, "+");      //what to display on the disappearing payment bar
			playerPaymentDisplay.SetActive(true);
			playerPaymentDisplay.GetComponent<Animator>().Play("Display");
			yield return new WaitForSeconds(2.0f);
			playerPaymentDisplay.SetActive(false);
			playerCoins += tempHalfBet;             //update the coins variable
			StartCoroutine(HalfBet());			//Displays deduction on Bet
			UpdateCoinDisplay();
	}

	IEnumerator EnableChipsPanel() {

		while (chipsPanel_Transform.localPosition.x > 265 ) {

			chipsPanel_Transform.localPosition -= new Vector3(20,0,0);
			yield return new WaitForSeconds(0.01f);
		}
		

		
	}

	IEnumerator DisableChipsPanel()
	{

		while (chipsPanel_Transform.localPosition.x < 560)
		{

			chipsPanel_Transform.localPosition += new Vector3(20, 0, 0);
			yield return new WaitForSeconds(0.01f);
		}



	}

	IEnumerator EnableChatObject(GameObject tempGameObject, Sprite tempSprite)
	{
		tempGameObject.SetActive(true);
		tempGameObject.transform.GetChild(0).GetComponent<Image>().sprite = tempSprite;
		yield return new WaitForSeconds(1.5f);
		tempGameObject.SetActive(false);
	}


}
