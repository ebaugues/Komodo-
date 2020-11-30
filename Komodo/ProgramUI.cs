using _DevTeamsProject;
using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo
{
    class ProgramUI
    {
        //private StreamingContentRepository _contentRepo = new StreamingContentRepository();
        private DevTeamRepo _developerTeamRepo = new DevTeamRepo();
        private DeveloperRepo _developerDirectory = new DeveloperRepo();

        //Method that runs/starts the appliaction
        public void Run()
        {
            seedContentList();
            Menu();
        }

        //Menu method
        private void Menu()
        {

            bool keepRunning = true;
            while (keepRunning)
            {



                //Display the options
                Console.WriteLine("Select a menu option:\n" +
                    "1 - Add New Developer\n" +
                    "2 - View All Developers\n" +
                    "3 - View Developer by ID\n" +
                    "4 - Update Existing Developer\n" +
                    "5 - Delete Existing Developer\n" +
                    "6 - Add New Team\n" +
                    "7 - View All Teams\n" +
                    "8 - View Team by ID\n" +
                    "9 - Update Existing Team\n" +
                    "10 -Delete Existing Team\n" +
                    "11 - Exit");

                // Get users input
                string input = Console.ReadLine();


                //Evaluate user input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create new developer
                        CreateNewDeveloper();
                        break;

                    case "2":
                        //View all developers
                       DisplayAllDevelopers();
                        break;

                    case "3":
                        //View developer by ID
                        DisplayDeveloperById();
                        break;

                    case "4":
                        //Update Existing developer
                       UpdateDeveloper();
                        break;

                    case "5":
                        //Delete Existing developer
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                        //Add new team
                        CreateNewTeam();
                        break;
                    case "7":
                        //View all team
                        DisplayAllTeams();
                        break;
                    case "8":
                        //View team by ID
                        DisplayTeamById();
                        break;
                    case "9":
                        //Update team by ID
                        UpdateTeam();
                        break;

                    case "10":
                        //Delete Team
                        DeleteExistingTeam();
                        break;

                    case "11":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;


                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }



        }


        //Creating new Developer
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            //EmployeeId
            Console.WriteLine("Enter a unique ID for the Employee:");
            newDeveloper.EmployeeId = Console.ReadLine();

            //EmployeeName
            Console.WriteLine("Enter the name for the Employee:");
            newDeveloper.EmployeeName = Console.ReadLine();

            //EmployeeStartDate
            Console.WriteLine("Enter the Employee Start Date (MM-DD-YYYY): ");
            DateTime userDateTime;
            bool FoundDate;
            if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
            {
                newDeveloper.StartDate = userDateTime;
                 FoundDate = true;
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
                 FoundDate = false;

            } 

            //Pluralsight Licence
            Console.WriteLine("Does Employee have Pluralsight Licence (Y/N):");
            string Pluralsight = Console.ReadLine().ToUpper();
            if (Pluralsight == "Y")
            {
                newDeveloper.PluralsightLicence = true;
            }
            else
            {
                newDeveloper.PluralsightLicence = false;
            }

            //IsActive
            Console.WriteLine("Is the Employee still active (Y/N)?:");
            string Active = Console.ReadLine().ToUpper();
            if (Active == "Y")
            {
                newDeveloper.ActiveEmplyoee = true;
            }
            else
            {
                newDeveloper.ActiveEmplyoee = false;
            }


            //show everything on content list
            List<DevTeam> listofTeams = _developerTeamRepo.GetDeveloperTeamLists();

            Console.WriteLine("List of Teams:\n");
            foreach (DevTeam devTeam in listofTeams)
            {
                Console.WriteLine($"Team ID: {devTeam.TeamId}  , Desc: {devTeam.TeamDescription}\n");      
            }
            string devteamid = Console.ReadLine();
            //bool isConvertible = false;
            //int parsedInt = 0;
            bool FoundTeam = false;
            if (int.TryParse(devteamid, out int parsedInt))
            {
                //Find Team in List
                DevTeam devTeamFind = _developerTeamRepo.GetDevTeamById(parsedInt);
               
                if (devTeamFind != null)
                {
                    newDeveloper.DevTeamId = devTeamFind.TeamId;
                    FoundTeam = true;
                }
                else
                {
                    Console.WriteLine($"Team: {devteamid} not found.");
                    FoundTeam = false;
                }

            }

            else
            {
                Console.WriteLine($"Team: {devteamid} not found.");
            }

            if (FoundDate == true && FoundTeam == true)
            {
                 _developerDirectory.AddDeveloperToLists(newDeveloper);
                
            }
            else
            {
                Console.WriteLine("Developer Not Created - Required Information not entered properly.  Try Again!!");
             }
            
        }

        //View All Current Developers 
        private void DisplayAllDevelopers()
        {
            Console.Clear();

            //show everything on content list
            List<Developer> listofDeveloper = _developerDirectory.GetDeveloperLists();

            foreach (Developer developer in listofDeveloper)
            {
                Console.WriteLine($"Employee ID: {developer.EmployeeId}\n" +
                    $", Name: {developer.EmployeeName}\n" +
                    $", Team ID: {developer.DevTeamId}\n" +
                    $", Plural Licence: {developer.PluralsightLicence}\n" +
                    $", Start Date: {developer.StartDate}\n" +
                    $", Active: {developer.ActiveEmplyoee}"); 
            }

        }

        //View existing Developer by ID
        private void DisplayDeveloperById()
        {
            Console.Clear();
            //Prompt user to give title
            Console.WriteLine("Enter the id of the developer you'd like to see:");

            //get the user's input
            string employeeId = Console.ReadLine();
         
                //Find the developer by id
                Developer developer = _developerDirectory.GetDeveloperById(employeeId);


                //Display Developer if it isn't null
                if (developer != null)
                {
                    Console.WriteLine($"Employee ID: {developer.EmployeeId}\n" +
                     $", Name: {developer.EmployeeName}\n" +
                     $", Team ID: {developer.DevTeamId}\n" +
                     $", Plural Licence: {developer.PluralsightLicence}\n" +
                     $", Start Date: {developer.StartDate}\n" +
                     $", Active: {developer.ActiveEmplyoee}");
                 }
                else
                {
                    Console.WriteLine($"EmployeeId [{employeeId}] not found.");
                }
            
         }


        //Update Existing Content
        private void UpdateDeveloper()
        {

            //Display all content
            DisplayAllDevelopers();

            // Ask for the title to update
            Console.WriteLine("Enter the EmployeeID of the employee you'd like to update:");

            //Get that title
            string EmployeeId = Console.ReadLine();

            //We will build new object
            Console.Clear();
            Developer newDeveloper = new Developer();

            //EmployeeName
            Console.WriteLine("Enter the name for the Employee:");
            newDeveloper.EmployeeName = Console.ReadLine();

            //EmployeeStartDate
            Console.WriteLine("Enter the Employee Start Date (MM-DD-YYYY): ");
            DateTime userDateTime;
            if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
            {
                newDeveloper.StartDate = userDateTime;
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
            }

            //Pluralsight Licence
            Console.WriteLine("Does Employee have Pluralsight Licence (Y/N):");
            string Pluralsight = Console.ReadLine().ToUpper();
            if (Pluralsight == "Y")
            {
                newDeveloper.PluralsightLicence = true;
            }
            else
            {
                newDeveloper.PluralsightLicence = false;
            }

            //IsActive
            Console.WriteLine("Is the Employee still active (Y/N)?:");
            string Active = Console.ReadLine().ToUpper();
            if (Active == "Y")
            {
                newDeveloper.ActiveEmplyoee = true;
            }
            else
            {
                newDeveloper.ActiveEmplyoee = false;
            }


            bool wasUpdated = _developerDirectory.UpdateExistingDeveloper(EmployeeId, newDeveloper);

            if (wasUpdated)
            {
                Console.WriteLine("Employee was updated successfully.");
            }
            else
            {
                Console.WriteLine("Could not update Employee.");
            }
        }

        //Delete Existing Employee
        private void DeleteExistingDeveloper()
        {

            DisplayAllDevelopers();

            //Get the title they want to remove
            Console.WriteLine("\nEnter the employee id you'd like to remove:");
            string input = Console.ReadLine();

            //Call the delete method
            bool wasDeleted = _developerDirectory.RemoveDeveloperFromLists(input);

            //If the content was deleted, say so
            //Otherwise state if could not be deleted/found
            if (wasDeleted)
            {
                Console.WriteLine("The employee was successfully deleted.");

            }
            else
            {
                Console.WriteLine("The employee could not be deleted.");
            }

        }


        //Creating new Team
        private void CreateNewTeam()
        {
            Console.Clear();
            DevTeam newTeam = new DevTeam();

            //show everything on content list
            List<DevTeam> listofTeams = _developerTeamRepo.GetDeveloperTeamLists();

            //Show all teams
            Console.WriteLine("List of Teams:\n");
            foreach (DevTeam devTeam in listofTeams)
            {
                Console.WriteLine($"Team ID: {devTeam.TeamId}  , Desc: {devTeam.TeamDescription}\n");
            }


            //Might want to add check to see if it is unique
            //TeamId
            Console.WriteLine("Enter a unique ID (integer) for the Team:");
            string teamid = Console.ReadLine();
            int number;
            Int32.TryParse(teamid, out number);
            newTeam.TeamId = number;  //Need to switch to int

            //Team Description
            Console.WriteLine("Enter the Team Description:");
            newTeam.TeamDescription = Console.ReadLine();

            //Employeesfor team, initalize to blank
            //newTeam.Employees 

            //Team  Active, Initialize to true
            newTeam.TeamActive = true;

            //if (FoundDate == true && FoundTeam == true)
            //{
            _developerTeamRepo.AddToTeamsLists(newTeam); //       (newDeveloper);

            //}
            //else
           // {
            //    Console.WriteLine("Team not Created - Required Information not entered properly.  Try Again!!");
           // }

        }

             //View All Teams 
        private void DisplayAllTeams()
        {
            Console.Clear();

            //show everything on content list
            List<DevTeam> listofTeams = _developerTeamRepo.GetDeveloperTeamLists();

            Console.WriteLine("List of Teams:\n");
            foreach (DevTeam devTeam in listofTeams)
            {
                Console.WriteLine($"Team ID: {devTeam.TeamId}  , Desc: {devTeam.TeamDescription}\n");      
            }

        }


        //View existing Developer by ID
        private void DisplayTeamById()
        {
            Console.Clear();
            //Prompt user to give title
            Console.WriteLine("Enter the id of the team you'd like to see:");

            //get the user's input
            string teamId = Console.ReadLine();
            int teamidint = Convert.ToInt16(teamId);
           
                //Find the content by title
                DevTeam devTeam = _developerTeamRepo.GetDevTeamById(teamidint);

                //Display Team if it isn't null
                if (devTeam != null)
                {
                    Console.WriteLine($"Team ID: {devTeam.TeamId}\n" +
                     $", Team Description: {devTeam.TeamDescription}\n" +
                     $", Active: {devTeam.TeamActive}");
                    bool Employees;
                    int emp = _developerTeamRepo.AreDevlopers(teamidint);
                    if (emp == 0)
                        {
                           Employees = false;
                        }
                    else
                        {
                           Employees = true;
                        }
                     Console.WriteLine($"*********LIST OF EMPLOYEES**********\n");
                    if (Employees)
                    {
                      foreach (Developer developer in devTeam.Employees)
                            {
                            Console.WriteLine($"Employee ID: {developer.EmployeeId}\n" +
                            $", Name: {developer.EmployeeName}\n" +
                            $", Team ID: {developer.DevTeamId}\n" +
                            $", Plural Licence: {developer.PluralsightLicence}\n" +
                            $", Start Date: {developer.StartDate}\n" +
                            $", Active: {developer.ActiveEmplyoee}\n\n");
                            }
                    }
                    else
                    {
                            Console.WriteLine("No Employees in Team!!\n");
                    }
                 }
                else
                {
                    Console.WriteLine($"TeamId [{teamId}] not found.");
                }
            
         }


         //Update Existing Team
        private void UpdateTeam()
        {
            Console.Clear();

            //Display all teams
            DisplayAllTeams();

            // Ask for the id to update
            Console.WriteLine("Enter the TeamId of the team you'd like to update:");

            //Get that title
            string teamId = Console.ReadLine();
            int teamidint = Convert.ToInt32(teamId);

            //We will build new object
            Console.Clear();
            DevTeam newTeam = new DevTeam();

            //Team Name
            Console.WriteLine("Enter a Team description:");
            newTeam.TeamDescription = Console.ReadLine();

          
            //Team Active
            Console.WriteLine("Team Active (Y/N):");
            string TeamActive = Console.ReadLine().ToUpper();
            if (TeamActive.Contains("Y"))
            {
                newTeam.TeamActive = true;
            }
            else
            {
                newTeam.TeamActive = false;
            }

            Console.WriteLine("*********LIST OF EMPLOYEES TO ADD**********\n");
            Console.WriteLine("*****THIS WILL MOVE THEM TO NEW TEAM********\n");
            //Build a new list of employees
            List<Developer> _newdeveloperList = new List<Developer>();
                   

            bool KeepAddingDevelopers = true;
            while (KeepAddingDevelopers)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1 - Add New Employee to Team by Id\n" +
                    "2 - End adding developers\n");
                string inputdev = Console.ReadLine();
                 
              switch (inputdev)
                   {
                        case "1":
                            Console.WriteLine("Enter Employee Id:\n");
                            string employeeId = Console.ReadLine();
                            bool EmployeeFound = _developerDirectory.FindDeveloper(employeeId);
                            if (EmployeeFound)
                            {
                             //Find the developer by id
                            Developer developer = _developerDirectory.GetDeveloperById(employeeId);
                            _newdeveloperList.Add(developer);
                            }
                            else
                            {
                            Console.WriteLine($"Employee ID [{employeeId}] not found, try again.");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Done adding!");
                            KeepAddingDevelopers = false;  
                            break;
                        default:
                            Console.WriteLine("Insert a correct value");
                            Console.WriteLine("Please press any key to continue...");
                            Console.ReadKey();
                            break;
                   }
                

            }
            newTeam.Employees = _newdeveloperList;
            bool wasUpdated = _developerTeamRepo.UpdateExistingDevTeam(teamidint, newTeam);

            if (wasUpdated)
            {
                Console.WriteLine("Team was updated successfully.");
            }
            else
            {
                Console.WriteLine("Could not update Team.");
            }
        }

        //Delete Existing Team
        private void DeleteExistingTeam()
        {
            Console.Clear();
            DisplayAllTeams();

            //Get the title they want to remove
            Console.WriteLine("\nEnter the team id you'd like to remove:");
            string input = Console.ReadLine();
            int teamid = Convert.ToInt32(input);

            //Call the delete method
            bool wasDeleted =  _developerTeamRepo.RemoveDevTeamFromLists(teamid);

            //If the content was deleted, say so
            //Otherwise state if could not be deleted/found
            if (wasDeleted)
            {
                Console.WriteLine("The team was successfully deleted.");

            }
            else
            {
                Console.WriteLine("The team could not be deleted.");
            }

        }

        //See method
        private void seedContentList()
        {

            
            Developer Erik = new Developer("1", 2, "Erik Baugues", true, new DateTime(2008, 3, 1), true);
            Developer Derek = new Developer("2", 2, "Derek Fenwick", true, new DateTime(2006, 8, 21), true);
           
            Developer Judy = new Developer("3", 1, "Judy Salinger", true, new DateTime(2000,1, 15), false);
            Developer Riley = new Developer("4", 3, "Riley Tatlock", true, new DateTime(2000, 1, 15), false);
            Developer Kayte = new Developer("5", 4, "Kayte SImon", true, new DateTime(2019, 2, 22), false);

            _developerDirectory.AddDeveloperToLists(Erik);
            _developerDirectory.AddDeveloperToLists(Derek);
            _developerDirectory.AddDeveloperToLists(Judy);
            _developerDirectory.AddDeveloperToLists(Riley);
            _developerDirectory.AddDeveloperToLists(Kayte);

            List<Developer> DeveloperList = new List<Developer>();
            DeveloperList.Add(Erik);
            DeveloperList.Add(Derek);

            DevTeam Developers = new DevTeam(DeveloperList, "Development", 2, true);
            _developerTeamRepo.AddToTeamsLists(Developers);

            List<Developer> HRList = new List<Developer>();
            HRList.Add(Judy);
            
            DevTeam HR = new DevTeam(HRList, "Human Resources", 1, true);
            _developerTeamRepo.AddToTeamsLists(HR);


            List<Developer> CSList = new List<Developer>();
            CSList.Add(Riley);

            DevTeam CS = new DevTeam(CSList, "Client Services", 3, true);
            _developerTeamRepo.AddToTeamsLists(CS);

            List<Developer> ProdList = new List<Developer>();
            ProdList.Add(Kayte);

            DevTeam Production = new DevTeam(ProdList, "Production", 4, true);
            _developerTeamRepo.AddToTeamsLists(Production);
        }


    }
}
