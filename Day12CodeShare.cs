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
