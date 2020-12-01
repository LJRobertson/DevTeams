using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevTeamsProject;

namespace ConsoleApp1
{
    class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();

        public void Run()
        {
            SeedDeveloperList();
            SeedTeamList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to the Komodo Insurance Developer Team Management Application. \nPlease choose from the following options:\n" +
                    "\n1. Add a New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View Developers by ID Number\n" +
                    "4. Update an Existing Developer\n" +
                    "5. Delete an Existing Developer\n" +
                    "6. Create a New Team\n" +
                    "7. View All Teams\n" +
                    "8. View Team Details by Team ID\n" +
                    "9. Update a Team\n" +
                    "10. Delete a Team\n" +
                    "11. Add a Developer to a Team\n" +
                    "12. Remove a Developer From a Team\n" +
                    "13. Pluralsight Report Generator\n" +
                    "14. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewDeveloper();
                        break;
                    case "2":
                        ViewAllDevelopers();
                        break;
                    case "3":
                        ViewDevelopersById();
                        break;
                    case "4":
                        UpdateExistingDevleoper();
                        break;
                    case "5":
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                        CreateNewTeam();
                        break;
                    case "7":
                        ViewAllTeams();
                        break;
                    case "8":
                        ViewTeamsById();
                        break;
                    case "9":
                        UpdateTeam();
                        break;
                    case "10":
                        DeleteTeam();
                        break;
                    case "11":
                        AddTeamMember();
                        break;
                    case "12":
                        RemoveTeamMember();
                        break;
                    case "13":
                        PluralsightReport();
                        break;
                    case "14":
                        Console.WriteLine("Thank you for using Komodo Insurance Developer Team Management Application. Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Your selection was invalid. Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            bool endErrorCheck = false;
            while (endErrorCheck == false)
            {
                int devID = 0;

                Console.WriteLine("Enter developer's ID:");

                if (int.TryParse(Console.ReadLine(), out int result) == true)
                {
                    devID = result;
                }

                if (devID <= 0)
                {
                    Console.WriteLine("ERROR: The developer ID must be numeric and greater than 0");
                }
                else
                {
                    Developer tempDev = _developerRepo.GetDeveloperById(devID);
                    if (tempDev != null)
                    {
                        Console.WriteLine("ERROR: The developer ID already exists.");
                    }
                    else
                    {
                        endErrorCheck = true;
                        newDeveloper.UniqueID = devID;
                    }
                }
            }

            Console.WriteLine("Enter developer's name:");
            newDeveloper.DevName = Console.ReadLine();

            Console.WriteLine("Does the developer have Pluralsight? (y/n)");
            string pluralsightAccess = Console.ReadLine().ToLower();

            if (pluralsightAccess == "y")
            {
                newDeveloper.HasPluralsight = true;
            }
            else
            {
                newDeveloper.HasPluralsight = false;
            }

            _developerRepo.AddDeveloperToList(newDeveloper);
        }
        public void ViewAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();

            foreach (Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Developer Name: {developer.DevName}\n" +
                    $"ID Number: {developer.UniqueID}\n");
            }
        }
        public void ViewDevelopersById()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID Number for the Developer you wish to view:");

            int idNumber = Convert.ToInt32(Console.ReadLine());
            Developer developer = _developerRepo.GetDeveloperById(idNumber);

            if (developer != null)
            {
                Console.Clear();
                Console.WriteLine($"Developer Name: {developer.DevName}\n" +
                    $"ID Number: {developer.UniqueID}");
               
                if (developer.HasPluralsight == true)
                {
                    Console.WriteLine("Pluralsight access: Y");
                }
                else
                {
                    Console.WriteLine("Pluralsight access: N");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No developer was found by that ID Number. Please try again.");
            }
        }
        public void UpdateExistingDevleoper()
        {
            ViewAllDevelopers();

            Console.WriteLine("Enter the ID Number of the Developer you would like to update:");

            int oldIdNumber = Convert.ToInt32(Console.ReadLine());

            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter a new ID Number for the Developer:");
            newDeveloper.UniqueID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a new name for the Developer:");
            newDeveloper.DevName = Console.ReadLine();

            Console.WriteLine("Does this Developer have access to Pluralsight? (y/n)");
            string hasPluralsightString = Console.ReadLine().ToLower();

            if (hasPluralsightString == "y")
            {
                newDeveloper.HasPluralsight = true;
            }
            else
            {
                newDeveloper.HasPluralsight = false;
            }
            bool wasUpdated = _developerRepo.UpdateDeveloperInfo(oldIdNumber, newDeveloper);

            if (wasUpdated)
            {
                Console.WriteLine("Developer successfully updated!");
            }
            else
            {
                Console.WriteLine("Developer could not be updated.");
            }
        }
        public void DeleteExistingDeveloper()
        {
            ViewAllDevelopers();

            Console.WriteLine("\nEnter the ID Number of the developer you'd like to remove:");

            int input = Convert.ToInt32(Console.ReadLine());

            bool wasDeleted = _developerRepo.RemoveDeveloperFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("The Developer was successfully deleted from the application.");
            }
            else
            {
                Console.WriteLine("The Developer could not be deleted.");
            }
        }
        public void CreateNewTeam()
        {
            Console.Clear();

            DevTeam newDevTeam = new DevTeam();

            Console.WriteLine("Enter a Team Number for the new team:");
            newDevTeam.TeamID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a name for the new Team:");
            newDevTeam.TeamName = Console.ReadLine();

            _devTeamRepo.AddDevTeamToList(newDevTeam);

            Console.WriteLine("To add Developers to this team, enter 1. Press any other key to return to the menu.");
               
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddTeamMember();
                    break;
                default:
                    Console.WriteLine("Returning to the menu...");
                    break;
            }
        }
        public void ViewAllTeams()
        {
            Console.Clear();

            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeamList();

            foreach (DevTeam team in listOfDevTeams)
            {
                Console.WriteLine($"\nTeam ID: {team.TeamID}\n" +
                    $"Team Name: {team.TeamName}");
            }
        }
        public void ViewTeamsById()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID Number for the team you would like to view:");
            int teamId = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            DevTeam teamToView = _devTeamRepo.GetDevTeamById(teamId);
            if (teamToView != null)
            {
                Console.WriteLine($"Team ID: {teamToView.TeamID}\n" +
                        $"\nTeam Name: {teamToView.TeamName}\n");
                string pSight = "No";

                foreach (Developer dev in teamToView.DeveloperList)
                {
                    if (dev.HasPluralsight == true)
                    {
                        pSight = "Yes";
                        break;
                    }
                }

                Console.WriteLine($"Has Pluralsight: {pSight}\n");
                Console.WriteLine($"Developers assigned to this team:");

                foreach (Developer dev in teamToView.DeveloperList)
                {
                    Console.WriteLine($"{dev.DevName}, {dev.UniqueID}");
                }
            }
            else
            {
                Console.WriteLine("No team was found using the entered Team ID number.");
            }
        }
        public void UpdateTeam()
        {
            ViewAllTeams();

            Console.WriteLine("Enter the Team ID for the team you would like to update:");
            int oldTeamInfo = Convert.ToInt32(Console.ReadLine());

            DevTeam newDevTeam = new DevTeam();

            Console.WriteLine("Enter the updated Team ID number:");
            newDevTeam.TeamID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the updated Team name:");
            newDevTeam.TeamName = Console.ReadLine();

            bool teamUpdated = _devTeamRepo.UpdateDevTeams(oldTeamInfo, newDevTeam);
            if (teamUpdated)
            {
                Console.WriteLine("Team successfully updated!");
            }
            else
            {
                Console.WriteLine("Team information was not updated.");
            }
        }
        public void DeleteTeam()
        {
            ViewAllTeams();

            Console.WriteLine("\nEnter the Team ID of the team you would like to remove:");
            int input = Convert.ToInt32(Console.ReadLine());

            bool wasDeleted = _devTeamRepo.RevmoveDevTeamFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("The team was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The team could not be deleted.");
            }
        }
        public void AddTeamMember()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the team you would like to add Developers to:");
            int teamID = Convert.ToInt32(Console.ReadLine());

            if (teamID != null)
            {
                Console.WriteLine("Enter the ID of the Developer you would like to add to the selected team. To add more than one Developer at a time, please separate the IDs with commas (11,13,14, etc...)");

                string DevIDs = Console.ReadLine();
                string[] arrDevID = DevIDs.Split(',');

                foreach (string s in arrDevID)
                {
                    int developerID = Convert.ToInt32(s);
                    Developer objDev = _developerRepo.GetDeveloperById(developerID);

                    _devTeamRepo.AddDevToTeam(objDev, teamID);
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid Team ID number.");
            }
        }
        public void RemoveTeamMember()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the team you would like to remove Developers from:");
            int teamID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the ID of the Developer you would like to remove from the selected team. To remove more than one Developer at a time, please separate the IDs with commas (11,13,14, etc...)");

            string DevIDs = Console.ReadLine();
            string[] arrDevID = DevIDs.Split(',');

            foreach (string s in arrDevID)
            {
                int developerID = Convert.ToInt32(s);
                Developer objDev = _developerRepo.GetDeveloperById(developerID);

                _devTeamRepo.RemoveDevFromTeam(objDev, teamID);
            }
        }
        public void PluralsightReport()
        {
            Console.Clear();
            Console.WriteLine("Press any key to see a list of all Developers with access to Pluralsight.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("The following Developers have access to Pluralsight:");
            foreach (Developer dev in _developerRepo.GetDeveloperList())
            {
                if (dev.HasPluralsight == true)
                {
                    Console.WriteLine($"Developer ID: {dev.UniqueID}\n" +
                        $"Developer Name: {dev.DevName}\n");
                }
            }
            DateTime now = DateTime.Now;
            Console.WriteLine($"This report was created {now}.");
        }
        private void SeedDeveloperList()
        {
            Developer abby = new Developer(1, "Abby Smith", true);
            Developer brian = new Developer(2, "Brian Jones", true);
            Developer carson = new Developer(3, "Carson Doe", false);
            Developer david = new Developer(4, "David Johnson", false);
            Developer evelyn = new Developer(5, "Evelyn Gonzalez", true);
            Developer frank = new Developer(6, "Frank Parks", false);

            _developerRepo.AddDeveloperToList(abby);
            _developerRepo.AddDeveloperToList(brian);
            _developerRepo.AddDeveloperToList(carson);
            _developerRepo.AddDeveloperToList(david);
            _developerRepo.AddDeveloperToList(evelyn);
            _developerRepo.AddDeveloperToList(frank);
        }
        private void SeedTeamList()
        {
            DevTeam teamA = new DevTeam(1, "The A Project Team");
            DevTeam teamB = new DevTeam(2, "The B Project Team");
            DevTeam teamC = new DevTeam(3, "The C Project Team");

            _devTeamRepo.AddDevTeamToList(teamA);
            _devTeamRepo.AddDevTeamToList(teamB);
            _devTeamRepo.AddDevTeamToList(teamC);
        }
    }
}

