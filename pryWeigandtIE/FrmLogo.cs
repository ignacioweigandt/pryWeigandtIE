namespace pryWeigandtIE
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           timerlogo.Start();
        }

        private void timerlogo_Tick(object sender, EventArgs e)
        {
            // Iniciar el Timer para mostrar el logo durante 3 segundos (3000 milisegundos).
            timerlogo.Stop();

            // Abrir la pantalla principal y cerrar el FormInicio.
            frmLogin formLogin = new frmLogin();
            formLogin.Show();
            this.Hide();
        }

        private void PicLogo_Click(object sender, EventArgs e)
        {

        }
    }
}