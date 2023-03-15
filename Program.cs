

//  T7 Dataset DigiKala

/* محمد یاسین ولی پور */

/* mohamad yasin valipor */



using System.Text.RegularExpressions;

string input;
ConsoleKeyInfo click2;
bool cnt = false;


DigiKala_DataSet a = new DigiKala_DataSet();


Console.WriteLine("Hello\n\nThis Program have a dataset from digikala\nyou can watch all city or all data that people buy from digikala\n\nif you want to watch all ciry press c\nif you want to watch all data press d");

Console.Write("I Chose : ");
string click = Console.ReadLine();


    if (click == "c")
    {

        Console.WriteLine("\n Please wait\r\n This process takes time\r\n Thank you for your patience");
        a.Pick_a_City();
        cnt = true;

    }
    else if (click == "d")
    {

        Console.WriteLine("\n Please wait\r\n This process takes time\r\n Thank you for your patience");
        a.Pick_a_DATE();
        cnt = true;

    }
    else
    {
        Console.WriteLine("Please enter a correct amount");
    }











    /// method







class DigiKala_DataSet
{

    // Part Of City

    public void Pick_a_City()
    {

        string address = @"DataSet\orders.csv";

        string line;

        List<string> citys = new List<string>();

        using (StreamReader reader = new StreamReader(address))
        {
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                citys.Add(Regex.Replace(line, @"(\d|\.|,|:|-| )+", ""));
            }
        }


        var nonduplicatecitys = citys.Distinct();

        Parallel.ForEach(nonduplicatecitys, city =>
        {
            using (StreamWriter writer = new StreamWriter(@"all_citys\" + city + ".csv"))
            {

                using (StreamReader reader2 = new StreamReader(address))
                {
                    while (!reader2.EndOfStream)
                    {
                        string line2 = reader2.ReadLine();

                        if (line2.Contains(city))
                        {
                            writer.WriteLine(line2);
                        }
                    }
                }
            }
        });
    }

    // Part Of Date

    public void Pick_a_DATE()
    {



        Regex pattern1 = new Regex(@"(\d{4}\-)");
        string addres1 = @"D:\orders.csv";
        StreamReader reader1 = new StreamReader(addres1);


        string line1;
        while ((line1 = reader1.ReadLine()) != null)
        {

            var match1 = pattern1.Match(line1);
            if (match1.Success)
            {

                using (StreamWriter writer1 = new StreamWriter(@"all_Data_s\" + match1 + ".csv"))
                {

                    using (StreamReader reader2 = new StreamReader(addres1))
                    {

                        while (!reader2.EndOfStream)
                        {
                            string line2 = reader2.ReadLine();

                            if (line2.Contains(Convert.ToString(match1)))
                            {

                                writer1.WriteLine(line2);
                            }
                        }
                    }
                }
            }
        }
    }
}

