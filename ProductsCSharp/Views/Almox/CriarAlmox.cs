using Controllers;
using Models;

namespace Views
{
    public class CriarAlmox : Form
    {
        public Label lblName;
        public TextBox txtName;
        public Button btnRegister;

        public void btnRegister_Click(object sender, EventArgs e)
        {
            Models.Almox almox = new Models.Almox(
                txtName.Text
            );

            Controllers.Almox.CriarAlmox(almox);
            MessageBox.Show("Almox foi registrado com sucesso!");

            ClearForm();

            ListarAlmox AlmoxLsit = Application.OpenForms.OfType<ListarAlmox>().FirstOrDefault();
            if (AlmoxLsit != null)
            {
                AlmoxLsit.RefreshList();
            }

            this.Close();
        }

        private void ClearForm(){
            txtName.Clear();
        }

        public CriarAlmox()
        {
            this.Text = "Registar Almox";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(280, 220);

            this.lblName = new Label();
            this.lblName.Text = "Nome:";
            this.lblName.Location = new System.Drawing.Point(10, 40);
            this.lblName.Size = new System.Drawing.Size(50, 20);

            this.txtName = new TextBox();
            this.txtName.Location = new System.Drawing.Point(80, 40);
            this.txtName.Size = new System.Drawing.Size(150, 20);

            this.btnRegister = new Button();
            this.btnRegister.Text = "Registrar";
            this.btnRegister.Location = new System.Drawing.Point(80, 110);
            this.btnRegister.Size = new System.Drawing.Size(150, 35);
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnRegister);

        }
    }

}