Serilization :
**************
For an application all its data is stored in memory what if u want to store that data somewhere else or transport it to some process or to some other location for that u have to convert that data into 
binary ,xml or some other format to store it or transfer so we can say saving the state of an object  permenantly in one format is called as serilization .

open one windows based application and put one button and one text box as well 
addd reference to dll file
System.Runtime.Serialization.Formatters.Binary;and 
System.Runtime.Serialization.Formatters.Soap; and as usual include namespaces 

add three text boxes and one button for serilize and deserilize like that and code is below 

using System.Collections;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
namespace serilization
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ArrayList obj = new ArrayList();
        private void button1_Click(object sender, EventArgs e)
        {
            obj.Add(textBox1.Text);
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoapFormatter ss = new SoapFormatter();
            string filename = @"D:\sampledemo1.xml";
            using (FileStream fs = new FileStream
                (filename, FileMode.Create))
            {
                ss.Serialize(fs, obj);
            }
        }





        [Serializable]
        class Customer
        {
            public int CustomerID { set; get; }
            public string CustomerName { set; get; }
            public string City { set; get; }
        }
        private const string filename2 = "data.dat";
        FileStream fs;
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter;


        private void button3_Click(object sender, EventArgs e)
        {

            Customer c1 = new Customer();
            c1.CustomerID = Convert.ToInt32(textBox2.Text);
            c1.CustomerName = textBox3.Text;
            c1.City = textBox4.Text;
            fs = File.Create(filename2);
            formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            formatter.Serialize(fs, c1);
            fs.Close();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            fs = File.OpenRead(filename2);
            Customer c2 = (Customer)formatter.Deserialize(fs);
            textBox2.Text = c2.CustomerID.ToString();
            textBox3.Text = c2.CustomerName;
            textBox4.Text = c2.City;
            fs.Close();

        }
    }
}
