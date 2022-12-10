using System;
using System.Windows.Forms;
using DotFuzzy;

namespace YebesFuzzyLogic
{
    public partial class Form1 : Form
    {
        FuzzyEngine fe;

        // Input - Distance (m), Angle (degree), Output - Deviation (degree) 
        MembershipFunctionCollection distance, angle, deviation;
        LinguisticVariable myspeed, myangle, mythrottle;
        FuzzyRuleCollection myrules;
        

        public Form1()
        {
            InitializeComponent();
        }

    
        public void setMembers()
        {   
            // Range value of Distance [0.1, ..., 2.2]
            distance = new MembershipFunctionCollection();
            distance.Add(new MembershipFunction("VERY NEAR", 0.1, 0.8, 0.8, 0.8));
            distance.Add(new MembershipFunction("NEAR", 0.1, 0.8, 0.8, 1.5));
            distance.Add(new MembershipFunction("FAR", 0.8, 1.5, 1.5, 2.2));
            distance.Add(new MembershipFunction("VERY FAR", 1.5, 2.2, 2.2, 2.2));

            // Range value of Angle [-90, ..., 0, ..., 90]
            angle = new MembershipFunctionCollection();
            angle.Add(new MembershipFunction("LEFT", -90.0, -45.0, -45.0, -45.0));
            angle.Add(new MembershipFunction("AHEAD LEFT", -90.0, -45.0, -45.0, 0.0));
            angle.Add(new MembershipFunction("AHEAD", -45.0, 0.0, 0.0, 45.0));
            angle.Add(new MembershipFunction("AHEAD RIGHT", 0.0, 45.0, 45.0, 90.0));
            angle.Add(new MembershipFunction("RIGHT", 45.0, 90.0, 90.0, 90.0));

            // Range value of Deviation [-90, ..., 0, ..., 90]
            deviation = new MembershipFunctionCollection();
            deviation.Add(new MembershipFunction("LEFT", -90.0, -45.0, -45.0, -45.0));
            deviation.Add(new MembershipFunction("AHEAD LEFT", -90.0, -45.0, -45.0, 0.0));
            deviation.Add(new MembershipFunction("AHEAD", -45.0, 0.0, 0.0, 45.0));
            deviation.Add(new MembershipFunction("AHEAD RIGHT", 0.0, 45.0, 45.0, 90.0));
            deviation.Add(new MembershipFunction("RIGHT", 45.0, 90.0, 90.0, 90.0));
        }

        public void setRules()
        {
          myrules = new FuzzyRuleCollection();
          myrules.Add(new FuzzyRule("IF (SPEED IS HIGH) AND (ANGLE IS UP) THEN THROTTLE IS LM"));
          myrules.Add(new FuzzyRule("IF (SPEED IS HIGH) AND (ANGLE IS LEVEL) THEN THROTTLE IS LM"));
          myrules.Add(new FuzzyRule("IF (SPEED IS HIGH) AND (ANGLE IS DOWN) THEN THROTTLE IS LOW"));
          myrules.Add(new FuzzyRule("IF (SPEED IS OK) AND (ANGLE IS UP) THEN THROTTLE IS HM"));
          myrules.Add(new FuzzyRule("IF (SPEED IS OK) AND (ANGLE IS LEVEL) THEN THROTTLE IS MED"));
          myrules.Add(new FuzzyRule("IF (SPEED IS OK) AND (ANGLE IS DOWN) THEN THROTTLE IS LM"));
          myrules.Add(new FuzzyRule("IF (SPEED IS LOW) AND (ANGLE IS UP) THEN THROTTLE IS HIGH"));
          myrules.Add(new FuzzyRule("IF (SPEED IS OK) AND (ANGLE IS LEVEL) THEN THROTTLE IS HM"));
          myrules.Add(new FuzzyRule("IF (SPEED IS OK) AND (ANGLE IS DOWN) THEN THROTTLE IS HM"));
        }

        public void setFuzzyEngine()
        {
            fe = new FuzzyEngine();
            fe.LinguisticVariableCollection.Add(myspeed);
            fe.LinguisticVariableCollection.Add(myangle);
            fe.LinguisticVariableCollection.Add(mythrottle);
            fe.FuzzyRuleCollection = myrules;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void defuziffyToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setMembers();
            setRules();
            //setFuzzyEngine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myspeed.InputValue=(Convert.ToDouble(textBox1.Text));
            myspeed.Fuzzify("OK");
            
            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            myangle.InputValue = (Convert.ToDouble(textBox2.Text));
            myangle.Fuzzify("LEVEL");
            
        }

        public void fuziffyvalues()
        {
            myspeed.InputValue = (Convert.ToDouble(textBox1.Text));
            myspeed.Fuzzify("LOW");
            myangle.InputValue = (Convert.ToDouble(textBox2.Text));
            myangle.Fuzzify("DOWN");
        
        }
        public void defuzzy()
        {
            setFuzzyEngine();
            fe.Consequent = "THROTTLE";
            textBox3.Text = "" + fe.Defuzzify();
        }

        public void computenewspeed()
        {

            double oldspeed = Convert.ToDouble(textBox1.Text);
            double oldthrottle = Convert.ToDouble(textBox3.Text);
            double oldangle = Convert.ToDouble(textBox2.Text);
            double newspeed = ((1 - 0.1) * (oldspeed)) + (oldthrottle - (0.1 * oldangle));
            textBox1.Text = "" + newspeed;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setFuzzyEngine();
            fe.Consequent = "THROTTLE";
            textBox3.Text = "" + fe.Defuzzify();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            computenewspeed();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            setMembers();
            setRules();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fuziffyvalues();
            defuzzy();
            computenewspeed();
        }

       
    }
}
