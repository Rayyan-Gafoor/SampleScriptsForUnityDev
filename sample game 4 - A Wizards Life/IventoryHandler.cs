using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using Cinemachine;

public class IventoryHandler : MonoBehaviour
{

    [Header("Inventory UI")]
    public float Open_Close;//close= 0 & open=1;
    public float Open_CloseCraft;
    public GameObject PickUpText;
    [SerializeField] GameObject HandBookUI_Handler;
    [SerializeField] GameObject CraftingUI;
    public GameObject DaisiesP;
    public GameObject LavaWeedP;
    public GameObject WaterP;
    public GameObject CoffeeP;
    public GameObject ChilliP;
    public GameObject PineSapP;
    public GameObject SnowFlakeP;
    public GameObject LotusP;
    public GameObject YetiHairP;
    public GameObject MossP;
    public GameObject GlowBerriesP;
    public GameObject SeedP;
    public GameObject IceFlowerP;
    public GameObject CorspeFlowerP;
   

    [Header("InventoryCount")]
    public Text tempText;
   //Ingredients
    public Text DaisiesCount;
    public Text LavaWeedCount;
    public Text WaterCount;
    public Text CoffeeCount;
    public Text ChilliCount;
    public Text PineSapCount;
    public Text SnowFlakeCount;
    public Text LotusCount;
    public Text YetiHairCount;
    public Text MossCount;
    public Text GlowBerriesCount;
    public Text SeedCount;
    public Text IceFlowerCount;
    public Text CorspeFlowerCount;
    public Text WolfsBaneCount;
    //POTIONS
    public Text SpeedPotionCount;
    public Text ShrinkPotionCount;
    public Text HeatPotionCount;
    public Text MeatPotionCount;
    public Text DigestivePotionCount;
    public Text ColdPotionCount;
    public Text GrowthPotionCount;
    public Text LinguisticsPotionCount;
    //Partciles
    public ParticleSystem Snow1;
    public ParticleSystem Snow2;
    public CinemachineVirtualCamera SnowChange;
    public float SystemTime, SystemSpeed;

    [Header("Crafting")]
    public GameObject Potion;
    public GameObject CraftingItem1;
    public GameObject CraftingItem2;
    public GameObject CraftingItem3;
    public GameObject CraftingItem4;
    public GameObject CraftingItem5;
    public int RequiredItemCount1;
    public int RequiredItemCount2;
    public int RequiredItemCount3;
    public int RequiredItemCount4;
    public int RequiredItemCount5;
    public bool CanCraft = false;
    public bool CanCraftPhase2 = false;


    //Narrative things
    [Header("Fungus")]
    public bool hasWater;
    public bool hasCoffeeBeans;
    public Flowchart SpeedPotion;
    public Flowchart IntroNarrative;
    public Flowchart HeatPotion;
    public Flowchart YuriNarrative;
    public Flowchart ColdPotion;
    public Flowchart MargothNarrative;
    public Flowchart LoseBook;
    public Flowchart OutroNarrative;
    public GameObject TutorialInstruction;
    public int Bookcounter;
    public PlayerController playerController;

    [Header("Camera")]
    public CinemachineVirtualCamera Main;
    public CinemachineFreeLook MainCam;
    //public Camera GiddeonCam;
    public CinemachineVirtualCamera GiddeonCam;
    public CinemachineVirtualCamera YuriCam;
    public CinemachineVirtualCamera MargotCam;

    [Header("Crafting Bar")]
    [SerializeField] GameObject CraftBar;
    [SerializeField] float CraftTime, CraftSpeed;
    [SerializeField] CraftBar craftBar_;

