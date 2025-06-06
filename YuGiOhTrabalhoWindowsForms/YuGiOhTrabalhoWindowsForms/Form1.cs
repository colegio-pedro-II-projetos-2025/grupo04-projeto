namespace YuGiOhTrabalhoWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CadastroForm cadastro = new CadastroForm();
            cadastro.ShowDialog();
        }
    }
}
