using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;

namespace Hang_Man_Skolans_upgift
{
    internal class Program
    {


        public static string Hemliga_ord()
        {
            string ordet = "";
            string fel = "fel";
            List<string> Hemligt_ord = new List<string>() { "pendla", "kollektivet", "stund", "ali", "usef", "amir", "johan", "anna", "lucian", "ammar" };
            var random = new Random();

            int index = random.Next(Hemligt_ord.Count);
            ordet = Hemligt_ord[index];

            if(ordet == null)
            {
                return fel;
            }

            return ordet;
        }

        public static int Get_input()
        {
            int check;
            int chosed = 0;
            bool runme = true;
            while (runme)
            {
                Console.Write("svar : ");
                var chose = Console.ReadLine();
                if (int.TryParse(chose, out check))
                {
                    chosed = Convert.ToInt32(chose);
                    runme = false;
                    break;
                }
                else
                {
                    Console.WriteLine("fel typ av input , tyvärr vi avslutar programmet.");
                    break;
                }
            }

            return chosed;
        }
        public static char Get_char()
        {
            char c = ' ';
            Console.Write("bokstavet : ");
            char inputes = Console.ReadKey().KeyChar;
            if (inputes.Equals(null))
            {
                Console.WriteLine("fel typ av input försök igen.");
                Get_char();
            }
            c = inputes;
            return c;
        }
        public static string Get_string()
        {
            string str = " ";
            Console.Write("ditt ord : ");
            var svar = Console.ReadLine();
            if (svar != null)
            {
                str = svar;
            }
            else
            {
                Console.WriteLine("fel typ av inputs !");
                Get_string();
            }
            return str;
        }

        public static int vinna(string gissa, string hemliga_ord)
        {
            int svar = 0;
            int val;
            Console.Clear();
            if (gissa == hemliga_ord)
            {
                Console.WriteLine();
                Console.WriteLine("congratulerar du vann spelaet !!");
                Console.WriteLine("ordet som du gissat ==>  " + gissa);
                Console.WriteLine("hemliga ordet varit ==>  " + hemliga_ord);


                Console.WriteLine("vill du köra en varv till ?  1= ja  //  2 =nej ");
                val = Get_input();
                switch (val)
                {
                    case 0:
                        Console.WriteLine("tryck på inter för att avsluta spelet !");
                        svar = 0;
                        break;
                    case 1:
                        Console.WriteLine("tryck inter för att komma till menu !");
                        Console.ReadLine();
                        svar = 1;
                        break;
                    case 2:
                        Console.WriteLine("tryck på inter för att avsluta spelet !");
                        svar = 0;
                        break;

                }
            }
            Console.WriteLine("tyvärr du har förlurat i den tur .");
            Console.WriteLine("vill du köra en varv till ?  1= ja  //  2 =nej ");
            val = Get_input();
            switch (val)
            {
                case 0:
                    Console.WriteLine("tryck på inter för att avsluta spelet !");
                    svar = 0;
                    break;
                case 1:
                    Console.WriteLine("tryck inter för att komma till menu !");
                    Console.ReadLine();
                    svar = 1;
                    break;
                case 2:
                    Console.WriteLine("tryck på inter för att avsluta spelet !");
                    svar = 0;
                    break;
            }
            
            return svar;
        }
        public static int checke (char gissa, string hemliga_ord){
            int _index = 100;
            char[] list = hemliga_ord.ToCharArray();

            for (int i = 0; i < hemliga_ord.Length; i++)
            {
                if (list[i] == gissa){
                    _index = i;
                    break;
                }

            }



            return _index;
        }

        public static void Easy_Spel()
        {
            Console.Clear();
            bool runme = true;
            int chose;
            int val = 0;
            int left = 10;
            string ordet;
            string Fel = "fel";
            char[] chosed = new char[10];
            char[] svar2 = new char[10];
            string svar= Hemliga_ord();
            if (svar.Equals(Fel))
            {
                Hemliga_ord();
            }
            ordet = svar;
            char[] list = ordet.ToCharArray();
            Console.WriteLine("Hej du kommit till första spelet.");

            while (runme)
            {
                   
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Vilken du få gissa 10 gånger försökt att kunna kommeletera ordet. samtidigt du få gissa hela ordet med !");
                Console.WriteLine("Eller om du vill komma till menu igen tyck 3 .");
                Console.WriteLine();
                Console.WriteLine("vill du gissa bokstavet eller hela ordet.");

                if (val == 10)
                {
                    string utvalda2 = new string(chosed);
                    if (svar !=utvalda2)
                    {
                        Console.Clear();
                        Console.WriteLine("Tyvärr du förlurade i den spel.");
                        Console.WriteLine("vill du köra om?  1 = ja // 2 = nej ");
                        int i = Get_input();
                        if(i == 1)
                        {
                            Menu();
                        }
                        runme = false;
                        break;
                    }

                }
                Console.WriteLine();
                Console.Write("                                                         Hemliga ordet-->  ");
                for (int i = 0; i < svar2.Length; i++)
                {
                    if (svar2[i] != 0)
                    {
                        Console.Write(svar2[i]);

                    }
                    else
                    {
                        Console.Write(" _ ");
                    }

                }
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("                                                         Dina utvalda -->  ");
                for (int i = 0; i < chosed.Length; i++)
                {
                    if (chosed[i] != 0)
                    {
                        Console.Write("  " +chosed[i]);

                    }
                    else
                    {
                        Console.Write(" _ ");
                    }
                    
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                                                         Antal försök du hade gjort -> " + val);
                Console.WriteLine("                                                         Antal försök kvar ----------> " + left);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" 1-  för bokstav .");
                Console.WriteLine(" 2-  hela ordet .");
                if (val == 8)
                {
                    Console.WriteLine("Sista chansen !! ");
                }
                chose = Get_input();
                val++;
                left--;
                switch (chose)
                {
                    case 0:
                        Console.WriteLine("tryck inter för att avsluta spelet !");
                        Console.ReadLine();
                        runme = false;
                        Console.Clear();
                        break;
                    case 1:
                        char cc = Get_char();
                        chosed[val-1] = cc;
                        int bb = checke(cc, svar);
                        if(bb != 100)
                        {
                            svar2[bb] = cc;
                        }
                        Console.Clear();
                        break;
                    case 2:
                        string ss = Get_string();
                        int slut = vinna( ss, svar);
                        if(slut == 1)
                        {
                            Menu();
                            break;
                        }
                        Console.Clear();
                        runme = false;
                        break;
                    case 3:
                        Menu();
                        break;
                }
                string utvalda = new string(chosed);
                if (utvalda.Equals(svar))
                {
                    int slutsats = vinna(utvalda, svar);
                    if (slutsats == 1)
                    {
                        Menu();
                        break;
                    }
                    runme = false;
                    break;
                }


            }
        }

