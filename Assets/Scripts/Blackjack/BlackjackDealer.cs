using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackjackDealer : MonoBehaviour {

	public GameManager GM_Script;
	public Animator DealerAnimator;

	public int dealerTotalCardValue;
	public string dealerStatus;
	public int hasAce;

	public PlayerScript Player1_Script;
	public PlayerScript Player2_Script;
	public PlayerScript Player3_Script;
	
	public RectTransform player1BetBar;
	public RectTransform player2BetBar;
	public RectTransform player3BetBar;

	public GameObject Player1BetBar_GO;
	public GameObject Player2BetBar_GO;
	public GameObject Player3BetBar_GO;

	public GameObject chatbubbleLeft;
	public GameObject chatbubbleRight;
	public Image chatbubbleLeftText;
	public Image chatbubbleRightText;

	public Sprite bettingBegins;
	public Sprite bettingEnds;
	public Sprite dealerHits;
	public Sprite dealerStands;

	public bool player1Betting;
	public bool player2Betting;
	public bool player3Betting;

	public int player1Bet;
	public int player2Bet;
	public int player3Bet;

	public int player1tempChipIndex;
	public int player2tempChipIndex;
	public int player3tempChipIndex;

	public int dealertempCardIndex;

	public int player1tempCardIndex;
		public int player1tempSplit1CardIndex;
		public int player1tempSplit2CardIndex;
	public int player2tempCardIndex;
		public int player2tempSplit1CardIndex;
		public int player2tempSplit2CardIndex;
	public int player3tempCardIndex;
		public int player3tempSplit1CardIndex;
		public int player3tempSplit2CardIndex;



	public PlayerScript player2_Script;


	public GameObject bettingPanel;
	public GameObject hittingPanel;
	public GameObject chipsPanel;

	//START Materials 
	public Material chip1;
	public Material chip5;
	public Material chip10;
	public Material chip50;
	public Material chip100;
	public Material chip500;
	public Material chip1000;
	public Material chip5000;
	//END Materials 

	//START Cards ------------------------------------------------------------------------------------------------------------//

	//Start for Enabling Cards
	public List<GameObject> tempENCardList;
	public string tempENPlayerNumber;
	public int tempENCardMatIndex;


	public GameObject DealerCardInfo;
	public GameObject player1CardInfoNoSplit;
		public GameObject player1CardInfoSplit1;
		public GameObject player1CardInfoSplit2;
	public GameObject player2CardInfoNoSplit;
		public GameObject player2CardInfoSplit1;
		public GameObject player2CardInfoSplit2;
	public GameObject player3CardInfoNoSplit;
		public GameObject player3CardInfoSplit1;
		public GameObject player3CardInfoSplit2;
	public Sprite bustedSprite;
	public Sprite blackjackSprite;
	public Sprite winSprite;
	public Sprite loseSprite;
	public Sprite drawSprite;
	//END for Enabling Cards

	//START Dealer
	public Renderer rightHandCard;
	public Renderer leftHandCard;

	public List<GameObject> DealerCards_LIST;
	public GameObject DealerCardSet;
	public GameObject dealerCard1Back;
	public GameObject dealerCard2Back;

	public float TEMPDELAY = 1.0f;
	public float TEMPDELAY2 = 0.5f;
	public float TEMPDELAY3 = 1.5f;
	//END Dealer

	//START Player1
	public List<GameObject> player1NoSplitCards_LIST;
	public GameObject player1NoSplitCardSet;
	public List<GameObject> player1Split1Cards_LIST;
	public GameObject player1Split1CardSet;
	public List<GameObject> player1Split2Cards_LIST;
	public GameObject player1Split2CardSet;
		//END Player1

		//START Player2
	public List<GameObject> player2NoSplitCards_LIST;
	public GameObject player2NoSplitCardSet;
	public List<GameObject> player2Split1Cards_LIST;
	public GameObject player2Split1CardSet;
	public List<GameObject> player2Split2Cards_LIST;
	public GameObject player2Split2CardSet;
		//END Player2

		//START Player3
	public List<GameObject> player3NoSplitCards_LIST;
	public GameObject player3NoSplitCardSet;
	public List<GameObject> player3Split1Cards_LIST;
	public GameObject player3Split1CardSet;
	public List<GameObject> player3Split2Cards_LIST;
	public GameObject player3Split2CardSet;
	//END Player3

	//Start Playing Cards
	public List<Sprite> cardSprite_LIST;
	public List<Material> cardMaterial_LIST;
	public List<int> cardValue_LIST;
	public Material tempMat;

	//END Playing Cards
	//END Cards ------------------------------------------------------------------------------------------------------------//


	public Vector3 player1ChipPos;
	public Vector3 player2ChipPos;
	public Vector3 player3ChipPos;
	public GameObject dealerChips;
	public List<GameObject> dealerChips_LIST;

	//START Players Chips
	public GameObject player1Chips;
	public GameObject player1ChipsPay;
	public GameObject player1ChipsPayDouble;
	public List<GameObject> player1Chips_LIST;
	public List<GameObject> player1ChipsPay_LIST;
	public List<GameObject> player1ChipsPayDouble_LIST;
	public GameObject player1ChipsSplit1;
	public GameObject player1ChipsPaySplit1;
	public GameObject player1ChipsPayDoubleSplit1;
	public List<GameObject> player1ChipsSplit1_LIST;
	public List<GameObject> player1ChipsPaySplit1_LIST;
	public List<GameObject> player1ChipsPayDoubleSplit1_LIST;
	public GameObject player1ChipsSplit2;
	public GameObject player1ChipsPaySplit2;
	public GameObject player1ChipsPayDoubleSplit2;
	public List<GameObject> player1ChipsSplit2_LIST;
	public List<GameObject> player1ChipsPaySplit2_LIST;
	public List<GameObject> player1ChipsPayDoubleSplit2_LIST;

	public GameObject player2Chips;
	public GameObject player2ChipsPay;
	public GameObject player2ChipsPayDouble;
	public List<GameObject> player2Chips_LIST;
	public List<GameObject> player2ChipsPay_LIST;
	public List<GameObject> player2ChipsPayDouble_LIST;
	public GameObject player2ChipsSplit1;
	public GameObject player2ChipsPaySplit1;
	public GameObject player2ChipsPayDoubleSplit1;
	public List<GameObject> player2ChipsSplit1_LIST;
	public List<GameObject> player2ChipsPaySplit1_LIST;
	public List<GameObject> player2ChipsPayDoubleSplit1_LIST;
	public GameObject player2ChipsSplit2;
	public GameObject player2ChipsPaySplit2;
	public GameObject player2ChipsPayDoubleSplit2;
	public List<GameObject> player2ChipsSplit2_LIST;
	public List<GameObject> player2ChipsPaySplit2_LIST;
	public List<GameObject> player2ChipsPayDoubleSplit2_LIST;

	public GameObject player3Chips;
	public GameObject player3ChipsPay;
	public GameObject player3ChipsPayDouble;
	public List<GameObject> player3Chips_LIST;
	public List<GameObject> player3ChipsPay_LIST;
	public List<GameObject> player3ChipsPayDouble_LIST;
	public GameObject player3ChipsSplit1;
	public GameObject player3ChipsPaySplit1;
	public GameObject player3ChipsPayDoubleSplit1;
	public List<GameObject> player3ChipsSplit1_LIST;
	public List<GameObject> player3ChipsPaySplit1_LIST;
	public List<GameObject> player3ChipsPayDoubleSplit1_LIST;
	public GameObject player3ChipsSplit2;
	public GameObject player3ChipsPaySplit2;
	public GameObject player3ChipsPayDoubleSplit2;
	public List<GameObject> player3ChipsSplit2_LIST;
	public List<GameObject> player3ChipsPaySplit2_LIST;
	public List<GameObject> player3ChipsPayDoubleSplit2_LIST;


	//END Players Chips

	// Use this for initialization

	private void Awake()
	{

		player1ChipPos = player1Chips.transform.localPosition;
		player2ChipPos = player2Chips.transform.localPosition;
		player3ChipPos = player3Chips.transform.localPosition;

		DealerAnimator = this.GetComponent<Animator>();
		dealerTotalCardValue = 0;
		hasAce = 0;

		player1Betting = false;
		player2Betting = false;
		player3Betting = false;

		player1tempChipIndex = 0;
		player2tempChipIndex = 0;
		player3tempChipIndex = 0;

		dealertempCardIndex = 0;

		player1tempCardIndex = 0;
		player2tempCardIndex = 0;
		player3tempCardIndex = 0;

		dealerChips_LIST = new List<GameObject>();

		player1Chips_LIST = new List<GameObject>();
		player1ChipsPay_LIST = new List<GameObject>();
		player1ChipsPayDouble_LIST = new List<GameObject>();
		player1ChipsSplit1_LIST = new List<GameObject>();
		player1ChipsPaySplit1_LIST = new List<GameObject>();
		player1ChipsPayDoubleSplit1_LIST = new List<GameObject>();
		player1ChipsSplit2_LIST = new List<GameObject>();
		player1ChipsPaySplit2_LIST = new List<GameObject>();
		player1ChipsPayDoubleSplit2_LIST = new List<GameObject>();

		player2Chips_LIST = new List<GameObject>();
		player2ChipsPay_LIST = new List<GameObject>();
		player2ChipsPayDouble_LIST = new List<GameObject>();
		player2ChipsSplit1_LIST = new List<GameObject>();
		player2ChipsPaySplit1_LIST = new List<GameObject>();
		player2ChipsPayDoubleSplit1_LIST = new List<GameObject>();
		player2ChipsSplit2_LIST = new List<GameObject>();
		player2ChipsPaySplit2_LIST = new List<GameObject>();
		player2ChipsPayDoubleSplit2_LIST = new List<GameObject>();

		player3Chips_LIST = new List<GameObject>();
		player3ChipsPay_LIST = new List<GameObject>();
		player3ChipsPayDouble_LIST = new List<GameObject>();
		player3ChipsSplit1_LIST = new List<GameObject>();
		player3ChipsPaySplit1_LIST = new List<GameObject>();
		player3ChipsPayDoubleSplit1_LIST = new List<GameObject>();
		player3ChipsSplit2_LIST = new List<GameObject>();
		player3ChipsPaySplit2_LIST = new List<GameObject>();
		player3ChipsPayDoubleSplit2_LIST = new List<GameObject>();


		AddChipsToList(dealerChips_LIST, dealerChips);

		AddChipsToList(player1Chips_LIST, player1Chips);
		AddChipsToList(player1ChipsPay_LIST, player1ChipsPay);
		AddChipsToList(player1ChipsPayDouble_LIST, player1ChipsPay);
		AddChipsToList(player1ChipsSplit1_LIST, player1ChipsSplit1);
		AddChipsToList(player1ChipsPaySplit1_LIST, player1ChipsPaySplit1);
		AddChipsToList(player1ChipsPayDoubleSplit1_LIST, player1ChipsPaySplit1);
		AddChipsToList(player1ChipsSplit2_LIST, player1ChipsSplit2);
		AddChipsToList(player1ChipsPaySplit2_LIST, player1ChipsPaySplit2);
		AddChipsToList(player1ChipsPayDoubleSplit2_LIST, player1ChipsPaySplit2);


		AddChipsToList(player2Chips_LIST, player2Chips);
		AddChipsToList(player2ChipsPay_LIST, player2ChipsPay);
		AddChipsToList(player2ChipsSplit1_LIST, player2ChipsSplit1);
		AddChipsToList(player2ChipsPaySplit1_LIST, player2ChipsPaySplit1);
		AddChipsToList(player2ChipsPayDoubleSplit1_LIST, player2ChipsPaySplit1);
		AddChipsToList(player2ChipsSplit2_LIST, player2ChipsSplit2);
		AddChipsToList(player2ChipsPaySplit2_LIST, player2ChipsPaySplit2);
		AddChipsToList(player2ChipsPayDoubleSplit2_LIST, player2ChipsPaySplit2);

		AddChipsToList(player3Chips_LIST, player3Chips);
		AddChipsToList(player3ChipsPay_LIST, player3ChipsPay);
		AddChipsToList(player3ChipsSplit1_LIST, player3ChipsSplit1);
		AddChipsToList(player3ChipsPaySplit1_LIST, player3ChipsPaySplit1);
		AddChipsToList(player3ChipsPayDoubleSplit1_LIST, player3ChipsPaySplit1);
		AddChipsToList(player3ChipsSplit2_LIST, player3ChipsSplit2);
		AddChipsToList(player3ChipsPaySplit2_LIST, player3ChipsPaySplit2);
		AddChipsToList(player3ChipsPayDoubleSplit2_LIST, player3ChipsPaySplit2);


		DealerCards_LIST = new List<GameObject>();

		player1NoSplitCards_LIST = new List<GameObject>();
		player1Split1Cards_LIST = new List<GameObject>();
		player1Split2Cards_LIST = new List<GameObject>();

		player2NoSplitCards_LIST = new List<GameObject>();
		player2Split1Cards_LIST = new List<GameObject>();
		player2Split2Cards_LIST = new List<GameObject>();

		player3NoSplitCards_LIST = new List<GameObject>();
		player3Split1Cards_LIST = new List<GameObject>();
		player3Split2Cards_LIST = new List<GameObject>();

		cardMaterial_LIST = new List<Material>();
		cardValue_LIST = new List<int>();
		cardSprite_LIST = new List<Sprite>();

		AddCardsToList(DealerCards_LIST, DealerCardSet);

		AddCardsToList(player1NoSplitCards_LIST, player1NoSplitCardSet);
		AddCardsToList(player1Split1Cards_LIST, player1Split1CardSet);
		AddCardsToList(player1Split2Cards_LIST, player1Split2CardSet);

		AddCardsToList(player2NoSplitCards_LIST, player2NoSplitCardSet);
		AddCardsToList(player2Split1Cards_LIST, player2Split1CardSet);
		AddCardsToList(player2Split2Cards_LIST, player2Split2CardSet);

		AddCardsToList(player3NoSplitCards_LIST, player3NoSplitCardSet);
		AddCardsToList(player3Split1Cards_LIST, player3Split1CardSet);
		AddCardsToList(player3Split2Cards_LIST, player3Split2CardSet);

		AddCardMaterials(cardMaterial_LIST, "d");
		AddCardMaterials(cardMaterial_LIST, "h");
		AddCardMaterials(cardMaterial_LIST, "s");
		AddCardMaterials(cardMaterial_LIST, "c");

		AddCardValue(cardValue_LIST);

		AddCardSprite(cardSprite_LIST, "cardsdiamondBIG");
		AddCardSprite(cardSprite_LIST, "cardsheartBIG");
		AddCardSprite(cardSprite_LIST, "cardsspadeBIG");
		AddCardSprite(cardSprite_LIST, "cardsclubBIG");



	}

	public void InitializeVariables() {

		player1Chips.transform.localPosition = player1ChipPos;
		player2Chips.transform.localPosition = player2ChipPos;
		player3Chips.transform.localPosition = player3ChipPos;

		player1Chips.SetActive(true);
		player2Chips.SetActive(true);
		player3Chips.SetActive(true);

		for (int x=0; x<22; x++) {
			player1Chips_LIST[x].SetActive(false);
		}

		for (int x = 0; x < 22; x++)
		{
			player2Chips_LIST[x].SetActive(false);
		}

		for (int x = 0; x < 22; x++)
		{
			player3Chips_LIST[x].SetActive(false);
		}

		cardValue_LIST.Clear();
		AddCardValue(cardValue_LIST);

		cardMaterial_LIST.Clear();
		AddCardMaterials(cardMaterial_LIST, "d");
		AddCardMaterials(cardMaterial_LIST, "h");
		AddCardMaterials(cardMaterial_LIST, "s");
		AddCardMaterials(cardMaterial_LIST, "c");

		cardSprite_LIST.Clear();
		AddCardSprite(cardSprite_LIST, "cardsdiamondBIG");
		AddCardSprite(cardSprite_LIST, "cardsheartBIG");
		AddCardSprite(cardSprite_LIST, "cardsspadeBIG");
		AddCardSprite(cardSprite_LIST, "cardsclubBIG");

		dealerTotalCardValue = 0;
		hasAce = 0;

		player1Betting = false;
		player2Betting = false;
		player3Betting = false;

		player1tempChipIndex = 0;
		player2tempChipIndex = 0;
		player3tempChipIndex = 0;

		dealertempCardIndex = 0;

		player1tempCardIndex = 0;
		player2tempCardIndex = 0;
		player3tempCardIndex = 0;

		DisableCardFrontDisplay(DealerCards_LIST);
		DisableCardFrontDisplay(player1NoSplitCards_LIST);
		DisableCardFrontDisplay(player2NoSplitCards_LIST);
		DisableCardFrontDisplay(player3NoSplitCards_LIST);
		DisableCardFrontDisplay(player1Split1Cards_LIST);
		DisableCardFrontDisplay(player2Split1Cards_LIST);
		DisableCardFrontDisplay(player3Split1Cards_LIST);
		DisableCardFrontDisplay(player1Split2Cards_LIST);
		DisableCardFrontDisplay(player2Split2Cards_LIST);
		DisableCardFrontDisplay(player3Split2Cards_LIST);

		DealerCardInfo.SetActive(false);
		player1CardInfoNoSplit.SetActive(false);
		player2CardInfoNoSplit.SetActive(false);
		player3CardInfoNoSplit.SetActive(false);
		player1CardInfoSplit1.SetActive(false);
		player2CardInfoSplit1.SetActive(false);
		player3CardInfoSplit1.SetActive(false);
		player1CardInfoSplit2.SetActive(false);
		player2CardInfoSplit2.SetActive(false);
		player3CardInfoSplit2.SetActive(false);


		hittingPanel.SetActive(false);
		bettingPanel.SetActive(true);
		chipsPanel.SetActive(true);

		player1Betting = true;
		player2Betting = true;
		player3Betting = true;

		StartCoroutine(StartBetTimer(player1BetBar, "player1"));
		StartCoroutine(StartBetTimer(player2BetBar, "player2"));
		StartCoroutine(StartBetTimer(player3BetBar, "player3"));
	}

	public void DisableCardFrontDisplay(List<GameObject> tempCardList) {

		for (int x=0; x<5; x++)
		{

			tempCardList[x].SetActive(false);

		}


	}

	public void AddCardMaterials(List<Material> tempMatList, string denotion) {
		for (int x=1; x<14; x++) {
			tempMatList.Add(Resources.Load("3D Models/Blackjack/Cards/Materials/"+x+denotion) as Material);
		}

	}
	public void AddCardValue(List<int> tempValList)
	{
		for (int y=0; y<4; y++) {
			for (int z = 1; z < 14; z++)
			{
				
					tempValList.Add(z);
			

			}
		}
	}

	public void AddCardSprite(List<Sprite> tempSpriteList, string denotion)
	{
		for (int x = 1; x < 14; x++)
		{
			tempSpriteList.Add(Resources.Load<Sprite>("2D Static/BlackJack/Cards/BigCards/" + denotion + x));
		}

	}

	public void AddChipsToList(List<GameObject> gameObject_LIST, GameObject gameObject_Transform) {

		Transform tempChips = gameObject_Transform.transform;
		for (int x=0; x < 22; x++) {
			gameObject_LIST.Add(tempChips.GetChild(x).gameObject);
		}


	}

	public void AddCardsToList(List<GameObject> gameObject_LIST, GameObject gameObject_Transform)
	{

		Transform tempChips = gameObject_Transform.transform;
		for (int x = 0; x < 5; x++)
		{
			gameObject_LIST.Add(tempChips.GetChild(x).transform.GetChild(0).gameObject);
		}


	}

	void Start () {



		hittingPanel.SetActive(false);
		bettingPanel.SetActive(true);
		chipsPanel.SetActive(true);

		player1Betting = true;
		player2Betting = true;
		player3Betting = true;
		StartCoroutine(StartBetTimer(player1BetBar, "player1"));
		StartCoroutine(StartBetTimer(player2BetBar, "player2"));
		StartCoroutine(StartBetTimer(player3BetBar, "player3"));

		


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//---------------------------------------------------START BETTING PHASE----------------------------------------------------------------//

	public void StartBettingPhase() {

		player1Betting = true;
		player2Betting = true;
		player3Betting = true;
		StartCoroutine(StartBetTimer(player1BetBar, "player1"));
		StartCoroutine(StartBetTimer(player2BetBar, "player2"));
		StartCoroutine(StartBetTimer(player3BetBar, "player3"));


		StartCoroutine(BettingPhase());
	

	}



	IEnumerator BettingPhase() {

		StartCoroutine(EnableChatObject(chatbubbleLeft,bettingBegins));

		if (Player1_Script.playerType == "AI" ) {
			Player1_Script.StartBettingAI();                //Player1 AI start Betting
		}
		//	GM_Script.MoveCameraBettingView();              //for Player2 Betting
		if (Player3_Script.playerType == "AI")
		{
			Player3_Script.StartBettingAI();                //Player1 AI start Betting
		}
		yield return StartCoroutine(CheckBetting());

		
		
		StartCoroutine(EnableChatObject(chatbubbleRight, bettingEnds));
		yield return new WaitForSeconds(1.5f);                              //Delay before dealing card phase starts
		GM_Script.gameState = "DONE";
		//Debug.Log("Done Betting Phase");
	}

	public IEnumerator CheckBetting()
	{

		while (player1Betting || player2Betting || player3Betting)
		{

			yield return new WaitForSeconds(1.0f);
		}

	}


	//---------------------------------------------------END BETTING PHASE----------------------------------------------------------------//


	//---------------------------------------------------START DEALING PHASE----------------------------------------------------------------//

	public void StartDealingPhase()
	{

		StartCoroutine(DealingPhase());
	}


	IEnumerator DealingPhase()
	{
		float tempDelay = 1.0f;
		float tempDelay2 = 0.5f;
		float tempDelay3 = 1.5f;
		//tempChips.GetComponent<Animator>().Play("AddChips");
		DealerAnimator.Play("PrepareToDraw");
		yield return new WaitForSeconds(tempDelay2);
		DealerAnimator.Play("DrawCard");
		yield return new WaitForSeconds(tempDelay);

		if (GM_Script.player1isPlaying)
		{
			int tempCardMaterialListIndex = Random.Range(0, cardValue_LIST.Count);
			rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];
			leftHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];

			DealerAnimator.Play("DealPlayer1Card1");
			yield return new WaitForSeconds(tempDelay);
			EnableCard(player1NoSplitCards_LIST,"player1", tempCardMaterialListIndex, Player1_Script, player1tempCardIndex);

		}

		yield return new WaitForSeconds(tempDelay2);         //Delay before next animation starts
		DealerAnimator.Play("DrawCard");
		yield return new WaitForSeconds(tempDelay);         //Delay before next animation starts

		if (GM_Script.player2isPlaying)
		{
			int tempCardMaterialListIndex = Random.Range(0, cardValue_LIST.Count);
			rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];
			leftHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];

			DealerAnimator.Play("DealPlayer2Card1");
			yield return new WaitForSeconds(tempDelay);
			EnableCard(player2NoSplitCards_LIST, "player2", tempCardMaterialListIndex, Player2_Script, player2tempCardIndex);

		}

		yield return new WaitForSeconds(tempDelay2);         //Delay before next animation starts
		DealerAnimator.Play("DrawCard");
		yield return new WaitForSeconds(tempDelay);         //Delay before next animation starts

		if (GM_Script.player3isPlaying)
		{
			int tempCardMaterialListIndex = Random.Range(0, cardValue_LIST.Count);
			rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];
			leftHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];

			DealerAnimator.Play("DealPlayer3Card1");
			yield return new WaitForSeconds(tempDelay);
			EnableCard(player3NoSplitCards_LIST, "player3", tempCardMaterialListIndex, Player3_Script, player3tempCardIndex);

		}

		yield return new WaitForSeconds(tempDelay2);         //Delay before next animation starts
		DealerAnimator.Play("DealDealerCard1");
		yield return new WaitForSeconds(0.8f);         //Delay before next animation starts

		int tempCardMaterialListIndex2 = Random.Range(0, cardValue_LIST.Count);
		rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex2];
		leftHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex2];

		EnableCard(DealerCards_LIST, "dealerCard1", tempCardMaterialListIndex2, Player1_Script, dealertempCardIndex);



		yield return new WaitForSeconds(tempDelay2);
		DealerAnimator.Play("DrawCard");
		yield return new WaitForSeconds(tempDelay);

		if (GM_Script.player1isPlaying)
		{
			int tempCardMaterialListIndex = Random.Range(0, cardValue_LIST.Count);
			rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];
			leftHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];

			DealerAnimator.Play("DealPlayer1Card2");
			yield return new WaitForSeconds(tempDelay);
			EnableCard(player1NoSplitCards_LIST, "player1", tempCardMaterialListIndex, Player1_Script, player1tempCardIndex);

		}

		yield return new WaitForSeconds(tempDelay2);         //Delay before next animation starts
		DealerAnimator.Play("DrawCard");
		yield return new WaitForSeconds(tempDelay);         //Delay before next animation starts

		if (GM_Script.player2isPlaying)
		{
			int tempCardMaterialListIndex = Random.Range(0, cardValue_LIST.Count);
			rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];
			leftHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];

			DealerAnimator.Play("DealPlayer2Card2");
			yield return new WaitForSeconds(tempDelay);
			EnableCard(player2NoSplitCards_LIST, "player2", tempCardMaterialListIndex, Player2_Script, player2tempCardIndex);

		}

		yield return new WaitForSeconds(tempDelay2);         //Delay before next animation starts
		DealerAnimator.Play("DrawCard");
		yield return new WaitForSeconds(tempDelay);         //Delay before next animation starts

		if (GM_Script.player3isPlaying)
		{
			int tempCardMaterialListIndex = Random.Range(0, cardValue_LIST.Count);
			rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];
			leftHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];

			DealerAnimator.Play("DealPlayer3Card2");
			yield return new WaitForSeconds(tempDelay);
			EnableCard(player3NoSplitCards_LIST, "player3", tempCardMaterialListIndex, Player3_Script, player3tempCardIndex);

		}

		yield return new WaitForSeconds(tempDelay2);         //Delay before next animation starts
		DealerAnimator.Play("DealDealerCard2");
		yield return new WaitForSeconds(tempDelay2);         //Delay before next animation starts
		rightHandCard.material = tempMat;
		dealerCard1Back.SetActive(false);
		yield return new WaitForSeconds(tempDelay);         //Delay before next animation starts
		DealerCards_LIST[0].GetComponent<Renderer>().material = tempMat;
		DealerCards_LIST[0].SetActive(true);
		yield return new WaitForSeconds(tempDelay2);         //Delay before next animation starts
		dealerCard2Back.SetActive(true);
		yield return new WaitForSeconds(tempDelay2);         //Delay before next animation starts

		//EnableCard(DealerCards_LIST, "dealerCard2", tempCardMaterialListIndex3);

	
		GM_Script.gameState = "DoneDealingPhase";

	}

