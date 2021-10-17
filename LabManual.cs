using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabManual : MonoBehaviour
{
    [SerializeField]
    GameObject leftPage;
    [SerializeField]
    GameObject displaySpot;
    [SerializeField]
    GameObject buttonPage;
    [SerializeField]
    GameObject button1;
    [SerializeField]
    GameObject button2;
    [SerializeField]
    GameObject button3;
    [SerializeField]
    GameObject textPage;
    [SerializeField]
    GameObject textDisplay;
    [SerializeField]
    GameObject textPgCt;
    [SerializeField]
    Vector3 pagePosition;

    GameObject currentPageType;

    Page currentPage;
    Page parentPage;

    //buttons- button1, button2, button3
    //links -  bt1 link, bt2 link, bt3 link, nextpg, lastpg,

    //test- display, pg_count
    //text_links - nextpg,lastpg,

    //string "none"= "None";


    Page nonePage = new Page();
    Page home = new Page();
    Page tutorialsPg1 = new Page();
    Page tutorialsPg2 = new Page();
    Page tutorialsPg3 = new Page();
    Page rulerPg1 = new Page();
    Page rulerPg2 = new Page();
    Page rulerPg3 = new Page();

    // Start is called before the first frame update
    void Start()
    {

        //
        // Page nonePage = new Page();
        BuildNonePage(nonePage);
        List<string> home_txt = new List<string> { "Welcome to the Lab", "-" };
        List<Page> home_links = new List<Page> { nonePage, nonePage };
        BuildTextPage(home, home_links, home_txt, true);



        List<string> rulerPg1_txt = new List<string> { "This is a Tutorial on how to use the Ruler", "1/3" };
        List<Page> rulerPg1_links = new List<Page> { rulerPg2, tutorialsPg1 };
        BuildTextPage(rulerPg1, rulerPg1_links, rulerPg1_txt, true);

        List<string> rulerPg2_txt = new List<string> { "Just grab onto it, and your sample, and measure like you would in real life.", "2/3" };
        List<Page> rulerPg2_links = new List<Page> { rulerPg3, rulerPg1 };
        BuildTextPage(rulerPg2, rulerPg2_links, rulerPg2_txt, false);

        List<string> rulerPg3_txt = new List<string> { "This ruler is in inches, with a mark every inch", "3/3" };
        List<Page> rulerPg3_links = new List<Page> { nonePage, rulerPg2 };
        BuildTextPage(rulerPg3, rulerPg3_links, rulerPg3_txt, false);

        // //Conductivity
        Page conductivityPg1 = new Page();
        Page conductivityPg2 = new Page();
        Page conductivityPg3 = new Page();
        List<string> conductivityPg1_txt = new List<string> { "The conductivity tester will allow you to check the resistivity of a sample", "1/3" };
        List<Page> conductivityPg1_links = new List<Page> { conductivityPg2, tutorialsPg1 };
        BuildTextPage(conductivityPg1, conductivityPg1_links, conductivityPg1_txt, true);

        List<string> conductivityPg2_txt = new List<string> { "Ohms law is the governing equation (V=IR). V is Voltage, I is Current, and R is Resistance", "2/3" };
        List<Page> conductivityPg2_links = new List<Page> { conductivityPg3, conductivityPg1 };
        BuildTextPage(conductivityPg2, conductivityPg2_links, conductivityPg2_txt, true);

        List<string> conductivityPg3_txt = new List<string> { "When the sample size changes, resistance will change according to the following relationship. R=pL/A, where R is resistance, p is resistivity, L is length, and A is cross sectional area.", "3/3" };
        List<Page> conductivityPg3_links = new List<Page> { nonePage, conductivityPg2 };
        BuildTextPage(conductivityPg3, conductivityPg3_links, conductivityPg3_txt, true);

        // //Tensilt Testing
        Page tensilePg1 = new Page();
        Page tensilePg2 = new Page();
        Page tensilePg3 = new Page();
        Page tensilePg4 = new Page();

        List<string> tensilePg1_txt = new List<string> { "Use the tensile tester to compare the physical properties of materials", "1/3" };
        List<Page> tensilePg1_links = new List<Page> { tensilePg2, tutorialsPg1 };
        BuildTextPage(tensilePg1, tensilePg1_links, tensilePg1_txt, true);

        List<string> tensilePg2_txt = new List<string> { "Check the side of the tensile tester to read the stress v. strain curve for each material", "1/3" };
        List<Page> tensilePg2_links = new List<Page> { tensilePg3, tensilePg1 };
        BuildTextPage(tensilePg2, tensilePg2_links, tensilePg2_txt, true);

        List<string> tensilePg3_txt = new List<string> { "Test one sample at a time, and reset the test station between samples. Place the graphs on a table to keep them organized.", "1/3" };
        List<Page> tensilePg3_links = new List<Page> { tensilePg4, tensilePg2 };
        BuildTextPage(tensilePg3, tensilePg3_links, tensilePg3_txt, true);

        List<string> tensilePg4_txt = new List<string> { "The green button will activate the testing station, while the red button will reset the sample and the testing station, though the stress v. strain graph will remain.", "1/3" };
        List<Page> tensilePg4_links = new List<Page> { nonePage, tensilePg3 };
        BuildTextPage(tensilePg4, tensilePg4_links, tensilePg4_txt, true);

        // //stressStrain
        Page stressStrainPg1 = new Page();
        Page stressStrainPg2 = new Page();
        Page stressStrainPg3 = new Page();
        Page stressStrainPg4 = new Page();

        List<string> stressStrainPg1_txt = new List<string> { "The maximum value on the graph is the samples ultimate tensile strength (UTS).", "1/3" };
        List<Page> stressStrainPg1_links = new List<Page> { stressStrainPg2, tutorialsPg1 };
        BuildTextPage(stressStrainPg1, stressStrainPg1_links, stressStrainPg1_txt, true);


        List<string> stressStrainPg2_txt = new List<string> { "More ductile samples will experience more strain before failure. Brittle samples fail more abruptly, but many brittle samples have a steep slope (Youngs modulus).", "1/3" };
        List<Page> stressStrainPg2_links = new List<Page> { stressStrainPg3, stressStrainPg1 };
        BuildTextPage(stressStrainPg2, stressStrainPg2_links, stressStrainPg2_txt, true);


        List<string> stressStrainPg3_txt = new List<string> { "The toughness of a sample is the area under the curve. Therefore a degree of strength and ductility is required to maximize that area.", "1/3" };
        List<Page> stressStrainPg3_links = new List<Page> { stressStrainPg4, stressStrainPg2 };
        BuildTextPage(stressStrainPg3, stressStrainPg3_links, stressStrainPg3_txt, true);


        List<string> stressStrainPg4_txt = new List<string> { "In this simulation, the graphs are linear for the sake of simplicity, however the slope typically decreases as strain increases when conducting a tensile test.", "1/3" };
        List<Page> stressStrainPg4_links = new List<Page> { nonePage, stressStrainPg3 };
        BuildTextPage(stressStrainPg4, stressStrainPg4_links, stressStrainPg4_txt, true);

        // //stressStrain
        // Page stressStrainPg1 = new Page();
        // List<string> stressStrainPg1_txt = new List<string> { "This is a Tutorial on how to use the stressStrain tester", "1/3" };
        // List<Page> stressStrainPg1_links = new List<Page> { nonePage, tutorialsPg1 };
        // BuildTextPage(stressStrainPg1, stressStrainPg1_links, stressStrainPg1_txt, true);

        // //Heat
        Page heatPg1 = new Page();
        Page heatPg2 = new Page();
        Page heatPg3 = new Page();
        Page heatPg4 = new Page();

        List<string> heatPg1_txt = new List<string> { "It is important to consider how a sample reacts when exposed to various enviornments", "1/3" };
        List<Page> heatPg1_links = new List<Page> { heatPg2, tutorialsPg1 };
        BuildTextPage(heatPg1, heatPg1_links, heatPg1_txt, true);

        List<string> heatPg2_txt = new List<string> { "It is not uncommon for a material to lose strength and increase in ductility in a hot enviornment.", "1/3" };
        List<Page> heatPg2_links = new List<Page> { heatPg3, heatPg1 };
        BuildTextPage(heatPg2, heatPg2_links, heatPg2_txt, true);

        List<string> heatPg3_txt = new List<string> { "Some materials may even experience a phase change if a critical temperature is reached for a sufficient amount of time.", "1/3" };
        List<Page> heatPg3_links = new List<Page> { heatPg4, heatPg2 };
        BuildTextPage(heatPg3, heatPg3_links, heatPg3_txt, true);

        List<string> heatPg4_txt = new List<string> { "Use the tensile tester to check for a loss in material toughness.", "1/3" };
        List<Page> heatPg4_links = new List<Page> { nonePage, heatPg3 };
        BuildTextPage(heatPg4, heatPg4_links, heatPg4_txt, true);

        // //Cold
        Page coldPg1 = new Page();
        Page coldPg2 = new Page();
        Page coldPg3 = new Page();
        Page coldPg4 = new Page();

        List<string> coldPg1_txt = new List<string> { "Low temperatures may also effect a materials physical properties.", "1/3" };
        List<Page> coldPg1_links = new List<Page> { coldPg2, tutorialsPg1 };
        BuildTextPage(coldPg1, coldPg1_links, coldPg1_txt, true);

        List<string> coldPg2_txt = new List<string> { "Some metals experience a Ductile to Brittle (DtB) transition at a sufficiently low temperature, leading to catastrophic failure.", "1/3" };
        List<Page> coldPg2_links = new List<Page> { coldPg3, coldPg1 };
        BuildTextPage(coldPg2, coldPg2_links, coldPg2_txt, true);

        List<string> coldPg3_txt = new List<string> { "This can be checked for through the use of a tensile tester. The DtB transition will drastically reduce toughness.", "1/3" };
        List<Page> coldPg3_links = new List<Page> { coldPg4, coldPg2 };
        BuildTextPage(coldPg3, coldPg3_links, coldPg3_txt, true);

        List<string> coldPg4_txt = new List<string> { "The Charpy tester, to be unlocked later, is a more convenient method of checking for a DtB transition.", "1/3" };
        List<Page> coldPg4_links = new List<Page> { nonePage, coldPg3 };
        BuildTextPage(coldPg4, coldPg4_links, coldPg4_txt, true);

        // //Compression
        Page compressionPg1 = new Page();
        Page compressionPg2 = new Page();
        Page compressionPg3 = new Page();
        Page compressionPg4 = new Page();

        List<string> compressionPg1_txt = new List<string> { "Compression testing is very similar to tensile testing, except the sample is squeezed instead of streched", "1/3" };
        List<Page> compressionPg1_links = new List<Page> { compressionPg2, tutorialsPg1 };
        BuildTextPage(compressionPg1, compressionPg1_links, compressionPg1_txt, true);

        List<string> compressionPg2_txt = new List<string> { "This can be useful for testing the properties of materials which are brittle, such as concrete", "1/3" };
        List<Page> compressionPg2_links = new List<Page> { compressionPg3, compressionPg1 };
        BuildTextPage(compressionPg2, compressionPg2_links, compressionPg2_txt, true);

        List<string> compressionPg3_txt = new List<string> { "Because compression does not propogate the growth of small flaws, like tensile testing does, a more reliable measurement may be gathered for brittle materials", "1/3" };
        List<Page> compressionPg3_links = new List<Page> { compressionPg4, compressionPg2 };
        BuildTextPage(compressionPg3, compressionPg3_links, compressionPg3_txt, true);

        List<string> compressionPg4_txt = new List<string> { "Likewise, brittle materials, such as concrete, are typically deployed to be placed in compression, and require reinforement (Such as rebar) to handle other stresses reliably", "1/3" };
        List<Page> compressionPg4_links = new List<Page> { nonePage, compressionPg3 };
        BuildTextPage(compressionPg4, compressionPg4_links, compressionPg4_txt, true);
        //       List<string> compressionPg1_txt = new List<string>{"This is a Tutorial on how to use the compression tester", "1/3"};
        //       List<Page> compressionPg1_links = new List<Page>{nonePage, tutorialsPg1 };
        //       List<Page> compressionPg1 =  new List<Page>{compressionPg1_txt, compressionPg1_links};
        //
        // //Charpy
        Page charpyPg1 = new Page();
        Page charpyPg2 = new Page();
        Page charpyPg3 = new Page();
        Page charpyPg4 = new Page();
        Page charpyPg5 = new Page();

        List<string> charpyPg1_txt = new List<string> { "The charpy tester is a much quicker and easier way to compare the toughness of samples than using the tensile tester", "1/3" };
        List<Page> charpyPg1_links = new List<Page> { charpyPg2, tutorialsPg1 };
        BuildTextPage(charpyPg1, charpyPg1_links, charpyPg1_txt, true);

        List<string> charpyPg2_txt = new List<string> { "Simply drop the hammer to break the sample, and measure the energy absorbed based on how far the hammer swings after impact.", "1/3" };
        List<Page> charpyPg2_links = new List<Page> { charpyPg3, charpyPg1 };
        BuildTextPage(charpyPg2, charpyPg2_links, charpyPg2_txt, true);

        List<string> charpyPg3_txt = new List<string> { "By impact testing two samples, the toughest sample will allow the hammer to swing the least distance", "1/3" };
        List<Page> charpyPg3_links = new List<Page> { charpyPg4, charpyPg2 };
        BuildTextPage(charpyPg3, charpyPg3_links, charpyPg3_txt, true);

        List<string> charpyPg4_txt = new List<string> { "By impact testing two samples, the toughest sample will allow the hammer to swing the least distance", "1/3" };
        List<Page> charpyPg4_links = new List<Page> { charpyPg5, charpyPg3 };
        BuildTextPage(charpyPg4, charpyPg4_links, charpyPg4_txt, true);

        List<string> charpyPg5_txt = new List<string> { "To operate.. ", "1/3" };
        List<Page> charpyPg5_links = new List<Page> { nonePage, charpyPg4 };
        BuildTextPage(charpyPg5, charpyPg5_links, charpyPg5_txt, true);



        // //XRD
        Page XRDPg1 = new Page();
        Page XRDPg2 = new Page();
        Page XRDPg3 = new Page();
        Page XRDPg4 = new Page();

        List<string> XRDPg1_txt = new List<string> { "The XRD allows us to compare the crystallographic features of materials", "1/3" };
        List<Page> XRDPg1_links = new List<Page> { XRDPg2, tutorialsPg1 };
        BuildTextPage(XRDPg1, XRDPg1_links, XRDPg1_txt, true);

        List<string> XRDPg2_txt = new List<string> { "The sample is placed into the x-ray beam in a powdered form, and the level of diffraction is measured at various angles", "1/3" };
        List<Page> XRDPg2_links = new List<Page> { XRDPg3, XRDPg1 };
        BuildTextPage(XRDPg2, XRDPg2_links, XRDPg2_txt, true);

        List<string> XRDPg3_txt = new List<string> { "Here we will use the XRD to compare samples, and see if they are the same material, however in application one could measure crystal lattice as well as determine the crystal structure of samples by using the spectrum from the XRD.", "1/3" };
        List<Page> XRDPg3_links = new List<Page> { XRDPg4, XRDPg2 };
        BuildTextPage(XRDPg3, XRDPg3_links, XRDPg3_txt, true);

        List<string> XRDPg4_txt = new List<string> { "To operate...", "1/3" };
        List<Page> XRDPg4_links = new List<Page> { nonePage, XRDPg3 };
        BuildTextPage(XRDPg4, XRDPg4_links, XRDPg4_txt, true);

        /// main page
        List<string> tutorialsPg1_txt = new List<string> { "Measuring", "Conductivity", "Tensile Test" };
        List<Page> tutorialsPg1_links = new List<Page> { rulerPg1, conductivityPg1, tensilePg1, tutorialsPg2, home };
        BuildButtonPage(tutorialsPg1, tutorialsPg1_links, tutorialsPg1_txt, true);

        List<string> tutorialsPg2_txt = new List<string> { "Stress-Strain", "Heat", "Cold" };
        List<Page> tutorialsPg2_links = new List<Page> { stressStrainPg1, heatPg1, coldPg1, tutorialsPg3, tutorialsPg1 };

        BuildButtonPage(tutorialsPg2, tutorialsPg2_links, tutorialsPg2_txt, false);

        List<string> tutorialsPg3_txt = new List<string> { "Compression Testing", "Charpy", "XRD" };
        List<Page> tutorialsPg3_links = new List<Page> { compressionPg1, charpyPg1, XRDPg1, nonePage, tutorialsPg2 };
        BuildButtonPage(tutorialsPg3, tutorialsPg3_links, tutorialsPg3_txt, false);




        SetPage(home);
    }
    void BuildButtonPage(Page pg, List<Page> links, List<string> text, bool first)
    {
        PageLinks linker = new PageLinks();
        linker.bt1Link = links[0];
        linker.bt2Link = links[1];
        linker.bt3Link = links[2];
        linker.nextpg = links[3];
        linker.lastpg = links[4];
        PageButtons btn = new PageButtons();
        btn.bt1 = text[0];
        btn.bt2 = text[1];
        btn.bt3 = text[2];
        pg.type = "button";
        pg.links = linker;
        pg.buttons = btn;
        pg.first = first;
    }
    void BuildTextPage(Page pg, List<Page> links, List<string> text, bool first)
    {
        PageLinks linker = new PageLinks();
        linker.nextpg = links[0];
        linker.lastpg = links[1];
        Pagetxt txt = new Pagetxt();
        txt.txt = text[0];
        txt.pgcount = text[1];
        pg.type = "text";
        pg.links = linker;
        pg.txt = txt;
        pg.first = first;
    }
    // Update is called once per frame
    class Page
    {
        public string type;
        public Pagetxt txt;
        public PageLinks links;
        public PageButtons buttons;
        public bool first;
    }
    class Pagetxt
    {
        public string txt;
        public string pgcount;

    }
    class PageLinks
    {
        public Page bt1Link;  //bt1 link, bt2 link, bt3 link, nextpg, lastpg,;
        public Page bt2Link;//test- display, pg_count   //text_links - nextpg,lastpg,
        public Page bt3Link;
        public Page nextpg;
        public Page lastpg;
    }
    class PageButtons
    {
        public string bt1;
        public string bt2;
        public string bt3;
    }

    void BuildNonePage(Page pg)
    {
        pg.type = "none";
    }

    void Update()
    {

    }

    void SetPage(Page page)
    {
        if (page.type == "none")
        {
            Debug.Log("pass");
        }

        else if (page.type == "button") //setting buttonPage
        {
            if (page.first == true)
            {
                parentPage = currentPage;
            }
            currentPage = page;
            currentPageType = buttonPage;
            setButton(button1, page.buttons.bt1);
            setButton(button2, page.buttons.bt2);
            setButton(button3, page.buttons.bt3);


        }

        else if (page.type == "text") //setting textPage
        {
            if (page.first == true)
            {
                parentPage = currentPage;
            }
            currentPage = page;
            currentPageType = buttonPage;
            textDisplay.GetComponent<Text>().text = page.txt.txt;
            textPgCt.GetComponent<Text>().text = page.txt.pgcount;
        }

        UpdatePageDisplay();

    }

    void setButton(GameObject button, string display)
    {
        Debug.Log("called Set Button");
        Debug.Log(button);
        Debug.Log(display);
        button.GetComponent<Text>().text = display;
    }

    void UpdatePageDisplay()
    {
        if (currentPage.type == "text")
        {
            textPage.transform.position = displaySpot.transform.position;
            buttonPage.transform.position += new Vector3(0, -20f, 0);
        }

        else
        {
            buttonPage.transform.position = displaySpot.transform.position;
            textPage.transform.position += new Vector3(0, -20f, 0);

        }
    }

    public void TutorialButton()
    {
        SetPage(tutorialsPg1);
    }
    public void ProgressButton()
    {
        SetPage(nonePage);
    }
    public void Button1()
    {
        SetPage(currentPage.links.bt1Link);

    }
    public void Button2()
    {

        SetPage(currentPage.links.bt2Link);
    }
    public void Button3()
    {

        SetPage(currentPage.links.bt3Link);
    }
    public void NextPage()
    {

        SetPage(currentPage.links.nextpg);
    }

    public void LastPage()
    {
        SetPage(currentPage.links.lastpg);
    }

    public void Backup()
    {
        SetPage(parentPage);
    }
}
