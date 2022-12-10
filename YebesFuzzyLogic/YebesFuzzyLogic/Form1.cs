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
        LinguisticVariable myDistance, myAngle, myDeviation;
        FuzzyRuleCollection myrules;
        

        public Form1()
        {
            InitializeComponent();
        }

    
        public void setMembers()
        {   
            // Range value of Distance [0.1, ..., 2.2]
            distance = new MembershipFunctionCollection();
            distance.Add(new MembershipFunction("VERY_NEAR", 0.1, 0.8, 0.8, 0.8));
            distance.Add(new MembershipFunction("NEAR", 0.1, 0.8, 0.8, 1.5));
            distance.Add(new MembershipFunction("FAR", 0.8, 1.5, 1.5, 2.2));
            distance.Add(new MembershipFunction("VERY_FAR", 1.5, 2.2, 2.2, 2.2));
            myDistance = new LinguisticVariable("DISTANCE", distance);

            // Range value of Angle [-90, ..., 0, ..., 90]
            angle = new MembershipFunctionCollection();
            angle.Add(new MembershipFunction("LEFT", -90.0, -45.0, -45.0, -45.0));
            angle.Add(new MembershipFunction("AHEAD_LEFT", -90.0, -45.0, -45.0, 0.0));
            angle.Add(new MembershipFunction("AHEAD", -45.0, 0.0, 0.0, 45.0));
            angle.Add(new MembershipFunction("AHEAD_RIGHT", 0.0, 45.0, 45.0, 90.0));
            angle.Add(new MembershipFunction("RIGHT", 45.0, 90.0, 90.0, 90.0));
            myAngle = new LinguisticVariable("ANGLE", angle);

            // Range value of Deviation [-90, ..., 0, ..., 90]
            deviation = new MembershipFunctionCollection();
            deviation.Add(new MembershipFunction("LEFT", -90.0, -45.0, -45.0, -45.0));
            deviation.Add(new MembershipFunction("AHEAD_LEFT", -90.0, -45.0, -45.0, 0.0));
            deviation.Add(new MembershipFunction("AHEAD", -45.0, 0.0, 0.0, 45.0));
            deviation.Add(new MembershipFunction("AHEAD_RIGHT", 0.0, 45.0, 45.0, 90.0));
            deviation.Add(new MembershipFunction("RIGHT", 45.0, 90.0, 90.0, 90.0));
            myDeviation = new LinguisticVariable("DEVIATION", deviation);
        }

        public void setRules()
        {
            // Set Rule Base
            myrules = new FuzzyRuleCollection();
            myrules.Add(new FuzzyRule("IF (DISTANCE IS VERY_NEAR) AND (ANGLE IS LEFT) THEN DEVIATION IS AHEAD"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS NEAR) AND (ANGLE IS LEFT) THEN DEVIATION IS AHEAD"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS FAR) AND (ANGLE IS LEFT) THEN DEVIATION IS AHEAD"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS VERY_FAR) AND (ANGLE IS LEFT) THEN DEVIATION IS AHEAD"));

            myrules.Add(new FuzzyRule("IF (DISTANCE IS VERY_NEAR) AND (ANGLE IS AHEAD_LEFT) THEN DEVIATION IS AHEAD_RIGHT"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS NEAR) AND (ANGLE IS AHEAD_LEFT) THEN DEVIATION IS AHEAD"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS FAR) AND (ANGLE IS AHEAD_LEFT) THEN DEVIATION IS AHEAD"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS VERY_FAR) AND (ANGLE IS AHEAD_LEFT) THEN DEVIATION IS AHEAD"));

            myrules.Add(new FuzzyRule("IF (DISTANCE IS VERY_NEAR) AND (ANGLE IS AHEAD) THEN DEVIATION IS AHEAD_LEFT"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS NEAR) AND (ANGLE IS AHEAD) THEN DEVIATION IS RIGHT"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS FAR) AND (ANGLE IS AHEAD) THEN DEVIATION IS AHEAD_RIGHT"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS VERY_FAR) AND (ANGLE IS AHEAD) THEN DEVIATION IS AHEAD"));

            myrules.Add(new FuzzyRule("IF (DISTANCE IS VERY_NEAR) AND (ANGLE IS AHEAD_RIGHT) THEN DEVIATION IS AHEAD_LEFT"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS NEAR) AND (ANGLE IS AHEAD_RIGHT) THEN DEVIATION IS AHEAD"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS FAR) AND (ANGLE IS AHEAD_RIGHT) THEN DEVIATION IS AHEAD"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS VERY_FAR) AND (ANGLE IS AHEAD_RIGHT) THEN DEVIATION IS AHEAD"));

            myrules.Add(new FuzzyRule("IF (DISTANCE IS VERY_NEAR) AND (ANGLE IS RIGHT) THEN DEVIATION IS AHEAD"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS NEAR) AND (ANGLE IS RIGHT) THEN DEVIATION IS AHEAD"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS FAR) AND (ANGLE IS RIGHT) THEN DEVIATION IS AHEAD"));
            myrules.Add(new FuzzyRule("IF (DISTANCE IS VERY_FAR) AND (ANGLE IS RIGHT) THEN DEVIATION IS AHEAD"));
        }

        public void setFuzzyEngine()
        {
            fe = new FuzzyEngine();
            fe.LinguisticVariableCollection.Add(myDistance);
            fe.LinguisticVariableCollection.Add(myAngle);
            fe.LinguisticVariableCollection.Add(myDeviation);
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
            myDistance.InputValue=(Convert.ToDouble(textBox1.Text));
            myDistance.Fuzzify("NEAR");
            
            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            myAngle.InputValue = (Convert.ToDouble(textBox2.Text));
            myAngle.Fuzzify("AHEAD_LEFT");
            
        }

        public void fuziffyvalues()
        {
            myDistance.InputValue = (Convert.ToDouble(textBox1.Text));
            myDistance.Fuzzify("VERY_NEAR");
            myAngle.InputValue = (Convert.ToDouble(textBox2.Text));
            myAngle.Fuzzify("LEFT");
        
        }
        public void defuzzy()
        {
            setFuzzyEngine();
            fe.Consequent = "DEVIATION";
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
            fe.Consequent = "DEVIATION";
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
        }

       
    }
}