//	public void EnableENCard() {
//		EnableCard(tempENCardList, tempENPlayerNumber, tempENCardMatIndex);
//	}

	public void EnableCard(List<GameObject> tempCardList, string tempPlayerNumber, int tempCardMatIndex, PlayerScript tempPlayerScript, int playerTempCardIndex) {


		if (tempPlayerNumber == "dealerCard1")
		{

			dealerCard1Back.SetActive(true);
			DealerCards_LIST[0].GetComponent<Renderer>().material = cardMaterial_LIST[tempCardMatIndex];
			tempMat = cardMaterial_LIST[tempCardMatIndex];
			AddValueForDealerCard(cardValue_LIST[tempCardMatIndex], tempCardMatIndex);
			
			dealertempCardIndex++;
		}
		else if (tempPlayerNumber == "dealerCard2")
		{
			//DealerCards_LIST[0].SetActive(true);
			//dealerCard2Back.SetActive(true);
			DealerCards_LIST[dealertempCardIndex].GetComponent<Renderer>().material = cardMaterial_LIST[tempCardMatIndex];

			//dealertempCardIndex++;
		}
		else if (tempPlayerNumber == "dealerCard2Front") {

			DealerCards_LIST[1].SetActive(true);
			DealerCards_LIST[1].GetComponent<Renderer>().material = cardMaterial_LIST[tempCardMatIndex];
			tempMat = cardMaterial_LIST[tempCardMatIndex];
			AddValueForDealerCard(cardValue_LIST[tempCardMatIndex], tempCardMatIndex);
			//dealerTotalCardValue += cardValue_LIST[tempCardMatIndex];
			dealertempCardIndex++;
		}
		else if (tempPlayerNumber == "dealerCard3" || tempPlayerNumber == "dealerCard4" || tempPlayerNumber == "dealerCard5") {

			DealerCards_LIST[dealertempCardIndex].SetActive(true);
			DealerCards_LIST[dealertempCardIndex].GetComponent<Renderer>().material = cardMaterial_LIST[tempCardMatIndex];
			tempMat = cardMaterial_LIST[tempCardMatIndex];

			//dealerTotalCardValue += cardValue_LIST[tempCardMatIndex];
			AddValueForDealerCard(cardValue_LIST[tempCardMatIndex], tempCardMatIndex);
			dealertempCardIndex++;


		}
		else if (tempPlayerNumber == "player1" || tempPlayerNumber == "player2" || tempPlayerNumber == "player3")
		{

			tempCardList[playerTempCardIndex].SetActive(true);
			tempCardList[playerTempCardIndex].GetComponent<Renderer>().material = cardMaterial_LIST[tempCardMatIndex];
			if (cardValue_LIST[tempCardMatIndex] == 1)
			{
				//tempPlayerScript.hasAceNumber++;
				//tempPlayerScript.playerTotalCardValue += 11;
				AddValueFromCard(tempPlayerScript, 11);
			}
			else if (cardValue_LIST[tempCardMatIndex] > 10)
			{
				//tempPlayerScript.playerTotalCardValue += 10;
				AddValueFromCard(tempPlayerScript, 10);
			}
			else
			{
				//tempPlayerScript.playerTotalCardValue += cardValue_LIST[tempCardMatIndex];
				AddValueFromCard(tempPlayerScript, cardValue_LIST[tempCardMatIndex]);
			}

			if (playerTempCardIndex == 0)
			{
				tempPlayerScript.card1CharValue = cardValue_LIST[tempCardMatIndex];
			}
			else if (playerTempCardIndex == 1)
			{
				tempPlayerScript.card2CharValue = cardValue_LIST[tempCardMatIndex];
			}

			tempPlayerScript.IncrementCardIndex(tempPlayerNumber);

		}

		cardMaterial_LIST.RemoveAt(tempCardMatIndex);
		cardSprite_LIST.RemoveAt(tempCardMatIndex);
		cardValue_LIST.RemoveAt(tempCardMatIndex);



	}

	public void AddValueForDealerCard(int tempValue, int tempCardMatIndex) {
		if (cardValue_LIST[tempCardMatIndex] == 1)
		{
			hasAce++;
			dealerTotalCardValue += 11;
			
		}
		else if (cardValue_LIST[tempCardMatIndex] > 10)
		{
			//tempPlayerScript.playerTotalCardValue += 10;
			dealerTotalCardValue += 10;
		}
		else
		{
			//tempPlayerScript.playerTotalCardValue += cardValue_LIST[tempCardMatIndex];
			dealerTotalCardValue += tempValue;
		}
	}

	public void AddValueFromCard(PlayerScript tempPlayerScript, int tempValue) {
		if (tempPlayerScript.whichCardSet == "NoSplit") {
			if (tempValue == 11) {
				tempPlayerScript.hasAceNumber++;
			}
			tempPlayerScript.playerTotalCardValue += tempValue;
		}
		else if (tempPlayerScript.whichCardSet == "Split1") {
			if (tempValue == 11)
			{
				tempPlayerScript.hasAceNumberSplit1++;
			}
			tempPlayerScript.playerTotalCardValueSplit1 += tempValue;
		}
		else if (tempPlayerScript.whichCardSet == "Split2")	{
			if (tempValue == 11)
			{
				tempPlayerScript.hasAceNumberSplit2++;
			}
			tempPlayerScript.playerTotalCardValueSplit2 += tempValue;
		}

	}

	//---------------------------------------------------END DEALING PHASE----------------------------------------------------------------//


	//---------------------------------------------------START HITTING PHASE----------------------------------------------------------------//
	public void StartHittingPhase()
	{

		StartCoroutine(HittingPhase());
	}



	IEnumerator HittingPhase()
	{
		float tempDelay = 1.0f;
		float tempDelay2 = 0.5f;
		float tempDelay3 = 1.5f;



		if (GM_Script.player1isPlaying)
		{

			GM_Script.MoveCameraHittingView();
			Player1_Script.hittingResponse = "hit";





			while (Player1_Script.hittingResponse == "hit")
			{
				player1Betting = true;


				DealerAnimator.Play("CheckHitPlayer1");
				yield return new WaitForSeconds(tempDelay);

				//Check for Blackjack
				if (Player1_Script.playerTotalCardValue == 21 && player1tempCardIndex < 3)
				{


					player1CardInfoNoSplit.SetActive(true);
					player1CardInfoNoSplit.GetComponent<SpriteRenderer>().sprite = blackjackSprite;
					Player1_Script.playerStatus = "Blackjack";
					Player1_Script.hittingResponse = "blackjack"; //needs to be blackjack!
					Player1_Script.hasNoSplitBet = false;

					yield return PayUpPlayer(player1Chips_LIST, player1ChipsPay_LIST, "FromCheckHitPlayer1ToIdle", "DealerDealChipsPlayer1");

					Player1_Script.CallEnablePaymentDisplay();
					Player1_Script.CallBlackjackBet();

					StartCoroutine(AnimateTakingChips(player1Chips_LIST));
					StartCoroutine(AnimateTakingChips(player1ChipsPay_LIST));


					yield return new WaitForSeconds(tempDelay);

				}
				else if (Player1_Script.playerTotalCardValue > 21)
				{

					yield return StartCoroutine(UtilizeAceFunctionAndOthers(Player1_Script, player1CardInfoNoSplit, player1tempCardIndex, player1Chips_LIST, "FromCheckHitPlayer1ToIdle", "DealerTakeChipsPlayer1", "NoSplit"));
				}
				else if (player1tempCardIndex > 4 || (Player1_Script.playerTotalCardValue >= Player1_Script.tempStandCheck && Player1_Script.playerNumber == "AI"))
				{

					Player1_Script.StartCoroutine(EnableChatObject(Player1_Script.speechBubble, Player1_Script.standSpeech));
					Player1_Script.ConfirmStandBet("stand");
					Player1_Script.playerStatus = "AIStand"; 
				}
				//End Check for Blackjack
				if (Player1_Script.playerStatus != "Blackjack" && Player1_Script.playerStatus != "AIStand" && Player1_Script.playerTotalCardValue <= 21 && player1tempCardIndex <= 4)
				{
					Player1_Script.playerStatus = "isHitting";
					if (Player1_Script.playerType == "AI")
					{
						Player1_Script.ConfirmStandBetAI();
					}
					else if (Player1_Script.playerType == "player")
					{
						Player1_Script.hittingResponse = "stand";
						Player1_Script.playerStatus = "isHitting";

					}
					StartCoroutine(StartBetTimer(player1BetBar, "player1"));
					yield return StartCoroutine(CheckHitting(Player1_Script));
					Debug.Log("Time Expired");
					if (Player1_Script.hittingResponse == "hit")
					{

						int tempCardMaterialListIndex = Random.Range(0, cardValue_LIST.Count);
						rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];
						leftHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];

						DealerAnimator.Play("DrawFromPlayer1Hit");
						yield return new WaitForSeconds(tempDelay);
						DealerAnimator.Play("DealPlayer1Card2");
						yield return new WaitForSeconds(tempDelay);
						EnableCard(player1NoSplitCards_LIST, "player1", tempCardMaterialListIndex, Player1_Script, player1tempCardIndex);
						yield return new WaitForSeconds(tempDelay2); 


						Debug.Log("hit");
					}
					else if (Player1_Script.hittingResponse == "split")
					{


						//Start Part1 of Split	
						yield return StartCoroutine(SplitRoutinePart1(Player1_Script, "SplitPlayer1Cards", player1NoSplitCards_LIST, player1Split1Cards_LIST, player1Split2Cards_LIST, player1Chips, "Player1SplitChips", player1Chips_LIST, player1ChipsSplit2_LIST, player1ChipsSplit1, player1ChipsSplit1_LIST, player1tempChipIndex, "DealPlayer1Card2", "CheckHitPlayer1Split1"));
						//END Part1 of Split

						//-----end new


						//Start First Split -----------------------------------------------------------------------------//
						yield return StartCoroutine(SplitRoutine(Player1_Script, "Split1", player1BetBar, "DrawFromPlayer1HitSplit1", "DealPlayer1Card2", player1Split1Cards_LIST, "CheckHitPlayer1Split1", player1CardInfoSplit1, player1ChipsSplit1_LIST, "FromCheckHitPlayer1Split1ToIdle", "DealerTakeChipsPlayer1"));
						DealerAnimator.Play("FromCheckHitPlayer1Split1ToIdle");
						yield return new WaitForSeconds(tempDelay);
						//END First Split -------------------------------------------------------------------------------//

						DealerAnimator.Play("CheckHitPlayer1Split2");

						//Start Second Split-----------------------------------------------------------------------//
						yield return StartCoroutine(SplitRoutine(Player1_Script, "Split2", player1BetBar, "DrawFromPlayer1HitSplit2",  "DealPlayer1Card1", player1Split2Cards_LIST, "CheckHitPlayer1Split2", player1CardInfoSplit2, player1ChipsSplit2_LIST, "FromCheckHitPlayer1Split2ToIdle", "DealerTakeChipsPlayer1"));
						DealerAnimator.Play("FromCheckHitPlayer1Split2ToIdle");
						yield return new WaitForSeconds(tempDelay);
						//END Second Split-------------------------------------------------------------------------//
					}
					else if (Player1_Script.hittingResponse == "stand")
					{
						Debug.Log("stand");
						//yield return StartCoroutine(UtilizeAceFunctionAndOthers(Player1_Script, player1CardInfoNoSplit, player1tempCardIndex, player1Chips_LIST, "FromCheckHitPlayer1ToIdle", "DealerTakeChipsPlayer1", "NoSplit"));

						if (Player1_Script.hittingResponse == "stand") {
							DealerAnimator.Play("FromCheckHitPlayer1ToIdle");
							yield return new WaitForSeconds(tempDelay);
						}

						if (Player1_Script.playerType == "player")
						{
							Player1_Script.StartCoroutine(EnableChatObject(Player1_Script.speechBubble, Player1_Script.standSpeech));
							Player1_Script.ConfirmStandBet("stand");
						}

					}

					//yield return StartCoroutine(UtilizeAceFunctionAndOthers(Player1_Script, player1CardInfoNoSplit, player1tempCardIndex, player1Chips_LIST, "FromCheckHitPlayer1ToIdle", "DealerTakeChipsPlayer1", "NoSplit"));

				}
			}
		}





		if (GM_Script.player2isPlaying)
		{

			GM_Script.MoveCameraHittingView();
			Player2_Script.hittingResponse = "hit";





			while (Player2_Script.hittingResponse == "hit")
			{
				player2Betting = true;


				DealerAnimator.Play("CheckHitPlayer2");
				yield return new WaitForSeconds(tempDelay);

				//Check for Blackjack
				if (Player2_Script.playerTotalCardValue == 21 && player2tempCardIndex < 3)
				{


					player2CardInfoNoSplit.SetActive(true);
					player2CardInfoNoSplit.GetComponent<SpriteRenderer>().sprite = blackjackSprite;
					Player2_Script.playerStatus = "Blackjack";
					Player2_Script.hittingResponse = "blackjack";
					Player2_Script.hasNoSplitBet = false;

					yield return PayUpPlayer(player2Chips_LIST, player2ChipsPay_LIST, "FromCheckHitPlayer2ToIdle", "DealerDealChipsPlayer2");

					Player2_Script.CallEnablePaymentDisplay();
					Player2_Script.CallBlackjackBet();

					StartCoroutine(AnimateTakingChips(player2Chips_LIST));
					StartCoroutine(AnimateTakingChips(player2ChipsPay_LIST));


					yield return new WaitForSeconds(tempDelay);
				}
				else if (Player2_Script.playerTotalCardValue > 21) {

					yield return StartCoroutine(UtilizeAceFunctionAndOthers(Player2_Script, player2CardInfoNoSplit, player2tempCardIndex, player2Chips_LIST, "FromCheckHitPlayer2ToIdle", "DealerTakeChipsPlayer2", "NoSplit"));
				}
				else if (player2tempCardIndex > 4 || (Player2_Script.playerTotalCardValue >= Player2_Script.tempStandCheck && Player2_Script.playerNumber == "AI")) {

					Player2_Script.StartCoroutine(EnableChatObject(Player2_Script.speechBubble, Player2_Script.standSpeech));
					Player2_Script.ConfirmStandBet("stand");
					Player2_Script.playerStatus = "AIStand";
				}
				//End Check for Blackjack
				if (Player2_Script.playerStatus != "Blackjack" && Player2_Script.playerStatus != "AIStand" && Player2_Script.playerTotalCardValue <= 21 && player2tempCardIndex <= 4)
				{
					Player2_Script.playerStatus = "isHitting";
					if (Player2_Script.playerType == "AI")
					{
						Player2_Script.ConfirmStandBetAI();
					}
					else if (Player2_Script.playerType == "player") {
						Player2_Script.hittingResponse = "stand";
											
					}
					StartCoroutine(StartBetTimer(player2BetBar, "player2"));
					yield return StartCoroutine(CheckHitting(Player2_Script));
					Debug.Log("Time Expired");
					if (Player2_Script.hittingResponse == "hit")
					{

						int tempCardMaterialListIndex = Random.Range(0, cardValue_LIST.Count);
						rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];
						leftHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];

						DealerAnimator.Play("DrawFromPlayer2Hit");
						yield return new WaitForSeconds(tempDelay);
						DealerAnimator.Play("DealPlayer2Card2");
						yield return new WaitForSeconds(tempDelay);
						EnableCard(player2NoSplitCards_LIST, "player2", tempCardMaterialListIndex, Player2_Script, player2tempCardIndex);
						yield return new WaitForSeconds(tempDelay2);



						Debug.Log("hit");
					}
					else if (Player2_Script.hittingResponse == "split")
					{


						//Start Part1 of Split	
						yield return StartCoroutine(SplitRoutinePart1(Player2_Script, "SplitPlayer2Cards", player2NoSplitCards_LIST, player2Split1Cards_LIST, player2Split2Cards_LIST, player2Chips, "Player2SplitChips", player2Chips_LIST, player2ChipsSplit2_LIST, player2ChipsSplit1, player2ChipsSplit1_LIST, player2tempChipIndex, "DealPlayer2Card2", "CheckHitPlayer2Split1"));
						//END Part1 of Split

						//-----end new


						//Start First Split -----------------------------------------------------------------------------//
						yield return StartCoroutine(SplitRoutine(Player2_Script, "Split1", player2BetBar, "DrawFromPlayer2HitSplit1", "DealPlayer2Card2", player2Split1Cards_LIST, "CheckHitPlayer2Split1", player2CardInfoSplit1, player2ChipsSplit1_LIST, "FromCheckHitPlayer2Split1ToIdle", "DealerTakeChipsPlayer2"));
						DealerAnimator.Play("FromCheckHitPlayer2Split1ToIdle");
						yield return new WaitForSeconds(tempDelay);
						//END First Split -------------------------------------------------------------------------------//

						DealerAnimator.Play("CheckHitPlayer2Split2");

						//Start Second Split-----------------------------------------------------------------------//
						yield return StartCoroutine(SplitRoutine(Player2_Script, "Split2", player2BetBar, "DrawFromPlayer2HitSplit2", "DealPlayer2Card1", player2Split2Cards_LIST, "CheckHitPlayer2Split2", player2CardInfoSplit2, player2ChipsSplit2_LIST, "FromCheckHitPlayer2Split2ToIdle", "DealerTakeChipsPlayer2"));
						DealerAnimator.Play("FromCheckHitPlayer2Split2ToIdle");
						yield return new WaitForSeconds(tempDelay);
						//END Second Split-------------------------------------------------------------------------//
					}
					else if (Player2_Script.hittingResponse == "stand")
					{
						Debug.Log("stand");
						//yield return StartCoroutine(UtilizeAceFunctionAndOthers(Player2_Script, player2CardInfoNoSplit, player2tempCardIndex, player2Chips_LIST, "FromCheckHitPlayer2ToIdle", "DealerTakeChipsPlayer2", "NoSplit"));


						if (Player2_Script.hittingResponse == "stand")
						{
							DealerAnimator.Play("FromCheckHitPlayer2ToIdle");
							yield return new WaitForSeconds(tempDelay);
						}

						if (Player2_Script.playerType == "player")
						{
							Player2_Script.StartCoroutine(EnableChatObject(Player2_Script.speechBubble, Player2_Script.standSpeech));
							Player2_Script.ConfirmStandBet("stand");
						}



					}

					//yield return StartCoroutine(UtilizeAceFunctionAndOthers(Player1_Script, player1CardInfoNoSplit, player1tempCardIndex, player1Chips_LIST, "FromCheckHitPlayer1ToIdle", "DealerTakeChipsPlayer1", "NoSplit"));

				}
			}
		}





		if (GM_Script.player3isPlaying)
		{

			GM_Script.MoveCameraHittingView();
			Player3_Script.hittingResponse = "hit";





			while (Player3_Script.hittingResponse == "hit")
			{
				player3Betting = true;


				DealerAnimator.Play("CheckHitPlayer3");
				yield return new WaitForSeconds(tempDelay);

				//Check for Blackjack
				if (Player3_Script.playerTotalCardValue == 21 && player3tempCardIndex < 3)
				{


					player3CardInfoNoSplit.SetActive(true);
					player3CardInfoNoSplit.GetComponent<SpriteRenderer>().sprite = blackjackSprite;
					Player3_Script.playerStatus = "Blackjack";
					Player3_Script.hittingResponse = "blackjack"; //needs to be blackjack!
					Player3_Script.hasNoSplitBet = false;

					yield return PayUpPlayer(player3Chips_LIST, player3ChipsPay_LIST, "FromCheckHitPlayer3ToIdle", "DealerDealChipsPlayer3");

					Player3_Script.CallEnablePaymentDisplay();
					Player3_Script.CallBlackjackBet();

					StartCoroutine(AnimateTakingChips(player3Chips_LIST));
					StartCoroutine(AnimateTakingChips(player3ChipsPay_LIST));


					yield return new WaitForSeconds(tempDelay);
				}
				else if (Player3_Script.playerTotalCardValue > 21)
				{

					yield return StartCoroutine(UtilizeAceFunctionAndOthers(Player3_Script, player3CardInfoNoSplit, player3tempCardIndex, player3Chips_LIST, "FromCheckHitPlayer3ToIdle", "DealerTakeChipsPlayer3", "NoSplit"));
				}
				else if (player3tempCardIndex > 4 || (Player3_Script.playerTotalCardValue >= Player3_Script.tempStandCheck && Player3_Script.playerNumber == "AI"))
				{

					Player3_Script.StartCoroutine(EnableChatObject(Player3_Script.speechBubble, Player3_Script.standSpeech));
					Player3_Script.ConfirmStandBet("stand");
					Player3_Script.playerStatus = "AIStand";

				}
				//End Check for Blackjack
				if (Player3_Script.playerStatus != "Blackjack" && Player3_Script.playerStatus != "AIStand" && Player3_Script.playerTotalCardValue <= 21 && player3tempCardIndex <= 4)
				{
					Player3_Script.playerStatus = "isHitting";
					if (Player3_Script.playerType == "AI")
					{
						Player3_Script.ConfirmStandBetAI();
					}
					else if (Player3_Script.playerType == "player")
					{
						Player3_Script.hittingResponse = "stand";
						Player3_Script.playerStatus = "isHitting";

					}
					StartCoroutine(StartBetTimer(player3BetBar, "player3"));
					yield return StartCoroutine(CheckHitting(Player3_Script));
					Debug.Log("Time Expired");
					if (Player3_Script.hittingResponse == "hit")
					{

						int tempCardMaterialListIndex = Random.Range(0, cardValue_LIST.Count);
						rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];
						leftHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];

						DealerAnimator.Play("DrawFromPlayer3Hit");
						yield return new WaitForSeconds(tempDelay);
						DealerAnimator.Play("DealPlayer3Card2");
						yield return new WaitForSeconds(tempDelay);
						EnableCard(player3NoSplitCards_LIST, "player3", tempCardMaterialListIndex, Player3_Script, player3tempCardIndex);
						yield return new WaitForSeconds(tempDelay2);



						Debug.Log("hit");
					}
					else if (Player3_Script.hittingResponse == "split")
					{


						//Start Part1 of Split	
						yield return StartCoroutine(SplitRoutinePart1(Player3_Script, "SplitPlayer3Cards", player3NoSplitCards_LIST, player3Split1Cards_LIST, player3Split2Cards_LIST, player3Chips, "Player3SplitChips", player3Chips_LIST, player3ChipsSplit2_LIST, player3ChipsSplit1, player3ChipsSplit1_LIST, player3tempChipIndex, "DealPlayer3Card2", "CheckHitPlayer3Split1"));
						//END Part1 of Split

						//-----end new


						//Start First Split -----------------------------------------------------------------------------//
						yield return StartCoroutine(SplitRoutine(Player3_Script, "Split1", player3BetBar, "DrawFromPlayer3HitSplit1", "DealPlayer3Card2", player3Split1Cards_LIST, "CheckHitPlayer3Split1", player3CardInfoSplit1, player3ChipsSplit1_LIST, "FromCheckHitPlayer3Split1ToIdle", "DealerTakeChipsPlayer3"));
						DealerAnimator.Play("FromCheckHitPlayer3Split1ToIdle");
						yield return new WaitForSeconds(tempDelay);
						//END First Split -------------------------------------------------------------------------------//

						DealerAnimator.Play("CheckHitPlayer3Split2");

						//Start Second Split-----------------------------------------------------------------------//
						yield return StartCoroutine(SplitRoutine(Player3_Script, "Split2", player3BetBar, "DrawFromPlayer3HitSplit2", "DealPlayer3Card1", player3Split2Cards_LIST, "CheckHitPlayer3Split2", player3CardInfoSplit2, player3ChipsSplit2_LIST, "FromCheckHitPlayer3Split2ToIdle", "DealerTakeChipsPlayer3"));
						DealerAnimator.Play("FromCheckHitPlayer3Split2ToIdle");
						yield return new WaitForSeconds(tempDelay);
						//END Second Split-------------------------------------------------------------------------//
					}
					else if (Player3_Script.hittingResponse == "stand")
					{
						Debug.Log("stand");
						yield return StartCoroutine(UtilizeAceFunctionAndOthers(Player3_Script, player3CardInfoNoSplit, player3tempCardIndex, player3Chips_LIST, "FromCheckHitPlayer3ToIdle", "DealerTakeChipsPlayer3", "NoSplit"));


						if (Player3_Script.hittingResponse == "stand")
						{
							DealerAnimator.Play("FromCheckHitPlayer3ToIdle");
							yield return new WaitForSeconds(tempDelay);

						if (Player3_Script.playerType == "player")
						{
							Player3_Script.StartCoroutine(EnableChatObject(Player3_Script.speechBubble, Player3_Script.standSpeech));
							Player3_Script.ConfirmStandBet("stand");
														
						}



						}

					}

					//yield return StartCoroutine(UtilizeAceFunctionAndOthers(Player1_Script, player1CardInfoNoSplit, player1tempCardIndex, player1Chips_LIST, "FromCheckHitPlayer1ToIdle", "DealerTakeChipsPlayer1", "NoSplit"));

				}
			}
		}

		GM_Script.gameState = "doneHittingPhase";
		//Debug.Log("End of Hitting Phase");
	}

	//Start Split Routine																																						
	//											Player1_Script,			 "SplitPlayer1Cards",			"Split1",						player1NoSplitCards_LIST,					player1Split1Cards_LIST,						player1Split2Cards_LIST,          player1Chips,		"Player1SplitChips",					player1Chips_LIST,						player1ChipsSplit2_LIST,			player1ChipsSplit1,							 player1ChipsSplit1_LIST, player1tempChipIndex, "DealPlayer1Card2", "CheckHitPlayer1Split1"
	IEnumerator SplitRoutinePart1(PlayerScript tempPlayer_Script, string tempSplitPlayerCards, List<GameObject> tempPlayerNoSplitCards_LIST, List<GameObject> tempPlayerSplit1Cards_LIST, List<GameObject> tempPlayerSplit2Cards_LIST, GameObject tempPlayerChips, string tempSplitAnim, List<GameObject> tempPlayerChips_LIST, List<GameObject> tempPlayerChipsSplit2_LIST, GameObject tempPlayerChipsSplit1, List<GameObject> tempPlayerChipsSplit1_LIST, int tempPlayerIndex, string tempDealCardAnim, string tempCheckHit) {

		float tempDelay = 1.0f;
		float tempDelay2 = 0.5f;
		float tempDelay3 = 1.5f;

		tempPlayer_Script.hasSplit = true;
		tempPlayer_Script.SplitCardValues();
		DealerAnimator.Play(tempSplitPlayerCards);
		tempPlayer_Script.whichCardSet = "Split1";

		if (tempPlayer_Script.playerNumber == "player1")
		{
			player1tempChipIndex = 0;
		}
		else if (tempPlayer_Script.playerNumber == "player2")
		{
			player2tempChipIndex = 0;
		}
		else if (tempPlayer_Script.playerNumber == "player3")
		{
			player3tempChipIndex = 0;
		}
		player1tempChipIndex = 0;




		rightHandCard.GetComponent<Renderer>().material = tempPlayerNoSplitCards_LIST[0].GetComponent<Renderer>().material;
		leftHandCard.GetComponent<Renderer>().material = tempPlayerNoSplitCards_LIST[1].GetComponent<Renderer>().material;
		tempPlayerSplit1Cards_LIST[0].GetComponent<Renderer>().material = tempPlayerNoSplitCards_LIST[1].GetComponent<Renderer>().material;
		tempPlayerSplit2Cards_LIST[0].GetComponent<Renderer>().material = tempPlayerNoSplitCards_LIST[0].GetComponent<Renderer>().material;
		yield return new WaitForSeconds(tempDelay2);

		tempPlayerChips.GetComponent<Animator>().Play(tempSplitAnim); //Chip movement on split
		tempPlayerNoSplitCards_LIST[1].SetActive(false);
		tempPlayerNoSplitCards_LIST[0].SetActive(false);

		yield return new WaitForSeconds(tempDelay2);

		tempPlayerSplit1Cards_LIST[0].SetActive(true);
		tempPlayerSplit2Cards_LIST[0].SetActive(true);

		CopyChipsToDealerChips(tempPlayerChips_LIST, tempPlayerChipsSplit2_LIST);
		tempPlayerChips_LIST[0].transform.parent.gameObject.SetActive(false);

		StartCoroutine(AnimateChips(tempPlayerChipsSplit1, tempPlayerChipsSplit1_LIST, tempPlayerIndex, tempPlayer_Script.bet, tempPlayer_Script.playerNumber));
		tempPlayer_Script.CallAddToBet();

		yield return new WaitForSeconds(tempDelay3);
		Debug.Log("card was split");

		//-----new
		// for 2nd Card of Splitted Card Split1
		int tempCardMaterialListIndex = Random.Range(0, cardValue_LIST.Count);
		rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];
		leftHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];

		//DealerAnimator.Play("DrawFromPlayer1Hit");
		DealerAnimator.Play(tempDealCardAnim);  //needs to be "DealPlayer1Card1Split1"
		yield return new WaitForSeconds(tempDelay);
		EnableCard(tempPlayerSplit1Cards_LIST, tempPlayer_Script.playerNumber, tempCardMaterialListIndex, tempPlayer_Script, 1);

		yield return new WaitForSeconds(tempDelay);
		//

		// for 2nd Card of Splitted Card Split2
		tempPlayer_Script.whichCardSet = "Split2";

		tempCardMaterialListIndex = Random.Range(0, cardValue_LIST.Count);
		rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];
		leftHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];

		DealerAnimator.Play("DrawCard");
		yield return new WaitForSeconds(tempDelay);
		DealerAnimator.Play(tempDealCardAnim);  //needs to be "DealPlayer1Card1Split1"
		yield return new WaitForSeconds(tempDelay);
		EnableCard(tempPlayerSplit2Cards_LIST, tempPlayer_Script.playerNumber, tempCardMaterialListIndex, tempPlayer_Script, 1);

		yield return new WaitForSeconds(tempDelay);
		DealerAnimator.Play(tempCheckHit);
		yield return new WaitForSeconds(tempDelay);

	}


	IEnumerator SplitRoutine(PlayerScript tempPlayer_Script, string tempCardSet, RectTransform tempPlayerBetBar, string tempDrawFromPlayerHitAnim, string tempDealPlayerAnim, List<GameObject> playerCards_LIST, string tempCheckHitPlayerSplit,  GameObject tempPlayerCardInfo, List<GameObject> tempPlayerChips_LIST, string tempFromCheckHitPlayerToIdle, string tempDealerTakeChipsPlayer) {
		float tempDelay = 1.0f;
		float tempDelay2 = 0.5f;
		float tempDelay3 = 1.5f;
		int tempCardIndex = 0;




		if (tempPlayer_Script.playerNumber == "player1") {
			player1tempCardIndex = 2; //reset the index to be used on another list
		}
		else if (tempPlayer_Script.playerNumber == "player2")
		{
			player2tempCardIndex = 2; //reset the index to be used on another list
		}
		else if (tempPlayer_Script.playerNumber == "player3")
		{
			player3tempCardIndex = 2; //reset the index to be used on another list
		}

		tempPlayer_Script.whichCardSet = tempCardSet;
		tempPlayer_Script.hittingResponse = "hit";
		while (tempPlayer_Script.hittingResponse == "hit")
		{
			if (tempPlayer_Script.playerNumber == "player1")
			{
				player1Betting = true;
				tempCardIndex = player1tempCardIndex;

				if (tempPlayer_Script.whichCardSet == "Split1") {
					player1tempSplit1CardIndex = player1tempCardIndex;
				}
				else if (tempPlayer_Script.whichCardSet == "Split2") {
					player1tempSplit2CardIndex = player1tempCardIndex;
				}

			}
			else if (tempPlayer_Script.playerNumber == "player2")
			{
				player2Betting = true;
				tempCardIndex = player2tempCardIndex;

				if (tempPlayer_Script.whichCardSet == "Split1")
				{
					player2tempSplit1CardIndex = player2tempCardIndex;
				}
				else if (tempPlayer_Script.whichCardSet == "Split2")
				{
					player2tempSplit2CardIndex = player2tempCardIndex;
				}

			}
			else if (tempPlayer_Script.playerNumber == "player3")
			{
				player3Betting = true;
				tempCardIndex = player3tempCardIndex;

				if (tempPlayer_Script.whichCardSet == "Split1")
				{
					player3tempSplit1CardIndex = player3tempCardIndex;
				}
				else if (tempPlayer_Script.whichCardSet == "Split2")
				{
					player3tempSplit2CardIndex = player3tempCardIndex;
				}

			}


			//Start Check for Bust or Limit

			if (tempPlayer_Script.playerTotalCardValue > 21)
			{
				yield return StartCoroutine(UtilizeAceFunctionAndOthers(tempPlayer_Script, tempPlayerCardInfo, tempCardIndex, tempPlayerChips_LIST, tempFromCheckHitPlayerToIdle, tempDealerTakeChipsPlayer, tempCardSet));
			}
			else if (tempCardIndex > 4 || (tempPlayer_Script.playerTotalCardValue >= tempPlayer_Script.tempStandCheck && tempPlayer_Script.playerNumber == "AI"))
			{

				
				tempPlayer_Script.StartCoroutine(EnableChatObject(tempPlayer_Script.speechBubble, tempPlayer_Script.standSpeech));
				tempPlayer_Script.ConfirmStandBet("stand");
				tempPlayer_Script.playerStatus = "AIStand";

			}
			//End Check for Bust or Limit
			if (tempPlayer_Script.playerStatus != "AIStand" && tempPlayer_Script.playerTotalCardValue <= 21 && tempCardIndex <= 4)
			{


				//DealerAnimator.Play("CheckHitPlayer1");   //no need for this as DealerAnimator.Play("SplitPlayer1Cards"); ending is checkhit player1split
				tempPlayer_Script.playerStatus = "isHitting";
				if (tempPlayer_Script.playerType == "AI")
				{
					tempPlayer_Script.ConfirmStandBetAI();
				}
				else if (tempPlayer_Script.playerType == "player")
				{
					tempPlayer_Script.hittingResponse = "stand";
					tempPlayer_Script.playerStatus = "isHitting";

				}
				StartCoroutine(StartBetTimer(tempPlayerBetBar, tempPlayer_Script.playerNumber));
				yield return StartCoroutine(CheckHitting(tempPlayer_Script));
				Debug.Log("Time Expired");


				if (tempPlayer_Script.hittingResponse == "hit")
				{

					
					int tempCardMaterialListIndex = Random.Range(0, cardValue_LIST.Count);
					rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];
					leftHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];

					DealerAnimator.Play(tempDrawFromPlayerHitAnim);
					yield return new WaitForSeconds(tempDelay);
					DealerAnimator.Play(tempDealPlayerAnim);  //needs to be "DealPlayer1Card1Split1"
					yield return new WaitForSeconds(tempDelay);

/*--					int tempCardIndex = 0; //note needed. moved to highe up in the code
					if (tempPlayer_Script.playerNumber == "player1")
					{
						tempCardIndex = player1tempCardIndex;
					}
					else if (tempPlayer_Script.playerNumber == "player2")
					{
						tempCardIndex = player2tempCardIndex;
					}
					else if (tempPlayer_Script.playerNumber == "player3")
					{
						tempCardIndex = player3tempCardIndex;
					}
				--*/
					EnableCard(playerCards_LIST, tempPlayer_Script.playerNumber, tempCardMaterialListIndex, tempPlayer_Script, tempCardIndex);
					yield return new WaitForSeconds(tempDelay2); //delay to finish the animation of DealerAnimator.Play(tempDealPlayerAnim); from above code


					DealerAnimator.Play(tempCheckHitPlayerSplit);

					yield return StartCoroutine(UtilizeAceFunctionAndOthers(tempPlayer_Script, tempPlayerCardInfo, tempCardIndex, tempPlayerChips_LIST, tempFromCheckHitPlayerToIdle, tempDealerTakeChipsPlayer, tempCardSet));


					Debug.Log("hit");
				}
				else if (tempPlayer_Script.hittingResponse == "stand")
				{
					Debug.Log("stand");
	//				int tempCardIndex = 0; // not needed anymore
					if (tempPlayer_Script.playerNumber == "player1")
					{
						tempCardIndex = player1tempCardIndex;
					}
					else if (tempPlayer_Script.playerNumber == "player2")
					{
						tempCardIndex = player2tempCardIndex;
					}
					else if (tempPlayer_Script.playerNumber == "player3")
					{
						tempCardIndex = player3tempCardIndex;
					}

					yield return StartCoroutine(UtilizeAceFunctionAndOthers(tempPlayer_Script, tempPlayerCardInfo, tempCardIndex, tempPlayerChips_LIST, tempFromCheckHitPlayerToIdle, tempDealerTakeChipsPlayer, tempCardSet));
				}
			}
		

		}
	}

	//END Split Routine

	IEnumerator PayUpPlayer(List<GameObject> tempPlayerChips_LIST, List<GameObject> tempPlayerChipsPay_LIST, string tempFromCheckHitPlayerToIdle, string tempDealerDealChipsPlayer) {

		float tempDelay = 1.0f;
		float tempDelay2 = 0.5f;

		CopyChipsToDealerChips(tempPlayerChips_LIST, dealerChips_LIST);
		CopyChipsToDealerChips(tempPlayerChips_LIST, tempPlayerChipsPay_LIST);

		if (GM_Script.gameState != "DealerPhase") {
			DealerAnimator.Play(tempFromCheckHitPlayerToIdle);
		}
		yield return new WaitForSeconds(tempDelay2);
		DealerAnimator.Play("DealerGrabChips");
		yield return new WaitForSeconds(tempDelay);
		DealerAnimator.Play(tempDealerDealChipsPlayer);
		yield return new WaitForSeconds(tempDelay2);
		tempPlayerChipsPay_LIST[0].transform.parent.gameObject.SetActive(true);
		yield return new WaitForSeconds(tempDelay2);
		
	}



	IEnumerator UtilizeAceFunctionAndOthers(PlayerScript tempPlayerScript, GameObject tempCardInfo, int tempCardIndex, List<GameObject> tempPlayerChips_LIST, string tempFromChecktoHit, string dealerTakeChip, string cardSet) {

		float tempDelay = 1.0f;
		float tempDelay2 = 0.5f;
		if (cardSet == "NoSplit") {
			if (tempPlayerScript.playerTotalCardValue > 21 && tempPlayerScript.hasAceNumber > 0)
			{
				tempPlayerScript.playerTotalCardValue -= 10;
				tempPlayerScript.hasAceNumber--;
			}
			else if (tempPlayerScript.playerTotalCardValue > 21 && tempPlayerScript.hasAceNumber <= 0)
			{
				tempCardInfo.SetActive(true);
				tempCardInfo.GetComponent<SpriteRenderer>().sprite = bustedSprite;
				tempPlayerScript.playerStatus = "busted";
				tempPlayerScript.CallHalfBet();
				tempPlayerScript.hittingResponse = "busted"; //was stand
				tempPlayerScript.hasNoSplitBet = false;
			}

		}
		else if (cardSet == "Split1") {
			if (tempPlayerScript.playerTotalCardValueSplit1 > 21 && tempPlayerScript.hasAceNumberSplit1 > 0)
			{
				tempPlayerScript.playerTotalCardValueSplit1 -= 10;
				tempPlayerScript.hasAceNumberSplit1--;
			}
			else if (tempPlayerScript.playerTotalCardValueSplit1 > 21 && tempPlayerScript.hasAceNumberSplit1 <= 0)
			{
				tempCardInfo.SetActive(true);
				tempCardInfo.GetComponent<SpriteRenderer>().sprite = bustedSprite;
				tempPlayerScript.playerStatus = "busted";
				tempPlayerScript.CallHalfBet();
				tempPlayerScript.hittingResponse = "busted"; //was stand
				tempPlayerScript.hasSplit1Bet = false;
			}


		}
		else if (cardSet == "Split2")
		{
			if (tempPlayerScript.playerTotalCardValueSplit2 > 21 && tempPlayerScript.hasAceNumberSplit2 > 0)
			{
				tempPlayerScript.playerTotalCardValueSplit2 -= 10;
				tempPlayerScript.hasAceNumberSplit2--;
			}
			else if (tempPlayerScript.playerTotalCardValueSplit2 > 21 && tempPlayerScript.hasAceNumberSplit2 <= 0)
			{
				tempCardInfo.SetActive(true);
				tempCardInfo.GetComponent<SpriteRenderer>().sprite = bustedSprite;
				tempPlayerScript.playerStatus = "busted";
				tempPlayerScript.CallHalfBet();
				tempPlayerScript.hittingResponse = "busted";
				tempPlayerScript.hasSplit2Bet = false;
			}


		}


		

		yield return new WaitForSeconds(tempDelay);

		if (tempPlayerScript.playerStatus == "busted")
		{
			CopyChipsToDealerChips(tempPlayerChips_LIST, dealerChips_LIST);
			DealerAnimator.Play(tempFromChecktoHit);
			yield return new WaitForSeconds(tempDelay2);
			DealerAnimator.Play(dealerTakeChip);
			yield return new WaitForSeconds(tempDelay2);
			tempPlayerChips_LIST[0].transform.parent.gameObject.SetActive(false);
			yield return new WaitForSeconds(tempDelay2);
			DealerAnimator.Play("DealerReturnChips");
			yield return new WaitForSeconds(tempDelay);
		}
		else if (tempCardIndex > 4)
		{

			tempPlayerScript.hittingResponse = "stand";
		}

	}

	public void CopyChipsToDealerChips(List<GameObject> tempChipList, List<GameObject> tempToCopyToChip_LIST) {
		for (int x=0; x<22; x++) {
			//dealerChips_LIST[0].GetComponent<Renderer>.material
			if (tempChipList[x].activeSelf) {
				tempToCopyToChip_LIST[x].SetActive(true);
				tempToCopyToChip_LIST[x].GetComponent<Renderer>().material = tempChipList[x].GetComponent<Renderer>().material;
			}
		}

	}

	IEnumerator CheckHitting(PlayerScript tempPlayer_Script)
	{
		float tempDelay = 1.0f;
		while (tempPlayer_Script.playerStatus != "doneHitting")
		{

			yield return new WaitForSeconds(tempDelay);
		}


	}

	//---------------------------------------------------END HITTING PHASE----------------------------------------------------------------//



	//---------------------------------------------------Start Dealer PHASE----------------------------------------------------------------//

	public void StartDealerPhase() {
		StartCoroutine(DealerPhase());
	}

	IEnumerator DealerPhase() {
		int tempDealerStandCheck = 17;
		dealerStatus = "isDealingSelf";
		
		//Start for Card 2 Value
		int tempCardMaterialListIndex = Random.Range(0, cardValue_LIST.Count);
		rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];
		DealerAnimator.Play("OpenDealerCard2");
		yield return new WaitForSeconds(TEMPDELAY2);
		dealerCard2Back.SetActive(false);
		yield return new WaitForSeconds(TEMPDELAY);                                                                    
		
															//should be dealerScript but, parameter requires PlayerScipt. It's not used anyway if it's a dealer
		EnableCard(DealerCards_LIST, "dealerCard2Front", tempCardMaterialListIndex, Player1_Script, dealertempCardIndex);
		yield return new WaitForSeconds(TEMPDELAY2);
		//END for Card 2 Value

		//

		while(dealerStatus == "isDealingSelf"){

				if (dealerTotalCardValue > 21 && hasAce > 0)
				{
					dealerTotalCardValue -= 10;
					hasAce--;
				}






			if (dealerTotalCardValue > 21) {

				DealerCardInfo.SetActive(true);
				DealerCardInfo.GetComponent<SpriteRenderer>().sprite = bustedSprite;
				dealerStatus = "busted";
				

			}
			else if (dealerTotalCardValue == 21 && dealertempCardIndex < 3)
			{


				DealerCardInfo.SetActive(true);
				DealerCardInfo.GetComponent<SpriteRenderer>().sprite = blackjackSprite;
				dealerStatus = "Blackjack";



			}
			else if (dealerTotalCardValue >= tempDealerStandCheck || dealertempCardIndex > 4) //17  stand
			{
				StartCoroutine(EnableChatObject(chatbubbleLeft, dealerStands));
				dealerStatus = "stands";

			}
			else if (dealerTotalCardValue < tempDealerStandCheck) //17	hit
			{
				StartCoroutine(EnableChatObject(chatbubbleLeft, dealerHits));
				//dealerStatus = "isDealingSelf"; this is by default. no need to write it again
				tempCardMaterialListIndex = Random.Range(0, cardValue_LIST.Count);
				rightHandCard.material = cardMaterial_LIST[tempCardMaterialListIndex];
				DealerAnimator.Play("DrawCard");
				yield return new WaitForSeconds(TEMPDELAY);
				DealerAnimator.Play("DealDealerCard3");
				yield return new WaitForSeconds(TEMPDELAY3);
				//should be dealerScript(Player1_Script) but, parameter requires PlayerScipt. It's not used anyway if it's a dealer
				EnableCard(DealerCards_LIST, "dealerCard3", tempCardMaterialListIndex, Player1_Script, dealertempCardIndex);
				yield return new WaitForSeconds(TEMPDELAY2);



			}

		}

		DealerAnimator.Play("FromDrawToIdle");
		yield return new WaitForSeconds(TEMPDELAY2);


		//Start Dealer Checking Cards
		
			if (Player1_Script.hasNoSplitBet == true) {
			Player1_Script.whichCardSet = "NoSplit";
				
				if (dealerStatus == "busted" || dealerTotalCardValue < Player1_Script.playerTotalCardValue || (dealerTotalCardValue == 21 && Player1_Script.playerTotalCardValue == 21 && dealertempCardIndex > player1tempCardIndex))
				{
					yield return StartCoroutine(DealerPayRoutine(Player1_Script, player1Chips_LIST, player1ChipsPay_LIST, "DealerDealChipsPlayer1", player1CardInfoNoSplit));
				}
				else
				{
					yield return StartCoroutine(DealerTakesLoserChips(Player1_Script, dealerTotalCardValue, Player1_Script.playerTotalCardValue, player1CardInfoNoSplit, player1Chips_LIST, "DealerTakeChipsPlayer1"));
				}
			}
			else
			{ 

				if (Player1_Script.hasSplit1Bet == true)
				{                                                                                                                   //"DealerDealChipsPlayer1Split1"
					Player1_Script.whichCardSet = "Split1";
					if (dealerStatus == "busted" || dealerTotalCardValue < Player1_Script.playerTotalCardValueSplit1 || (dealerTotalCardValue == 21 && Player1_Script.playerTotalCardValueSplit1 == 21 && dealertempCardIndex > player1tempSplit1CardIndex))
					{
						yield return StartCoroutine(DealerPayRoutine(Player1_Script, player1ChipsSplit1_LIST, player1ChipsPaySplit1_LIST, "DealerDealChipsPlayer1", player1CardInfoSplit1));
					}
					else
					{																																													//"DealerTakeChipsPlayer1Split1"
						yield return StartCoroutine(DealerTakesLoserChips(Player1_Script, dealerTotalCardValue, Player1_Script.playerTotalCardValueSplit1, player1CardInfoSplit1, player1ChipsSplit1_LIST, "DealerTakeChipsPlayer1"));
					}
			}
				if (Player1_Script.hasSplit2Bet == true)
				{                                                                                                                   //"DealerDealChipsPlayer1Split2"
					Player1_Script.whichCardSet = "Split2";
					if (dealerStatus == "busted" || dealerTotalCardValue < Player1_Script.playerTotalCardValueSplit2 || (dealerTotalCardValue == 21 && Player1_Script.playerTotalCardValueSplit2 == 21 && dealertempCardIndex > player1tempSplit2CardIndex))
					{

						yield return StartCoroutine(DealerPayRoutine(Player1_Script, player1ChipsSplit2_LIST, player1ChipsPaySplit2_LIST, "DealerDealChipsPlayer1", player1CardInfoSplit2));
					}
					else
					{                                                                                                                                                                                   //"DealerTakeChipsPlayer1Split2"
						yield return StartCoroutine(DealerTakesLoserChips(Player1_Script, dealerTotalCardValue, Player1_Script.playerTotalCardValueSplit2, player1CardInfoSplit2, player1ChipsSplit2_LIST, "DealerTakeChipsPlayer1"));
					}
				}

			}

			if (Player2_Script.hasNoSplitBet == true)
			{
				Player2_Script.whichCardSet = "NoSplit";
				if (dealerStatus == "busted" || dealerTotalCardValue < Player2_Script.playerTotalCardValue || (dealerTotalCardValue == 21 && Player2_Script.playerTotalCardValue == 21 && dealertempCardIndex > player2tempCardIndex))
				{

					yield return StartCoroutine(DealerPayRoutine(Player2_Script, player2Chips_LIST, player2ChipsPay_LIST, "DealerDealChipsPlayer2", player2CardInfoNoSplit));
				}
				else
				{
					yield return StartCoroutine(DealerTakesLoserChips(Player2_Script, dealerTotalCardValue, Player2_Script.playerTotalCardValue, player2CardInfoNoSplit, player2Chips_LIST, "DealerTakeChipsPlayer2"));
				}

			}
			else
			{

				if (Player2_Script.hasSplit1Bet == true)
				{                                                                                                                   //"DealerDealChipsPlayer2Split1"
					Player2_Script.whichCardSet = "Split1";
					if (dealerStatus == "busted" || dealerTotalCardValue < Player2_Script.playerTotalCardValueSplit1 || (dealerTotalCardValue == 21 && Player2_Script.playerTotalCardValueSplit1 == 21 && dealertempCardIndex > player2tempSplit1CardIndex))
					{
						yield return StartCoroutine(DealerPayRoutine(Player2_Script, player2ChipsSplit1_LIST, player2ChipsPaySplit1_LIST, "DealerDealChipsPlayer2", player2CardInfoSplit1));
					}
					else
					{																																													//"DealerTakeChipsPlayer1Split2"
						yield return StartCoroutine(DealerTakesLoserChips(Player2_Script, dealerTotalCardValue, Player2_Script.playerTotalCardValueSplit1, player2CardInfoSplit1, player2ChipsSplit1_LIST, "DealerTakeChipsPlayer2"));
					}
				}
				if (Player2_Script.hasSplit2Bet == true)
				{                                                                                                                   //"DealerDealChipsPlayer2Split2"
					Player2_Script.whichCardSet = "Split2";
					if (dealerStatus == "busted" || dealerTotalCardValue < Player2_Script.playerTotalCardValueSplit2 || (dealerTotalCardValue == 21 && Player2_Script.playerTotalCardValueSplit2 == 21 && dealertempCardIndex > player2tempSplit2CardIndex))
					{
						yield return StartCoroutine(DealerPayRoutine(Player2_Script, player2ChipsSplit2_LIST, player2ChipsPaySplit2_LIST, "DealerDealChipsPlayer2", player2CardInfoSplit2));
					}
					else
					{                                                                                                                                                                                   //"DealerTakeChipsPlayer1Split2"
						yield return StartCoroutine(DealerTakesLoserChips(Player2_Script, dealerTotalCardValue, Player2_Script.playerTotalCardValueSplit2, player2CardInfoSplit2, player2ChipsSplit2_LIST, "DealerTakeChipsPlayer2"));
					}
				}

			}

			if (Player3_Script.hasNoSplitBet == true)
			{
				Player3_Script.whichCardSet = "NoSplit";
				if (dealerStatus == "busted" || dealerTotalCardValue < Player3_Script.playerTotalCardValue || (dealerTotalCardValue == 21 && Player3_Script.playerTotalCardValue == 21 && dealertempCardIndex > player3tempCardIndex))
				{
					yield return StartCoroutine(DealerPayRoutine(Player3_Script, player3Chips_LIST, player3ChipsPay_LIST, "DealerDealChipsPlayer3", player3CardInfoNoSplit));
				}
				else
				{
					yield return StartCoroutine(DealerTakesLoserChips(Player3_Script, dealerTotalCardValue, Player3_Script.playerTotalCardValue, player3CardInfoNoSplit, player3Chips_LIST, "DealerTakeChipsPlayer3"));
				}

			}

			else
			{

				if (Player3_Script.hasSplit1Bet == true)
				{                                                                                                                   //"DealerDealChipsPlayer3Split1"
					Player3_Script.whichCardSet = "Split1";
					if (dealerStatus == "busted" || dealerTotalCardValue < Player3_Script.playerTotalCardValueSplit1 || (dealerTotalCardValue == 21 && Player3_Script.playerTotalCardValueSplit1 == 21 && dealertempCardIndex > player3tempSplit1CardIndex))
					{
						yield return StartCoroutine(DealerPayRoutine(Player3_Script, player3ChipsSplit1_LIST, player3ChipsPaySplit1_LIST, "DealerDealChipsPlayer3", player3CardInfoSplit1));
					}
					else
					{                                                                                                                                                                                   //"DealerTakeChipsPlayer1Split2"
						yield return StartCoroutine(DealerTakesLoserChips(Player3_Script, dealerTotalCardValue, Player3_Script.playerTotalCardValueSplit1, player3CardInfoSplit1, player3ChipsSplit1_LIST, "DealerTakeChipsPlayer3"));
					}
				}
				if (Player3_Script.hasSplit2Bet == true)
				{                                                                                                                   //"DealerDealChipsPlayer1Split2"
					Player3_Script.whichCardSet = "Split2";
					if (dealerStatus == "busted" || dealerTotalCardValue < Player3_Script.playerTotalCardValueSplit2 || (dealerTotalCardValue == 21 && Player3_Script.playerTotalCardValueSplit2 == 21 && dealertempCardIndex > player3tempSplit2CardIndex))
					{
						yield return StartCoroutine(DealerPayRoutine(Player3_Script, player3ChipsSplit2_LIST, player3ChipsPaySplit2_LIST, "DealerDealChipsPlayer3", player3CardInfoSplit2));
					}
					else
					{                                                                                                                                                                                   //"DealerTakeChipsPlayer1Split2"
						yield return StartCoroutine(DealerTakesLoserChips(Player3_Script, dealerTotalCardValue, Player3_Script.playerTotalCardValueSplit2, player3CardInfoSplit2, player3ChipsSplit2_LIST, "DealerTakeChipsPlayer3"));
					}
				}

		}



		DealerAnimator.Play("DealerTakePlayerCards");
		yield return new WaitForSeconds(4.0f);
		//End Dealer Checking Cards

		//--while loop 
		GM_Script.gameState = "doneDealerPhase";
		yield return null;
	}


	IEnumerator DealerPayRoutine(PlayerScript tempPlayer_Script, List<GameObject> tempPlayerChips_LIST, List<GameObject> tempPlayerChipsPay_LIST, string tempDealerDealChipsPlayer, GameObject tempCardInfo)
	{

		tempCardInfo.SetActive(true);
		tempCardInfo.GetComponent<SpriteRenderer>().sprite = winSprite;
		yield return StartCoroutine(PayUpPlayer(tempPlayerChips_LIST, tempPlayerChipsPay_LIST, "Not in use for this Call", tempDealerDealChipsPlayer));
		tempPlayer_Script.CallEnablePaymentDisplay();
		StartCoroutine(AnimateTakingChips(tempPlayerChips_LIST));
		StartCoroutine(AnimateTakingChips(tempPlayerChipsPay_LIST));
		yield return new WaitForSeconds(TEMPDELAY);

	}

	IEnumerator DealerTakesLoserChips(PlayerScript tempPlayerScript, int tempDealerCardValue, int tempPlayerCardValue, GameObject tempCardInfo, List<GameObject> tempPlayerChips_LIST, string dealerTakeChip)
	{


		tempCardInfo.SetActive(true);

		tempPlayerScript.CallHalfBet();

		if (tempDealerCardValue > tempPlayerCardValue)
		{
			tempCardInfo.GetComponent<SpriteRenderer>().sprite = loseSprite;
			tempPlayerScript.playerStatus = "lose";
		}
		else if (tempDealerCardValue == tempPlayerCardValue)
		{
			tempCardInfo.GetComponent<SpriteRenderer>().sprite = drawSprite;
			tempPlayerScript.playerStatus = "draw";
			tempPlayerScript.UpdatePaymentDisplay(tempPlayerScript.bet, "+");
			tempPlayerScript.CallEnablePaymentDisplay();
		}




		yield return new WaitForSeconds(TEMPDELAY);

		if (tempPlayerScript.playerStatus == "lose")
		{
			CopyChipsToDealerChips(tempPlayerChips_LIST, dealerChips_LIST);
			DealerAnimator.Play(dealerTakeChip);
			yield return new WaitForSeconds(TEMPDELAY2);
			tempPlayerChips_LIST[0].transform.parent.gameObject.SetActive(false);
			yield return new WaitForSeconds(TEMPDELAY2);
			DealerAnimator.Play("DealerReturnChips");
			yield return new WaitForSeconds(TEMPDELAY);
		}
		else if (tempPlayerScript.playerStatus == "draw")
		{
			StartCoroutine(AnimateTakingChips(tempPlayerChips_LIST));
			
			
			

		}
	}

	//---------------------------------------------------END Dealer PHASE----------------------------------------------------------------//

	IEnumerator StartBetTimer(RectTransform tempPlayer, string tempPlayerName) {

		int divisorScale = 500;
		float tempReducingValue = tempPlayer.localScale.x/ divisorScale;

		if (tempPlayerName == "player1") {
			Player1BetBar_GO.SetActive(true);
		}
		else if (tempPlayerName == "player2") {
			Player2BetBar_GO.SetActive(true);
		}
		else if (tempPlayerName == "player3")
		{
			Player3BetBar_GO.SetActive(true);
		}

		while (tempPlayer.localScale.x>0) {
			//tempPlayer.sizeDelta -= new Vector2(0.15f, 0);
			tempPlayer.localScale -= new Vector3(tempReducingValue, 0, 0);
			yield return new WaitForSeconds(0.03f);

			if (player1Betting == false && tempPlayerName == "player1")
			{
				Player1BetBar_GO.SetActive(false);
				if (Player1_Script.playerType == "player")
				{
					bettingPanel.SetActive(false);
					hittingPanel.SetActive(true);
				}

				Player1_Script.playerStatus = "doneHitting";
				player1Betting = false;
				tempPlayer.localScale = new Vector3(tempReducingValue * divisorScale, tempPlayer.localScale.y, tempPlayer.localScale.z);

				yield break;
			}
			if (player2Betting == false && tempPlayerName == "player2")
			{
				Player2BetBar_GO.SetActive(false);

				if (Player2_Script.playerType == "player") {
					bettingPanel.SetActive(false);
					hittingPanel.SetActive(true);
				}
				//
				
				Player2_Script.playerStatus = "doneHitting";
				player2Betting = false;
				tempPlayer.localScale = new Vector3(tempReducingValue * divisorScale, tempPlayer.localScale.y, tempPlayer.localScale.z);
				//
				yield break;
			}
			if (player3Betting == false && tempPlayerName == "player3")
			{
				Player3BetBar_GO.SetActive(false);

				if (Player3_Script.playerType == "player")
				{
					bettingPanel.SetActive(false);
					hittingPanel.SetActive(true);
				}
				Player3_Script.playerStatus = "doneHitting";
				player3Betting = false;
				tempPlayer.localScale = new Vector3(tempReducingValue * divisorScale, tempPlayer.localScale.y, tempPlayer.localScale.z);
				yield break;
			}
		}

		if (tempPlayerName == "player1")
		{
			Player1BetBar_GO.SetActive(false);
			if (Player1_Script.playerType == "player")
			{
				bettingPanel.SetActive(false);
				hittingPanel.SetActive(true);

				if (GM_Script.gameState == "BettingChips")
				{
					Player1_Script.ChipsConfirm();
				}
			}
			
			Player1_Script.playerStatus = "doneHitting";
			player1Betting = false;
			Player1_Script.hittingResponse = "stand"; // this is for if the player didn't press anything and times runs out
			tempPlayer.localScale = new Vector3(tempReducingValue * divisorScale, tempPlayer.localScale.y, tempPlayer.localScale.z);
		}
		if (tempPlayerName == "player2")
		{
			Player2BetBar_GO.SetActive(false);
			if (Player2_Script.playerType == "player")
			{
				bettingPanel.SetActive(false);
				hittingPanel.SetActive(true);

				if (GM_Script.gameState == "BettingChips")
				{
					Player2_Script.ChipsConfirm();
				}
			}
			Player2_Script.playerStatus = "doneHitting";
			player2Betting = false;
			Player2_Script.hittingResponse = "stand"; // this is for if the player didn't press anything and times runs out
			tempPlayer.localScale = new Vector3(tempReducingValue * divisorScale, tempPlayer.localScale.y, tempPlayer.localScale.z);

//			ReceiveBet(player2_Script.bet, "player2");
		}
		if (tempPlayerName == "player3")
		{
			Player3BetBar_GO.SetActive(false);
			if (Player3_Script.playerType == "player")
			{
				bettingPanel.SetActive(false);
				hittingPanel.SetActive(true);

				if (GM_Script.gameState == "BettingChips")
				{
					Player3_Script.ChipsConfirm();
				}
			}
			
			Player3_Script.playerStatus = "doneHitting";
			player3Betting = false;
			Player3_Script.hittingResponse = "stand"; // this is for if the player didn't press anything and times runs out
			tempPlayer.localScale = new Vector3(tempReducingValue * divisorScale, tempPlayer.localScale.y, tempPlayer.localScale.z);
		}


	}

	//Start Dealer Receives Bet ----------------------------------------------------------------------------------------------------------------------------------------//

	public void ReceiveBet(int bet, string tempPlayer) {

		if (tempPlayer == "player1")
		{
			player1Bet = bet;
			StartCoroutine(AnimateChips(player1Chips, player1Chips_LIST, player1tempChipIndex, player1Bet, "player1"));
		}
		else if(tempPlayer == "player2")
		{
			player2Bet = bet;
			StartCoroutine(AnimateChips(player2Chips, player2Chips_LIST, player2tempChipIndex , player2Bet, "player2"));
			

		}
		else if (tempPlayer == "player3")
		{
			player3Bet = bet;
			StartCoroutine(AnimateChips(player3Chips, player3Chips_LIST, player3tempChipIndex, player3Bet, "player3"));
		}


	}

	IEnumerator AnimateTakingChips(List<GameObject> tempChips_LIST) {

		Animator tempChipAnimator = tempChips_LIST[0].transform.parent.gameObject.GetComponent<Animator>();
		
		for (int x = 20; x > -1; x--)
		{
			if (tempChips_LIST[x].activeSelf) {
				tempChips_LIST[21].GetComponent<Renderer>().material = tempChips_LIST[x].GetComponent<Renderer>().material;
				tempChips_LIST[x].SetActive(false);
				tempChipAnimator.Play("TakeChips");
				yield return new WaitForSeconds(0.25f);                                      //This delay is to wait for chip animation to finish before enabling the chip
			}
		
			
		}
		
	}
	

	IEnumerator AnimateChips(GameObject tempChips, List<GameObject> tempChips_LIST, int tempPlayerChipIndex, int bet, string tempPlayer) {

		int tempBet;
		int tempTotalBet = bet;
		float tempAnimationDelay = 0.2f;

		tempChips.SetActive(true);

		int tempChipValue = 5000;
		if (tempTotalBet / tempChipValue >= 1) {
			tempBet = tempTotalBet / tempChipValue;
			tempTotalBet -= tempChipValue*tempBet;

			for (int x=0; x < tempBet; x++) {
				ChangeChipMaterials(tempChips_LIST, tempPlayer, chip5000);
				tempChips.GetComponent<Animator>().Play("AddChips");
				yield return new WaitForSeconds(tempAnimationDelay);                                      //This delay is to wait for chip animation to finish before enabling the chip
				EnableChip(tempChips_LIST,tempPlayer);		

			}
		}
		tempChipValue = 1000;
		if (tempTotalBet / tempChipValue >= 1) {
			tempBet = tempTotalBet / tempChipValue;
			tempTotalBet -= tempChipValue * tempBet;
			Debug.Log(tempChipValue);

			for (int x = 0; x < tempBet; x++)
			{
				ChangeChipMaterials(tempChips_LIST, tempPlayer, chip1000);
				tempChips.GetComponent<Animator>().Play("AddChips");
				yield return new WaitForSeconds(tempAnimationDelay);                                      //This delay is to wait for chip animation to finish before enabling the chip
				EnableChip(tempChips_LIST, tempPlayer);

			}
		}
		tempChipValue = 500;
		if (tempTotalBet / tempChipValue >= 1)
		{
			tempBet = tempTotalBet / tempChipValue;
			tempTotalBet -= tempChipValue * tempBet;
			Debug.Log(tempChipValue);

			for (int x = 0; x < tempBet; x++)
			{
				ChangeChipMaterials(tempChips_LIST, tempPlayer, chip500);
				tempChips.GetComponent<Animator>().Play("AddChips");
				yield return new WaitForSeconds(tempAnimationDelay);                                      //This delay is to wait for chip animation to finish before enabling the chip
				EnableChip(tempChips_LIST, tempPlayer);

			}
		}
		tempChipValue = 100;
		if (tempTotalBet / tempChipValue >= 1)
		{
			tempBet = tempTotalBet / tempChipValue;
			tempTotalBet -= tempChipValue * tempBet;
			Debug.Log(tempChipValue);

			for (int x = 0; x < tempBet; x++)
			{
				ChangeChipMaterials(tempChips_LIST, tempPlayer, chip100);
				tempChips.GetComponent<Animator>().Play("AddChips");
				yield return new WaitForSeconds(tempAnimationDelay);                                      //This delay is to wait for chip animation to finish before enabling the chip
				EnableChip(tempChips_LIST, tempPlayer);

			}
		}
		tempChipValue = 50;
		if (tempTotalBet / tempChipValue >= 1)
		{
			tempBet = tempTotalBet / tempChipValue;
			tempTotalBet -= tempChipValue * tempBet;
			Debug.Log(tempChipValue);

			for (int x = 0; x < tempBet; x++)
			{
				ChangeChipMaterials(tempChips_LIST, tempPlayer, chip50);
				tempChips.GetComponent<Animator>().Play("AddChips");
				yield return new WaitForSeconds(tempAnimationDelay);                                      //This delay is to wait for chip animation to finish before enabling the chip
				EnableChip(tempChips_LIST, tempPlayer);

			}
		}
		tempChipValue = 10;
		if (tempTotalBet / tempChipValue >= 1)
		{
			tempBet = tempTotalBet / tempChipValue;
			tempTotalBet -= tempChipValue * tempBet;
			Debug.Log(tempChipValue);

			for (int x = 0; x < tempBet; x++)
			{
				ChangeChipMaterials(tempChips_LIST, tempPlayer, chip10);
				tempChips.GetComponent<Animator>().Play("AddChips");
				yield return new WaitForSeconds(tempAnimationDelay);                                      //This delay is to wait for chip animation to finish before enabling the chip
				EnableChip(tempChips_LIST, tempPlayer);

			}
		}
		tempChipValue = 5;
		if (tempTotalBet / tempChipValue >= 1)
		{
			tempBet = tempTotalBet / tempChipValue;
			tempTotalBet -= tempChipValue * tempBet;
			Debug.Log(tempChipValue);

			for (int x = 0; x < tempBet; x++)
			{
				ChangeChipMaterials(tempChips_LIST, tempPlayer, chip5);
				tempChips.GetComponent<Animator>().Play("AddChips");
				yield return new WaitForSeconds(tempAnimationDelay);                                      //This delay is to wait for chip animation to finish before enabling the chip
				EnableChip(tempChips_LIST, tempPlayer);

			}
		}
		tempChipValue = 1;
		if (tempTotalBet / tempChipValue >= 1)
		{
			tempBet = tempTotalBet / tempChipValue;
			tempTotalBet -= tempChipValue * tempBet;
			Debug.Log(tempChipValue);

			for (int x = 0; x < tempBet; x++)
			{
				ChangeChipMaterials(tempChips_LIST, tempPlayer, chip1);
				tempChips.GetComponent<Animator>().Play("AddChips");
				yield return new WaitForSeconds(tempAnimationDelay);                                      //This delay is to wait for chip animation to finish before enabling the chip
				EnableChip(tempChips_LIST, tempPlayer);

			}
		}
	}

	public void ChangeChipMaterials(List<GameObject> tempChip_LIST, string tempPlayer, Material tempChip_MAT) {
		


		if (tempPlayer == "player1")
		{
			tempChip_LIST[21].GetComponent<Renderer>().material = tempChip_MAT;
			tempChip_LIST[player1tempChipIndex].GetComponent<Renderer>().material = tempChip_MAT;
		}
		else if (tempPlayer == "player2")
		{

			tempChip_LIST[21].GetComponent<Renderer>().material = tempChip_MAT;
			tempChip_LIST[player2tempChipIndex].GetComponent<Renderer>().material = tempChip_MAT;
		}
		else if (tempPlayer == "player3")
		{
			tempChip_LIST[21].GetComponent<Renderer>().material = tempChip_MAT;
			tempChip_LIST[player3tempChipIndex].GetComponent<Renderer>().material = tempChip_MAT;
		}
		

	}


	public void EnableChip(List<GameObject> tempChip_LIST, string tempPlayer) {

		tempChip_LIST[0].transform.parent.gameObject.SetActive(true);
		if (tempPlayer == "player1") {
			tempChip_LIST[player1tempChipIndex].SetActive(true);
			player1tempChipIndex++;
		}
		else if (tempPlayer == "player2")
		{
			tempChip_LIST[player2tempChipIndex].SetActive(true);
			player2tempChipIndex++;
		}
		else if (tempPlayer == "player3")
		{
			tempChip_LIST[player3tempChipIndex].SetActive(true);
			player3tempChipIndex++;
		}


	}

	//END Dealer Receives Bet ----------------------------------------------------------------------------------------------------------------------------------------//
	IEnumerator EnableChatObject(GameObject tempGameObject, Sprite tempSprite)
	{
		tempGameObject.SetActive(true);
		tempGameObject.transform.GetChild(0).GetComponent<Image>().sprite = tempSprite;
		yield return new WaitForSeconds(2.0f);
		tempGameObject.SetActive(false);
	}


	
}
