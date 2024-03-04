namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            stringText.Text = Properties.Settings.Default.OriginalStr.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            
            try
            {
                str = stringText.Text;
            }
            catch (FormatException) 
            {            
                return; 
            }
            
            Properties.Settings.Default.OriginalStr = this.stringText.Text;
            Properties.Settings.Default.Save();

            MessageBox.Show("Слова в обратном порядке: \n" + Logic.Change(str));
        }
    }

    public class Logic
    {
        public static string Change(string a)
        {
            string[] slova = a.Split(" ");
            string[] newStr = new string[slova.Length];
            string newString = "";
            for (int i = 0; i < slova.Length - 1; i++)
            {
                newStr[i] = slova[slova.Length - i - 1];
                newString += newStr[i] + " ";
            }
            newStr[slova.Length - 1] = slova[0];
            newString += newStr[slova.Length - 1];


            return newString;
        }
    }
}
