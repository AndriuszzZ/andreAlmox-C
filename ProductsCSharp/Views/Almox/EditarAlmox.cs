using Models;
using Controllers;


namespace Views{
    public class EditarAlmox : Form{

        public Label lblName;
        public TextBox txtName;
        public Button btnRegister;
        public Models.Almox almox;


        public void btnEdit_Click(object sender, EventArgs e){

            Models.Almox almox = this.almox;
            almox.Nome = txtName.Text;

            Controllers.Almox.AtualizarAlmox(almox);
            MessageBox.Show("O almox foi alterado com sucesso!");

            Views.ListarAlmox AlmoxList = Application.OpenForms.OfType<Views.ListarAlmox>().FirstOrDefault();
            if (AlmoxList != null){
                AlmoxList.RefreshList();
            }
            this.Close();
        }
        public EditarAlmox(Models.Almox almox){

            this.almox = almox;

            this.Text = "Editar almox";
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
            this.txtName.Text = almox.Nome;
            this.txtName.Location = new System.Drawing.Point(80, 40);
            this.txtName.Size = new System.Drawing.Size(150, 20);

            this.btnRegister = new Button();
            this.btnRegister.Text = "Registrar";
            this.btnRegister.Location = new System.Drawing.Point(80, 110);
            this.btnRegister.Size = new System.Drawing.Size(150, 35);
            this.btnRegister.Click += new EventHandler(this.btnEdit_Click);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnRegister);
        }
    }
}