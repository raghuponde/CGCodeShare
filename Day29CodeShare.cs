
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



next code 
----------
   private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
   {
       if (dataGridView1.CurrentRow == null) return;

       var emp = dataGridView1.CurrentRow.DataBoundItem as Employee;

       if (emp == null) return;

       textBox1.Text = emp.Id.ToString();
       textBox2.Text = emp.Name;
       textBox3.Text = emp.Department;
       textBox4.Text = emp.Salary.ToString();

   }
next code
---------
private void button3_Click(object sender, EventArgs e)//update code 
{
    if(!int.TryParse(textBox1.Text,out var id))
    {
        MessageBox.Show("select and employee to update");
        return;
    }

    var emp = db.Employees.SingleOrDefault(x => x.Id == id);
    if(emp==null)
    {
        MessageBox.Show("Employee not found");
        return;
    }
    emp.Name = textBox2.Text;
    emp.Department = textBox3.Text;
    emp.Salary = decimal.TryParse(textBox4.Text, out var s) ? s : emp.Salary;

    db.SubmitChanges();//generates update 
    LoadEmployees();
    clearfields();

}

next code 
----------
 private void button4_Click(object sender, EventArgs e)// deelete code 
 {
     if (!int.TryParse(textBox1.Text, out var id))
     {
         MessageBox.Show("select an employee to delete");
         return;
     }
     var emp = db.Employees.SingleOrDefault(x => x.Id == id);
     if(emp==null)
     {
         MessageBox.Show("Employee not found");
         return;
     }

     if (MessageBox.Show("delete this employee?", "confirm", 
         MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
     {
         return;
     }
     else
     {
         db.Employees.DeleteOnSubmit(emp);
         db.SubmitChanges();
         LoadEmployees();
         clearfields();
     }


 }

 Now same tasks i want to do using stored procedures 
 
 so these stored procedures i will put in db CG
 
 -- READ: Get all employees
CREATE PROCEDURE sp_GetEmployees
AS
BEGIN
    SELECT Id, Name, Department, Salary FROM Employees;
END
GO

-- CREATE: Insert new employee
CREATE PROCEDURE sp_InsertEmployee
    @Name NVARCHAR(100),
    @Department NVARCHAR(50),
    @Salary DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Employees (Name, Department, Salary)
    VALUES (@Name, @Department, @Salary);
END
GO

-- UPDATE: Modify employee
CREATE PROCEDURE sp_UpdateEmployee
    @Id INT,
    @Name NVARCHAR(100),
    @Department NVARCHAR(50),
    @Salary DECIMAL(10,2)
AS
BEGIN
    UPDATE Employees SET
        Name = @Name, Department = @Department, Salary = @Salary
    WHERE Id = @Id;
END
GO

-- DELETE: Remove employee
CREATE PROCEDURE sp_DeleteEmployee
    @Id INT
AS
BEGIN
    DELETE FROM Employees WHERE Id = @Id;
END
GO

CREATE PROCEDURE sp_GetEmployeeById
    @Id INT
AS
BEGIN
    SELECT Id, Name, Department, Salary 
    FROM Employees 
    WHERE Id = @Id;
END
GO
