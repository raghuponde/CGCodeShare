
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LnqToSqlDemo
{
    public partial class Form1 : Form
    {

        private DataClasses1DataContext db;
        public Form1()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
        }

        private void button1_Click(object sender, EventArgs e)//load
        {
            LoadEmployees();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void LoadEmployees()
        {
            dataGridView1.DataSource = db.Employees.ToList();
        }
        private void clearfields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)//insert 
        {
            if(string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Name is required");
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Dept is required");
                return;
            }
            //if (string.IsNullOrEmpty(textBox4.Text))
            //{
            //    MessageBox.Show("Salary is required");
            //    return;
            //}
            var emp = new Employee
            {
                Name = textBox2.Text,
                Department = textBox3.Text,
                Salary=decimal.TryParse(textBox4.Text,out var s)?s:0


            };
            db.Employees.InsertOnSubmit(emp);
            db.SubmitChanges();
            LoadEmployees();
            clearfields();


        }
    }
}
