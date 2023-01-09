using SampleConApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILayer;

namespace SampleConApp
{
    class MediaclResearch
    {

        public string D_name { get; set; }

        public string symtoms { get; set; }
        public string Severity { get; set; }

        public string description { get; set; }

        public String P_Name { get; set; }

    }


    class patientdetails
    {
        private MediaclResearch[] Ms = null;
        private int _size = 0;
        public patientdetails(int size)
        {
            size = _size;

            Ms = new MediaclResearch[_size];

        }



        public MediaclResearch[] FindBysymtomos(string symtoms)
        {
            int count = 0;
            foreach (MediaclResearch research in Ms)
            {
                if (research != null && research.symtoms.Contains(symtoms))
                {
                    count += 1;
                }
            }
            MediaclResearch[] mss = new MediaclResearch[count];

           count = 0;
            foreach (MediaclResearch research in Ms)
            {
                if (research != null && research.symtoms.Contains(symtoms))
                {
                    count += 1;
                   
                }

            }
            return  count;
            
        }

        public void AddNewDisease(MediaclResearch mr)
        {
            for (int i = 0; i < _size; i++)
            {
                if (Ms[i] == null)
                {
                    Ms[i] = new MediaclResearch { D_name = mr.D_name, Severity = mr.Severity, description = mr.description, P_Name = mr.P_Name };
                    Console.WriteLine(" added sucessfully");
                    return;
                }
            }
        }




        public void AddSymDes(MediaclResearch mr)
        {
            for (int i = 0; i < _size; i++)
            {
                Ms[i] = new MediaclResearch { D_name = mr.D_name, symtoms = mr.symtoms, };
            }
        }



    }

}

namespace UILayer
{
    class UIManager
    {
        public static patientdetails p;


        public const string menu = "To add  patient  press 1\n to add symptoms press 2 to serach details by symtoms press 3 \n for exit press any button ";

        public void run()
        {
            Console.WriteLine("enter the no of patient details u want to store");
            int size = int.Parse(Console.ReadLine());

            p = new patientdetails(size);



            bool processing = true;
            do
            {


                Console.WriteLine(menu);
                int choice = int.Parse(Console.ReadLine());

                processing = processMenu(choice);

            } while (processing);
            Console.WriteLine("Thank you!!!");

        }

        private static bool processMenu(int choice)
        {
            switch (choice)
            {

           
                case 1:
                    addpatient();
                    break;
                case 2:
                    AddSymtom();
                    break;



                default:
                    return false;
            }
            return true;//break vs. goto vs. return vs. throw.
        }



        public static void addpatient()
        {
            Console.WriteLine("enter the dicease name of the patienct");
            string dname = Console.ReadLine();

            Console.WriteLine("enter the severitity of the decease");
            String sev = Console.ReadLine();

            Console.WriteLine("enter the description of Disease");
            string des = Console.ReadLine();

            Console.WriteLine("enter the Patient name");
            string name = Console.ReadLine();




            MediaclResearch mr = new MediaclResearch { D_name = dname, Severity = sev, description = des, P_Name = name };
            p.AddNewDisease(mr);


            Console.WriteLine("added sucessfully");

            Console.WriteLine("press enter to clear");

            Console.Clear();

           

        }



        public static void AddSymtom()
        {


            Console.WriteLine("enter the dicease name of the patienct");
            string dname = Console.ReadLine();

            Console.WriteLine("enter the description of Disease");
            string des = Console.ReadLine();


            Console.WriteLine("enter the symtom of the dises");
            string sym = Console.ReadLine();

            MediaclResearch mr = new MediaclResearch { D_name = dname, description = des, symtoms = sym };
            p.AddSymDes(mr);
           
            Console.Clear();



        }




    }
}
    namespace repo
    {

    class main
    {
        static void Main(string[] args)
        {


                UIManager u = new UIManager();
                u.run();
        }


    }
}
