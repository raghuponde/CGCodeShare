namespace FileHandlinginWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = fontDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }
        FileStream fs;
        StreamReader sr;
        StreamWriter sw;
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                string file1 = openFileDialog1.FileName;
                try
                {
                    fs = new FileStream(file1, FileMode.Open);
                    sr = new StreamReader(fs);
                    textBox1.Text = sr.ReadToEnd();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    fs.Close();
                    sr.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                string file2 = saveFileDialog1.FileName;
                try
                {
                    fs = new FileStream(file2, FileMode.Create);
                    sw = new StreamWriter(fs);
                    sw.Write(textBox1.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                string file3 = saveFileDialog1.FileName;
                try
                {
                    fs = new FileStream(file3, FileMode.Append);
                    sw = new StreamWriter(fs);
                    sw.Write(textBox1.Text);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            DialogResult sourceResult = openFileDialog1.ShowDialog();
            if (sourceResult == DialogResult.OK)
            {
                string sourceFile = openFileDialog1.FileName; 

                DialogResult destResult = saveFileDialog1.ShowDialog();
                if (destResult == DialogResult.OK)
                {
                    string destFile = saveFileDialog1.FileName;

                    File.Copy(sourceFile, destFile, true);
                    MessageBox.Show("File copied successfully.");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                if (MessageBox.Show($"Are you sure you want to delete {filename}?", "Confirm Delete", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    File.Delete(filename);
                    MessageBox.Show("File deleted successfully.");
                }
            }
        }
    }
}




File Handling in Console 
-------------------------
add one file of txt into the project and go to proeprties of that file and make this
copy to output directory :always copy do it and add some text data from lipsum.com 

from 3rd method copy the path of file in txt file and paste it in command prompt and execute the code 
it is same as windows only readdata we are using seek method means where to start and end etc 


namespace FileHandlinginConsole
{
    internal class Program
    {
        public static void readdata()
        {
            FileStream fs = null;
            StreamReader sr;

            fs = new FileStream(@"D:\CapgeminiChandigarh\Day12\Day12Projects\FileHandlinginConsole\sample.txt", FileMode.Open,FileAccess.Read);
            sr= new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            //first try above then put 200 and begin it will come 
            // put 200 and say end nothing will come 
            // put -200 and say end from backward direction it will read 
            // here first take the psotion to begin and after leaving 100 read it okay 
            // in the same manner current psotion by default will be begining only so again it 
            // will go to begining as current and after leaving 100 prrint all 
            // now if i write end then cussor will go to end point and after 100 spaces it will read
            // where of course data 
            // wont be there so u can do -100 and say end then curose will go 100 inside from back side
            // and after that
            // we  will read so this is the logic          
            string str = sr.ReadLine();
            while (str != null)
            {
                Console.WriteLine($"{str}");
                str = sr.ReadLine();


            }

        }
        public static void writedata()
        {
            FileStream fs = new FileStream
                (@"D:\CapgeminiChandigarh\Day12\Day12Projects\FileHandlinginConsole\sample.txt",
                FileMode.Append, FileAccess.Write);
            Console.WriteLine("enter something inside the file ");
            string input = Console.ReadLine();
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(input);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        public static void fileappend()
        {

            Console.WriteLine("Enter the file path where you want to save the text:");
            string filePath = Console.ReadLine();

            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Append))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        Console.WriteLine("Enter the text you want to append:");
                        string textToAppend = Console.ReadLine();

                        sw.Write(textToAppend);
                        sw.Flush();
                    }

                    Console.WriteLine("Text appended successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("No file path provided.");
            }
        }

        public static void filecopy()
        {
            Console.WriteLine("Enter the source file path:");
            string sourceFilePath = Console.ReadLine();

            if (File.Exists(sourceFilePath))
            {
                Console.WriteLine("Enter the destination file path:");
                string destinationFilePath = Console.ReadLine();

                try
                {
                    File.Copy(sourceFilePath, destinationFilePath, true);
                    Console.WriteLine("File copied successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while copying the file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("The source file does not exist.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static void filedelete()
        {
            Console.WriteLine("Enter the file path you want to delete:");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                Console.WriteLine($"Are you sure you want to delete {filePath}? (yes/no)");
                string confirmation = Console.ReadLine();

                if (confirmation?.ToLower() == "yes")
                {
                    try
                    {
                        File.Delete(filePath);
                        Console.WriteLine("File deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while deleting the file: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("File deletion canceled.");
                }
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
           // readdata();
            writedata();
            //  fileappend();
            // filecopy();
            //filedelete();
            Console.ReadLine();
        }
    }
}


Logging 
-------
In real world applications how do you make sure that your application is running successfully without any error And even though some errors are encountered how do you track them so You need to record and track the error which are occurring in your application at run time  and that recording process is called as logging 

Exactly when ever the execution sequence has reached to specific method for example execution has been reached to specific action method then at that you will leave message in the log telling what is the status of the program or 
anything where u are are etc so this log diplays and stores the log message for later review purpose

eg some user has specified that while executing i am getting error message so that message we can see log information 

because log is the record of all the actions and errors during execution time okay 

check slide logging1 now from the folder 

check slide logging2 now as from each layer of application we can leave log message

so you can see there from loggng2  logging framework is the mediator between the application layer and the logs 

so logs are here data store where actual data messages are persisted so you can review them at any point of time

so here in logging2 slide except console logs other logs can be reviewed later okay because all the remaining logs are persisted for later review purpose okay 

persistent means sql where permenant storage is given not on fly like if i use collection arrays they are not stored 
when i stop the application the values will go .

But his console log display the error message immedtely in krestel window itself 


so in this section we will see how do we create and persist the log and we will also learn about third party log framework which is serilog which is extremely popular in asp.net core space 

logging is very much important to track the application health 

now check slide logging3 here we can see the different log levels okay 

based on purpose we have to choose and log information into them suppose u want to provide the current value of particular variable then u have to use debug log and other log levels the explanation is given okay 

so they are classifed based on pupose and situation of the log 

image there is a loop that executed ten times 

while (i < 10)

you want to execute and want to check current value of i in the loop everytime 
for change in current value of i you use log debug method okay 

while connecting to file or database there is an exception how do u write that exception details in log 
using error log okay 

suppose u have connected but u are unable to update the data then that is called  warning so keep it in warning log 


now add an asp.net core empty web app C#  windows and web 

and in program.cs file add like this 

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            app.Logger.LogDebug("debug-message");
            app.Logger.LogInformation("info-message");
            app.Logger.LogWarning("warn-message");
            app.Logger.LogError("error-message");
            app.Logger.LogCritical("critical-message");

            app.Run();
        }
    }
}

now then run the application https u can see these messages im kresetel server okay ..here what i am seeing that except 
debug all logs are getting displayed 

so debug i cannot see and another is there which is trace that also i am not seeing it here okay 

as they have set that information and other should be shown when we are going with web based applictions okay 


so how do change this settings let us see now 

now check logging4 slide 

so once go and check the appsetting and its internal file also default u  can see like this 

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

so manually if u change also it will move to inernal file where it will check development settings 

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}


so after expanding appsettings.json i am seeing development file which is above code written okay 

so here if i keep warning then as per slide u can see the order after warning all will be logged and debug and information will not be shown okay 

now above file add Debug and here u have to write your own logic for your own logic it works and now for asp.net core libararies it is better to keep "warning" so now after this setting i can see debug message as well 



{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}


dbug: WebApplication1[0]
      debug-message
info: WebApplication1[0]
      info-message
warn: WebApplication1[0]
      warn-message
fail: WebApplication1[0]
      error-message
crit: WebApplication1[0]
      critical-message
	  
	  
okay 

so now let us see logging providers okay 

now check logging5 slide okay

The above slide is telling me that where i can see theses message and all one is automatically in krestel server 

and another is  in output window debug option also u can see not check logging 6 slide


so another place where u can check is go to start menu and type event viewer and custom views and go insdie that here 
debug is not default but information messages i can check okay 

select source as .netruntime and see logs checking logging7 slide for this okay 

now right side create custom view add above setting as shown in logging8 

and give some name to view after these settinngs and say okk so same is created as custom view and shown here 

so i want to show debug also 

go to development setting internal file and do the following changes okay ...

so 

{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "EventLog": {
    "LogLevel": {
      "Default": "Debug"
     
    }
  }
}


now build and run and again go to event viewer which u have created and refresh it once to see ..debug also 

after doing this much setting also i am not seeing inoformation icon as in that i can see the debug message 


now i dont have any project or i dont know any web based programing where i can go inside difffernt layers of project 
like controllers ,presentation and data access layer where i can implement this logging which i had learned 

i am creating a person class and on that person class i am adding some methods and from middle ware i am calling those methods and when it goes into each stage of excution i keep log message which u can see okay so this program name is 

add one class 

namespace WebApplication1
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}


another class 

namespace WebApplication1
{
    public class PersonService
    {

        public readonly ILogger<PersonService> _logger;

        public PersonService(ILogger<PersonService> logger)
        {
            _logger = logger;
        }

        List<Person> persons = new List<Person>()
        {
            
            new Person(){ Id=1, Name="Alice"},
            new Person(){ Id=2, Name="Bob"},
            new Person(){ Id=3, Name="Charlie"},
        };
        public IEnumerable<Person> GetAllPersons()
        {
            _logger.LogInformation("Fetching all persons");
            return persons;
        }

public Person? GetPersonById(int id)
{
	_logger.LogInformation("Fetching person with ID: {Id}", id);
			foreach (Person p in persons)
			{
			if (p.Id == id)
			{
			return p;
			}
			}
			return null;
}


        public void AddPerson(Person person)
        {
            _logger.LogInformation("Adding new person with ID: {Id}", person.Id);
            persons.Add(person);
        }

    }
}

and now program.cs will look like this 


namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.AddEventLog();
            // Register PersonService as singleton (to preserve data)
            builder.Services.AddSingleton<PersonService>();


            var app = builder.Build();

           // app.MapGet("/", () => "Hello World!");
            app.Logger.LogDebug("debug-message");
            app.Logger.LogInformation("info-message");
            app.Logger.LogWarning("warn-message");
            app.Logger.LogError("error-message");
            app.Logger.LogCritical("critical-message");

           
            

            // Get logger and service instances
            var logger = app.Services.GetRequiredService<ILogger<Program>>();
            var personService = app.Services.GetRequiredService<PersonService>();

            // === DEMONSTRATE PersonService METHODS ===
            logger.LogInformation("=== Starting PersonService Demo ===");

            // 1. Get All Persons
            logger.LogInformation("1. Calling GetAllPersons()");
            var allPersons = personService.GetAllPersons();
            foreach (var person in allPersons)
            {
                logger.LogInformation($"Found person: ID={person.Id}, Name={person.Name}");
            }

            // 2. Get Person by ID
            logger.LogInformation("2. Calling GetPersonById(2)");
            var person2 = personService.GetPersonById(2);
            if (person2 != null)
                logger.LogInformation($"Person found: ID={person2.Id}, Name={person2.Name}");
            else
                logger.LogWarning("Person with ID 2 not found!");

            // 3. Add New Person
            logger.LogInformation("3. Calling AddPerson()");
            var newPerson = new Person { Id = 4, Name = "David" };
            personService.AddPerson(newPerson);
            logger.LogInformation($"Added new person: ID={newPerson.Id}, Name={newPerson.Name}");

            // Verify addition
            var updatedList = personService.GetAllPersons();
            logger.LogInformation($"Total persons now: {updatedList.Count()}");

            // Test non-existent ID
            logger.LogInformation("4. Testing GetPersonById(999)");
            var missingPerson = personService.GetPersonById(999);
            if (missingPerson == null)
                logger.LogWarning("Person ID 999 not found (expected)");

            logger.LogInformation("=== Demo Complete ===");

            // Minimal HTTP endpoint to test service (optional)
            app.MapGet("/", () => "PersonService Demo - Check console logs!");

            app.Run();

            
        }
    }
}

so this program i had stored in Day12 folder only for your reference okay 
