namespace LoginPanelTask2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            methods.Control();
        }

        private void frmLogin_Load_1(object sender, EventArgs e)
        {
            methods.Control();
        }
    }
}