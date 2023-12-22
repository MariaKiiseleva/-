using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JewerlyApp
{
    public partial class Form2 : Form
    {
        

        public Form2()
        {
            InitializeComponent();
        }
        private bool button1Clicked;
        private bool button2Clicked;

        public bool Button1Clicked
        {
            get { return button1Clicked; }
            set { button1Clicked = value; }
        }

        public bool Button2Clicked
        {
            get { return button2Clicked; }
            set { button2Clicked = value; }
        }

        private string valueForForm1;

        public string ValueForForm1
        {
            get { return valueForForm1; }
            set { valueForForm1 = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2Clicked = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1Clicked = true;
            valueForForm1 = textBox1.Text;
            this.Close();
        }
    }
}
