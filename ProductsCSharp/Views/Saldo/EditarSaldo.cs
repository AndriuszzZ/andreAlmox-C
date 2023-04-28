using Models;
using Controllers;


namespace Views
{
    public class EditarSaldo : Form
    {

        private Label lblIdProduct;
        private Label lblIdAlmox;
        private Label lblQuantidade;
        private TextBox txtIdProduct;
        private TextBox txtIdAlmox;
        private TextBox txtQuantidade;
        private Button btnEdit;
        public Models.Saldo saldo;


        public void btnEdit_Click(object sender, EventArgs e)
        {

            Models.Saldo saldo = this.saldo;
            saldo.IdProduct = Convert.ToInt32(txtIdProduct.Text);
            saldo.IdAlmox = Convert.ToInt32(txtIdAlmox.Text);
            saldo.Quantidade = Convert.ToInt32(txtQuantidade.Text);

            Controllers.Saldo.AtualizarSaldo(saldo);
            MessageBox.Show("O saldo foi alterado com sucesso!");

            Views.ListarSaldo SaldoList = Application.OpenForms.OfType<Views.ListarSaldo>().FirstOrDefault();
            if (SaldoList != null)
            {
                SaldoList.RefreshList();
            }
            this.Close();
        }
        public EditarSaldo(Models.Saldo saldo)
        {

            this.saldo = saldo;

            this.Text = "Editar Saldo";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(350, 250);

            this.lblIdProduct = new Label();
            this.lblIdProduct.Text = "Id do Product:";
            this.lblIdProduct.Location = new System.Drawing.Point(10, 40);
            this.lblIdProduct.Size = new System.Drawing.Size(150, 20);

            this.txtIdProduct = new TextBox();
            this.txtIdProduct.Text = saldo.IdProduct.ToString();
            this.txtIdProduct.Location = new System.Drawing.Point(170, 40);
            this.txtIdProduct.Size = new System.Drawing.Size(150, 20);

            this.lblIdAlmox = new Label();
            this.lblIdAlmox.Text = "Id do almox:";
            this.lblIdAlmox.Location = new System.Drawing.Point(10, 70);
            this.lblIdAlmox.Size = new System.Drawing.Size(150, 20);

            this.txtIdAlmox = new TextBox();
            this.txtIdAlmox.Text = saldo.IdAlmox.ToString();
            this.txtIdAlmox.Location = new System.Drawing.Point(170, 70);
            this.txtIdAlmox.Size = new System.Drawing.Size(150, 20);

            this.lblQuantidade = new Label();
            this.lblQuantidade.Text = "Quantidade:";
            this.lblQuantidade.Location = new System.Drawing.Point(10, 100);
            this.lblQuantidade.Size = new System.Drawing.Size(150, 20);

            this.txtQuantidade = new TextBox();
            this.txtQuantidade.Text = saldo.Quantidade.ToString();
            this.txtQuantidade.Location = new System.Drawing.Point(170, 100);
            this.txtQuantidade.Size = new System.Drawing.Size(150, 20);

            this.btnEdit = new Button();
            this.btnEdit.Text = "Alterar";
            this.btnEdit.Location = new System.Drawing.Point(170, 150);
            this.btnEdit.Size = new System.Drawing.Size(150, 35);
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);

            this.Controls.Add(this.lblIdProduct);
            this.Controls.Add(this.lblIdAlmox);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.txtIdProduct);
            this.Controls.Add(this.txtIdAlmox);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.btnEdit);
        }
    }
}