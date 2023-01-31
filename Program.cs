
          static void Main(string[] args)
        {
            string file = "tickets.txt";
            string choice;

            do
            {
                Console.WriteLine("\n1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string header = sr.ReadLine();
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    StreamWriter sw = new StreamWriter(file);
                    string watching = "";

                    for(int i = 0; i<7;i++)
                    {
                        Console.WriteLine("Enter a new ticket (Y/N)?");
                        choice=Console.ReadLine().ToUpper();
                        if(choice != "Y") {break;}

                        Console.WriteLine("Enter the TicketID.");
                        string ticketID = Console.ReadLine();

                        Console.WriteLine("Enter the summary.");
                        string summary = Console.ReadLine();

                        Console.WriteLine("Enter the status.");
                        string status = Console.ReadLine();

                        Console.WriteLine("Enter the priority.");
                        string priority = Console.ReadLine();

                        Console.WriteLine("Enter the submitter.");
                        string submitter = Console.ReadLine();

                        Console.WriteLine("Enter who was assigned.");
                        string assigned = Console.ReadLine();

                        do 
                        {
                            Console.WriteLine("Enter who is watching.");
                            watching = watching + Console.ReadLine();

                            Console.WriteLine("Is there another person watching (Y/N)?");
                            choice = Console.ReadLine().ToUpper();
                            if(choice == "Y") { watching = watching + "|"; }
                        } 
                        while (choice == "Y");

                        sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                        sw.WriteLine($"{ticketID},{summary},{status},{priority},{submitter},{assigned},{watching}");
                    }
                    sw.Close();
                }
            } while (choice == "1" || choice == "2" || choice == "N");

        }
    }
}
