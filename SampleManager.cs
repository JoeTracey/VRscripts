using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleManager : MonoBehaviour
{

  int mainIdx = 0;
  int condIdx = 0;
  int tensIdx = 0 ;
  int compIdx = 0;
  int CVNIdx = 0;
  int XRDIdx=0;
FixedJoint joint ;
SampleFunctions sample_alt;
SampleFunctions sampleL;
SampleFunctions sampleR;

  SampleFunctions sample;
  int sampleType = 0;
  List<SampleFunctions> curSamples = new List<SampleFunctions>();
  List<List<List<SampleFunctions>>> sampleLib = new List<List<List<SampleFunctions>>>();
  [SerializeField]
  public Vector3 goneSpot;
  [SerializeField]
  public Vector3 sample1Spot;
  [SerializeField]
  public Vector3 sample2Spot;
  [SerializeField]
  public Vector3 sample3Spot;
  [SerializeField]
  public Vector3 sample4Spot;
  [SerializeField]
  public Vector3 sample5Spot;
  [SerializeField]
  public Vector3 altloc;
  [SerializeField]
  public Vector3 altLloc;
  [SerializeField]
  public Vector3 altRloc;

  //Main Story Samples
  [SerializeField]
  public SampleFunctions blankSample;
  [SerializeField]
  public SampleFunctions Mm1;
  [SerializeField]
  public SampleFunctions Mt1;
  [SerializeField]
  public SampleFunctions Mt2;
  [SerializeField]
  public SampleFunctions Mt3;
  [SerializeField]
  public SampleFunctions Mt4;
  [SerializeField]
  public SampleFunctions Mt5;
  [SerializeField]
  public SampleFunctions Mt6;
  [SerializeField]
  public SampleFunctions Mt7;
  [SerializeField]
  public SampleFunctions Mt8;
  [SerializeField]
  public SampleFunctions Mt9;
  [SerializeField]
  public SampleFunctions Mt10;
  [SerializeField]
  public SampleFunctions Mt11;

  [SerializeField]
  public SampleFunctions Mc1;
  [SerializeField]
  public SampleFunctions Mc2;
  [SerializeField]
  public SampleFunctions Mc3;

  [SerializeField]
  public SampleFunctions Mc4;

  [SerializeField]
  public SampleFunctions Mcv1;
  [SerializeField]
  public SampleFunctions Mcv2;
  [SerializeField]
  public SampleFunctions Mcv3;

  [SerializeField]
  public SampleFunctions Mx1;
  [SerializeField]
  public SampleFunctions Mx2;
  [SerializeField]
  public SampleFunctions Mx3;
  [SerializeField]
  public SampleFunctions Mx4;
  [SerializeField]
  public SampleFunctions Mx5;
  [SerializeField]
  public SampleFunctions Mx6;
  [SerializeField]
  public SampleFunctions Mx7;

  [SerializeField]
  public SampleFunctions C1;
  [SerializeField]
  public SampleFunctions C2;
  [SerializeField]
  public SampleFunctions C3;
  [SerializeField]
  public SampleFunctions C4;
  [SerializeField]
  public SampleFunctions C5;
  [SerializeField]
  public SampleFunctions C6;
  [SerializeField]
  public SampleFunctions C7;
  [SerializeField]
  public SampleFunctions C8;
  [SerializeField]
  public SampleFunctions C9;
  [SerializeField]
  public SampleFunctions C10;
  [SerializeField]
  public SampleFunctions C11;
  [SerializeField]
  public SampleFunctions C12;
  [SerializeField]
  public SampleFunctions C14;
  [SerializeField]
  public SampleFunctions C15;
  [SerializeField]
  public SampleFunctions C16;
  [SerializeField]
  public SampleFunctions C17;


  [SerializeField]
  public SampleFunctions Cp1;
  [SerializeField]
  public SampleFunctions Cp2;
  [SerializeField]
  public SampleFunctions Cp3;
  [SerializeField]
  public SampleFunctions Cp4;
  [SerializeField]
  public SampleFunctions Cp5;
  [SerializeField]
  public SampleFunctions Cp6;



  [SerializeField]
  public SampleFunctions T1;
  [SerializeField]
  public SampleFunctions T2;
  [SerializeField]
  public SampleFunctions T3;
  [SerializeField]
  public SampleFunctions T4;
  [SerializeField]
  public SampleFunctions T5;
  [SerializeField]
  public SampleFunctions T6;
  [SerializeField]
  public SampleFunctions T7;
  [SerializeField]
  public SampleFunctions T8;
  [SerializeField]
  public SampleFunctions T9;
  [SerializeField]
  public SampleFunctions T10;
  [SerializeField]
  public SampleFunctions T11;
  [SerializeField]
  public SampleFunctions T12;
  [SerializeField]
  public SampleFunctions T13;
  [SerializeField]
  public SampleFunctions T14;
  [SerializeField]
  public SampleFunctions T15;
  [SerializeField]
  public SampleFunctions T16;
  [SerializeField]
  public SampleFunctions T16b;
  [SerializeField]
  public SampleFunctions T16c;
  [SerializeField]
  public SampleFunctions T17;
  [SerializeField]
  public SampleFunctions T18;
  [SerializeField]
  public SampleFunctions T19;
  [SerializeField]
  public SampleFunctions T20;
  [SerializeField]
  public SampleFunctions T21;
  [SerializeField]
  public SampleFunctions T22;
  [SerializeField]
  public SampleFunctions T23;
  [SerializeField]
  public SampleFunctions T24;
  [SerializeField]
  public SampleFunctions T25;
  [SerializeField]
  public SampleFunctions T26;
  [SerializeField]
  public SampleFunctions T27;
  [SerializeField]
  public SampleFunctions T28;
  [SerializeField]
  public SampleFunctions T29;
  [SerializeField]
  public SampleFunctions T30;


  [SerializeField]
  public SampleFunctions X1;
  [SerializeField]
  public SampleFunctions X2;
  [SerializeField]
  public SampleFunctions X3;
  [SerializeField]
  public SampleFunctions X4;
  [SerializeField]
  public SampleFunctions X5;
  [SerializeField]
  public SampleFunctions X6;
  [SerializeField]
  public SampleFunctions X7;
  [SerializeField]
  public SampleFunctions X8;
  [SerializeField]
  public SampleFunctions X9;
  [SerializeField]
  public SampleFunctions X10;
  [SerializeField]
  public SampleFunctions X11;
  [SerializeField]
  public SampleFunctions X12;
  [SerializeField]
  public SampleFunctions X13;
  [SerializeField]
  public SampleFunctions X14;
  [SerializeField]
  public SampleFunctions X15;
  [SerializeField]
  public SampleFunctions X16;


  [SerializeField]
  public SampleFunctions Cv1;
  [SerializeField]
  public SampleFunctions Cv2;
  [SerializeField]
  public SampleFunctions Cv3;
  [SerializeField]
  public SampleFunctions Cv4;
  [SerializeField]
  public SampleFunctions Cv5;
  [SerializeField]
  public SampleFunctions Cv6;
  [SerializeField]
  public SampleFunctions Cv7;
  [SerializeField]
  public SampleFunctions Cv8;
  [SerializeField]
  public SampleFunctions Cv9;
  [SerializeField]
  public SampleFunctions Cv10;
  [SerializeField]
  public SampleFunctions Cv11;
  [SerializeField]
  public SampleFunctions Cv12;
  [SerializeField]
  public SampleFunctions Cv13;
  [SerializeField]
  public SampleFunctions Cv14;
  [SerializeField]
  public SampleFunctions Cv15;





//Labels for Main questions
string blank = "No Sample";
string q0_0 = "No Sample";
string q1_0 = "Sample-1: \n Plastic (ABS)";
string q2_0 = "Sample-1: \n Plastic (ABS)";
string q3_0 = "Sample-1: \n Plastic (ABS)";
string q4_0 = "Sample-1: \n Plastic (ABS)";
string q5_0 = "Sample-1: \n Plastic (ABS)";
string q6_0 = "Sample-1: \n Plastic (ABS)";
string q6pt1_0 = "Sample-1: \n Plastic (ABS)";
string q7_0 = "Sample-1: \n Plastic (ABS)";
string q8_0 = "Sample-1: \n Plastic (ABS)";
string q9_0 = "Sample-1: \n Plastic (ABS)";
string q10_0 = "No Sample";
string q11_0 = "No Sample";
string q12_0 = "No Sample";
string q13_0 = "No Sample";
string q14_0 = "Sample-1: \n Rubber";
string q14pt1_0 = "Sample-1: \n Rubber";
string q15_0 = "Sample-1: \n Rubber";
string q16_0 = "Sample-1: \n Rubber";
string q16_1 = "Sample-2: \n Glass";
string q17_0 = "Sample-1: \n Rubber";
string q17_1 = "Sample-2: \n Glass";
string q18_0 = "No Sample";
string q19_0 = "Sample-1: \n Foam (EPS)";
string q19pt1_0 = "Sample-1: \n Foam (EPS)";
string q19pt2_0 = "Sample-1: \n Steel";
string q19pt2_1 = "Sample-2: \n Copper";
string q20_0 = "Sample-1: \n Steel";
string q20_1 = "Sample-2: \n High-Carbon \n Steel";
string q20_2 = "Sample-3: \n Stainless \n Steel";
string q21_0 = "No Sample";
string q22_0 = "Sample-1: \n Plastic (PLA)";
string q23_0 = "Sample-1: \n Plastic (PLA)";
string q24_0 = "Sample-1: \n Rubber";
string q24_1 = "Sample-2: \n Gold";
string q24_2 = "Sample-3: \n Steel";
string q25_0 = "Sample-1: \n Rubber";
string q25_1 = "Sample-2: \n Gold";
string q25_2 = "Sample-3: \n Steel";
string q26_0 = "No Sample";
string q27_0 = "Sample-1: \n Concrete";
string q28_0 = "Sample-1: \n Concrete";
string q29_0 = "Sample-1: \n Concrete";
string q30_0 = "Sample-1: \n Concrete";
string q31_0 = "Sample-1: \n Concrete";
string q32_0 = "No Sample";
string q33_0 = "No Sample";
string q34_0 = "Sample-1: \n Gold";
string q34_1 = "Sample-2: \n Aluminum";
string q35_0 = "Sample-1: \n Gold";
string q35_1 = "Sample-2: \n Aluminum";
string q36_0 = "No Sample";
string q37_0 = "Sample-1: \n Aluminum";
string q37_1 = "Sample-2: \n Unknown";
string q38_0 = "Sample-1: \n Gold";
string q38_1 = "Sample-2: \n Unknown";
string q39_0 = "Sample-1: \n Aluminum";
string q39_1 = "Sample-2: \n Tin";
string q39_2 = "Sample-3: \n Unknown";
string q40_0 = "Sample-1: \n Factory Tin";
string q40_1 = "Sample-2: \n Tin";
string q40_2 = "Sample-3: \n Tin";
string q41_0 = "No Sample";

string cond0_0 = "Sample-1: \n Emerald";
string cond1_0 = "Sample-1: \n Copper";
string cond1_1 = "Sample-2: \n Gold";
string cond2_0 = "Sample-1: \n Plastic (PLA)";
string cond2_1 = "Sample-2: \n Plastic (ABS)";
string cond3_0 = "Sample-1: \n Plastic (PLA)";
string cond3_1 = "Sample-2: \n Plastic (ABS)";
string cond4_0 = "Sample-1: \n Rubber";
string cond4_1 = "Sample-2: \n Steel";
string cond4_2 = "Sample-3: \n Gold";
string cond4_3 = "Sample-4: \n Copper";
string cond5_0 = "Sample-1: \n Rubber";
string cond5_1 = "Sample-2: \n Steel";
string cond5_2 = "Sample-3: \n Gold";
string cond5_3 = "Sample-4: \n Copper";
string cond6_0 = "Sample-1: \n Rubber";
string cond6_1 = "Sample-2: \n Steel";
string cond6_2 = "Sample-3: \n Gold";
string cond6_3 = "Sample-4: \n Copper";
string cond7_0 = "Sample-1: \n Copper";
string cond7_1 = "Sample-2: \n Steel";
string cond7_2 = "Sample-3: \n Tin";
string cond8_0 = "No Sample";
string cond9_0 = "No Sample";
string cond10_0 = "No Sample";
string cond10pt1_0 = "Sample-1: \n Copper";
string cond10pt1_1 = "Sample-2: \n Steel";
string cond10pt1_2 = "Sample-3: \n Tin";
string cond11_0 = "Sample-1: \n Copper";
string cond11_1 = "Sample-2: \n Steel";
string cond11_2 = "Sample-3: \n Tin";
string cond12_0 = "Sample-1: \n Steel";
string cond12_1 = "Sample-2: \n Copper";
string cond12_2 = "Sample-3: \n Brass";
string cond13_0 = "Sample-1: \n Steel";
string cond13_1 = "Sample-2: \n Copper";
string cond13_2 = "Sample-3: \n Brass";


string tens0_0 = "Sample-1: \n Plastic (PP)";
string tens1_0 = "Sample-1: \n Steel \n (Martensite)";
string tens1_1 = "Sample-2: \n Steel \n (Spheroidite)";
string tens1_2 = "Sample-3: \n Steel \n (Pearlite)";
string tens2_0 = "Sample-1: \n Steel \n (Martensite)";
string tens2_1 = "Sample-2: \n Steel \n (Spheroidite)";
string tens2_2 = "Sample-3: \n Steel \n (Pearlite)";
string tens3_0 = "Sample-1: \n NanoSteel";
string tens3_1 = "Sample-2: \n Steel \n (Pearlite)";
string tens3_2 = "Sample-3: \n Steel \n (Martensite)";
string tens4_0 = "Sample-1: \n NanoSteel";
string tens4_1 = "Sample-2: \n Steel \n (Pearlite)";
string tens4_2 = "Sample-3: \n Steel \n (Martensite)";
string tens5_0 = "Sample-1: \n copper";
string tens5_1 = "Sample-2: \n Steel \n (Pearlite)";
string tens5_2 = "Sample-3: \n Steel \n (Martensite)";
string tens5_3 = "Sample-4: \n Gold";
string tens6_0 = "Sample-1: \n copper";
string tens6_1 = "Sample-2: \n Steel \n (Pearlite)";
string tens6_2 = "Sample-3: \n Steel \n (Martensite)";
string tens6_3 = "Sample-4: \n Gold";
string tens8_0 = "Sample-1: \n Rubber";
string tens8_1 = "Sample-2: \n Plastic \n (PLA)";
string tens8_2 = "Sample-3: \n Rubber \n (Volcanized)";
string tens8_3 = "Sample-4: \n Putty";
string tens9_0 = "Sample-1: \n Rubber";
string tens9_1 = "Sample-2: \n Plastic \n (PLA)";
string tens9_2 = "Sample-3: \n Rubber \n (Volcanized)";
string tens9_3 = "Sample-4: \n Putty";
string tens10_0 = "Sample-1: \n  Plastic \n (ABS)";
string tens10_1 = "Sample-2: \n Steel \n (Pearlite)";
string tens10_2 = "Sample-3: \n Rubber \n (Volcanized)";
string tens11_0 = " No Sample";

string liq0_0 = "Sample-1: \n Wire steel";
string liq1_0 = "Sample-1: \n Plastic (FEP)";
string liq2_0 = "Sample-1: \n Wire steel";
string liq2_1 = "Sample-2: \n Wire steel (corroded)";
string liq3_0 = "Sample-1: \n Wire steel";
string liq3_1 = "Sample-2: \n Wire steel (corroded)";
string liq4_0 = "Sample-1: \n Wire steel";
string liq4_1 = "Sample-2: \n Wire steel (corroded)";
string liq4pt1_0 = "Sample-1: \n Wire steel (corroded)";
string liq4pt1_1 = "Sample-2: \n Wire steel";
string liq4pt1_2 = "Sample-3: \n Wire steel (corroded)";
string liq5_0 = "Sample-1: \n Iron Alloy 1";
string liq5_1 = "Sample-2: \n Iron Alloy 2";
string liq5_2 = "Sample-3: \n Iron Alloy 3";
string liq6_0 = "Sample-1: \n Iron Alloy 1";
string liq6_1 = "Sample-2: \n Iron Alloy 2";
string liq6_2 = "Sample-3: \n Iron Alloy 3";
string liq7_0 = "Sample-1: \n Iron Alloy 1";
string liq7_1 = "Sample-2: \n Iron Alloy 2";
string liq7_2 = "Sample-3: \n Iron Alloy 3";
string liq8_0 = "Sample-1: \n Iron Alloy 1";
string liq8_1 = "Sample-2: \n Iron Alloy 2";
string liq8_2 = "Sample-3: \n Iron Alloy 3";
string liq9_0 = "Sample-1: \n Iron Alloy 1";
string liq9_1 = "Sample-2: \n Iron Alloy 2";
string liq9_2 = "Sample-3: \n Iron Alloy 3";
string liq10_0 = "Sample-1: \n Iron Alloy 1";
string liq10_1 = "Sample-2: \n Iron Alloy 2";
string liq10_2 = "Sample-3: \n Iron Alloy 3";
string liq11_0 = "Sample-1: \n Iron Alloy 1";
string liq11_1 = "Sample-2: \n Iron Alloy 2";
string liq11_2 = "Sample-3: \n Iron Alloy 3";

string f0_0 = "Sample-1: \n Plastic \n (PLA)";
string f1_0 = "Sample-1: \n Rubber";
string f1_1 = "Sample-2: \n Rubber";
string f1_2 = "Sample-3: \n Rubber";
string f2_0 = "Sample-1: \n Rubber";
string f2_1 = "Sample-2: \n Rubber";
string f2_2 = "Sample-3: \n Rubber";
string f3_0 = "Sample-1: \n Rubber";
string f3_1 = "Sample-2: \n Rubber";
string f3_2 = "Sample-3: \n Rubber";
string f4_0 = "Sample-1: \n Rubber";
string f4_1 = "Sample-2: \n Rubber";
string f4_2 = "Sample-3: \n Rubber";
string f5_0 = "Sample-1: \n Carbon";
string f5_1 = "Sample-2: \n Metal";
string f5_2 = "Sample-3: \n Ceramic";
string f6_0 = "Sample-1: \n Carbon";
string f6_1 = "Sample-2: \n Metal";
string f6_2 = "Sample-3: \n Ceramic";
string f7_0 = "Sample-1: \n Carbon";
string f7_1 = "Sample-2: \n Metal";
string f7_2 = "Sample-3: \n Ceramic";
string f8_0 = "Sample-1: \n Ceramic";
string f8_1 = "Sample-2: \n Ceramic";
string f8_2 = "Sample-3: \n Ceramic";
string f8_3 = "Sample-4: \n Ceramic";
string f9_0 = "No Sample";

string comp0_0 = "Sample-1: \n Concrete";
string comp0_1 = "Sample-2: \n Concrete";
string comp0_2 = "Sample-3: \n Concrete";
string comp1_0 = "Sample-1: \n Concrete";
string comp1_1 = "Sample-2: \n Steel";
string comp1_2 = "Sample-3: \n Aluminum";
string comp2_0 = "Sample-1: \n Concrete";
string comp2_1 = "Sample-2: \n Steel";
string comp2_2 = "Sample-3: \n Aluminum";
string comp3_0 = "Sample-1: \n Nylon Fibers";
string comp3_1 = "Sample-2: \n Glass Fibers";
string comp3_2 = "Sample-2: \n Rebar";
string comp4_0 = "Sample-1: \n Concrete";
string comp4_1 = "Sample-2: \n Rebar";
string comp5_0 = "Sample-1: \n Concrete";
string comp5_1 = "Sample-2: \n Rebar";
string comp6_0 = "Sample-1: \n Concrete";
string comp6_1 = "Sample-2: \n Rebar";
string comp7_0 = "Sample-1: \n Concrete";
string comp7_1 = "Sample-2: \n Rebar";
string comp8_0 = "Sample-1: \n Concrete";
string comp8_1 = "Sample-2: \n Rebar";
string comp9_0 = "Sample-1: \n Concrete";
string comp9_1 = "Sample-2: \n Rebar";
string comp10_0 = "Sample-1: \n Concrete";
string comp10_1 = "Sample-2: \n Rebar";
string comp11_0 = "Sample-1: \n Concrete";
string comp11_1 = "Sample-2: \n Rebar";

string cvn0_0 = "Sample-1: \n Ceramic";
string cvn0_1 = "Sample-2: \n Ceramic";
string cvn0_2 = "Sample-3: \n Ceramic";
string cvn0_3 = "Sample-4: \n Ceramic";
string cvn1_0 = "Sample-1: \n Ceramic";
string cvn1_1 = "Sample-2: \n Ceramic";
string cvn1_2 = "Sample-3: \n Ceramic";
string cvn1_3 = "Sample-4: \n Ceramic";
string cvn2_0 = "Sample-1: \n Ceramic";
string cvn2_1 = "Sample-2: \n Ceramic";
string cvn2_2 = "Sample-3: \n Ceramic";
string cvn2_3 = "Sample-4: \n Ceramic";
string cvn3_0 = "Sample-1: \n Ceramic";
string cvn3_1 = "Sample-2: \n Ceramic";
string cvn3_2 = "Sample-3: \n Ceramic";
string cvn3_3 = "Sample-4: \n Ceramic";
string cvn4_0 = "Sample-1: \n Ceramic";
string cvn4_1 = "Sample-2: \n Ceramic";
string cvn5_0 = "Sample-1: \n Ceramic";
string cvn5_1 = "Sample-2: \n Ceramic";
string cvn6_0 = "Sample-1: \n Aluminum";
string cvn6_1 = "Sample-2: \n Aluminum";
string cvn7_0 = "Sample-1: \n Steel";
string cvn7_1 = "Sample-2: \n Steel";
string cvn8_0 = "Sample-1: \n Porcelain";
string cvn8_1 = "Sample-2: \n Porcelain";
string cvn9_0 = "Sample-1: \n Steel";
string cvn9_1 = "Sample-2: \n Steel";
string cvn10_0 = "Sample-1: \n Steel";
string cvn10_1 = "Sample-2: \n Steel";
string cvn11_0 = "Sample-1: \n Notchless Steel";
string cvn12_0 = "Sample-1: \n Notched Steel";
string cvn13_0 = "Sample-1: \n Concrete";
string cvn13_1 = "Sample-2: \n Rebar";
string cvn14_0 = "Sample-1: \n Concrete";
string cvn14_1 = "Sample-2: \n Rebar";
string cvn15_0 = "Sample-1: \n Concrete";
string cvn15_1 = "Sample-2: \n Rebar \n Reinforced \n Concrete";
string cvn16_0 = "Sample-1: \n Concrete";
string cvn16_1 = "Sample-2: \n Fiber \n Reinforced \n Concrete";
string cvn17_0 = "Sample-1: \n Concrete";
string cvn17_1 = "Sample-2: \n Fiber \n Reinforced \n Concrete";
string cvn17_2 = "Sample-2: \n Rebar and fiber \n Reinforced \n Concrete";

string x0_0 = "Sample-1: \n Baseline-Aluminum";
string x0_1 = "Sample-2: \n Unknown";
string x0_2 = "Sample-3: \n Unknown";
string x0_3 = "Sample-4: \n Unknown";
string x0_4 = "Sample-5: \n Unknown";
string x1_0 = "Sample-1: \n Baseline-Aluminum";
string x1_1 = "Sample-2: \n Unknown";
string x1_2 = "Sample-3: \n Unknown";
string x1_3 = "Sample-4: \n Unknown";
string x1_4 = "Sample-5: \n Unknown";
string x2_0 = "Sample-1: \n Baseline-Steel";
string x2_1 = "Sample-2: \n Treated Steel";
string x2_2 = "Sample-3: \n Treated Steel";
string x2_3 = "Sample-4: \n Treated Steel";
string x3_0 = "Sample-1: \n Alpha-Aluminum";
string x3_1 = "Sample-2: \n Beta-Aluminum";
string x3_2 = "Sample-3: \n Unknown Alloy";
string x3_3 = "Sample-4: \n Unknown Alloy";
string x3_4 = "Sample-5: \n Unknown Alloy";
string x4_0 = "Sample-1: \n Stainless Steel";
string x4_1 = "Sample-2: \n Chromium";
string x4_2 = "Sample-3: \n Unknown Alloy";
string x4_3 = "Sample-4: \n Unknown Alloy";
string x4_4 = "Sample-5: \n Unknown Alloy";
string x5_0 = "Sample-1: \n Factory Aluminum";
string x5_1 = "Sample-2: \n Unknown Alloy";
string x5_2 = "Sample-3: \n Unknown Alloy";
string x5_3 = "Sample-4: \n Unknown Alloy";
string x6_0 = "Sample-1: \n Beta Brass";
string x6_1 = "Sample-2: \n Unknown Alloy";
string x6_2 = "Sample-3: \n Unknown Alloy";
string x6_3 = "Sample-4: \n Unknown Alloy";
string x7_0 = "Sample-1: \n Baseline-Ceramic";
string x7_1 = "Sample-2: \n Unknown Ceramic";
string x8_0 = "Sample-1: \n Fired Ceramic";
string x8_1 = "Sample-2: \n Unfired Ceramic \n (Clay)";
string x8_2 = "Sample-3: \n Unknown Ceramic";

int curIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
      curIdx = mainIdx;
 //Lists of string labels
      List<string> Q0 = new List<string>{q0_0, blank, blank, blank, blank };
      List<string> Q0pt1 = new List<string>{q0_0, blank, blank, blank, blank };
      List<string> Q1 = new List<string>{q1_0, blank, blank, blank, blank };
      List<string> Q2 = new List<string>{q2_0, blank, blank, blank, blank };
      List<string> Q3 = new List<string>{q3_0, blank, blank, blank, blank };
      List<string> Q4 = new List<string>{q4_0, blank, blank, blank, blank };
      List<string> Q5 = new List<string>{q5_0, blank, blank, blank, blank };
      List<string> Q6 = new List<string>{q6_0, blank, blank, blank, blank };
      List<string> Q6pt1 = new List<string>{q6pt1_0, blank, blank, blank, blank };
      List<string> Q7 = new List<string>{q7_0, blank, blank, blank, blank };
      List<string> Q8 = new List<string>{q8_0, blank, blank, blank, blank };
      List<string> Q9 = new List<string>{q9_0, blank, blank, blank, blank };
      List<string> Q10 = new List<string>{q10_0, blank, blank, blank, blank };
      List<string> Q11 = new List<string>{q11_0, blank, blank, blank, blank };
      List<string> Q12 = new List<string>{q12_0, blank, blank, blank, blank };
      List<string> Q13 = new List<string>{q13_0, blank, blank, blank, blank };
      List<string> Q14 = new List<string>{q14_0, blank, blank, blank, blank };
      List<string> Q14pt1 = new List<string>{q14pt1_0, blank, blank, blank, blank };
      List<string> Q15 = new List<string>{q15_0, blank, blank, blank, blank };
      List<string> Q16 = new List<string>{q16_0, q16_1, blank, blank, blank };
      List<string> Q17 = new List<string>{q17_0, q17_1, blank, blank, blank };
      List<string> Q18 = new List<string>{q18_0, blank, blank, blank, blank };
      List<string> Q19 = new List<string>{q19_0, blank, blank, blank, blank };
      List<string> Q19pt1 = new List<string>{q19pt1_0, blank, blank, blank, blank };
      List<string> Q19pt2 = new List<string>{q19pt2_0, q19pt2_1, blank, blank, blank };
      List<string> Q20 = new List<string>{q20_0, q20_1, q20_2, blank, blank };
      List<string> Q21 = new List<string>{q21_0, blank, blank, blank, blank };
      List<string> Q22 = new List<string>{q22_0, blank, blank, blank, blank };
      List<string> Q23 = new List<string>{q23_0, blank, blank, blank, blank };
      List<string> Q24 = new List<string>{q24_0, q24_1, q24_2, blank, blank };
      List<string> Q25 = new List<string>{q25_0, q25_1, q25_2, blank, blank };
      List<string> Q26 = new List<string>{q26_0, blank, blank, blank, blank };
      List<string> Q27 = new List<string>{q27_0, blank, blank, blank, blank };
      List<string> Q28 = new List<string>{q28_0, blank, blank, blank, blank };
      List<string> Q29 = new List<string>{q29_0, blank, blank, blank, blank };
      List<string> Q30 = new List<string>{q30_0, blank, blank, blank, blank };
      List<string> Q31 = new List<string>{q31_0, blank, blank, blank, blank };
      List<string> Q32 = new List<string>{q32_0, blank, blank, blank, blank };
      List<string> Q33 = new List<string>{q33_0, blank, blank, blank, blank };
      List<string> Q34 = new List<string>{q34_0, q34_1, blank, blank, blank };
      List<string> Q35 = new List<string>{q35_0, q35_1, blank, blank, blank };
      List<string> Q36 = new List<string>{q36_0, blank, blank, blank, blank };
      List<string> Q37 = new List<string>{q37_0, q37_1, blank, blank, blank };
      List<string> Q38 = new List<string>{q38_0, q38_1, blank, blank, blank };
      List<string> Q39 = new List<string>{q39_0, q39_1, q39_2, blank, blank };
      List<string> Q40 = new List<string>{q40_0, q40_1, q40_2, blank, blank };
      List<string> Q41 = new List<string>{q41_0, blank, blank, blank, blank };

      List<string> Qc0 = new List<string>{cond0_0, blank, blank, blank, blank };
      List<string> Qc1 = new List<string>{cond1_0, cond1_1, blank, blank, blank };
      List<string> Qc2 = new List<string>{cond2_0, cond2_1, blank, blank, blank };
      List<string> Qc3 = new List<string>{cond3_0, cond3_1, blank, blank, blank };
      List<string> Qc4 = new List<string>{cond4_0, cond4_1, cond4_2, cond4_3, blank };
      List<string> Qc5 = new List<string>{cond5_0, cond5_1, cond5_2, cond5_3, blank };
      List<string> Qc6 = new List<string>{cond6_0, cond6_1, cond6_2, cond6_3, blank };
      List<string> Qc7 = new List<string>{cond7_0, cond7_1, cond7_2, blank, blank };
      List<string> Qc8 = new List<string>{cond8_0, blank, blank, blank, blank };
      List<string> Qc9 = new List<string>{cond9_0, blank, blank, blank, blank };
      List<string> Qc10 = new List<string>{cond10_0, blank, blank, blank, blank };
      List<string> Qc10pt1 = new List<string>{cond10pt1_0, cond10pt1_1, cond10pt1_2, blank, blank };
      List<string> Qc11 = new List<string>{cond11_0, cond11_1, blank, blank, blank };
      List<string> Qc12 = new List<string>{cond12_0, cond12_1, cond12_2, blank, blank };
      List<string> Qc13 = new List<string>{cond13_0, cond13_1, cond13_2, blank, blank };

      List<string> Qt0 = new List<string>{tens0_0, blank, blank, blank, blank };
      List<string> Qt1 = new List<string>{tens1_0, tens1_1, tens1_2, blank, blank };
      List<string> Qt2 = new List<string>{tens2_0, tens2_1, tens2_2, blank, blank };
      List<string> Qt3 = new List<string>{tens3_0, tens3_1, tens3_2, blank, blank };
      List<string> Qt4 = new List<string>{tens4_0, tens4_1, tens4_2, blank, blank };
      List<string> Qt5 = new List<string>{tens5_0, tens5_1, tens5_2, tens5_3, blank };
      List<string> Qt6 = new List<string>{tens6_0, tens6_1, tens6_2, tens6_3, blank };
      List<string> Qt8 = new List<string>{tens8_0, tens8_1, tens8_2, tens8_3, blank };
      List<string> Qt9 = new List<string>{tens9_0, tens9_1, tens9_2, tens9_3, blank };
      List<string> Qt10 = new List<string>{tens10_0, tens10_1, tens10_2, blank, blank };
      List<string> Qt11 = new List<string>{tens11_0, blank, blank, blank, blank };


      List<string> Qliq0 = new List<string>{liq0_0, blank, blank, blank, blank };
      List<string> Qliq1 = new List<string>{liq1_0, blank, blank, blank, blank };
      List<string> Qliq2 = new List<string>{liq2_0, liq2_1, blank, blank, blank };
      List<string> Qliq3 = new List<string>{liq3_0, liq3_1, blank, blank, blank };
      List<string> Qliq4 = new List<string>{liq4_0, liq4_1, blank, blank, blank };
      List<string> Qliq4pt1 = new List<string>{liq4pt1_0, liq4pt1_1, liq4pt1_2, blank, blank };
      List<string> Qliq5 = new List<string>{liq5_0, liq5_1, liq5_2, blank, blank };
      List<string> Qliq6 = new List<string>{liq6_0, liq6_1, liq6_2, blank, blank };
      List<string> Qliq7 = new List<string>{liq7_0, liq7_1, liq7_2, blank, blank };
      List<string> Qliq8 = new List<string>{liq8_0, liq8_1, liq8_2, blank, blank };
      List<string> Qliq9 = new List<string>{liq9_0, liq9_1, liq9_2, blank, blank };
      List<string> Qliq10 = new List<string>{liq10_0, liq10_1, liq10_2, blank, blank };
      List<string> Qliq11 = new List<string>{liq11_0, liq11_1, liq11_2, blank, blank };

      List<string> Qf0 = new List<string>{f0_0, blank, blank, blank, blank };
      List<string> Qf1 = new List<string>{f1_0, f1_1, f1_2, blank, blank };
      List<string> Qf2 = new List<string>{f2_0, f2_1, f2_2, blank, blank };
      List<string> Qf3 = new List<string>{f3_0, f3_1, f3_2, blank, blank };
      List<string> Qf4 = new List<string>{f4_0, f4_1, f4_2, blank, blank };
      List<string> Qf5 = new List<string>{f5_0, f5_1, f5_2, blank, blank };
      List<string> Qf6 = new List<string>{f6_0, f6_1, f6_2, blank, blank };
      List<string> Qf7 = new List<string>{f7_0, f7_1, f7_2, blank, blank };
      List<string> Qf8 = new List<string>{f8_0, f8_1, f8_2, f8_3, blank };
      List<string> Qf9 = new List<string>{ f9_0, blank, blank, blank, blank };

      List<string> Qcomp0 = new List<string>{comp0_0, comp0_1, comp0_2, blank, blank };
      List<string> Qcomp1 = new List<string>{comp1_0, comp1_1, comp1_2, blank, blank };
      List<string> Qcomp2 = new List<string>{comp2_0, comp2_1, comp2_2, blank, blank };
      List<string> Qcomp3 = new List<string>{comp3_0, comp3_1, comp3_2, blank, blank };
      List<string> Qcomp4 = new List<string>{comp4_0, comp4_1, blank, blank, blank };
      List<string> Qcomp5 = new List<string>{comp5_0, comp5_1, blank, blank, blank };
      List<string> Qcomp6 = new List<string>{comp6_0, comp6_1, blank, blank, blank };
      List<string> Qcomp7 = new List<string>{comp7_0, comp7_1, blank, blank, blank };
      List<string> Qcomp8 = new List<string>{comp8_0, comp8_1, blank, blank, blank };
      List<string> Qcomp9 = new List<string>{comp9_0, comp9_1, blank, blank, blank };
      List<string> Qcomp10 = new List<string>{comp10_0, comp10_1, blank, blank, blank };
      List<string> Qcomp11 = new List<string>{comp11_0, comp11_1, blank, blank, blank };

      List<string> Qcvn0 = new List<string>{cvn0_0, cvn0_1, cvn0_2, cvn0_3, blank };
      List<string> Qcvn1 = new List<string>{cvn1_0, cvn1_1, cvn1_2, cvn1_3, blank };
      List<string> Qcvn2 = new List<string>{cvn2_0, cvn2_1, cvn2_2, cvn2_3, blank };
      List<string> Qcvn3 = new List<string>{cvn3_0, cvn3_1, cvn3_2, cvn3_3, blank };
      List<string> Qcvn4 = new List<string>{cvn4_0, cvn4_1, blank, blank, blank };
      List<string> Qcvn5 = new List<string>{cvn5_0, cvn5_1, blank, blank, blank };
      List<string> Qcvn6 = new List<string>{cvn6_0, cvn6_1, blank, blank, blank };
      List<string> Qcvn7 = new List<string>{cvn7_0, cvn7_1, blank, blank, blank };
      List<string> Qcvn8 = new List<string>{cvn8_0, cvn8_1, blank, blank, blank };
      List<string> Qcvn9 = new List<string>{cvn9_0, cvn9_1, blank, blank, blank };
      List<string> Qcvn10 = new List<string>{cvn10_0, cvn10_1, blank, blank, blank };
      List<string> Qcvn11 = new List<string>{cvn11_0, blank, blank, blank, blank };
      List<string> Qcvn12 = new List<string>{cvn12_0, blank, blank, blank, blank };
      List<string> Qcvn13 = new List<string>{cvn13_0, cvn13_1, blank, blank, blank };
      List<string> Qcvn14 = new List<string>{cvn14_0, cvn14_1, blank, blank, blank };
      List<string> Qcvn15 = new List<string>{cvn15_0, cvn15_1, blank, blank, blank };
      List<string> Qcvn16 = new List<string>{cvn16_0, cvn16_1, blank, blank, blank };
      List<string> Qcvn17 = new List<string>{cvn17_0, cvn17_1, cvn17_2, blank, blank };
      List<string> Qcvn18 = new List<string>{ blank, blank, blank, blank, blank };

      List<string> Qx0 = new List<string>{x0_0, x0_1, x0_2, x0_3, x0_4 };
      List<string> Qx1 = new List<string>{x1_0, x1_1, x1_2, x1_3, x1_4 };
      List<string> Qx2 = new List<string>{x2_0, x2_1, x2_2, x2_3, blank };
      List<string> Qx3 = new List<string>{x3_0, x3_1, x3_2, x3_3, x3_4 };
      List<string> Qx4 = new List<string>{x4_0, x4_1, x4_2, x4_3, x4_4 };
      List<string> Qx5 = new List<string>{x5_0, x5_1, x5_2, x5_3, blank };
      List<string> Qx6 = new List<string>{x6_0, x6_1, x6_2, x6_3, blank };
      List<string> Qx7 = new List<string>{x7_0, x7_1, blank, blank, blank };
      List<string> Qx8 = new List<string>{x8_0, x8_1, x8_2, blank, blank };
      List<string> Qx9 = new List<string>{ blank, blank, blank, blank, blank };


      // Start listing samples for each question
      // List<string> sampleMainLabels = new List<string>();
      List<SampleFunctions> samplesQ0 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ0pt1 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ1 = new List<SampleFunctions>{Mm1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ2 = new List<SampleFunctions>{Mm1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ3 = new List<SampleFunctions>{Mm1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ4 = new List<SampleFunctions>{Mm1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ5 = new List<SampleFunctions>{Mm1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ6 = new List<SampleFunctions>{Mm1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ6pt1 = new List<SampleFunctions>{Mm1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ7 = new List<SampleFunctions>{Mm1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ8 = new List<SampleFunctions>{Mm1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ9 = new List<SampleFunctions>{Mm1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ10 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ11 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ12 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ13 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ14 = new List<SampleFunctions>{Mt1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ14pt1 = new List<SampleFunctions>{Mt1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ15 = new List<SampleFunctions>{Mt1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ16 = new List<SampleFunctions>{Mt1, Mt2, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ17 = new List<SampleFunctions>{Mt1, Mt2, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ18 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ19 = new List<SampleFunctions>{Mt3, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ19pt1 = new List<SampleFunctions>{Mt3, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ19pt2 = new List<SampleFunctions>{Mt4, Mt5, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ20 = new List<SampleFunctions>{Mt4, Mt6, Mt7, blankSample, blankSample};
      List<SampleFunctions> samplesQ21 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ22 = new List<SampleFunctions>{Mt8, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ23 = new List<SampleFunctions>{Mt8, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ24 = new List<SampleFunctions>{Mt9, Mt10, Mt4, blankSample, blankSample};
      List<SampleFunctions> samplesQ25 = new List<SampleFunctions>{Mt9, Mt10, Mt4, blankSample, blankSample};
      List<SampleFunctions> samplesQ26 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ27 = new List<SampleFunctions>{Mc1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ28 = new List<SampleFunctions>{Mc1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ29 = new List<SampleFunctions>{Mt11, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ30 = new List<SampleFunctions>{Mc1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ31 = new List<SampleFunctions>{Mc1, Mt11, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ32 = new List<SampleFunctions>{Mc1, Mc2, Mc3, Mc4,blankSample};
      List<SampleFunctions> samplesQ33 = new List<SampleFunctions>{blankSample, blankSample, blankSample,blankSample, blankSample};
      List<SampleFunctions> samplesQ34 = new List<SampleFunctions>{Mcv1, Mcv2, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ35 = new List<SampleFunctions>{Mcv3, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ36 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ37 = new List<SampleFunctions>{Mx1, Mx2, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ38 = new List<SampleFunctions>{Mx3, Mx4, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ39 = new List<SampleFunctions>{Mx5, Mx7, Mx6, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQ40 = new List<SampleFunctions>{Mx5, Mx6, Mx7, blankSample, blankSample};
      List<SampleFunctions> samplesQ41 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      // List<SampleFunctions> samplesMainAlt = new List<SampleFunctions>();

      // List<string> sampleCondLabels = new List<string>();
      List<SampleFunctions> samplesQc0 = new List<SampleFunctions>{C1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQc1 = new List<SampleFunctions>{C2, C3, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQc2 = new List<SampleFunctions>{C4, C5, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQc3 = new List<SampleFunctions>{C4, C5, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQc4 = new List<SampleFunctions>{C6, C7, C8, C9, C10};
      List<SampleFunctions> samplesQc5 = new List<SampleFunctions>{C6, C7, C8, C9, C10};
      List<SampleFunctions> samplesQc6 = new List<SampleFunctions>{C6, C7, C8, C9, C10};
      List<SampleFunctions> samplesQc7 = new List<SampleFunctions>{C9, C7, C11, blankSample, blankSample};
      List<SampleFunctions> samplesQc8 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQc9 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQc10 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesQc10pt1 = new List<SampleFunctions>{C9, C7, C11, blankSample, blankSample};
      List<SampleFunctions> samplesQc11 = new List<SampleFunctions>{C9, C7, C11, blankSample, blankSample};
      List<SampleFunctions> samplesQc12 = new List<SampleFunctions>{C7, C9, C12, blankSample, blankSample};
      List<SampleFunctions> samplesQc13 = new List<SampleFunctions>{C7, C9, C12, blankSample, blankSample};
      // List<SampleFunctions> samplesCondAlt = new List<SampleFunctions>();

      // List<string> sampleTensLabels = new List<string>();
      List<SampleFunctions> samplesTens0 = new List<SampleFunctions>{T1, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesTens1 = new List<SampleFunctions>{T2, T3, T4, blankSample, blankSample};
      List<SampleFunctions> samplesTens2 = new List<SampleFunctions>{T2, T3, T4, blankSample, blankSample};
      List<SampleFunctions> samplesTens3 = new List<SampleFunctions>{T2, T4, T5, blankSample, blankSample};
      List<SampleFunctions> samplesTens4 = new List<SampleFunctions>{T5, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesTens5 = new List<SampleFunctions>{T2, T3, T4, T5, T6};
      List<SampleFunctions> samplesTens6 = new List<SampleFunctions>{T2, T3, T4, T6, blankSample};
      List<SampleFunctions> samplesTens7 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesTens8 = new List<SampleFunctions>{T7, T8, T9, T10, blankSample};
      List<SampleFunctions> samplesTens9 = new List<SampleFunctions>{T7, T8, T9, T10, blankSample};
      List<SampleFunctions> samplesTens10 = new List<SampleFunctions>{T11, T12, blankSample, blankSample, blankSample};
      // List<SampleFunctions> samplesTensAlt = new List<SampleFunctions>();

      // List<string> sampleLiqLabels = new List<string>();
      List<SampleFunctions> samplesLiq0 = new List<SampleFunctions>{T1, T6, T7, blankSample, blankSample};
      List<SampleFunctions> samplesLiq1 = new List<SampleFunctions>{T1, T6, T7, blankSample, blankSample};
      List<SampleFunctions> samplesLiq2 = new List<SampleFunctions>{T1, T6, T7, blankSample, blankSample};
      List<SampleFunctions> samplesLiq3 = new List<SampleFunctions>{T1, T6, T7, blankSample, blankSample};
      List<SampleFunctions> samplesLiq4 = new List<SampleFunctions>{T1, T6, T7, blankSample, blankSample};
      List<SampleFunctions> samplesLiq4pt1 = new List<SampleFunctions>{T1, T14, T15, blankSample, blankSample};
      List<SampleFunctions> samplesLiq5 = new List<SampleFunctions>{T16, T16b, T16c, blankSample, blankSample};
      List<SampleFunctions> samplesLiq6 = new List<SampleFunctions>{T16, T16b, T16c, blankSample, blankSample};
      List<SampleFunctions> samplesLiq7 = new List<SampleFunctions>{T16, T16b, T16c, blankSample, blankSample};
      List<SampleFunctions> samplesLiq8 = new List<SampleFunctions>{T16, T16b, T16c, blankSample, blankSample};
      List<SampleFunctions> samplesLiq9 = new List<SampleFunctions>{T16, T16b, T16c, blankSample, blankSample};
      List<SampleFunctions> samplesLiq10 = new List<SampleFunctions>{T16, T16b, T16c, blankSample, blankSample};
      List<SampleFunctions> samplesLiq11 = new List<SampleFunctions>{T16, T16b, T16c, blankSample, blankSample};


      List<SampleFunctions> samplesF0 = new List<SampleFunctions>{T17, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesF1 = new List<SampleFunctions>{T17, T18, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesF2 = new List<SampleFunctions>{T17, T18, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesF3 = new List<SampleFunctions>{T17, T18, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesF4 = new List<SampleFunctions>{T17, T18, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesF5 = new List<SampleFunctions>{T19, T20, T21, T22, blankSample};
      List<SampleFunctions> samplesF6 = new List<SampleFunctions>{T22, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesF7 = new List<SampleFunctions>{T22, blankSample, blankSample, blankSample, blankSample};
      List<SampleFunctions> samplesF8 = new List<SampleFunctions>{T22, T23, T24, blankSample, blankSample};


      // List<SampleFunctions> samplesLiq12 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      // List<SampleFunctions> samplesLiq13 = new List<SampleFunctions>{blankSample, blankSample, blankSample, blankSample, blankSample};
      // List<SampleFunctions> samplesLiqAlt = new List<SampleFunctions>();

      // List<string> sampleCompLabels = new List<string>();
      List<SampleFunctions> samplesComp = new List<SampleFunctions>();
      // List<SampleFunctions> samplesCompAlt = new List<SampleFunctions>();

      // List<string> sampleCVNLabels = new List<string>();
      List<SampleFunctions> samplesCVN = new List<SampleFunctions>();
      // List<SampleFunctions> samplesCVNAlt = new List<SampleFunctions>();

      // List<string> sampleXRDLabels = new List<string>();
      List<SampleFunctions> samplesXRD = new List<SampleFunctions>();
      // List<SampleFunctions> samplesXRDAlt = new List<SampleFunctions>();

      //LabelSet
    List<List<string>> mainSet =new List<List<string>>{Q0,Q0pt1,Q1,Q2,Q3, Q4, Q5, Q6,Q6pt1,Q7,Q8,Q9,Q10,Q11,Q12,Q13,Q14,Q14pt1,Q15,Q16,Q17,Q18,Q19,Q19pt1,Q19pt2,Q20,Q21,Q22,Q23,Q24,Q25,Q26,Q27,Q28,Q29,Q30,Q31,Q32, Q33, Q34, Q35,Q36,Q37,Q38,Q39,Q40,Q41};
      List<List<string>> condSet =new List<List<string>>{Qc0,Qc1,Qc2,Qc3, Qc4, Qc5, Qc6, Qc7, Qc8, Qc9, Qc10, Qc10pt1, Qc11, Qc12, Qc13};
      List<List<string>> tenSet =new List<List<string>>{Qt0,Qt1,Qt2,Qt3, Qt5, Qt6,  Qt8, Qt9, Qt10, Qliq0,Qliq1,Qliq2,Qliq3,Qliq4,Qliq4pt1,Qliq5,Qliq6,Qliq7,Qliq8,Qliq9,Qliq10,Qliq11, Qf0, Qf1 ,Qf2, Qf3, Qf4, Qf5, Qf6, Qf7, Qf8,};
      // List<List<string>> liqSet =new List<List<string>>{Qliq0,Qliq1,Qliq2,Qliq3};
      // List<List<string>> fSet =new List<List<string>>{Qf0,Qf1,Qf2,Qf3};
      List<List<string>> compSet=new List<List<string>>{Qcomp0,Qcomp1,Qcomp2,Qcomp3};
      List<List<string>> cvnSet =new List<List<string>>{Qcvn0,Qcvn1,Qcvn2,Qcvn3};
      List<List<string>> xrdSet =new List<List<string>>{Qx0,Qx1,Qx2,Qx3};

      //SampleSet
      List<List<SampleFunctions>> samplesMainSet = new List<List<SampleFunctions>>{samplesQ0, samplesQ0pt1, samplesQ1, samplesQ2, samplesQ3, samplesQ4, samplesQ5, samplesQ6, samplesQ6pt1, samplesQ7, samplesQ8,samplesQ9,samplesQ10,samplesQ11,samplesQ12,samplesQ13,samplesQ14,samplesQ14pt1,samplesQ15,samplesQ16,samplesQ17,samplesQ18,samplesQ19,samplesQ19pt1,samplesQ19pt2,samplesQ20,samplesQ21,samplesQ22,samplesQ23,samplesQ24,samplesQ25,samplesQ26,samplesQ27,samplesQ28,samplesQ29,samplesQ30,samplesQ31,samplesQ32, samplesQ33, samplesQ34, samplesQ35,samplesQ36,samplesQ37,samplesQ38,samplesQ39,samplesQ40,samplesQ41};
      List<List<SampleFunctions>> samplesCondSet = new List<List<SampleFunctions>>{samplesQc0, samplesQc1, samplesQc2, samplesQc3, samplesQc4,samplesQc5, samplesQc6, samplesQc7, samplesQc8, samplesQc9, samplesQc10, samplesQc10pt1, samplesQc11, samplesQc12};
      List<List<SampleFunctions>> samplesTensSet = new List<List<SampleFunctions>>{samplesTens0, samplesTens1,samplesTens2, samplesTens3,samplesTens4, samplesTens5,samplesTens6, samplesTens7,samplesTens8, samplesTens9,samplesTens10, samplesLiq0, samplesLiq1,samplesLiq2, samplesLiq3,samplesLiq4,samplesLiq4pt1, samplesLiq5,samplesLiq6, samplesLiq7,samplesLiq8, samplesLiq9,samplesLiq10, samplesLiq11, samplesF0, samplesF1, samplesF2, samplesF3, samplesF4, samplesF5, samplesF6, samplesF7, samplesF8};
      curSamples = samplesMainSet[0];

    sampleLib = new List<List<List<SampleFunctions>>>{samplesMainSet, samplesCondSet};
      SetSample();
    }

    public void SetSampleType(int q_type)
    {
      ResetGone();
      if (q_type == 0)
      {
        curIdx = mainIdx;
      }
      else if (q_type == 1)
      {
        curIdx = condIdx;
      }
      sampleType =q_type;
      SetSample();
    }

    public void SetSample()
    {
      Debug.Log("SetSample()");
      Debug.Log(sampleType);
      Debug.Log(curIdx);
      Debug.Log(sampleLib.ToString());
//           foreach (var item in sampleLib)
//     {
//       foreach (var item2 in item)
// {
//     Debug.Log(item2.ToString());
// }
//     }
      Debug.Log(sampleLib[0]);
      Reset();
      ResetGone();
      curSamples =sampleLib[sampleType][curIdx];
      LoadSample(sample1Spot, curSamples[0]);
      LoadSample(sample2Spot, curSamples[1]);
      LoadSample(sample3Spot, curSamples[2]);
      LoadSample(sample4Spot, curSamples[3]);
      LoadSample(sample5Spot, curSamples[4]);

    }

    public void LoadSample( Vector3 spot,SampleFunctions sample)
    {
      sample.transform.position = spot;
      sample.GetComponent<SampleFunctions>().sampleTempIndex = 0;
      if (sample.gameObject.GetComponent<SampleFunctions>().sampletype == 3){
        Debug.Log("small compression reset calling");
        sample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0);
      }
      // sample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0);
    }

    public void NextSample()
    {
      if (sampleType == 0)
      {
        mainIdx +=1;
      }
      if (sampleType == 1)
      {
        condIdx +=1;
      }
      if (sampleType == 2)
      {
        tensIdx +=1;
      }
      if (sampleType == 3)
      {
        compIdx +=1;
      }
      if (sampleType == 4)
      {
        CVNIdx +=1;
      }
      if (sampleType == 5)
      {
        XRDIdx +=1;
      }
      curIdx+= 1;
      SetSample();
    }

    public void Reset()
    {Debug.Log("reset calling");
      if (sampleType == 2)
      {
        TensileReset();
      }
        if (sampleType == 3)
        { Debug.Log("compression reset calling");
          CompressionReset();
        }
        if (sampleType == 4)
        {
          CVNReset();
        }
      LoadSample(sample1Spot, curSamples[0]);
      LoadSample(sample2Spot, curSamples[1]);
      LoadSample(sample3Spot, curSamples[2]);
      LoadSample(sample4Spot, curSamples[3]);
      LoadSample(sample5Spot, curSamples[4]);
    }

    public void ResetGone()
    {
      LoadSample(goneSpot, curSamples[0]);
      LoadSample(goneSpot, curSamples[1]);
      LoadSample(goneSpot, curSamples[2]);
      LoadSample(goneSpot, curSamples[3]);
      LoadSample(goneSpot, curSamples[4]);
    }

    void TensileReset()
    {
      foreach(SampleFunctions sample in curSamples);
      {
            List<GameObject> sampleParts = new List<GameObject>();
            GameObject bottomOfSample;
            GameObject topOfSample;
      foreach(Transform child in sample.GetComponent<Transform>())
      {
        sampleParts.Add(child.gameObject);
      }
      bottomOfSample = sampleParts[1];
      topOfSample = sampleParts[0];
      bottomOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,0);
      topOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,0);
      bottomOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1,0);
      topOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1,0);
      bottomOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(3,0);
      topOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(3,0);
      }
      }

    void CVNReset()
    {foreach(SampleFunctions sample in curSamples);
    {
          sample_alt = sample.detachedPair;
          sample_alt.transform.position = altloc;
          sampleL  = sample_alt.sampleLeft;
          sampleR  = sample_alt.sampleRight;
          sampleL.transform.position= altLloc;
          sampleR.transform.position= altRloc;
          joint = sampleL.GetComponent<FixedJoint>();
          joint.connectedBody = sampleR.GetComponent<Rigidbody>();
          joint.breakForce =sample_alt.breakForce;
          joint.breakTorque = sample_alt.breakForce;



    }

    }

        void CompressionReset()
    {foreach(SampleFunctions sample in curSamples);
    {
               sample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0);
                Debug.Log("compression reset");



    }

    }
}
