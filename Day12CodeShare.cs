
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
          DialogResult res=  colorDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color; 
            }
        }
    }
}
