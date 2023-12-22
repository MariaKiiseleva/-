using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace JewerlyApp
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
            
        }

        public interface IJewelry
        {
            int ID { get; set; }
            string Name { get; set; }
            string Metal { get; set; }
            double Price { get; set; }
        }

        public class Jewelry: IJewelry
        {
            private string name;

            private string metal;
            private double price;
            private int id;

            public int ID
            {
                get { return id; }
                set { id = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }



            public string Metal
            {
                get { return metal; }
                set { metal = value; }
            }

            public double Price
            {
                get { return price; }
                set { price = value; }
            }

        }

        public class Ring : Jewelry
        {

            private string stone;
            private double size;
            public string Stone
            {
                get { return stone; }
                set { stone = value; }
            }

            public double Size
            {
                get { return size; }
                set { size = value; }
            }

        }

        public class Chain : Jewelry
        {

            private double weight;
            private double size;
            public double Weight
            {
                get { return weight; }
                set { weight = value; }
            }

            public double Size
            {
                get { return size; }
                set { size = value; }
            }
        }

        public class Bracelet : Jewelry
        {
            private double weight;
            public double Weight
            {
                get { return weight; }
                set { weight = value; }
            }

        }

        public class Earrings : Jewelry
        {

            private string stone;
            public string Stone
            {
                get { return stone; }
                set { stone = value; }
            }
        }




        public class JewelryBase
        {
            private List<Jewelry> jewelryList;

            public JewelryBase()
            {
                jewelryList = new List<Jewelry>();
            }

            public void AddJewelry(Jewelry jewelry)
            {
                jewelryList.Add(jewelry);
            }

            public void RemoveJewelry(Jewelry jewelry)
            {
                jewelryList.Remove(jewelry);
            }

            public Jewelry FindJewelry(int id)
            {
                return jewelryList.FirstOrDefault(j => j.ID == id);
            }


            public void SaveJewelry(List<Jewelry> jewelryList, string filePath)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Jewelry>));
                    serializer.Serialize(writer, jewelryList);
                }
            }

        }


        public class RingBase
        {
            private List<Ring> ringList;

            public RingBase()
            {
                ringList = new List<Ring>();
            }

            public void AddRing(Ring ring)
            {
                ringList.Add(ring);
            }

            public void RemoveRing(Ring ring)
            {
                ringList.Remove(ring);
            }

            public Ring FindRing(int id)
            {
                return ringList.FirstOrDefault(j => j.ID == id);
            }


            public void SaveRing(List<Ring> ringList, string filePath)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Ring>));
                    serializer.Serialize(writer, ringList);
                }
            }

        }

        public class EarringsBase
        {
            private List<Earrings> earringsList;

            public EarringsBase()
            {
                earringsList = new List<Earrings>();
            }

            public void AddEarrings(Earrings earrings)
            {
                earringsList.Add(earrings);
            }

            public void RemoveEarrings(Earrings earrings)
            {
                earringsList.Remove(earrings);
            }

            public Earrings FindEarrings(int id)
            {
                return earringsList.FirstOrDefault(e => e.ID == id);
            }

            public void SaveEarrings(List<Earrings> earringsList, string filePath)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Earrings>));
                    serializer.Serialize(writer, earringsList);
                }
            }
        }


        public class ChainBase
        {
            private List<Chain> chainList;

            public ChainBase()
            {
                chainList = new List<Chain>();
            }

            public void AddChain(Chain chain)
            {
                chainList.Add(chain);
            }

            public void RemoveChain(Chain chain)
            {
                chainList.Remove(chain);
            }

            public Chain FindChain(int id)
            {
                return chainList.FirstOrDefault(c => c.ID == id);
            }

            public void SaveChain(List<Chain> chainList, string filePath)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Chain>));
                    serializer.Serialize(writer, chainList);
                }
            }
        }


        public class BraceletBase
        {
            private List<Bracelet> braceletList;

            public BraceletBase()
            {
                braceletList = new List<Bracelet>();
            }

            public void AddBracelet(Bracelet bracelet)
            {
                braceletList.Add(bracelet);
            }

            public void RemoveBracelet(Bracelet bracelet)
            {
                braceletList.Remove(bracelet);
            }

            public Bracelet FindBracelet(int id)
            {
                return braceletList.FirstOrDefault(b => b.ID == id);
            }

            public void SaveBracelet(List<Bracelet> braceletList, string filePath)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Bracelet>));
                    serializer.Serialize(writer, braceletList);
                }
            }
        }


        

        public class Employees
        {
            public static double prozent = 0.04;
            private double salary;
            private string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public double Salary
            {
                get { return salary; }
                set { salary = value; }
            }



            public static double CountSalary(Employees emplyee, double price)
            {
                double prozentSalary =  price * prozent;
                emplyee.salary += prozentSalary;
                double salaryNow = emplyee.salary;
                return salaryNow;
            }

            public static double ShowSalary(Employees emplyee)
            {
                return emplyee.salary;
            }
        }


        public abstract class Payment<T1, T2, T3>
        {
            public abstract  string MakePayment(T1 paymentMethod, T2 value1, T3 value2);
        }

        public class CashPayment: Payment<string, double, double>
        {
            public override  string MakePayment(string paymentMethod, double price, double cash)
            {
                double change = cash - price;
                return $"Цена: {price}\n Получено: {cash} \n Сдача: {change} \n \n Украшение продано";
            }
        }

        public class BankCardPayment : Payment<string, string, double>
        {
            public override string MakePayment(string paymentMethod, string bankSystem, double price)
            {
                if (bankSystem == "Сбербанк")
                {
                    Random random = new Random();
                    int newPrice = (int)(price * 0.3);
                    int bonuses = random.Next(50,newPrice);
                    newPrice = (int)price - bonuses;
                    return $"...Установка соединения с банком... \n Списание бонусов: {bonuses} \n Оплата {newPrice}р прошла успешно";
                }
                else
                {
                    return $"...Установка соединения с банком... \n Бонусная система не найдена \n Оплата {price} р прошла успешно";
                }
            }
        }
    }

}
    
    


        

   