        public static void Avancerat_Spel()
        {
            Console.Clear();
            bool runme = true;
            int chose;
            string ordet;
            string Fel = "fel";
            string svar = Hemliga_ord();
            int lenght = svar.Length;
            char[] chosed = new char[lenght];
            char[] svar2 = new char[lenght];
            int val = 0;
            int left = lenght;
            if (svar.Equals(Fel))
            {
                Hemliga_ord();
            }
            ordet = svar;
            char[] list = ordet.ToCharArray();
            Console.WriteLine("Hej du kommit till första spelet.");

            while (runme)
            {

                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Vilken du få gissa 10 gånger försökt att kunna kommeletera ordet. samtidigt du få gissa hela ordet med !");
                Console.WriteLine("Eller om du vill komma till menu igen tyck 3 .");
                Console.WriteLine();
                Console.WriteLine("vill du gissa bokstavet eller hela ordet.");

                if (val == lenght)
                {
                    string utvalda2 = new string(chosed);
                    if (svar != utvalda2)
                    {
                        Console.Clear();
                        Console.WriteLine("Tyvärr du förlurade i den spel.");
                        Console.WriteLine("vill du köra om?  1 = ja // 2 = nej ");
                        int i = Get_input();
                        if (i == 1)
                        {
                            Menu();
                        }
                        runme = false;
                        break;
                    }

                }
                Console.WriteLine();
                Console.Write("                                                         Hemliga ordet-->  ");
                for (int i = 0; i < lenght; i++)
                {
                    if (svar2[i] != 0)
                    {
                        Console.Write(svar2[i]);

                    }
                    else
                    {
                        Console.Write(" _ ");
                    }

                }
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("                                                         Dina utvalda -->  ");
                for (int i = 0; i < lenght; i++)
                {
                    if (chosed[i] != 0)
                    {
                        Console.Write("  " + chosed[i]);

                    }
                    else
                    {
                        Console.Write(" _ ");
                    }

                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                                                         Antal försök du hade gjort -> " + val);
                Console.WriteLine("                                                         Antal försök kvar ----------> " + left);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" 1-  för bokstav .");
                Console.WriteLine(" 2-  hela ordet .");
                if (val == lenght-1)
                {
                    Console.WriteLine("Sista chansen !! ");
                }
                chose = Get_input();
                val++;
                left--;
                switch (chose)
                {
                    case 0:
                        Console.WriteLine("tryck inter för att avsluta spelet !");
                        Console.ReadLine();
                        runme = false;
                        Console.Clear();
                        break;
                    case 1:
                        char cc = Get_char();
                        chosed[val-1] = cc;
                        int bb = checke(cc, svar);
                        if (bb != 100)
                        {
                            svar2[bb] = cc;
                        }
                        Console.Clear();
                        break;
                    case 2:
                        string ss = Get_string();
                        int slut = vinna(ss, svar);
                        if (slut == 1)
                        {
                            Menu();
                            break;
                        }
                        Console.Clear();
                        runme = false;
                        break;

                    case 3:
                        Menu();
                        break;
                }
                string utvalda = new string(chosed);
                if (utvalda.Equals(svar))
                {
                    int slutsats = vinna(utvalda, svar);
                    if (slutsats == 1)
                    {
                        Menu();
                        break;
                    }
                    runme = false;
                    break;
                }


            }
        }




        public static void Menu()
        {
            Console.Clear();
            int chose;
            Console.WriteLine("Hej välkommen till spelaet .");
            Console.WriteLine("vi har två olika level i spelet. ");
            Console.WriteLine(" 1- Första du har 10 försökt att hitta ordet ! och samtidigt du har möjligheten att gissa hela ordet på engång.");
            Console.WriteLine(" 2- Andra är att du har lika många som ordets alfabetet är .");
            Console.WriteLine(" 3- Avsluta programmet .");
            Console.WriteLine(" Vilken vill du spelar : ");
            chose = Get_input();
            switch (chose)
            {
                case 0:
                    Console.WriteLine("tryck inter att avsluta programet !");
                    Console.ReadLine();
                    break;
                case 1:
                    Easy_Spel();
                    break;
                case 2:
                    Avancerat_Spel();   
                    break;
                case 3:
                    break;
            }
        }




        static void Main(string[] args)
        {

            Menu();
          
        }
    }
}