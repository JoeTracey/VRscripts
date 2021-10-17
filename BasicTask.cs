using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicTask : MonoBehaviour
{
  [SerializeField]
  GameObject userDisplay;
  [SerializeField]
  GameObject gameDisplay;
  [SerializeField]
  GameObject unitDisplay;
  [SerializeField]
  SampleManager sampleManager;
  [SerializeField]
  Bank bank;

  int loc = 0;
  int c_loc = 0;
  int comp_loc = 0;
  int t_loc = 0;
  int cvn_loc = 0;
  int xrd_loc = 0;

  int q_type = 0; //0=main, 1=cond, 2=tensile,

  List<string> questions = new List<string>();
  List<float> answers = new List<float>();
  List<string> units = new List<string>();
  List<float> values = new List<float>(); //how many points

  List<string> c_questions = new List<string>();
  List<float> c_answers = new List<float>();
  List<string> c_units = new List<string>();
  List<float> c_values = new List<float>(); //how many points

  List<string> t_questions = new List<string>();
  List<float> t_answers = new List<float>();
  List<string> t_units = new List<string>();
  List<float> t_values = new List<float>(); //how many points

  List<string> l_questions = new List<string>();
  List<float> l_answers = new List<float>();
  List<string> l_units = new List<string>();
  List<float> l_values = new List<float>(); //how many points

  List<string> f_questions = new List<string>();
  List<float> f_answers = new List<float>();
  List<string> f_units = new List<string>();
  List<float> f_values = new List<float>(); //how many points

  List<string> comp_questions = new List<string>();
  List<float> comp_answers = new List<float>();
  List<string> comp_units = new List<string>();
  List<float> comp_values = new List<float>(); //how many points

  List<string> cvn_questions = new List<string>();
  List<float> cvn_answers = new List<float>();
  List<string> cvn_units = new List<string>();
  List<float> cvn_values = new List<float>(); //how many points

  List<string> xrd_questions = new List<string>();
  List<float> xrd_answers = new List<float>();
  List<string> xrd_units = new List<string>();
  List<float> xrd_values = new List<float>(); //how many points

  List<float> subs = new List<float>();

  string cont1 = "";
  string cont2 = "";

  string qNow = "";
  string uNow= "";
  float aNow= 0.0f;
  float vNow = 0f;

  string q0 = "You need to buy a Scale so we can get started. Type in '0' and then hit enter ('-->') to get the appropriate funding";
  float a0 = 0f;
  string u0 = "N/A";
  float v0 = 20f;

    string q0pt1 = "Now run to the store, down the hallway, and purchase a scale.";
    float a0pt1 = 4321f;
    string u0pt1= "N/A";
    float v0pt1 = 0f;

  string q1 = "Very good! \n Now, use the scale to find and enter the Mass of the white sample. The Samples are behind you, on the other side of the lab. You can pick it up and weigh it on the scale, sitting on the red table";
  float a1= 12.54f;
  string u1 = "g";
  float v1= 20f;

  string q2 = "Now how long is it? There is a ruler next to the scale. There is a reset button next to the sample table, in case you drop it.";
  float a2= 5.7f;
  string u2 = "in";
    float v2= 35f;

  string q3 = "And how wide? (the width and thickness of this sample are equal)";
  float a3 = 1.55f;
  string u3 = "in";
    float v3= 20f;

  string q4 = "Now use the width to find the area of the sample. (width^2)";
  float a4 = 1.55f* 1.5f;
  string u4 = "in^2";
    float v4= 35f;


  string q5 = "I suppose we can use all of that to find the volume too. \n Thats Length*Width*Height!";
  float a5 = 14f;
  string u5 = "in^3";
    float v5= 45f;

  string q6 = "Fantastic! Now lets start doing some science. We'll start simple with some conductivity testing. Go ahead and use what you've earned to buy your first testing station: \nThe Conductivity Tester!";
  float a6 = 4321f;
  string u6 = " ";
  float v6= 0f;

  string q6pt1 = " What is the Potential (Voltage) for your machine? This is labeled on the conductivity tester.";
  float a6pt1 = 110f;
  string u6pt1 = "V";
  float v6pt1= 20f;

  string q7 = "Good, that's going to be a fixed value for your model, so we can use it to calculate the resistance of our samples. \n What is the current running through the machines probes right now?";
  float a7 = 0f;
  string u7 = "Amps";
  float v7= 20f;

  string q8 = "Yes! 0 Amps. That means there is infinite resistance between the probes, and no electricity is flowing. \n How much current flows through when our sample is placed in the tester? ";
  float a8 = 1100f;
  string u8 = "Amps";
  float v8= 20f;

  string q9 = "Great! You can relate the resistance and voltage to current by using the equation V=I*R, or\n   (Voltage/Current)=Resistance. \n What is this samples resistance?  \n 'You might want to use the calculator to your right!' ";
  float a9 = 0.1f;
  string u9 = "Ohms";
  float v9= 20f;


  string q10 = "One last thing! If you forget anything you can read your manual for instructions. \n Use yours to find out what year Ohm's law was established by.";
  float a10 = 1827f;
  string u10 = "AD";
  float v10= 20f;

  string q11 = "Alright, looks like you know what you're doing here. Time for your first contract. \n Hit the blue contract button and complete some contracts until you earn some funding and an access code. If youve completed enough contracts the code will be in your journal under 'Progress->Access Codes'";
  float a11 = 3.14f;
  string u11 = "#";
  float v11= 20f;

  string q12 = "Congratulations, you are really getting a lot done for the lab. It's time we trained you on how to use the tensile tester, it's harder to use than the conductivity tester, but you can use it to gain a lot of useful information. \n Go ahead an buy one. Input the tensile tester's maximum force";
  float a12 = 2000000f;
  string u12 = "lbs";
  float v12= 20f;

  string q13 = "Great, you may have also noticed that the store has gotten a little nicer now that you've invested into your lab so much. You can now upgrade your equipment, grab an upgrade for the the scale to get a more presise model. Punch in it's model number.";
  float a13 = 2.12f;
  string u13 = "#";
  float v13= 20f;

  string q14 = "So that one was mostly cosmetic, but upgrades can give your test stations important new features, or increase their capacity. Notice the tensile sample is shaped differently. Find the area of a sample at the thinnest point";
  float a14 = 1.0f;
  string u14 = "in^2";
  float v14= 20f;

  string q14pt1 = "Good. Since your tensile tester maxes out at 2,000,000 Pounds of pressure, you can check the maximum stress that it can output onto a sample, since Stress=Force/Area. \n The tensile samples are all the same size.";
  float a14pt1 = 2000000f;
  string u14pt1 = "psi";
  float v14pt1= 20f;


  string q15 = "Okay, lets figure out how much stress that this sample can take. Toss it in the tensile tester and hit the green button to run it. A graph will come out, and you need to find the highest value that the stress hits.";
  float a15 = 4500f;
  string u15 = "psi";
  float v15= 20f;

  string q16 = "That is the Ultimate Tensile Strength ('UTS'). The maximum strength of the sample. Take Sample-2 and check it's UTS";
  float a16 = 4500;
  string u16 = "psi";
  float v16= 20f;

  string q17 = "Hmmm, both samples have the same Ultimate Tensile Strength, but Sample-2 broke in a brittle manner, which means it shattered. The first sample was ductile and stretched during failure. \n Which sample failed more suddenly? 1 or 2?";
  float a17 = 2f;
  string u17 = "#";
  float v17= 20f;

  string q18 = "Yes, brittle failures happen more suddenly, and can therefore be more dangerous since they are harder to predict. Keep this in mind, and complete some contracts until you can afford some liquid nitrogen. If you already have the liquid nitrogen, then enter the next acess code from your notebook's progress section.";
  float a18 = 112358f;
  string u18 = "#";
  float v18= 20f;

  string q19 = "Now that you have liquid nitrogen, it's time to learn about a new concept, the Ductile to Brittle Transition. Some materials become brittle below a certain temperature. For example, classify the ductility of this foam at room temperature. Ductile(0) or Brittle(1)?";
  float a19 = 0;
  string u19 = "#";
  float v19= 20f;

  string q19pt1 = "Now freeze the foam in liquid nitrogen and classify the ductility again. Ductile(0) or Brittle(1)?";
  float a19pt1 = 1;
  string u19pt1 = "#";
  float v19pt1= 20f;


  string q19pt2 = "Not all samples experience a ductile to brittle transition. Take these steel (sample-1) and copper (sample-2) blocks and see which experiences a ductile to brittle transition when cold. Sample 1 or 2?";
  float a19pt2 = 1;
  string u19pt2 = "#";
  float v19pt2= 20f;


  string q20 = "For some tasks, the ductile to brittle transition can be vital to keep in mind, especially when working in cold conditions. Check which of these three alloys would be better for building a ship in the arctic, considering strength and avoiding brittle failure at operating temperature.";
  float a20 = 3f;
  string u20 = "#";
  float v20= 20f;


  string q21 = "Go ahead and complete contracts until you save up for a furnace, then enter the furnace access code";
  float a21 = 42f;
  string u21 = "#";
  float v21= 20f;


  string q22 = "Some materials actually lose their strength due to an increase in temperature. What is the UTS of this plastic block at room temperature?";
  float a22 = 2000f;
  string u22 = "psi";
  float v22= 20f;


  string q23 = "Now go ahead and heat it up in the furnace. It is vital that you do not touch the hot material with your hand, so equip gloves. Once it's warm, find the new UTS";
  float a23 = 400f;
  string u23 = "psi";
  float v23= 20f;


  string q24 = "Determine the best of these three samples to operate at both room and elevated temperatures";
  float a24 = 3f;
  string u24 = "#";
  float v24= 20f;


  string q25 = "All enviornments that a part will be exposed to must be considered. Find the sample which remains ductile when cold, but strong when hot";
  float a25 = 2f;
  string u25 = "#";
  float v25= 20f;


  string q26 = "Go ahead and complete contracts until you save up for a compression tester. When you get one, enter the maximum force of your compression tester";
  float a26 = 2000000f;
  string u26 = "psi";
  float v26= 20f;


  string q27 = "Before you use the compression tester you will need to find the area of the sample. What is the area of a round concrete compression sample. For a circle A=pi*r^2, or Area= 3.14*radius*radius";
  float a27 = 22.2f;
  string u27 = "in^2";
  float v27= 20f;


  string q28 = "With the surface area of our sample being about 22.2in^2, with a maximum force of 2,000,000 psi, we can find the maximum stress that we can output \n  (Stress=Force/Area)";
  float a28 = 90090f;
  string u28 = "AD";
  float v28= 20f;


  string q29 = "The compression tester is useful for testing the strength of brittle ceramics, like concrete, which are stronger in compression. Use the Tensile Tester to find the UTS of this sample";
  float a29 = 980f;
  string u29 = "psi";
  float v29= 20f;


  string q30 = "Now use the compression tester to find the Ultimate Compressive Stress of the cylindrical concrete sample";
  float a30 = 28000f;
  string u30 = "psi";
  float v30= 20f;


  string q31 = "Yet both are the same material. This would imply that the concrete is stronger in \n \n 1- Compression \n 2- Tension \n 3- Both are equal";
  float a31 = 1f;
  string u31 = "#";
  float v31= 20f;


  string q32 = "Correct, the concrete is stronger in compression. As a Brittle ceramic, small defects in the surface can concentrate stress and cause premature failure in tension. Note, not all compression samples are brittle. Choose the compression sample with the greatest toughness";
  float a32 = 0f;
  string u32 = "#";
  float v32= 20f;

  string q33 = "Go ahead and complete contracts until you save up for a Charpy Impact Tester. What mass is being used on the impact tester";
  float a33 = 150f;
  string u33 = "lbs";
  float v33= 20f;


  string q34 = "The charpy test station is great for comparing the toughness of samples. Toughness is a combination of strength and ductility. If a sample is too brittle, it will not have time to absorb much energy. Which of these two samples is tougher?";
  float a34 = 2f;
  string u34 = "#";
  float v34= 20f;


  string q35 = "The Charpy test can be used to quickly check for a ductile to brittle transition. Check if this iron-carbon alloy experiences a ductile to brittle transition. Do this by freezing one, and testing both. A large decrease in energy absorbed indicats a transition took place. Is it present?  Yes(1) No(0)";
  float a35 = 1;
  string u35 = "#";
  float v35= 20f;


  string q36 = "The final test station you will learn to use is the X-Ray Dispersive Spectroscopy, or XRD. Complete contracts to save up for one, then puch in your XRD access code";
  float a36 = 2319f;
  string u36 = "#";
  float v36= 20f;


  string q37 = "One simple use for the XRD is to check the crystal structure of a material. If these two samples have the same XRD, then they are of the same phase. Check are Samples 1 and 2 the same phase? Yes(1) No(0)";
  float a37 = 0f;
  string u37 = "#";
  float v37= 20f;


  string q38 = "How about these two samples? Yes(1) No(0)";
  float a38 = 1f;
  string u38 = "#";
  float v38= 20f;


  string q39 = "Finally, is Sample-3 aluminum or tin? \n  Use these known samples to find out. \n Aluminum(1) Tin(2): Check the XRD";
  float a39 = 1f;
  string u39 = "#";
  float v39= 20f;


  string q40 = "You can also use the XRD to check for residual stresses. Stresses will shift the XRD peaks to the side. One of these three samples has been deformed and is in residual compressive stress, which one?";
  float a40 = 3f;
  string u40 = "#";
  float v40= 20f;


  string q41 = "Congratulations! You have learned to use all of the test stations. Keep completing tasks to upgrade your lab further. Save up 100,000$ to retire";
  float a41 = 1827f;
  string u41 = "$$$$$$$$";
  float v41= 20f;

//start conductivity testing code

  string c_q0 = "Measure the resistance of the given sample.a";
  float c_a0 = 0.3f;
  string c_u0 = "Ohms";
  float c_v0= 20f;

  string c_q1 = "An engineering firm is looking to change their wiring material in an attempt to maximize conductivity. Should they use their original material (sample-1), or the new material (sample-2)";
  float c_a1 = 1f;
  string c_u1 = "AD";
  float c_v1= 20f;

  string c_q2 = "A toy company wants to use their 3D printer to print insulated blocks for their circuit. Which of the printing samples has a higher resistance to electrical flow? ";
  float c_a2 = 2;
  string c_u2 = "AD";
  float c_v2= 30f;

  string c_q3 = "Since the circuit will need to be insulated with 10,000 ohms of resistance, how thick must the printed walls be around the wiring mount given a contact patch of 2.56 in^2? (2.56in^2 is the area of the sample, and we know the resistance per 5.6inches of length) ";
  float c_a3 = 3.73f;
  string c_u3 = "in";
  float c_v3= 30f;

  string c_q4 = "Given the assortent of the following 5 samples, which is the best conductor?";
  float c_a4 = 3f;
  string c_u4 = "";
  float c_v4= 20f;

  string c_q5 = "And the best insulator? Insulators resist conducting electricity";
  float c_a5 = 1f;
  string c_u5 = "";
  float c_v5= 20f;

  string c_q6 = "How many of our best conductor samples (sample-3) would one need to be lined up to create the same resistance as the best insulating sample (sample-1)";
  float c_a6 = 40740700f;
  string c_u6 = "ft";
  float c_v6= 50f;

  string c_q7 = "The green pasture electric fence company is trying to build electric fences. They are looking for the material with the highest conductivity. Recommend a sample";
  float c_a7 = 3f;
  string c_u7 = "";
  float c_v7= 20f;

  string c_q8 = "The Orchard Acre horse farm is looking to build an electric fence as well, but wants the cheapest material that will allow them to run 50V across 410 ft of fencing at a current of at least 0.1 Amp. What is the maximum total resistance the wire may have? (V=I*R)";
  float c_a8 = 500f;
  string c_u8 = "ohms";
  float c_v8= 40f;

  string c_q9 = "Yes 500 ohms.At 410ft, how many ohms per feet is this?";
  float c_a9 = 1.22f;
  string c_u9 = "";
  float c_v9= 40f;

  string c_q10 = "Yup, 1.22 ohm per feet. They dont want the wire to be more than 0.1 in^2 in area. Given our sample's area of 2.56 in^2 and length of 5.6 in, what is it's maximum resistance our conductivity sample may have? \n 'Whatch your units'";
  float c_a10 = 0.226f;
  string c_u10 = "";
  float c_v10= 20f;


  string c_q10pt1 = "Which is the cheapest sample for the job, with less than 0.226 ohms of resistance?";
  float c_a10pt1 = 1f;
  string c_u10pt1 = "";
  float c_v10pt1= 20f;

  string c_q11 = "Which is the most suitable sample for a fence running 110V? Here higher resistance is acceptable, remember that 50V was accomplished with an 0.226 ohm maximum for the sample";
  float c_a11 = 1f;
  string c_u11 = "";
  float c_v11= 20f;

  string c_q12 = "Choose the material of highest conductivity for a telephone line";
  float c_a12= 2f;
  string c_u12 = "";
  float c_v12= 20f;

  string c_q13 = "since the wire will need to be 46.67 ft (560in), with a voltage of 110V and a minimum current of 1000Amps, what is the minimum wire thickness?";
  float c_a13 = 0.419f;
  string c_u13 = "in^2";
  float c_v13= 20f;

  string c_q14 = "Great Job! You've really mastered the conductivity station!";
  float c_a14 = 2894294446662841f;
  string c_u14 = "";
  float c_v14= 20f;

  // Tensile test c_questions

    string t_q0 = "find the Ultimate Tensile stress of the given sample";
    float t_a0 = 1827f;
    string t_u0 = "lb/in^2";
    float t_v0= 20f;

    string t_q1 = "A car company is trying to choose a steel manufacturer based on their ability to create a strong frame material. Which is the strongest, while remaining ductile? If the metal is not ductile, then the cars frame will not be able to absorb imact energy.";
    float t_a1 = 1827f;
    string t_u1 = "";
    float t_v1= 20f;

    string t_q2 = "And which of the materials is overall strongest?";
    float t_a2 = 1827f;
    string t_u2 = "";
    float t_v2= 20f;

    string t_q3 = "An aerospace company is choosing manufacturers for their turbines. Which of these samples has the greatest specific strength (UTS per weight)";
    float t_a3 = 1827f;
    string t_u3 = "";
    float t_v3= 20f;

    string t_q4 = "What surface area of this strong sample must be used to prevent failure under 25,000 lbs of stress";
    float t_a4 = 1827f;
    string t_u4 = "in^2";
    float t_v4= 20f;

    string t_q5 = "A cable company has come to you with a contract for chooing a suitable wiring metal. The material must be ductile, conductive, and strong enough to support 45lb of stress on only 0.8 in^2. Choose the best of these five samples.";
    float t_a5 = 1827f;
    string t_u5 = "lb/in^2";
    float t_v5= 20f;

    string t_q6 = "Given the cost of the samples, per foot of wire, which is the cheapest that will work for the job?";
    float t_a6 = 1827f;
    string t_u6 = "lb/in^2";
    float t_v6= 20f;

    // string t_q7 = "A cable company has come to you with a contract for chooing a suitable wiring metal. The material must be ductile, conductive, and strong enough to support 45lb of stress on only 0.8 in^2. Choose the most conductive sample, which is strong enough for the job.";
    // float t_a7 = 1827f;
    // string t_u7 = "lb/in^2";
    // float t_v7= 20f;

    string t_q8 = "A toy company is making a stretchy man. Which of these materials has the highest ductility?";
    float t_a8 = 1827f;
    string t_u8 = "lb/in^2";
    float t_v8= 20f;

    string t_q9 = "Since most kids can exert about 50 lbs of force with their hands, which material will be strong enough for stretchy-man, with arms about 1/4 in in diameter, while still maximizing ductility?";
    float t_a9 = 1827f;
    string t_u9 = "lb/in^2";
    float t_v9= 20f;

    string t_q10 = "A small electronics company is looking for a hard material with low conductivity for their plastics. Find a sample that minimizes ductility and conductivity while maximizing strength.";
    float t_a10 = 1827f;
    string t_u10 = "lb/in^2";
    float t_v10= 20f;

    //Liquid nitrogen

    string l_q0 = "An audio company is having clients tell them that their headphones are failing suddely this February. These product were released this summer, but are only now breaking. Test the metal wiring for Ductile to Brittle Transition. Yes (1), No (0)";
    float l_a0 = 0f;
    string l_u0 = "N/A";
    float l_v0 = 10f;

    string l_q1 = "Hmm, Strange. Lets test the casing plastic. Is a transition present? Yes(1), No(2)";
    float l_a1 = 1f;
    string l_u1 = "N/A";
    float l_v1 = 10f;

    string l_q2 = "The corrosion from leaky plastic could be causing failure due to increased impedence (resistance). The wires used had a redundency of 3 times the current required to feed a clean signal to the headphones. Will the corroded samples resistance allow at least a third of the current through the wire? Yes (1), No (0)";
    float l_a2 = 1f;
    string l_u2 = "N/A";
    float l_v2 = 0f;

    string l_q3 = "Well then, perhaps the  corrosion allowed the wires to break. Is the corroded version of the metal significantly weaker than the wire? Yes(1), No(2)";
    float l_a3 = 0f;
    string l_u3 = "N/A";
    float l_v3 = 0f;

    string l_q4 = "This one is quite tricky... Does this corroded phase of the metal metal experience a ductile to brittle transition? Yes(1), No(2)";
    float l_a4 = 1f;
    string l_u4 = "N/A";
    float l_v4 = 0f;

    string l_q4pt1 = "Bingo! That was a good failure analysis. Now choose the best plastic for the job. It must remain ductile at low temperatures, to prevent this corrosion.";
    float l_a4pt1 = 0f;
    string l_u4pt1 = "N/A";
    float l_v4pt1 = 0f;

    string l_q5 = "An axe company wants a strong steel for their axes, but they must not shatter. Choose their best axe for the cold enviornment of Northern Canada.";
    float l_a5 = 0f;
    string l_u5 = "N/A";
    float l_v5 = 0f;

    string l_q6 = "Now select the best metal for their Panamanian axe line. This one wont be exposed to low operating temperatures";
    float l_a6 = 0f;
    string l_u6 = "N/A";
    float l_v6 = 0f;

    string l_q7 = "What is the toughness of the Panamanian axe metal at room temperature. Toughness is the area under the curve before fracture. Here we will use (strain*UTS)/2, as the materials fracture at UTS and forms a triangle.";
    float l_a7 = 0f;
    string l_u7 = "N/A";
    float l_v7 = 0f;

    string l_q8 = "What is the toughness of the Panamanian axe at low temperature?";
    float l_a8 = 0f;
    string l_u8 = "N/A";
    float l_v8 = 0f;

    string l_q9 = "Therefore, what is the percent of toughness lost due to temperature?";
    float l_a9 = 0f;
    string l_u9 = "N/A";
    float l_v9 = 0f;

    string l_q10 = "What is the percent toughness lost due to temperature transition in the canadian targeted line?";
    float l_a10 = 0f;
    string l_u10 = "N/A";
    float l_v10 = 0f;

    string l_q11 = "Finally the client wants to know how many times tougher their warm climate axe will be. Compare the toughness of the canadian axe at cold operating temperature to the Panamanian line at it's operating temperature (room temp). Divide the strength of the Panamanian axe metal by the strength of the Canadian metal";
    float l_a11 = 0f;
    string l_u11 = "times";
    float l_v11 = 0f;

    //High temperature
    string f_q0 = "Check the plastic sample to see what percent of it's Ultimate Tensile Strength it retains at high temperatures. That is 'Hot UTS'/'Room UTS'. ";
    float f_a0 = 0f;
    string f_u0 = "N/A";
    float f_v0 = 0f;

    string f_q1 = "A Tire company wants to ensure their tires will work over a wide range of temperatures. Test their experimental compounds to see which sample has the greatest UTS at room temperature of the range of samples.";
    float f_a1 = 0f;
    string f_u1 = "N/A";
    float f_v1 = 0f;

    string f_q2 = "Good to know, but we must also consider which sample has the highest minimum toughness across the high, medium, and low temperatures.";
    float f_a2 = 0f;
    string f_u2 = "N/A";
    float f_v2 = 0f;

    string f_q3 = "Which of the samples would you recommend the company use for their Desert series of tires.";
    float f_a3 = 0f;
    string f_u3 = "N/A";
    float f_v3 = 0f;

    string f_q4 = "Recommend a compound for their arctic tundra series of tires as well";
    float f_a4 = 0f;
    string f_u4 = "N/A";
    float f_v4 = 0f;

    string f_q5 = "A new aerospace manufacturer is using a composite material for their break pad. They need to figure out why it is failing when used on their faster landing planes. How many components are losing their strength at high temperature? ";
    float f_a5 = 2f; //also use carbon as an option
    string f_u5 = "N/A";
    float f_v5 = 0f;

    string f_q6 = "Hmm. What is the percent tensile toughness decrease in the ceramic due to temperature increase?";
    float f_a6 = 0f;
    string f_u6 = "N/A";
    float f_v6 = 0f;

    string f_q7 = "And what is the percent tensile toughness decrease in the metal due to temperature increase? ";
    float f_a7 = 0f;
    string f_u7 = "N/A";
    float f_v7 = 0f;

    string f_q8 = "Reccomend a tough ceramic that will last at high temperatures. Aim to maximize UTS";
    float f_a8 = 0f;
    string f_u8 = "N/A";
    float f_v8 = 0f;
    //compression
    string comp_q0 = "Use the compression tester to find the best sample for a concrete. The company is only interested in compressive strength for the sample.";
    float comp_a0 = 0f;
    string comp_u0 = "N/A";
    float comp_v0 = 0f;

    string comp_q1 = "A masonry company is reaching out in an attempt to choose some materials for a foundation with arch ways. Start out by choosing the material with the best mixture of compressive and tensile strength.";
    float comp_a1 = 0f; //steel
    string comp_u1 = "N/A";
    float comp_v1 = 0f;

    string comp_q2 = "That is a good start, but if they are only making foundations, perhaps we can improve their cost efficiency by creating a cheap composite instead of using one material. Start with a matrix! We need something with very high compressive strength, it is okay if it is not too ductile. We can work around that";
    float comp_a2 = 0f;
    string comp_u2 = "N/A";
    float comp_v2 = 0f;

    string comp_q3 = "Great, they can pour concrete for only a fraction of the cost. However, it's brittle nature causes it to fail suddenly under tensile stresses. We should choose a reinforcement material. Choose something that is ductile but can handle a tensile load.";
    float comp_a3 = 0f;
    string comp_u3 = "N/A";
    float comp_v3 = 0f;

    string comp_q4 = "Great! What is the compression strength of the concrete alone if a 1-ft by 1-ft sample were to be used?";
    float comp_a4 = 0f;
    string comp_u4 = "N/A";
    float comp_v4 = 0f;

    string comp_q5 = "And what is the rebars compression strength?";
    float comp_a5 = 0f;
    string comp_u5 = "N/A";
    float comp_v5 = 0f;

    string comp_q6 = "Now if rebar is placed in the concrete, taking up 10% of it's surface area, what will the total compressive strength be? (Hint, 90% of a full concrete plus 10% of full rebar strength)";
    float comp_a6 = 0f;
    string comp_u6 = "N/A";
    float comp_v6 = 0f;

    string comp_q7 = "Interesting. So the sample will be a little weaker than the concrete, but the rebar will actually increase it's toughness as well";
    float comp_a7 = 0f;
    string comp_u7 = "N/A";
    float comp_v7 = 0f;

    string comp_q8 = "Use the tensile tester to find tensile strength of a 1-ft by 1-ft concrete sample";
    float comp_a8 = 0f;
    string comp_u8 = "N/A";
    float comp_v8 = 0f;

    string comp_q9 = "And the strength if the sample is made of rebar?";
    float comp_a9 = 0f;
    string comp_u9 = "N/A";
    float comp_v9 = 0f;

    string comp_q10 = "Use these two value to find the tensile strength of the sample if 10% rebar is used?";
    float comp_a10 = 0f;
    string comp_u10 = "N/A";
    float comp_v10 = 0f;

    string comp_q11= "There we go. This is a significant increase from the lone concrete, plus the concrete will retain shape after suffering damage. The XRD testing will teach you more about this.";
    float comp_a11 = 0f;
    string comp_u11 = "N/A";
    float comp_v11 = 0f;

    //charpy

    string cvn_q0 = "Test this batch of ceramics to see if any samples have flaws. As a start, what is the CVN-toughness of the baseline sample";
    float cvn_a0 = 0f;
    string cvn_u0 = "N/A";
    float cvn_v0 = 0f;

    string cvn_q1 = "Now test batches 2,3,4 for toughness and pick out the weakest sample.";
    float cvn_a1 = 3f;
    string cvn_u1 = "N/A";
    float cvn_v1 = 0f;

    string cvn_q2 = "Interesting... Batch 3 is shattering with much less energy than the other samples. What is it's CVN-toughness?";
    float cvn_a2 = 0f;
    string cvn_u2 = "N/A";
    float cvn_v2 = 0f;

    string cvn_q3 = "What percent CVN-toughness does this sample have compared to the baseline then? That is K3/K1, where K is the fracture toughness a the sample";
    float cvn_a3 = 0f;
    string cvn_u3 = "N/A";
    float cvn_v3 = 0f;

    string cvn_q4 = " Let's see wether is it more brittle than the others, or if it is simple weaker. Use the tensile test to determine if the sample more brittle than the rest of the batches? Yes(1), No(0)";
    float cvn_a4 = 0f;
    string cvn_u4 = "N/A";
    float cvn_v4 = 0f;

    string cvn_q5 = "Then perhaps it has a lower Ultimate Tensile Stress. What percent of UTS does the sample have compared to the baseline (sample's UTS / Baseline UTS)*100 = % difference ";
    float cvn_a5 = 40f;
    string cvn_u5 = "N/A";
    float cvn_v5 = 0f;

    string cvn_q6 = "See how the charpy gave us a quick overview of the materials charactaristics without needing to evaluate any graphs. You can quickly test for ductile to brittle transition as well by cooling a sample. Is it present in this aluminum sample? Yes(1), No(0)";
    float cvn_a6 = 0f;
    string cvn_u6 = "N/A";
    float cvn_v6 = 0f;

    string cvn_q7 = "Does this high carbon steel have a ductile to brittle transition? Yes(1), No(0)";
    float cvn_a7 = 1f;
    string cvn_u7 = "N/A";
    float cvn_v7 = 0f;

    string cvn_q8 = "How about this ceramic pot? Yes(1), No(0)";
    float cvn_a8 = 0f;
    string cvn_u8 = "N/A";
    float cvn_v8 = 0f;

    string cvn_q9 = "The pot does not have a transition, as it is always brittle. Check if this steel is applicable at high temperatures by ensuring it doesn't lose more than 20% CVN-toughness when at high temperature. Is the steel applicable? Yes(1), No(0) ";
    float cvn_a9 = 0f;
    string cvn_u9 = "N/A";
    float cvn_v9 = 0f;

    string cvn_q10 = "What percentage CVN-toughness does the steel lose at high temperature?";
    float cvn_a10 = 0f;
    string cvn_u10 = "N/A";
    float cvn_v10 = 0f;

    string cvn_q11 = "Try this unnotched sample, so you can learn why we notch the charpy. What is it's CVN-toughness?, notice the way the sample breaks irregularly";
    float cvn_a11= 0f;
    string cvn_u11 = "N/A";
    float cvn_v11 = 0f;

    string cvn_q12 = "Now use the same sample, notched. What is the toughness.";
    float cvn_a12 = 0f;
    string cvn_u12 = "N/A";
    float cvn_v12 = 0f;

    string cvn_q13 = "The toughness was lower, but the break was much cleaner as well. This leads to a reliable, more consistant result. Remember, toughness and strength aren't always the same thing. Which is tougher, this rebar, or this concrete?" ;
    float cvn_a13 = 2f;
    string cvn_u13 = "N/A";
    float cvn_v13 = 0f;

    string cvn_q14 = "True, but which has a higher compressive strength? concrete(1) or rebar(2)";
    float cvn_a14 = 1f;
    string cvn_u14 = "N/A";
    float cvn_v14 = 0f;

    string cvn_q15 = "What is the percent change in CVN-toughness of our concreteby adding 10% rebar through the middle?";
    float cvn_a15 = 0f;
    string cvn_u15 = "N/A";
    float cvn_v15 = 0f;

    string cvn_q16 = "Similarly, what is the percent change in our concrete's CVN-toughness by adding loose fiberglass into the mixture?";
    float cvn_a16 = 0f;
    string cvn_u16 = "N/A";
    float cvn_v16 = 0f;

    string cvn_q17 = "Which is the toughest concrete mixture?";
    float cvn_a17 = 0f; //fiberglass matric with rebar
    string cvn_u17 = "N/A";
    float cvn_v17 = 0f;

    //XRD
    string xrd_q0 = "One may use the XRD for crystal structure identification. The simplist method would be to compare peak of the target sample with a baseline sample. Use the baseline aluminum FCC structure chart and the XRD to find the aluminum-FCC sample";
    float xrd_a0 = 0f;
    string xrd_u0 = "N/A";
    float xrd_v0 = 0f;

    string xrd_q1 = "Good job, now try to find the copper sample using the XRD and the example peaks.";
    float xrd_a1 = 0f;
    string xrd_u1 = "N/A";
    float xrd_v1 = 0f;

    string xrd_q2 = "One can also detect the presence of other phases of materials using the XRD. Use the XRD to see which of these steels was heat treated improperly. Look for peaks at different locations as evidence.";
    float xrd_a2= 0f;
    string xrd_u2 = "N/A";
    float xrd_v2 = 0f;

    string xrd_q3 = "Sometimes there will be  multiple phases present, competing for space in your XRD graph. Choose the sample with both alpha and beta aluminum present, by looking for evidence of both phases.";
    float xrd_a3 = 0f;
    string xrd_u3 = "N/A";
    float xrd_v3 = 0f;

    string xrd_q4 = "Find the stainless steel with contaminated pure chromium layers. Use the XRD sample graphs for aid.";
    float xrd_a4 = 0f;
    string xrd_u4 = "N/A";
    float xrd_v4 = 0f;

    string xrd_q5 = "The XRD may be used to check samples for residual stresses as well. This is indicated by the peaks being shifted to the side. Check these Aluminum samples for residual stresses from manufacturing. Look for the sample with shifted peaks.";
    float xrd_a5 = 0f;
    string xrd_u5 = "N/A";
    float xrd_v5 = 0f;

    string xrd_q6 = "Search through the heap of alloys for some beta-brass, matching the given graph, and input the samples conductivity.";
    float xrd_a6 = 0f;
    string xrd_u6 = "N/A";
    float xrd_v6 = 0f;

    string xrd_q7 = "A ceramics manufacturer has been seeing their urns fall apart after extended use. Test their samples toughness compared to the desired baseline sample. Is the test sample less tough?";
    float xrd_a7 = 0f;
    string xrd_u7 = "N/A";
    float xrd_v7 = 0f;

    string xrd_q8 = "Hmm, if it's not less tough, there must be another issue. Perhaps the material is not fully transitioning during it's firing. Compare the baseline sample's XRd and the unfired samples XRD to the test sample's and check for presence of the unfired phase. Yes(1) No(0)";
    float xrd_a8 = 1f;
    string xrd_u8 = "N/A";
    float xrd_v8 = 0f;

    string xrd_q9 = "There we go, it seems the sample simply needs to be fired for longer in order fully get that hardedned glassy finish.";
    float xrd_a9 = 0f;
    string xrd_u9 = "N/A";
    float xrd_v9 = 0f;

    // Start is called before the first frame update
    void Start()
    {

        questions.Add(q0);
        questions.Add(q0pt1);
        questions.Add(q1);
        questions.Add(q2);
        questions.Add(q3);
        questions.Add(q4);
        questions.Add(q5);
        questions.Add(q6);
        questions.Add(q6pt1);
        questions.Add(q7);
        questions.Add(q8);
        questions.Add(q9);
        questions.Add(q10);
        questions.Add(q11);
        questions.Add(q12);
        questions.Add(q13);
        questions.Add(q14);
        questions.Add(q14pt1);
        questions.Add(q15);
        questions.Add(q16);
        questions.Add(q17);
        questions.Add(q18);
        questions.Add(q19);
        questions.Add(q19pt1);
        questions.Add(q19pt2);
        questions.Add(q20);
        questions.Add(q21);
        questions.Add(q22);
        questions.Add(q23);
        questions.Add(q24);
        questions.Add(q25);
        questions.Add(q26);
        questions.Add(q27);
        questions.Add(q28);
        questions.Add(q29);
        questions.Add(q30);
        questions.Add(q31);
        questions.Add(q32);
        questions.Add(q33);
        questions.Add(q34);
        questions.Add(q35);
        questions.Add(q36);
        questions.Add(q37);
        questions.Add(q38);
        questions.Add(q39);
        questions.Add(q40);
        questions.Add(q41);

        answers.Add(a0);
        answers.Add(a0pt1);
        answers.Add(a1);
        answers.Add(a2);
        answers.Add(a3);
        answers.Add(a4);
        answers.Add(a5);
        answers.Add(a6);
        answers.Add(a6pt1);
        answers.Add(a7);
        answers.Add(a8);
        answers.Add(a9);
        answers.Add(a10);
        answers.Add(a11);
        answers.Add(a12);
        answers.Add(a13);
        answers.Add(a14);
        answers.Add(a14pt1);
        answers.Add(a15);
        answers.Add(a16);
        answers.Add(a17);
        answers.Add(a18);
        answers.Add(a19);
        answers.Add(a19pt1);
        answers.Add(a19pt2);
        answers.Add(a20);
        answers.Add(a21);
        answers.Add(a22);
        answers.Add(a23);
        answers.Add(a24);
        answers.Add(a25);
        answers.Add(a26);
        answers.Add(a27);
        answers.Add(a28);
        answers.Add(a29);
        answers.Add(a30);
        answers.Add(a31);
        answers.Add(a32);
        answers.Add(a33);
        answers.Add(a34);
        answers.Add(a35);
        answers.Add(a36);
        answers.Add(a37);
        answers.Add(a38);
        answers.Add(a39);
        answers.Add(a40);
        answers.Add(a41);

        units.Add(u0);
        units.Add(u0pt1);
        units.Add(u1);
        units.Add(u2);
        units.Add(u3);
        units.Add(u4);
        units.Add(u5);
        units.Add(u6);
        units.Add(u6pt1);
        units.Add(u7);
        units.Add(u8);
        units.Add(u9);
        units.Add(u10);
        units.Add(u11);
        units.Add(u12);
        units.Add(u13);
        units.Add(u14);
        units.Add(u14pt1);
        units.Add(u15);
        units.Add(u16);
        units.Add(u17);
        units.Add(u18);
        units.Add(u19);
        units.Add(u19pt1);
        units.Add(u19pt2);
        units.Add(u20);
        units.Add(u21);
        units.Add(u22);
        units.Add(u23);
        units.Add(u24);
        units.Add(u25);
        units.Add(u26);
        units.Add(u27);
        units.Add(u28);
        units.Add(u29);
        units.Add(u30);
        units.Add(u31);
        units.Add(u32);
        units.Add(u33);
        units.Add(u34);
        units.Add(u35);
        units.Add(u36);
        units.Add(u37);
        units.Add(u38);
        units.Add(u39);
        units.Add(u40);
        units.Add(u41);

        values.Add(v0);
        values.Add(v0pt1);
        values.Add(v1);
        values.Add(v2);
        values.Add(v3);
        values.Add(v4);
        values.Add(v5);
        values.Add(v6);
        values.Add(v6pt1);
        values.Add(v7);
        values.Add(v8);
        values.Add(v9);
        values.Add(v10);
        values.Add(v11);
        values.Add(v12);
        values.Add(v13);
        values.Add(v14);
        values.Add(v14pt1);
        values.Add(v15);
        values.Add(v16);
        values.Add(v17);
        values.Add(v18);
        values.Add(v19);
        values.Add(v19pt1);
        values.Add(v19pt2);
        values.Add(v20);
        values.Add(v21);
        values.Add(v22);
        values.Add(v23);
        values.Add(v24);
        values.Add(v25);
        values.Add(v26);
        values.Add(v27);
        values.Add(v28);
        values.Add(v29);
        values.Add(v30);
        values.Add(v31);
        values.Add(v32);
        values.Add(v33);
        values.Add(v34);
        values.Add(v35);
        values.Add(v36);
        values.Add(v37);
        values.Add(v38);
        values.Add(v39);
        values.Add(v40);
        values.Add(v41);


        c_questions.Add(c_q0);
        c_questions.Add(c_q1);
        c_questions.Add(c_q2);
        c_questions.Add(c_q3);
        c_questions.Add(c_q4);
        c_questions.Add(c_q5);
        c_questions.Add(c_q6);
        c_questions.Add(c_q7);
        c_questions.Add(c_q8);
        c_questions.Add(c_q9);
        c_questions.Add(c_q10);
        c_questions.Add(c_q10pt1);
        c_questions.Add(c_q11);
        c_questions.Add(c_q12);
        c_questions.Add(c_q13);

        c_answers.Add(c_a0);
        c_answers.Add(c_a1);
        c_answers.Add(c_a2);
        c_answers.Add(c_a3);
        c_answers.Add(c_a4);
        c_answers.Add(c_a5);
        c_answers.Add(c_a6);
        c_answers.Add(c_a7);
        c_answers.Add(c_a8);
        c_answers.Add(c_a9);
        c_answers.Add(c_a10);
        c_answers.Add(c_a10pt1);
        c_answers.Add(c_a11);
        c_answers.Add(c_a12);
        c_answers.Add(c_a13);

        c_units.Add(c_u0);
        c_units.Add(c_u1);
        c_units.Add(c_u2);
        c_units.Add(c_u3);
        c_units.Add(c_u4);
        c_units.Add(c_u5);
        c_units.Add(c_u6);
        c_units.Add(c_u7);
        c_units.Add(c_u8);
        c_units.Add(c_u9);
        c_units.Add(c_u10);
        c_units.Add(c_u10pt1);
        c_units.Add(c_u11);
        c_units.Add(c_u12);
        c_units.Add(c_u13);

        c_values.Add(c_v0);
        c_values.Add(c_v1);
        c_values.Add(c_v2);
        c_values.Add(c_v3);
        c_values.Add(c_v4);
        c_values.Add(c_v5);
        c_values.Add(c_v6);
        c_values.Add(c_v7);
        c_values.Add(c_v8);
        c_values.Add(c_v9);
        c_values.Add(c_v10);
        c_values.Add(c_v10pt1);
        c_values.Add(c_v11);
        c_values.Add(c_v12);
        c_values.Add(c_v13);

       //tensile

       t_questions.Add(t_q0);
       t_questions.Add(t_q1);
       t_questions.Add(t_q2);
       t_questions.Add(t_q3);
       t_questions.Add(t_q4);
       t_questions.Add(t_q5);
       t_questions.Add(t_q6);
       t_questions.Add(t_q8);
       t_questions.Add(t_q9);
       t_questions.Add(t_q10);

       t_answers.Add(t_a0);
       t_answers.Add(t_a1);
       t_answers.Add(t_a2);
       t_answers.Add(t_a3);
       t_answers.Add(t_a4);
       t_answers.Add(t_a5);
       t_answers.Add(t_a6);
       t_answers.Add(t_a8);
       t_answers.Add(t_a9);
       t_answers.Add(t_a10);

       t_units.Add(t_u0);
       t_units.Add(t_u1);
       t_units.Add(t_u2);
       t_units.Add(t_u3);
       t_units.Add(t_u4);
       t_units.Add(t_u5);
       t_units.Add(t_u6);
       t_units.Add(t_u8);
       t_units.Add(t_u9);
       t_units.Add(t_u10);

       t_values.Add(t_v0);
       t_values.Add(t_v1);
       t_values.Add(t_v2);
       t_values.Add(t_v3);
       t_values.Add(t_v4);
       t_values.Add(t_v5);
       t_values.Add(t_v6);
       t_values.Add(t_v8);
       t_values.Add(t_v9);
       t_values.Add(t_v10);

       //liqN2
       t_questions.Add(l_q0);
       t_questions.Add(l_q1);
       t_questions.Add(l_q2);
       t_questions.Add(l_q3);
       t_questions.Add(l_q4);
       t_questions.Add(l_q4pt1);
       t_questions.Add(l_q5);
       t_questions.Add(l_q6);
       t_questions.Add(l_q7);
       t_questions.Add(l_q8);
       t_questions.Add(l_q9);
       t_questions.Add(l_q10);
       t_questions.Add(l_q11);

       t_answers.Add(l_a0);
       t_answers.Add(l_a1);
       t_answers.Add(l_a2);
       t_answers.Add(l_a3);
       t_answers.Add(l_a4);
       t_answers.Add(l_a4pt1);
       t_answers.Add(l_a5);
       t_answers.Add(l_a6);
       t_answers.Add(l_a7);
       t_answers.Add(l_a8);
       t_answers.Add(l_a9);
       t_answers.Add(l_a10);
       t_answers.Add(l_a11);

       t_units.Add(l_u0);
       t_units.Add(l_u1);
       t_units.Add(l_u2);
       t_units.Add(l_u3);
       t_units.Add(l_u4);
       t_units.Add(l_u4pt1);
       t_units.Add(l_u5);
       t_units.Add(l_u6);
       t_units.Add(l_u7);
       t_units.Add(l_u8);
       t_units.Add(l_u9);
       t_units.Add(l_u10);
       t_units.Add(l_u11);

       t_values.Add(l_v0);
       t_values.Add(l_v1);
       t_values.Add(l_v2);
       t_values.Add(l_v3);
       t_values.Add(l_v4);
       t_values.Add(l_v4pt1);
       t_values.Add(l_v5);
       t_values.Add(l_v6);
       t_values.Add(l_v7);
       t_values.Add(l_v8);
       t_values.Add(l_v9);
       t_values.Add(l_v10);
       t_values.Add(l_v11);

       //furnace
       t_questions.Add(f_q0);
       t_questions.Add(f_q1);
       t_questions.Add(f_q2);
       t_questions.Add(f_q3);
       t_questions.Add(f_q4);
       t_questions.Add(f_q5);
       t_questions.Add(f_q6);
       t_questions.Add(f_q7);
       t_questions.Add(f_q8);

      t_answers.Add(f_a0);
      t_answers.Add(f_a1);
      t_answers.Add(f_a2);
      t_answers.Add(f_a3);
      t_answers.Add(f_a4);
      t_answers.Add(f_a5);
      t_answers.Add(f_a6);
      t_answers.Add(f_a7);
      t_answers.Add(f_a8);

       t_units.Add(f_u0);
       t_units.Add(f_u1);
       t_units.Add(f_u2);
       t_units.Add(f_u3);
       t_units.Add(f_u4);
       t_units.Add(f_u5);
       t_units.Add(f_u6);
       t_units.Add(f_u7);
       t_units.Add(f_u8);

       t_values.Add(f_v0);
       t_values.Add(f_v1);
       t_values.Add(f_v2);
       t_values.Add(f_v3);
       t_values.Add(f_v4);
       t_values.Add(f_v5);
       t_values.Add(f_v6);
       t_values.Add(f_v7);
       t_values.Add(f_v8);

       //Compression
       comp_questions.Add(comp_q0);
       comp_questions.Add(comp_q1);
       comp_questions.Add(comp_q2);
       comp_questions.Add(comp_q3);
       comp_questions.Add(comp_q4);
       comp_questions.Add(comp_q5);
       comp_questions.Add(comp_q6);
       comp_questions.Add(comp_q7);
       comp_questions.Add(comp_q8);
       comp_questions.Add(comp_q9);
       comp_questions.Add(comp_q10);
       comp_questions.Add(comp_q11);

       comp_answers.Add(comp_a0);
       comp_answers.Add(comp_a1);
       comp_answers.Add(comp_a2);
       comp_answers.Add(comp_a3);
       comp_answers.Add(comp_a4);
       comp_answers.Add(comp_a5);
       comp_answers.Add(comp_a6);
       comp_answers.Add(comp_a7);
       comp_answers.Add(comp_a8);
       comp_answers.Add(comp_a9);
       comp_answers.Add(comp_a10);
       comp_answers.Add(comp_a11);

       comp_units.Add(comp_u0);
       comp_units.Add(comp_u1);
       comp_units.Add(comp_u2);
       comp_units.Add(comp_u3);
       comp_units.Add(comp_u4);
       comp_units.Add(comp_u5);
       comp_units.Add(comp_u6);
       comp_units.Add(comp_u7);
       comp_units.Add(comp_u8);
       comp_units.Add(comp_u9);
       comp_units.Add(comp_u10);
       comp_units.Add(comp_u11);

       comp_values.Add(comp_v0);
       comp_values.Add(comp_v1);
       comp_values.Add(comp_v2);
       comp_values.Add(comp_v3);
       comp_values.Add(comp_v4);
       comp_values.Add(comp_v5);
       comp_values.Add(comp_v6);
       comp_values.Add(comp_v7);
       comp_values.Add(comp_v8);
       comp_values.Add(comp_v9);
       comp_values.Add(comp_v10);
       comp_values.Add(comp_v11);

       //CVN
       cvn_questions.Add(cvn_q0);
       cvn_questions.Add(cvn_q1);
       cvn_questions.Add(cvn_q2);
       cvn_questions.Add(cvn_q3);
       cvn_questions.Add(cvn_q4);
       cvn_questions.Add(cvn_q5);
       cvn_questions.Add(cvn_q6);
       cvn_questions.Add(cvn_q7);
       cvn_questions.Add(cvn_q8);
       cvn_questions.Add(cvn_q9);
       cvn_questions.Add(cvn_q10);
       cvn_questions.Add(cvn_q11);
       cvn_questions.Add(cvn_q12);
       cvn_questions.Add(cvn_q13);
       cvn_questions.Add(cvn_q14);
       cvn_questions.Add(cvn_q15);
       cvn_questions.Add(cvn_q16);
       cvn_questions.Add(cvn_q17);

       cvn_answers.Add(cvn_a0);
       cvn_answers.Add(cvn_a1);
       cvn_answers.Add(cvn_a2);
       cvn_answers.Add(cvn_a3);
       cvn_answers.Add(cvn_a4);
       cvn_answers.Add(cvn_a5);
       cvn_answers.Add(cvn_a6);
       cvn_answers.Add(cvn_a7);
       cvn_answers.Add(cvn_a8);
       cvn_answers.Add(cvn_a9);
       cvn_answers.Add(cvn_a10);
       cvn_answers.Add(cvn_a11);
       cvn_answers.Add(cvn_a12);
       cvn_answers.Add(cvn_a13);
       cvn_answers.Add(cvn_a14);
       cvn_answers.Add(cvn_a15);
       cvn_answers.Add(cvn_a16);
       cvn_answers.Add(cvn_a17);

       cvn_units.Add(cvn_u0);
       cvn_units.Add(cvn_u1);
       cvn_units.Add(cvn_u2);
       cvn_units.Add(cvn_u3);
       cvn_units.Add(cvn_u4);
       cvn_units.Add(cvn_u5);
       cvn_units.Add(cvn_u6);
       cvn_units.Add(cvn_u7);
       cvn_units.Add(cvn_u8);
       cvn_units.Add(cvn_u9);
       cvn_units.Add(cvn_u10);
       cvn_units.Add(cvn_u11);
       cvn_units.Add(cvn_u12);
       cvn_units.Add(cvn_u13);
       cvn_units.Add(cvn_u14);
       cvn_units.Add(cvn_u15);
       cvn_units.Add(cvn_u16);
       cvn_units.Add(cvn_u17);

       cvn_values.Add(cvn_v0);
       cvn_values.Add(cvn_v1);
       cvn_values.Add(cvn_v2);
       cvn_values.Add(cvn_v3);
       cvn_values.Add(cvn_v4);
       cvn_values.Add(cvn_v5);
       cvn_values.Add(cvn_v6);
       cvn_values.Add(cvn_v7);
       cvn_values.Add(cvn_v8);
       cvn_values.Add(cvn_v9);
       cvn_values.Add(cvn_v10);
       cvn_values.Add(cvn_v11);
       cvn_values.Add(cvn_v12);
       cvn_values.Add(cvn_v13);
       cvn_values.Add(cvn_v14);
       cvn_values.Add(cvn_v15);
       cvn_values.Add(cvn_v16);
       cvn_values.Add(cvn_v17);

       //XRD
       xrd_questions.Add(xrd_q0);
       xrd_questions.Add(xrd_q1);
       xrd_questions.Add(xrd_q2);
       xrd_questions.Add(xrd_q3);
       xrd_questions.Add(xrd_q4);
       xrd_questions.Add(xrd_q5);
       xrd_questions.Add(xrd_q6);
       xrd_questions.Add(xrd_q7);
       xrd_questions.Add(xrd_q8);
       xrd_questions.Add(xrd_q9);

       xrd_answers.Add(xrd_a0);
       xrd_answers.Add(xrd_a1);
       xrd_answers.Add(xrd_a2);
       xrd_answers.Add(xrd_a3);
       xrd_answers.Add(xrd_a4);
       xrd_answers.Add(xrd_a5);
       xrd_answers.Add(xrd_a6);
       xrd_answers.Add(xrd_a7);
       xrd_answers.Add(xrd_a8);
       xrd_answers.Add(xrd_a9);

       xrd_units.Add(xrd_u0);
       xrd_units.Add(xrd_u1);
       xrd_units.Add(xrd_u2);
       xrd_units.Add(xrd_u3);
       xrd_units.Add(xrd_u4);
       xrd_units.Add(xrd_u5);
       xrd_units.Add(xrd_u6);
       xrd_units.Add(xrd_u7);
       xrd_units.Add(xrd_u8);
       xrd_units.Add(xrd_u9);

       xrd_values.Add(xrd_v0);
       xrd_values.Add(xrd_v1);
       xrd_values.Add(xrd_v2);
       xrd_values.Add(xrd_v3);
       xrd_values.Add(xrd_v4);
       xrd_values.Add(xrd_v5);
       xrd_values.Add(xrd_v6);
       xrd_values.Add(xrd_v7);
       xrd_values.Add(xrd_v8);
       xrd_values.Add(xrd_v9);

        qNow = questions[loc];

        gameDisplay.GetComponent<Text>().text = qNow;
        userDisplay.GetComponent<Text>().text = "";//">>>";
        unitDisplay.GetComponent<Text>().text = units[loc];


    }

    // Update is called once per frame
    public void Check(float guess)
    {
      if (q_type == 0)
      {

      if (answers[loc]*.85 <= guess && guess <= answers[loc]*1.2f  )
      {
        subs.Add(guess);
        vNow = values[loc];
        loc+=1;
        bank.money += vNow;
        qNow = questions[loc];
        uNow= units[loc];
        aNow= answers[loc];
        vNow = values[loc];
        gameDisplay.GetComponent<Text>().text = qNow;
        unitDisplay.GetComponent<Text>().text = units[loc];
        sampleManager.NextSample();
        //userDisplay.GetComponent<Text>().text = "";//">>>";
      }
      else
      {
        gameDisplay.GetComponent<Text>().text= qNow + "  Sorry Not Quite!";
      }
      }
      if (q_type == 1)
      {

      if (c_answers[c_loc]*.95 <= guess && guess <= c_answers[c_loc]*1.07f  )
      {
        subs.Add(guess);
        vNow = c_values[c_loc];
        c_loc+=1;
        bank.money += vNow;
        qNow = c_questions[c_loc];
        uNow= c_units[c_loc];
        aNow= c_answers[c_loc];
        vNow = c_values[c_loc];
        gameDisplay.GetComponent<Text>().text = qNow;
        unitDisplay.GetComponent<Text>().text = c_units[c_loc];
        sampleManager.NextSample();
        //userDisplay.GetComponent<Text>().text = "";//">>>";
      }
      }
      if (q_type == 2)
      {

      if (t_answers[t_loc]*.95 <= guess && guess <= t_answers[t_loc]*1.07f  )
      {
        subs.Add(guess);
        vNow = t_values[t_loc];
        t_loc+=1;
        bank.money += vNow;
        qNow = t_questions[t_loc];
        uNow= t_units[t_loc];
        aNow= t_answers[t_loc];
        vNow = t_values[t_loc];
        gameDisplay.GetComponent<Text>().text = qNow;
        unitDisplay.GetComponent<Text>().text = t_units[t_loc];
        sampleManager.NextSample();
        //userDisplay.GetComponent<Text>().text = "";//">>>";
      }
      }
      if (q_type == 3)
      {

      if (comp_answers[comp_loc]*.95 <= guess && guess <= comp_answers[comp_loc]*1.07f  )
      {
        subs.Add(guess);
        vNow = comp_values[comp_loc];
        comp_loc+=1;
        bank.money += vNow;
        qNow = comp_questions[comp_loc];
        uNow= comp_units[comp_loc];
        aNow= comp_answers[comp_loc];
        vNow = comp_values[comp_loc];
        gameDisplay.GetComponent<Text>().text = qNow;
        unitDisplay.GetComponent<Text>().text = comp_units[comp_loc];
        sampleManager.NextSample();
        //userDisplay.GetComponent<Text>().text = "";//">>>";
      }
      }
      if (q_type == 4)
      {

      if (cvn_answers[cvn_loc]*.95 <= guess && guess <= cvn_answers[cvn_loc]*1.07f  )
      {
        subs.Add(guess);
        vNow = cvn_values[cvn_loc];
        cvn_loc+=1;
        bank.money += vNow;
        qNow = cvn_questions[cvn_loc];
        uNow= cvn_units[cvn_loc];
        aNow= cvn_answers[cvn_loc];
        vNow = cvn_values[cvn_loc];
        gameDisplay.GetComponent<Text>().text = qNow;
        unitDisplay.GetComponent<Text>().text = cvn_units[cvn_loc];
        sampleManager.NextSample();
        //userDisplay.GetComponent<Text>().text = "";//">>>";
      }
      }
      if (q_type == 5)
      {

      if (xrd_answers[xrd_loc]*.95 <= guess && guess <= xrd_answers[xrd_loc]*1.07f  )
      {
        subs.Add(guess);
        vNow = xrd_values[xrd_loc];
        xrd_loc+=1;
        bank.money += vNow;
        qNow = xrd_questions[xrd_loc];
        uNow= xrd_units[xrd_loc];
        aNow= xrd_answers[xrd_loc];
        vNow = xrd_values[xrd_loc];
        gameDisplay.GetComponent<Text>().text = qNow;
        unitDisplay.GetComponent<Text>().text = xrd_units[xrd_loc];
        sampleManager.NextSample();
        //userDisplay.GetComponent<Text>().text = "";//">>>";
      }
      else
      {
        gameDisplay.GetComponent<Text>().text= qNow + "  Sorry Not Quite!";
      }
      }
    }
    public void SetMO()
    {
      qNow = questions[loc];
      uNow= units[loc];
      aNow= answers[loc];
      vNow = values[loc];
      q_type=0;
      gameDisplay.GetComponent<Text>().text = qNow;
      unitDisplay.GetComponent<Text>().text = uNow;
      sampleManager.SetSampleType(q_type);
    }

    public void SetCondTask()
    {
      qNow = c_questions[c_loc];
      uNow= c_units[c_loc];
      aNow= c_answers[c_loc];
      vNow = c_values[c_loc];
      q_type=1;
      gameDisplay.GetComponent<Text>().text = qNow;
      unitDisplay.GetComponent<Text>().text = uNow;
        Debug.Log('3');
      sampleManager.SetSampleType(q_type);
    }


    public void SetTensTask()
    {
      qNow = c_questions[t_loc];
      uNow= c_units[t_loc];
      aNow= c_answers[t_loc];
      vNow = c_values[t_loc];
      q_type=2;
      gameDisplay.GetComponent<Text>().text = qNow;
      unitDisplay.GetComponent<Text>().text = uNow;
        Debug.Log('3');
      sampleManager.SetSampleType(q_type);
    }


    public void SetCompTask()
    {
      qNow = c_questions[comp_loc];
      uNow= c_units[comp_loc];
      aNow= c_answers[comp_loc];
      vNow = c_values[comp_loc];
      q_type=3;
      gameDisplay.GetComponent<Text>().text = qNow;
      unitDisplay.GetComponent<Text>().text = uNow;
        Debug.Log('3');
      sampleManager.SetSampleType(q_type);
    }


    public void SetCvnTask()
    {
      qNow = c_questions[cvn_loc];
      uNow= c_units[cvn_loc];
      aNow= c_answers[cvn_loc];
      vNow = c_values[cvn_loc];
      q_type=4;
      gameDisplay.GetComponent<Text>().text = qNow;
      unitDisplay.GetComponent<Text>().text = uNow;
        Debug.Log('3');
      sampleManager.SetSampleType(q_type);
    }

    public void SetXRDTask()
    {
      qNow = c_questions[xrd_loc];
      uNow= c_units[xrd_loc];
      aNow= c_answers[xrd_loc];
      vNow = c_values[xrd_loc];
      q_type=5;
      gameDisplay.GetComponent<Text>().text = qNow;
      unitDisplay.GetComponent<Text>().text = uNow;
        Debug.Log('3');
      sampleManager.SetSampleType(q_type);
    }

    public void SkipQuestion()
    {
      Check(answers[loc]);
    }
}
