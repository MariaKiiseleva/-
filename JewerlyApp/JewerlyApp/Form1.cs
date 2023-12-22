using JewerlyApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using static JewerlyApp.Program;

namespace JewerlyApp
{
    public partial class Form1 : Form
    {
        JewelryBase jewelryBase = new JewelryBase();
        RingBase ringBase = new RingBase();
        EarringsBase earringsBase = new EarringsBase();
        ChainBase chainBase = new ChainBase();
        BraceletBase braceletBase = new BraceletBase();
        Employees Kiseleva = new Employees();
        Employees Korneeva = new Employees();
        Employees Kozhaeva = new Employees();
        Employees Komkova = new Employees();

        public Form1()
        {
            InitializeComponent();
        }

        private string valueFromForm2;

        public string ValueFromForm2
        {
            get { return valueFromForm2; }
            set { valueFromForm2 = value; }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            int b = int.Parse(textBox1.Text);
           

            if (jewelryBase.FindJewelry(b) != null)
            {
                richTextBox1.Text = "Украшение найдено        " + jewelryBase.FindJewelry(b).Name;
            }
            else
            {
                richTextBox1.Text = "Украшение не найдено";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int b = int.Parse(id2.Text);
            if (jewelryBase.FindJewelry(b) == null)
            {
                if (name2.Text == "ring")
                {
                    Ring ring = new Ring();
                    ring.Name = name2.Text;
                    ring.Metal = metal2.Text;
                    ring.Size = double.Parse(size2.Text);
                    ring.ID = int.Parse(id2.Text);
                    ring.Price = double.Parse(price2.Text);
                    ring.Stone = stone2.Text;
                    jewelryBase.AddJewelry(ring);
                    ringBase.AddRing(ring);
                    richTextBox1.Text = "Украшение добавлено";
                }
                else if (name2.Text == "earrings")
                {
                    Earrings earrings = new Earrings();
                    earrings.Name = name2.Text;
                    earrings.Metal = metal2.Text;
                    earrings.ID = int.Parse(id2.Text);
                    earrings.Price = double.Parse(price2.Text);
                    earrings.Stone = stone2.Text;
                    jewelryBase.AddJewelry(earrings);
                    earringsBase.AddEarrings(earrings);
                    richTextBox1.Text = "Украшение добавлено";
                }
                else if (name2.Text == "chain")
                {
                    Chain chain = new Chain();
                    chain.Name = name2.Text;
                    chain.Metal = metal2.Text;
                    chain.Size = double.Parse(size2.Text);
                    chain.ID = int.Parse(id2.Text);
                    chain.Price = double.Parse(price2.Text);
                    chain.Weight = double.Parse(weight2.Text);
                    jewelryBase.AddJewelry(chain);
                    chainBase.AddChain(chain);
                    richTextBox1.Text = "Украшение добавлено";
                }
                else if (name2.Text == "bracelet")
                {
                    Bracelet bracelet = new Bracelet();
                    bracelet.Name = name2.Text;
                    bracelet.Metal = metal2.Text;
                    bracelet.ID = int.Parse(id2.Text);
                    bracelet.Price = double.Parse(price2.Text);
                    bracelet.Weight = double.Parse(weight2.Text);
                    jewelryBase.AddJewelry(bracelet);
                    braceletBase.AddBracelet(bracelet);
                    richTextBox1.Text = "Украшение добавлено";
                }
            }
            else
            {
                richTextBox1.Text = "Украшение с таким ID уже существует";
            }
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int b = int.Parse(textBox2.Text);
            Jewelry jewerly = jewelryBase.FindJewelry(b);
            double price = jewerly.Price;
            Employees employee = new Employees();
            if (textBox3.Text == "Киселева")
            {
                Employees.CountSalary(Kiseleva, price);
            }else
            if (textBox3.Text == "Корнеева")
            {
                Employees.CountSalary(Korneeva, price);
            }else
            if (textBox3.Text == "Кожаева")
            {
                Employees.CountSalary(Kozhaeva, price);
            }
            else
            if(textBox3.Text == "Комкова")
            {
                Employees.CountSalary(Komkova, price);
            }
            else
            {
                richTextBox1.Text = "Введите корректную фамилию сотрудника";
            }

            


            if (jewerly != null)
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();

                var cashPayment = new CashPayment();
                var bankCardPayment = new BankCardPayment();

                if (form2.Button1Clicked)
                {
                    valueFromForm2 = form2.ValueForForm1;
                    richTextBox1.Text = cashPayment.MakePayment("наличные", price, double.Parse(valueFromForm2));
                }
                else if (form2.Button2Clicked)
                {
                    Random random = new Random();
                    string bankSystem;
                    int defineBankSystem = random.Next(1, 4);
                    if (defineBankSystem == 1)
                    {
                        bankSystem = "Сбербанк";
                    }
                    else
                    {
                        bankSystem = "";
                    }

                    richTextBox1.Text = bankCardPayment.MakePayment("банковской картой", bankSystem, price);

                }
                jewelryBase.RemoveJewelry(jewerly);
                
            }
            else
            {
                richTextBox1.Text = "Украшение не найдено";
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            int b = int.Parse(textBox1.Text);


            if (jewelryBase.FindJewelry(b) != null)
            {
                if (jewelryBase.FindJewelry(b).Name == "ring")
                {

                    Ring ring = ringBase.FindRing(b);
                    richTextBox1.Text = $"ID: {ring.ID}" + Environment.NewLine +
                        $"Name: {ring.Name}" + Environment.NewLine +
                        $"Size: {ring.Size}" + Environment.NewLine +
                        $"Metal: {ring.Metal}" + Environment.NewLine +
                        $"Price: {ring.Price}" + Environment.NewLine +
                        $"Stone: {ring.Stone}";
                }
                else
                if (jewelryBase.FindJewelry(b).Name == "earrings")
                {
                    Earrings earrings = earringsBase.FindEarrings(b);
                    richTextBox1.Text = $"ID: {earrings.ID}" + Environment.NewLine +
                        $"Name: {earrings.Name}" + Environment.NewLine +
                        $"Metal: {earrings.Metal}" + Environment.NewLine +
                        $"Price: {earrings.Price}" + Environment.NewLine +
                        $"Stone: {earrings.Stone}";
                }
                else
                if (jewelryBase.FindJewelry(b).Name == "chain")
                {
                    Chain chain = chainBase.FindChain(b);
                    richTextBox1.Text = $"ID: {chain.ID}" + Environment.NewLine +
                        $"Name: {chain.Name}" + Environment.NewLine +
                        $"Metal: {chain.Metal}" + Environment.NewLine +
                        $"Price: {chain.Price}" + Environment.NewLine +
                        $"Length: {chain.Size}" + Environment.NewLine +
                        $"Weight: {chain.Weight}";
                }
                else
                if (jewelryBase.FindJewelry(b).Name == "bracelet")
                {
                    Bracelet bracelet = braceletBase.FindBracelet(b);
                    richTextBox1.Text = $"ID: {bracelet.ID}" + Environment.NewLine +
                        $"Name: {bracelet.Name}" + Environment.NewLine +
                        $"Metal: {bracelet.Metal}" + Environment.NewLine +
                        $"Price: {bracelet.Price}" + Environment.NewLine +
                        $"Weight: {bracelet.Weight}";
                }

                else
                {
                    richTextBox1.Text = "Украшение не найдено";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Киселева" + Environment.NewLine + Employees.ShowSalary(Kiseleva).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Кожаева" + Environment.NewLine + Employees.ShowSalary(Kozhaeva).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Корнеева" + Environment.NewLine + Employees.ShowSalary(Korneeva).ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Комкова" + Environment.NewLine + Employees.ShowSalary(Komkova).ToString();
        }
    }
}
    
