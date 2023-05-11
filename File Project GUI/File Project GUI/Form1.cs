namespace File_Project_GUI
{
    public partial class Form1 : Form
    {
        FileStream fs;
        StreamWriter sw;
        StreamReader sr;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fs = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);
            sr = new StreamReader(fs);
            MessageBox.Show("Opened");
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sw.Close();
            fs.Close();
            MessageBox.Show("Closed");
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                fs.Seek(0, SeekOrigin.End);
                sw.WriteLine(textBox1.Text);
                sw.Flush();
                MessageBox.Show("Done");
                textBox1.Clear();
            }
            else
                MessageBox.Show("Enter data");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            fs.Seek(0, SeekOrigin.Begin);
            textBox2.Text = "";
            string str;
            while ((str = sr.ReadLine()) != null)
            {
                int n = str.Length;
                for (int i = 0; i < n; i++)
                {
                    // Count occurrences of current character
                    int count = 1;
                    while (i < n - 1 && str[i] == str[i + 1])
                    {
                        count++;
                        i++;
                    }
                    // Print character and its count
                    textBox2.Text += str[i];
                    textBox2.Text += Convert.ToString(count);
                }
                textBox2.Text += "\r\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}