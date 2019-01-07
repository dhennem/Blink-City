using UnityEngine;
using UnityEngine.UI;


public class Bar : MonoBehaviour {


    public GameObject background, foreground;
    public GameObject topBar,centerBar,bottomBar;
    public GameObject bar,fullBar;
    public GUIMessageManager messager;
    public WinDetector winDetector;
    public AudioClip fullBarSound;
    public AudioClip loseSound;

    private LoseDetector loseDetector;
    private PlayerController player;

    float d;
    Vector2 emptyTopPos;
    public Color[] color = new Color[4];
    public float persent;
    public float percentDecreaseRate;

    private bool isFull = false;
    private bool displayedFullMessage = false;
    private bool decreasing;

    void Start () {
    	decreasing = true;
		bar.SetActive(true);
		LoseDetector.lost = false;
    	messager = FindObjectOfType<GUIMessageManager>();
    	winDetector = FindObjectOfType<WinDetector>();
    	loseDetector = FindObjectOfType<LoseDetector>();
        centerBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, d);
        emptyTopPos = centerBar.transform.localPosition;
        if(color.Length > 0 && color.Length < 4)
        SetColor(color[0]);

    }
	
	// Update is called once per frame
	void Update () {
		if(player==null) player = FindObjectOfType<PlayerController>();
		if(isFull) persent = 100;
		if(decreasing && !LoseDetector.lost) decreasePercent();
        if (color.Length != 4)
            Debug.LogError("dont change Color array size, equale 4 !!!");
        d = (109f / 100f)* persent ;

        centerBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, d);
        topBar.transform.localPosition = emptyTopPos + new Vector2(0,d) ;
        if (persent <= 0)
        {
        	if(decreasing){
				AudioSource.PlayClipAtPoint(loseSound,player.transform.position);
        	}
            persent = 0;
            decreasing = false;
            LoseDetector.lost = true;
            bar.SetActive(false);
            fullBar.SetActive(false);
            player.gameObject.SetActive(false);
            loseDetector.ShowLosePanel(LoseDetector.LoseReason.resource);
            if (color.Length > 0 && color.Length < 5)
                SetColor(color[3]);
        }
        else if (persent > 0 && persent < 100)
        {
            bar.SetActive(true);
            fullBar.SetActive(false);
            if (d < 25   && color.Length > 0 && color.Length < 5) {
                SetColor(color[3]);
            }
            else if(persent > 25 && persent < 50 && color.Length > 0 && color.Length < 5)
            {
                SetColor(color[2]);
            }
            else if (persent > 50 && persent < 75 && color.Length > 0 && color.Length < 5)
            {
                SetColor(color[1]);
            }
            else if (persent > 75 && color.Length >0 && color.Length < 5)
            {
                SetColor(color[0]);
            }
        }
        else if (persent >= 100 && !isFull)
        {
            bar.SetActive(false);
            fullBar.SetActive(true);
            decreasing = false;
            persent = 100;
            isFull = true;
            AudioSource.PlayClipAtPoint(fullBarSound, player.transform.position);
            if ( color.Length > 0 && color.Length < 5)
            SetColor(color[0]);
        }

        if(isFull && !displayedFullMessage){ //allows only one full bar message to display at a time. If a bar is full when another message is showing, the message will show afterwards
        	if(!messager.displayingMessage){
				messager.displayNewMessage(gameObject.name + " is now full!");
	            Invoke("deleteFullBarMessage", 3f);
	            displayedFullMessage = true;
	            winDetector.numBarsFilled += 1;
	        }
        }
       
    }

    void deleteFullBarMessage(){
    	messager.deleteMessage();
    }

    public void SetColor(Color color) {
        topBar.GetComponent<Image>().color = color;
        centerBar.GetComponent<Image>().color = color;
        bottomBar.GetComponent<Image>().color = color;
        fullBar.GetComponent<Image>().color = color;
    }

    void decreasePercent(){
    	if(!IntroSequenceManager.introFinished){
    		persent = 49f;
    	}
    	else{
    		persent -= percentDecreaseRate * Time.deltaTime;
    	}
    }
}
