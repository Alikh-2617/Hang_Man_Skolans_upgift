using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace Hang_Man_Skolans_upgift
{
    internal class Program
    {
        

        public string Hemliga_ord()
        {
            string ordet = "";
            string fel = "fel";
            List<string> Hemligt_ord = new List<string>() { "pendla", "kollektivet", "stund", "ali", "usef", "amir", "johan", "anna", "lucian", "ammar" };
            int lenght = Hemligt_ord.Count;
            Random random = new Random();
            int ord = random.Next(Hemligt_ord.Count);

            for(int i = 0; i > lenght; i++)
            {
                if(ord == i)
                {
                    if (Hemligt_ord[i]== null)
                    {
                        ordet = fel;
                    }
                    else{
                        ordet = Hemligt_ord[i];
                    }

                    break;
                }
            }
            return ordet;
        }

        public int Get_input()
        {
            int check;
            int chosed = 0;
            Console.Write("svar : ");
            var chose = Console.ReadLine();
            if (int.TryParse(chose, out check))
            {
                chosed = Convert.ToInt32(chose);
            }
            else
            {
                Console.WriteLine("fel input vill du försöka igen ?  1 ja/ 2 nej ");
                var chose1 = Console.ReadLine();
                if (int.TryParse(chose1, out check))
                {
                   
                    chosed = Convert.ToInt32(chose1);
                    if(chosed == 1)
                    {
                        Get_input();
                    }
                    else if (chosed == 2){
                        chosed = 0;
                    }


                }
                else
                {
                    Get_input();
                }

            }

            return chosed;   
        }
        public char Get_char()
        {
            char c = ' ';
            Console.Write("bokstavet : ");
            var inputes = Console.ReadLine();
            if (!inputes.Equals(null))
            {
                if (inputes is char) 
                {
                    c = Convert.ToChar(inputes);
                }
            }
            return c;
        }
        public string Get_string()
        {
            string str = " ";
            Console.Write("ditt ord : ");
            var svar = Console.ReadLine();
            if(svar != null)
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

        public int vinna(string gissa , string hemliga_ord)
        {
            int svar = 0;
            int val;
            if (gissa.Equals(hemliga_ord))
            {
                Console.WriteLine("congratulerar du vann spelaet !!");
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
            return svar;
        }


        public void Easy_Spel()
        {
            Console.Clear();
            bool runme = true;
            int chose;
            int val = 0;
            int left = 0;
            string ordet;
            string Fel = "fel";
            char[] chosed = new char[10];
            string svar= Hemliga_ord();
            if (svar.Equals(Fel))
            {
                Hemliga_ord();
            }
            ordet = svar;
            char[] list = ordet.ToCharArray();


            Console.WriteLine("Hej du kommit till första spelet.");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Vilken du få gissa 10 gånger försökt att kunna kommeletera ordet. samtidigt du få gissa hela ordet med !");
            Console.WriteLine("Eller om du vill komma till menu igen tyck 3 .");
            Console.WriteLine();
            Console.WriteLine("vill du gissa bokstavet eller hela ordet.");
            Console.WriteLine(" 1-  för bokstav .");
            Console.WriteLine(" 2-  hela ordet .");
            Console.WriteLine();

            while (runme)
            {
                Console.Clear();
                if(val == 8)
                {
                    Console.WriteLine("Sista chansen !! ");
                }
                if (val == 9)
                {
                    string utvalda2 = new string(chosed);
                    if (!svar.Equals(utvalda2))
                    {
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
                val++;
                left--;
                Console.Write("dina utvalda -->  ");
                for (int i = 0; i < chosed.Length; i++)
                {
                    if (chosed[i] != 0)
                    {
                        Console.Write(chosed[i]);

                    }
                    else
                    {
                        Console.Write(" _ ");
                    }
                }
                Console.WriteLine("                                     Antal försök du hade gjort -> " + val);
                Console.WriteLine("                                     Antal försök kvar ----------> " + left);
                Console.WriteLine();
                Console.WriteLine();
                chose = Get_input();
                switch (chose)
                {
                    case 0:
                        Console.WriteLine("tryck inter för att avsluta spelet !");
                        Console.ReadLine();
                        runme = false;
                        break;
                    case 1:
                        chosed[val] = Get_char();
                        break;
                    case 2:
                        string ss = Get_string();
                        int slut = vinna( ss, svar);
                        if(slut == 1)
                        {
                            Menu();
                            break;
                        }
                        runme = false;
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
                }


            }
        }






        public void Menu()
        {
            Console.Clear();
            int chose;
            Console.WriteLine("Hej välkommen till spelaet .");
            Console.WriteLine("vi har två olika level i spelet. ");
            Console.WriteLine(" 1- Första du har 10 försökt att hitta ordet ! och samtidigt du har möjligheten att gissa hela ordet på engång.");
            Console.WriteLine(" 2- Andra är att du har lika många som ordets alfabetet är .");
            Console.Write("Vilken vill du spelar : ");
            chose = Get_input();
            switch (chose)
            {
                case 0:
                    Console.WriteLine("tryck inter att avsluta programet !");
                    Console.ReadLine();
                    break;
                case 1:
                    Console.WriteLine("första late ");
                    break;
                case 2:
                    Console.WriteLine("svåra !! ");
                    break;
            }
            

        }




        static void Main(string[] args)
        {
            char[] s = new char[10];

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("---");
                if(i == 8)
                {
                    Console.WriteLine("9");
                }
            }

        }
    }
}