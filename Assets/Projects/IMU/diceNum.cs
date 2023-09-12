using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diceNum : MonoBehaviour
{
    // Start is called before the first frame update

    //objects
    GameObject Diceone;
    GameObject Dicetwo;
    GameObject oned;
    GameObject twod;
    GameObject threed;
    GameObject fourd;
    GameObject fived;
    GameObject sixd;

    //dice plane
    public GameObject redone;
    public GameObject redtwo;
    public GameObject redthree;
    public GameObject redfour;
    public GameObject redfive;
    public GameObject redsix;

    public GameObject blueone;
    public GameObject bluetwo;
    public GameObject bluethree;
    public GameObject bluefour;
    public GameObject bluefive;
    public GameObject bluesix;

    //text
    GameObject playernum;
    GameObject commands;
    GameObject number;
    GameObject timer;
    GameObject p1text;
    GameObject p2text;

    //variable
    float oneh;
    float twoh;
    float threeh;
    float fourh;
    float fiveh;
    float sixh;

    bool start = false;
    bool rolling = false;
    bool p1 = false;
    bool p2 = false;

    int dicept;

    int p1dice = 0;
    int p2dice = 0;

    int p1pt = 0;
    int p2pt = 0;

    float deltime = 5.0f;

    void Start()
    {
        this.Diceone = GameObject.Find("Dice_1");
        this.Dicetwo = GameObject.Find("Dice_2");
        this.oned = GameObject.Find("one");
        this.twod = GameObject.Find("two");
        this.threed = GameObject.Find("three");
        this.fourd = GameObject.Find("four");
        this.fived = GameObject.Find("five");
        this.sixd = GameObject.Find("six");

        this.playernum = GameObject.Find("Playernum");
        this.commands = GameObject.Find("Command");
        this.number = GameObject.Find("Dicenumber");
        this.timer = GameObject.Find("timer");

        this.p1text = GameObject.Find("p1point");
        this.p2text = GameObject.Find("p2point");

        this.commands.GetComponent<Text>().text = "Press B and start game";
        this.Dicetwo.GetComponent<Renderer>().enabled = !this.Dicetwo.GetComponent<Renderer>().enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if(!start)
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
                start = true;
                p1 = true;
                this.commands.GetComponent<Text>().text = "Press D and Roll the Dice";
            }
        }

        else
        {
            if (p1dice < 5 || p2dice < 5)
            {
                if (!rolling)
                {
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        rolling = true;
                    }
                }
                else if (rolling)
                {
                    oneh = oned.transform.position.y;
                    twoh = twod.transform.position.y;
                    threeh = threed.transform.position.y;
                    fourh = fourd.transform.position.y;
                    fiveh = fived.transform.position.y;
                    sixh = sixd.transform.position.y;

                    if (oneh > 0.3f)
                    {
                        this.number.GetComponent<Text>().text = "1";
                        dicept = 1;
                    }
                    else if (twoh > 0.3f)
                    {
                        this.number.GetComponent<Text>().text = "2";
                        dicept = 2;
                    }
                    else if (threeh > 0.3f)
                    {
                        this.number.GetComponent<Text>().text = "3";
                        dicept = 3;
                    }
                    else if (fourh > 0.3f)
                    {
                        this.number.GetComponent<Text>().text = "4";
                        dicept = 4;
                    }
                    else if (fiveh > 0.3f)
                    {
                        this.number.GetComponent<Text>().text = "5";
                        dicept = 5;
                    }
                    else if (sixh > 0.3f)
                    {
                        this.number.GetComponent<Text>().text = "6";
                        dicept = 6;
                    }

                    deltime -= Time.deltaTime;
                    this.timer.GetComponent<Text>().text = deltime.ToString("F1");
                    this.commands.GetComponent<Text>().text = "Rolling!!!";

                    if (deltime <= 0.0f)
                    {
                        rolling = false;
                        deltime = 5.0f;
                        if (p1)
                        {
                            p1 = false;
                            p2 = true;
                            p1pt += dicept;
                            p1dice += 1;
                            switch(dicept)
                            {
                                case 1:
                                    GameObject tempdice = Instantiate(blueone) as GameObject;
                                    tempdice.transform.position = new Vector3(-5.626f, 0.191f, 2.42f - (0.8f * p1dice));
                                    break;
                                case 2:
                                    tempdice = Instantiate(bluetwo) as GameObject;
                                    tempdice.transform.position = new Vector3(-5.626f, 0.191f, 2.42f - (0.8f * p1dice));
                                    break;
                                case 3:
                                    tempdice = Instantiate(bluethree) as GameObject;
                                    tempdice.transform.position = new Vector3(-5.626f, 0.191f, 2.42f - (0.8f * p1dice));
                                    break;
                                case 4:
                                    tempdice = Instantiate(bluefour) as GameObject;
                                    tempdice.transform.position = new Vector3(-5.626f, 0.191f, 2.42f - (0.8f * p1dice));
                                    break;
                                case 5:
                                    tempdice = Instantiate(bluefive) as GameObject;
                                    tempdice.transform.position = new Vector3(-5.626f, 0.191f, 2.42f - (0.8f * p1dice));
                                    break;
                                case 6:
                                    tempdice = Instantiate(bluesix) as GameObject;
                                    tempdice.transform.position = new Vector3(-5.626f, 0.191f, 2.42f - (0.8f * p1dice));
                                    break;
                                default:
                                    break;
                            }
                            this.Diceone.GetComponent<Renderer>().enabled = !this.Diceone.GetComponent<Renderer>().enabled;
                            this.Dicetwo.GetComponent<Renderer>().enabled = !this.Dicetwo.GetComponent<Renderer>().enabled;
                        }
                        else
                        {
                            p1 = true;
                            p2 = false;
                            p2pt += dicept;
                            p2dice += 1;
                            switch (dicept)
                            {
                                case 1:
                                    GameObject tempdice = Instantiate(redone) as GameObject;
                                    tempdice.transform.position = new Vector3(5.626f, 0.191f, 2.42f - (0.8f * p2dice));
                                    break;
                                case 2:
                                    tempdice = Instantiate(redtwo) as GameObject;
                                    tempdice.transform.position = new Vector3(5.626f, 0.191f, 2.42f - (0.8f * p2dice));
                                    break;
                                case 3:
                                    tempdice = Instantiate(redthree) as GameObject;
                                    tempdice.transform.position = new Vector3(5.626f, 0.191f, 2.42f - (0.8f * p2dice));
                                    break;
                                case 4:
                                    tempdice = Instantiate(redfour) as GameObject;
                                    tempdice.transform.position = new Vector3(5.626f, 0.191f, 2.42f - (0.8f * p2dice));
                                    break;
                                case 5:
                                    tempdice = Instantiate(redfive) as GameObject;
                                    tempdice.transform.position = new Vector3(5.626f, 0.191f, 2.42f - (0.8f * p2dice));
                                    break;
                                case 6:
                                    tempdice = Instantiate(redsix) as GameObject;
                                    tempdice.transform.position = new Vector3(5.626f, 0.191f, 2.42f - (0.8f * p2dice));
                                    break;
                                default:
                                    break;
                            }
                            this.Diceone.GetComponent<Renderer>().enabled = !this.Diceone.GetComponent<Renderer>().enabled;
                            this.Dicetwo.GetComponent<Renderer>().enabled = !this.Dicetwo.GetComponent<Renderer>().enabled;
                        }

                        this.p1text.GetComponent<Text>().text = p1pt.ToString();
                        this.p2text.GetComponent<Text>().text = p2pt.ToString();

                        this.commands.GetComponent<Text>().text = "Press D and Roll the Dice";
                    }
                }

                if (p1)
                    this.playernum.GetComponent<Text>().text = "Player 1";
                else if (p2)
                    this.playernum.GetComponent<Text>().text = "Player 2";
            }
            else
            {
                if(p1pt > p2pt)
                    this.playernum.GetComponent<Text>().text = "Player 1 Win!";
                else if (p1pt < p2pt)
                    this.playernum.GetComponent<Text>().text = "Player 2 Win!";
                else 
                    this.playernum.GetComponent<Text>().text = "Draw";

                this.p1text.GetComponent<Text>().text = p1pt.ToString();
                this.p2text.GetComponent<Text>().text = p2pt.ToString();
                this.timer.GetComponent<Text>().text = "";
                this.commands.GetComponent<Text>().text = "Game Is Over!";
                this.number.GetComponent<Text>().text = "";
            }
        }
    }
}
