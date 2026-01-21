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


<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net8.0-windows</TargetFramework>
    <Nullable>enable</Nullable>
    <UseWindowsForms>true</UseWindowsForms>
    <ImplicitUsings>enable</ImplicitUsings>
	  <EnableUnsafeBinaryFormatterSerialization>true</EnableUnsafeBinaryFormatterSerialization>
  </PropertyGroup>

  <ItemGroup>
    <None Include="bin\Debug\net8.0-windows\data.dat" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="BinaryFormatter" Version="3.0.0" />
    <PackageReference Include="SoapFormatter" Version="1.1.9" />
    <PackageReference Include="System.Runtime.Serialization.Formatters" Version="10.0.2" />
  </ItemGroup>

</Project>

post lunch join batch code :CAP-.NE-JAN-OFF-0091
	and give the exam 

Linq 
********
Data sources means which provides data 

Types of data sources :

--->flat files like .txt,xml etc they provide data (file hanlding) 

--->collection objects also contains data like array ,arraylist etc (programming like for loops and for each loop etc  )

--->tables also contain data (to reqtrive data sql is used,ado.net etc )

The same data u want to access from different data sources provided in easy way 
then u will use linq 

if u are using linq to access objects in memory objects then it is called linqtoobjects

if u are using linq to access sql then it is called as linq to sql 

thrid party softwares access linq to amazon is also there 



The acronym LINQ stands for Language Integrated Query.

Microsoft’s query language is
fully integrated and offers easy data access from in-memory objects, databases, XML
documents, and many more. 

In your syllabus they have given only linq to objects so we will be doing demos only on this 


syntax will be like sql way but select comes last and from comes first and in between where ,order by and other functionalities can be used .



