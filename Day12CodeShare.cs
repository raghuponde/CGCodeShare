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
          DialogResult res= openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                string file1 = openFileDialog1.FileName;
                try
                {
                    fs=new FileStream(file1,FileMode.Open);
                    sr=new StreamReader(fs);
                    textBox1.Text = sr.ReadToEnd();
                }
                catch(Exception ex)
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
    }
}