    public bool MenuOpen = true;
    public GameObject PauseMenuUI;
    public bool pausemenuOpen;
    private void Start()
    {
        Snow1.Play();
        Snow2.Pause();
    }
    private void Update()
    {
        #region Display Inventory
        if (Input.GetKeyDown(KeyCode.I) && Open_Close == 0)
        {
            playerController.canPlayerMove = false;
            MainCam.m_YAxis.m_MaxSpeed = 0;
            MainCam.m_XAxis.m_MaxSpeed = 0;
            HandBookUI_Handler.SetActive(true);
            StartCoroutine(OpenOrClose());
            string result = "My Iventory: ";
            
            
        }
        else if (Input.GetKeyDown(KeyCode.I) && Open_Close == 1)
        {
            playerController.canPlayerMove = true;
            MainCam.m_YAxis.m_MaxSpeed = 1.5f;
            MainCam.m_XAxis.m_MaxSpeed = 200;
            StartCoroutine(OpenOrClose());
            HandBookUI_Handler.SetActive(false);
            Bookcounter += 1;
            TutorialInstruction.SetActive(false);
            Debug.Log("It should go away!");
            
            
        }

        #endregion
        #region Display Crafting
        if (Input.GetKeyDown(KeyCode.I) && Open_CloseCraft == 0)
        {
            SpeedPotion.SetBooleanVariable("InventoryBool", true);
            CraftingUI.SetActive(true);
            StartCoroutine(OpenOrCloseCrafting());
            string result = "My Iventory: ";

        }
        else if (Input.GetKeyDown(KeyCode.I) && Open_CloseCraft == 1)
        {
            SpeedPotion.SetBooleanVariable("InventoryBool", false);
            StartCoroutine(OpenOrCloseCrafting());
            CraftingUI.SetActive(false);
            Bookcounter += 1;
            TutorialInstruction.SetActive(false);
            Debug.Log("It should go away!");

            if (Bookcounter == 2)
            {
                SpeedPotion.ExecuteBlock("Prompt");
            }
            else if (Bookcounter >= 4)
            {
                Bookcounter = 4;
            }
            

        }


        #endregion
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausemenuOpen = true;
            PauseMenuUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            /*if (Open_CloseCraft == 0) // craft is not open
            {//Change This to Inventory
                //Application.Quit();
                

            }*/
        }
        #region Narrative
        if (IntroNarrative.GetBooleanVariable("mouseLock") == true) 
        {
            //GiddeonCam.gameObject.SetActive(true);
            
            playerController.canPlayerMove = false;
            MainCam.m_YAxis.m_MaxSpeed = 0;
            MainCam.m_XAxis.m_MaxSpeed = 0;
            Debug.Log("The player shouldn't move!!!");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (YuriNarrative.GetBooleanVariable("YuriCamera") == true)
            {
                MargotCam.gameObject.SetActive(false);
                YuriCam.gameObject.SetActive(false);
                YuriCam.gameObject.SetActive(true);
                MainCam.m_YAxis.m_MaxSpeed = 0;
                MainCam.m_XAxis.m_MaxSpeed = 0;
            }
            if (MargothNarrative.GetBooleanVariable("MargothCamera") == true)
            {
                YuriCam.gameObject.SetActive(false);
                GiddeonCam.gameObject.SetActive(false);
                MargotCam.gameObject.SetActive(true);
                MainCam.m_YAxis.m_MaxSpeed = 0;
                MainCam.m_XAxis.m_MaxSpeed = 0;
            }
            if (IntroNarrative.GetBooleanVariable("GiddeonCamera") == true)
            {
                YuriCam.gameObject.SetActive(false);
                MargotCam.gameObject.SetActive(false);
                GiddeonCam.gameObject.SetActive(true);
                MainCam.m_YAxis.m_MaxSpeed = 0;
                MainCam.m_XAxis.m_MaxSpeed = 0;
            }
            if (OutroNarrative.GetBooleanVariable("GiddeonCamera") == true)
            {
                YuriCam.gameObject.SetActive(false);
                MargotCam.gameObject.SetActive(false);
                GiddeonCam.gameObject.SetActive(true);
                MainCam.m_YAxis.m_MaxSpeed = 0;
                MainCam.m_XAxis.m_MaxSpeed = 0;
            }
        }
        else if (IntroNarrative.GetBooleanVariable("mouseLock") == false && Open_CloseCraft == 0)
        {
            if (pausemenuOpen == false)
            {
                GiddeonCam.gameObject.SetActive(false);
                MargotCam.gameObject.SetActive(false);
                YuriCam.gameObject.SetActive(false);
                Debug.Log("The player  move!!!");
                playerController.canPlayerMove = true;
                MainCam.m_YAxis.m_MaxSpeed = 1.5f;
                MainCam.m_XAxis.m_MaxSpeed = 200;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (pausemenuOpen == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }


        }



        /*if (YuriNarrative.GetBooleanVariable("yuriMouseLock") == true)
        {
            //GiddeonCam.gameObject.SetActive(true);
            Debug.Log("Im Talking to Yuri");
            YuriCam.gameObject.SetActive(true);
            MainCam.m_YAxis.m_MaxSpeed = 0;
            MainCam.m_XAxis.m_MaxSpeed = 0;
            playerController.canPlayerMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (YuriNarrative.GetBooleanVariable("yuriMouseLock") == false && Open_CloseCraft == 0)
        {
            //GiddeonCam.gameObject.SetActive(false);
            YuriCam.gameObject.SetActive(false);
            MainCam.m_YAxis.m_MaxSpeed = 1.5f;
            MainCam.m_XAxis.m_MaxSpeed = 200;
            playerController.canPlayerMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

         if (MargothNarrative.GetBooleanVariable("MargothMouseLock") == true)
        {
            //GiddeonCam.gameObject.SetActive(true);
            MargotCam.gameObject.SetActive(true);
            MainCam.m_YAxis.m_MaxSpeed = 0;
            MainCam.m_XAxis.m_MaxSpeed = 0;
            playerController.canPlayerMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (MargothNarrative.GetBooleanVariable("MargothMouseLock") == false && Open_CloseCraft == 0)
        {
            //GiddeonCam.gameObject.SetActive(false);
            MargotCam.gameObject.SetActive(false);
            MainCam.m_YAxis.m_MaxSpeed = 1.5f;
            MainCam.m_XAxis.m_MaxSpeed = 200;
            playerController.canPlayerMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        else if (LoseBook.GetBooleanVariable("LoseBookMouseLock") == true)
        {
            //GiddeonCam.gameObject.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (LoseBook.GetBooleanVariable("LoseBookMouseLock") == false && Open_CloseCraft == 0)
        {
            //GiddeonCam.gameObject.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }*/



        /*if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Test Success!");
            StartCoroutine(SnowSystem());
            //Debug.Log(WaterCount.text);
            
        }*/
        #endregion
    }
    public void ClosePauseMenu()
    {
        pausemenuOpen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "item")
        {
            
            if (Input.GetKey(KeyCode.E))
            {
                AddItem(other.gameObject);
                Item itemHandler = other.GetComponent<Item>();
                itemHandler.Disable();
            }
            
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            PickUpText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                AddItem(other.gameObject);
                Item itemHandler = other.GetComponent<Item>();
                itemHandler.Disable();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "item" || other.gameObject.tag == null)
        {
            PickUpText.SetActive(false);
        }
    }

    #region Add Item To List 
    public void AddItem(GameObject item)
    {
        //Ingredients
        if(item.name== "Water")
        {
            int ItemCount = 0;
            ItemCount= int.Parse(WaterCount.text);
            ItemCount= ItemCount + 10;
            WaterCount.text = " " + ItemCount;
            StartCoroutine(DisplayItemPickedUp(WaterP));
            if (ItemCount > 0)
            {
                SpeedPotion.SetBooleanVariable("hasWater", true);

                if (SpeedPotion.GetBooleanVariable("hasCoffeeBeans") == false && SpeedPotion.GetBooleanVariable("hasWater") == true)
                {
                    SpeedPotion.ExecuteBlock("Water");
                }

                else if (SpeedPotion.GetBooleanVariable("hasCoffeeBeans") == true && SpeedPotion.GetBooleanVariable("hasWater") == false)
                {
                    SpeedPotion.ExecuteBlock("Water");
                }
                else if (SpeedPotion.GetBooleanVariable("hasCoffeeBeans") == true && SpeedPotion.GetBooleanVariable("hasWater") == true)
                {
                    SpeedPotion.ExecuteBlock("GotIngredients");
                }

                /*HeatPotion.SetBooleanVariable("hasHeatWater", true);
                Debug.Log("Should get water");
                if (HeatPotion.GetBooleanVariable("hasChillies") == false && HeatPotion.GetBooleanVariable("hasHeatWater") == true)
                {
                    HeatPotion.ExecuteBlock("Water");
                }

                else if (HeatPotion.GetBooleanVariable("hasChillies") == true && HeatPotion.GetBooleanVariable("hasHeatWater") == false)
                {
                    HeatPotion.ExecuteBlock("Chillies");
                }
                else if (HeatPotion.GetBooleanVariable("hasChillies") == true && HeatPotion.GetBooleanVariable("hasHeatWater") == true)
                {
                    HeatPotion.ExecuteBlock("GotHeatIngredients");
                }*/

            }

        }
        if (item.name == "CoffeeBean")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(CoffeeCount.text);
            ItemCount++;
            CoffeeCount.text = " " + ItemCount;
            StartCoroutine(DisplayItemPickedUp(CoffeeP));

            if (ItemCount > 0)
            {
                SpeedPotion.SetBooleanVariable("hasCoffeeBeans", true);

                if (SpeedPotion.GetBooleanVariable("hasCoffeeBeans") == false && SpeedPotion.GetBooleanVariable("hasWater") == true)
                {
                    SpeedPotion.ExecuteBlock("CoffeeBean");
                }

                else if (SpeedPotion.GetBooleanVariable("hasCoffeeBeans") == true && SpeedPotion.GetBooleanVariable("hasWater") == false)
                {
                    SpeedPotion.ExecuteBlock("CoffeeBean");
                }
                else if (SpeedPotion.GetBooleanVariable("hasCoffeeBeans") == true && SpeedPotion.GetBooleanVariable("hasWater") == true)
                {
                    SpeedPotion.ExecuteBlock("GotIngredients");
                }
            
            }

        }
        if (item.name == "Chilli")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(ChilliCount.text);
            ItemCount++;
            ChilliCount.text = " " + ItemCount;
            StartCoroutine(DisplayItemPickedUp(ChilliP));
            /*if (ItemCount > 0)
            {
               HeatPotion.SetBooleanVariable("hasChillies", true);
                Debug.Log("Should have chillies");
                if (HeatPotion.GetBooleanVariable("hasChillies") == false && HeatPotion.GetBooleanVariable("hasWater") == true)
                {
                    HeatPotion.ExecuteBlock("Chillies");
                }

                else if (HeatPotion.GetBooleanVariable("hasChillies") == true && HeatPotion.GetBooleanVariable("hasWater") == false)
                {
                    HeatPotion.ExecuteBlock("Chillies");
                }
                else if (HeatPotion.GetBooleanVariable("hasChillies") == true && HeatPotion.GetBooleanVariable("hasWater") == true)
                {
                    HeatPotion.ExecuteBlock("GotHeatIngredients");
                }

            }*/

        }     
        if (item.name == "LavaWeed")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(LavaWeedCount.text);
            ItemCount++;
            LavaWeedCount.text = " " + ItemCount;
            StartCoroutine(DisplayItemPickedUp(LavaWeedP));
        }
        if (item.name == "Daisies")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(DaisiesCount.text);
            ItemCount++;
            DaisiesCount.text = " " + ItemCount;
            StartCoroutine(DisplayItemPickedUp(DaisiesP));
        }      
        if (item.name == "PineSap")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(PineSapCount.text);
            ItemCount++;
            PineSapCount.text = " " + ItemCount;
            StartCoroutine(DisplayItemPickedUp(PineSapP));

        }
        if (item.name == "Snowflake")
        {
            StartCoroutine(SnowSystem());
            int ItemCount = 0;
            ItemCount = int.Parse(SnowFlakeCount.text);
            ItemCount++;
            SnowFlakeCount.text = " " + ItemCount;
            StartCoroutine(DisplayItemPickedUp(SnowFlakeP));
        }
        if (item.name == "Lotus")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(LotusCount.text);
            ItemCount++;
            LotusCount.text = " " + ItemCount;
            StartCoroutine(DisplayItemPickedUp(LotusP));
        }
        if (item.name == "IceFlower")
        {
                int ItemCount = 0;
                ItemCount = int.Parse(IceFlowerCount.text);
                ItemCount++;
                IceFlowerCount.text = " " + ItemCount;
                StartCoroutine(DisplayItemPickedUp(IceFlowerP));

        }
        if (item.name == "YetiHair")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(YetiHairCount.text);
            ItemCount++;
            YetiHairCount.text = " " + ItemCount;
            StartCoroutine(DisplayItemPickedUp(YetiHairP));
        }
        if (item.name == "Seed")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(SeedCount.text);
            ItemCount++;
            SeedCount.text = " " + ItemCount;
            StartCoroutine(DisplayItemPickedUp(SeedP));
        }
        if (item.name == "Moss")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(MossCount.text);
            ItemCount++;
            MossCount.text = " " + ItemCount;
            StartCoroutine(DisplayItemPickedUp(MossP));
        }
        if (item.name == "IceBerries")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(GlowBerriesCount.text);
            ItemCount= ItemCount+3;
            GlowBerriesCount.text = " " + ItemCount;
            StartCoroutine(DisplayItemPickedUp(GlowBerriesP));
        }
        if (item.name == "CorspeFlower")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(CorspeFlowerCount.text);
            ItemCount++;
            CorspeFlowerCount.text = " " + ItemCount;
            StartCoroutine(DisplayItemPickedUp(CorspeFlowerP));

        }

        //Potions
        if (item.name == "HeatPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(HeatPotionCount.text);
            ItemCount++;
            HeatPotionCount.text = " " + ItemCount;
            if (YuriNarrative.GetBooleanVariable("YuriDialogueComplete") == true)
            {
                HeatPotion.ExecuteBlock("GotHeatPotion");
            }


        }
        if (item.name == "SpeedPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(SpeedPotionCount.text);
            ItemCount++;
            SpeedPotionCount.text = " " + ItemCount;
            SpeedPotion.ExecuteBlock("GotSpeedPotion");
            playerController.canPlayerMove = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;

        }
        if (item.name == "ShrinkPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(ShrinkPotionCount.text);
            ItemCount++;
            ShrinkPotionCount.text = " " + ItemCount;

            YuriNarrative.SetBooleanVariable("HasShrinkingPotion", true);
        }
        if (item.name == "MeatPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(MeatPotionCount.text);
            ItemCount++;
            MeatPotionCount.text = " " + ItemCount;

            MargothNarrative.SetBooleanVariable("HasMeatPotion", true);
        }
        if (item.name == "DigestivePotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(DigestivePotionCount.text);
            ItemCount++;
            DigestivePotionCount.text = " " + ItemCount;
        }
        if (item.name == "ColdPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(ColdPotionCount.text);
            ItemCount++;
            ColdPotionCount.text = " " + ItemCount;
        }
        if (item.name == "GrowthPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(GrowthPotionCount.text);
            ItemCount++;
            GrowthPotionCount.text = " " + ItemCount;
        }
        if (item.name == "LinguisticsPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(LinguisticsPotionCount.text);
            ItemCount++;
            LinguisticsPotionCount.text = " " + ItemCount;
        }
    }
    #endregion
    #region Remove Item from List
    public void RemoveItem(GameObject item)
    {//Ingredients
        if (item.name == "Water")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(WaterCount.text);
            ItemCount--;
            WaterCount.text = " " + ItemCount;

        }
        if (item.name == "CoffeeBean")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(CoffeeCount.text);
            ItemCount--;
            CoffeeCount.text = " " + ItemCount;

        }
        if (item.name == "Chilli")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(ChilliCount.text);
            ItemCount--;
            ChilliCount.text = " " + ItemCount;

        }
        if (item.name == "LavaWeed")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(LavaWeedCount.text);
            ItemCount--;
            LavaWeedCount.text = " " + ItemCount;

        }
        if (item.name == "Daisies")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(DaisiesCount.text);
            ItemCount--;
            DaisiesCount.text = " " + ItemCount;

        }
        if (item.name == "PineSap")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(PineSapCount.text);
            ItemCount--;
            PineSapCount.text = " " + ItemCount;


        }
        if (item.name == "Snowflake")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(SnowFlakeCount.text);
            ItemCount--;
            SnowFlakeCount.text = " " + ItemCount;

        }
        if (item.name == "Lotus")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(LotusCount.text);
            ItemCount--;
            LotusCount.text = " " + ItemCount;
        }
        if (item.name == "IceFlower")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(IceFlowerCount.text);
            ItemCount--;
            IceFlowerCount.text = " " + ItemCount;
        }
        if (item.name == "YetiHair")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(YetiHairCount.text);
            ItemCount--;
            YetiHairCount.text = " " + ItemCount;
        }
        if (item.name == "Seed")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(SeedCount.text);
            ItemCount--;
            SeedCount.text = " " + ItemCount;
        }
        if (item.name == "Moss")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(MossCount.text);
            ItemCount--;
            MossCount.text = " " + ItemCount;
        }
        if (item.name == "IceBerries")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(GlowBerriesCount.text);
            ItemCount--;
            GlowBerriesCount.text = " " + ItemCount;
        }
        if (item.name == "CorspeFlower")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(CorspeFlowerCount.text);
            ItemCount--;
            CorspeFlowerCount.text = " " + ItemCount;

        }

        //Potions
        if (item.name == "HeatPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(HeatPotionCount.text);
            ItemCount--;
            HeatPotionCount.text = " " + ItemCount;

        }
        if (item.name == "SpeedPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(SpeedPotionCount.text);
            ItemCount--;
            SpeedPotionCount.text = " " + ItemCount;

        }
        if (item.name == "ShrinkPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(ShrinkPotionCount.text);
            ItemCount--;
            ShrinkPotionCount.text = " " + ItemCount;

        }
        if (item.name == "MeatPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(MeatPotionCount.text);
            ItemCount--;
            MeatPotionCount.text = " " + ItemCount;
        }
        if (item.name == "DigestivePotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(DigestivePotionCount.text);
            ItemCount--;
            DigestivePotionCount.text = " " + ItemCount;
        }
        if (item.name == "ColdPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(ColdPotionCount.text);
            ItemCount--;
            ColdPotionCount.text = " " + ItemCount;
        }
        if (item.name == "GrowthPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(GrowthPotionCount.text);
            ItemCount--;
            GrowthPotionCount.text = " " + ItemCount;
        }
        if (item.name == "LinguisticsPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(LinguisticsPotionCount.text);
            ItemCount--;
            LinguisticsPotionCount.text = " " + ItemCount;
        }
    }
    #endregion
    #region Crafting System
    public void Crafting(GameObject item1, GameObject item2, GameObject item3, GameObject item4, GameObject item5, GameObject Potion, int RequiredCount1, int RequiredCount2, int RequiredCount3, int RequiredCount4, int RequiredCount5)
    {
        int Count1 = 0;
        int Count2 = 0;
        int Count3 = 0;
        int Count4 = 0;
        int Count5 = 0;

        //Text name1;
        // tempText.text = item1.name + "Count";
        //Count1 = int.Parse(tempText.text);
        // tempText.text = item2.name + "Count";
        // Count2 = int.Parse(tempText.text);

        #region item1
        if (item1.name == "Daisies")
        {
            Count1 = int.Parse(DaisiesCount.text);
        }
        else if (item1.name == "Pinesap")
        {
            Count1 = int.Parse(PineSapCount.text);
        }
        else if (item1.name == "WolfsBane")
        {
            Count1 = int.Parse(WolfsBaneCount.text);
        }
        else if (item1.name == "LavaWeed")
        {
            Count1 = int.Parse(LavaWeedCount.text);
        }
        else if (item1.name == "CoffeeBean")
        {
            Count1 = int.Parse(CoffeeCount.text);
        }
        else if (item1.name == "Water")
        {
            Count1 = int.Parse(WaterCount.text);
        }
        else if (item1.name == "Chilli")
        {
            Count1 = int.Parse(ChilliCount.text);
        }
        else if (item1.name == "Snowflake")
        {
            Count1 = int.Parse(SnowFlakeCount.text);
        }
        else if (item1.name == "CorspeFlower")
        {
            Count1 = int.Parse(CorspeFlowerCount.text);
        }
        else if (item1.name == "Lotus")
        {
            Count1 = int.Parse(LotusCount.text);
        }
        else if (item1.name == "IceFlower")
        {
            Count1 = int.Parse(IceFlowerCount.text);
        }
        else if (item1.name == "YetiHair")
        {
            Count1 = int.Parse(YetiHairCount.text);
        }
        else if (item1.name == "Seed")
        {
            Count1 = int.Parse(SeedCount.text);
        }
        else if (item1.name == "Moss")
        {
            Count1 = int.Parse(MossCount.text);
        }
        else if (item1.name == "IceBerries")
        {
            Count1 = int.Parse(GlowBerriesCount.text);
        }
        #endregion
        #region item2
        if (item2.name == "Daisies")
        {
            Count2 = int.Parse(DaisiesCount.text);
        }
        else if (item2.name == "PineSap")
        {
            Count2 = int.Parse(PineSapCount.text);
        }
        else if (item2.name == "WolfsBane")
        {
            Count2 = int.Parse(WolfsBaneCount.text);
        }
        else if (item2.name == "LavaWeed")
        {
            Count2 = int.Parse(LavaWeedCount.text);
        }
        else if (item2.name == "CoffeeBean")
        {
            Count2 = int.Parse(CoffeeCount.text);
        }
        else if (item2.name == "Water")
        {
            Count2 = int.Parse(WaterCount.text);
        }
        else if (item2.name == "Chilli")
        {
            Count2 = int.Parse(ChilliCount.text);
        }
        else if (item2.name == "Snowflake")
        {
            Count2 = int.Parse(SnowFlakeCount.text);
        }
        else if (item2.name == "CorpseFlower")
        {
            Count2 = int.Parse(CorspeFlowerCount.text);
        }
        else if (item2.name == "Lotus")
        {
            Count2 = int.Parse(LotusCount.text);
        }
        else if (item2.name == "IceFlower")
        {
            Count2 = int.Parse(IceFlowerCount.text);
        }
        else if (item2.name == "YetiHair")
        {
            Count2 = int.Parse(YetiHairCount.text);
        }
        else if (item2.name == "Seed")
        {
            Count2 = int.Parse(SeedCount.text);
        }
        else if (item2.name == "Moss")
        {
            Count2 = int.Parse(MossCount.text);
        }
        else if (item2.name == "IceBerries")
        {
            Count2 = int.Parse(GlowBerriesCount.text);
        }
        #endregion  
        #region item3
        if (item3.name == "Daisies")
        {
            Count3 = int.Parse(DaisiesCount.text);
        }
        else if (item3.name == "PineSap")
        {
            Count3 = int.Parse(PineSapCount.text);
        }
        else if (item3.name == "WolfsBane")
        {
            Count3 = int.Parse(WolfsBaneCount.text);
        }
        else if (item3.name == "LavaWeed")
        {
            Count3 = int.Parse(LavaWeedCount.text);
        }
        else if (item3.name == "CoffeeBean")
        {
            Count3 = int.Parse(CoffeeCount.text);
        }
        else if (item3.name == "Water")
        {
            Count3 = int.Parse(WaterCount.text);
        }
        else if (item3.name == "Chilli")
        {
            Count3 = int.Parse(ChilliCount.text);
        }
        else if (item3.name == "Snowflake")
        {
            Count3 = int.Parse(SnowFlakeCount.text);
        }
        else if (item3.name == "CorpseFlower")
        {
            Count3 = int.Parse(CorspeFlowerCount.text);
        }
        else if (item3.name == "Lotus")
        {
            Count3 = int.Parse(LotusCount.text);
        }
        else if (item3.name == "IceFlower")
        {
            Count3 = int.Parse(IceFlowerCount.text);
        }
        else if (item3.name == "YetiHair")
        {
            Count3 = int.Parse(YetiHairCount.text);
        }
        else if (item3.name == "Seed")
        {
            Count3 = int.Parse(SeedCount.text);
        }
        else if (item3.name == "Moss")
        {
            Count3 = int.Parse(MossCount.text);
        }
        else if (item3.name == "IceBerries")
        {
            Count3 = int.Parse(GlowBerriesCount.text);
        }
        #endregion     
        #region item4
        if (item4.name == "Daisies")
        {
            Count4 = int.Parse(DaisiesCount.text);
        }
        else if (item4.name == "PineSap")
        {
            Count4 = int.Parse(PineSapCount.text);
        }
        else if (item4.name == "WolfsBane")
        {
            Count4 = int.Parse(WolfsBaneCount.text);
        }
        else if (item4.name == "LavaWeed")
        {
            Count4 = int.Parse(LavaWeedCount.text);
        }
        else if (item4.name == "CoffeeBean")
        {
            Count4 = int.Parse(CoffeeCount.text);
        }
        else if (item4.name == "Water")
        {
            Count4 = int.Parse(WaterCount.text);
        }
        else if (item4.name == "Chilli")
        {
            Count4 = int.Parse(ChilliCount.text);
        }
        else if (item4.name == "Snowflake")
        {
            Count4 = int.Parse(SnowFlakeCount.text);
        }
        else if (item4.name == "CorspeFlower")
        {
            Count4 = int.Parse(CorspeFlowerCount.text);
        }
        else if (item4.name == "Lotus")
        {
            Count4 = int.Parse(LotusCount.text);
        }
        else if (item4.name == "IceFlower")
        {
            Count4 = int.Parse(IceFlowerCount.text);
        }
        else if (item4.name == "YetiHair")
        {
            Count4 = int.Parse(YetiHairCount.text);
        }
        else if (item4.name == "Seed")
        {
            Count4 = int.Parse(SeedCount.text);
        }
        else if (item4.name == "Moss")
        {
            Count4 = int.Parse(SnowFlakeCount.text);
        }
        else if (item4.name == "IceBerries")
        {
            Count4 = int.Parse(GlowBerriesCount.text);
        }
        #endregion
        #region item5
        if (item5.name == "Daisies")
        {
            Count5 = int.Parse(DaisiesCount.text);
        }
        else if (item5.name == "PineSap")
        {
            Count5 = int.Parse(PineSapCount.text);
        }
        else if (item5.name == "WolfsBane")
        {
            Count5 = int.Parse(WolfsBaneCount.text);
        }
        else if (item5.name == "LavaWeed")
        {
            Count5 = int.Parse(LavaWeedCount.text);
        }
        else if (item5.name == "CoffeeBean")
        {
            Count5 = int.Parse(CoffeeCount.text);
        }
        else if (item5.name == "Water")
        {
            Count5 = int.Parse(WaterCount.text);
        }
        else if (item5.name == "Chilli")
        {
            Count5 = int.Parse(ChilliCount.text);
        }
        else if (item5.name == "Snowflake")
        {
            Count5 = int.Parse(SnowFlakeCount.text);
        }
        else if (item5.name == "CorspeFlower")
        {
            Count5 = int.Parse(CorspeFlowerCount.text);
        }
        else if (item5.name == "Lotus")
        {
            Count5 = int.Parse(LotusCount.text);
        }
        else if (item5.name == "IceFlower")
        {
            Count5 = int.Parse(IceFlowerCount.text);
        }
        else if (item5.name == "YetiHair")
        {
            Count5 = int.Parse(YetiHairCount.text);
        }
        else if (item5.name == "Seed")
        {
            Count5 = int.Parse(SeedCount.text);
        }
        else if (item5.name == "Moss")
        {
            Count5 = int.Parse(SnowFlakeCount.text);
        }
        else if (item5.name == "IceBerries")
        {
            Count5 = int.Parse(GlowBerriesCount.text);
        }
        #endregion


        CheckItemCount(RequiredCount1, RequiredCount2, RequiredCount3, RequiredCount4, RequiredCount5, Count1, Count2, Count3, Count4, Count5);
        if (CanCraft == true)
        {
            StartCoroutine(CraftingBar());
            if (CanCraftPhase2 == true)
            {
                CraftPotion(item1, item2, item3, item4, item5, Potion, RequiredCount1, RequiredCount2, RequiredCount3, RequiredCount4, RequiredCount5);
            }
            //
            
        }
        else if (CanCraft == false)
        {
            Debug.Log("can not Craft");
            Debug.Log(Count1 + " + " + Count2 + " + " + Count3);
        }

    }
    //function Checks if we have enough ingredients to craft 
    void CheckItemCount(int requiredCount1, int requiredCount2, int requiredCount3, int requiredCount4, int requiredCount5, int ItemCount1, int ItemCount2, int ItemCount3, int ItemCount4, int ItemCount5)
    {
        if (ItemCount1 >= requiredCount1 && ItemCount2 >= requiredCount2 && ItemCount3 >= requiredCount3 && ItemCount4 >= requiredCount4 && ItemCount5 >= requiredCount5)
        {
            CanCraft = true;
        }
        else
        {
            CanCraft = false;
        }
    }
    //removes the amount of ingredients to craft and adds the potion we need;
     void CraftPotion(GameObject itemToUse1, GameObject itemToUse2, GameObject itemToUse3, GameObject itemToUse4, GameObject itemToUse5, GameObject PotionToCraft, int obj1, int obj2, int obj3, int obj4, int obj5)
    {
        for (int i = 0; i < obj1; i++)
        {
            RemoveItem(itemToUse1);
        }
        for (int i = 0; i < obj2; i++)
        {
            RemoveItem(itemToUse2);
        }
        for (int i = 0; i < obj3; i++)
        {
            RemoveItem(itemToUse3);
        }
        for (int i = 0; i < obj4; i++)
        {
            RemoveItem(itemToUse4);
        }
        for (int i = 0; i < obj5; i++)
        {
            RemoveItem(itemToUse5);
        }

        AddItem(PotionToCraft);
       
    }
    #endregion
    public void CallCraftSystem()
    {
        Crafting(CraftingItem1, CraftingItem2, CraftingItem3, CraftingItem4, CraftingItem5, Potion, RequiredItemCount1, RequiredItemCount2, RequiredItemCount3, RequiredItemCount4, RequiredItemCount5);
    }
    #region MyRoutines
    IEnumerator OpenOrClose()
    {

        if (Open_Close == 0)
        {
            //Debug.Log("closed");
            Open_Close = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            yield return null;

            //  yield return new WaitForSeconds(2);
        }
        else
        {
            //Debug.Log("Open");
            Open_Close = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            yield return null;
            //yield return new WaitForSeconds(2);
        }

    }
    IEnumerator OpenOrCloseCrafting()
    {

        if (Open_CloseCraft == 0)
        {
            //Debug.Log("closed");
            Open_CloseCraft = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            yield return null;

            //  yield return new WaitForSeconds(2);
        }
        else
        {
            //Debug.Log("Open");
            Open_CloseCraft = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            yield return null;
            //yield return new WaitForSeconds(2);
        }

    }

    #endregion

    IEnumerator DisplayItemPickedUp(GameObject item)
    {
        item.SetActive(true);
        yield return new WaitForSeconds(5);
        item.SetActive(false);
    }

    IEnumerator CraftingBar()
    {
        craftBar_.Cur = 0;
        float i = 0;
        float rate = (1.0f / CraftTime) * CraftSpeed;
        while (i < craftBar_.Max)
        {
            CanCraftPhase2 = false;
            i = i + Time.deltaTime * rate;
            craftBar_.Cur = i;
            
        }
        CanCraftPhase2 = true;
        yield return null;

    }
    IEnumerator SnowSystem()
    {
        SnowChange.gameObject.SetActive(true);
        playerController.canPlayerMove = false;
        MainCam.m_YAxis.m_MaxSpeed = 0;
        MainCam.m_XAxis.m_MaxSpeed = 0;
        float i = 0;
        float rate = (1.0f / SystemTime) * SystemSpeed;
        while (i < 100)
        {
            
            i = i + Time.deltaTime * rate;
            var no = Snow1.noise;
            var em = Snow1.emission;
            var lv = Snow1.limitVelocityOverLifetime;
            var vel = Snow1.velocityOverLifetime;
            yield return new WaitForSeconds(2);
            no.strength = 5f;
            yield return new WaitForSeconds(2);
            //em.SetBurst(0,new ParticleSystem.Burst(2.0f, 100));
            yield return new WaitForSeconds(2);
            lv.dampen = 0.5f;
            AnimationCurve curve = new AnimationCurve();
            curve.AddKey(0.0f, 1.0f);
            curve.AddKey(1.0f, 0.0f);
            lv.limit = new ParticleSystem.MinMaxCurve(0, curve);

            AnimationCurve curve1 = new AnimationCurve();
            curve.AddKey(0.0f, 1.0f);
            curve.AddKey(1.0f, 0.0f);
            vel.x = new ParticleSystem.MinMaxCurve(10.0f, curve1);
            vel.y = new ParticleSystem.MinMaxCurve(10.0f, curve1);
            vel.z = new ParticleSystem.MinMaxCurve(10.0f, curve1);

            yield return new WaitForSeconds(2);
            Snow2.Play();
            Snow1.Stop();
            yield return new WaitForSeconds(5);
            SnowChange.gameObject.SetActive(false);
            //Snow1.Stop();
            yield return new WaitForSeconds(3);
            MainCam.m_YAxis.m_MaxSpeed = 1.5f;
            MainCam.m_XAxis.m_MaxSpeed = 200;
            playerController.canPlayerMove = true;
            Debug.Log("end of Sytem");
        }
        
        
        //yield return null;

    }
}

