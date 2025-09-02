// ask for input
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
    // create data file

    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = Convert.ToInt32(Console.ReadLine());
    // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    // random number generator
    Random rnd = new();
    // create file
    StreamWriter sw = new("data.txt");

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        }
        // M/d/yyyy,#|#|#|#|#|#|#
        // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
    // TODO: parse data file    
    StreamReader sr = new("data.txt");
    while (!sr.EndOfStream)
    {
        string? line = sr.ReadLine();

        string[] date = String.IsNullOrEmpty(line) ? [] : line.Split(',', '|', '/');

        DateTime weekOf = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[0]), Convert.ToInt32(date[1]));



        Console.WriteLine("Week of {0}.\n Su Mo Tu We Th Fr Sa Tot Avg \n -- -- -- -- -- -- -- --- --- \n {1,2} {2,2} {3,2} {4,2} {5,2} {6,2} {7,2} {8,3} {9,3}", weekOf.ToString("MMMM dd, yyyy"),date[3],date[4],date[5],date[6],date[7],date[8],date[9], Convert.ToInt32(date[3])+Convert.ToInt32(date[4])+Convert.ToInt32(date[5])+Convert.ToInt32(date[6])+Convert.ToInt32(date[7])+Convert.ToInt32(date[8])+Convert.ToInt32(date[9]),((Convert.ToInt32(date[3])+Convert.ToInt32(date[4])+Convert.ToInt32(date[5])+Convert.ToInt32(date[6])+Convert.ToInt32(date[7])+Convert.ToInt32(date[8])+Convert.ToInt32(date[9]))/7.0).ToString("f1"));




        
    }
    



}
