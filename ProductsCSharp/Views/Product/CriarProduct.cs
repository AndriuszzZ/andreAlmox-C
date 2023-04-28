using Controllers;
using Models;

namespace Views
{
    public class CriarProduct : Form
    {
        public Label lblName;
        public TextBox txtName;
        public Label lblPrice;
        public TextBox txtPrice;
        public Button btnRegister;

        public void btnRegister_Click(object sender, EventArgs e)
        {
            Models.Product Product = new Models.Product(
                txtName.Text,
                Convert.ToDecimal(txtPrice.Text)
            );

            Controllers.Product.CriarProduct(Product);
            MessageBox.Show("Product foi registrado com sucesso!");

            ClearForm();

            ListarProduct ProductList = Application.OpenForms.OfType<ListarProduct>().FirstOrDefault();
            if (ProductList != null)
            {
                ProductList.RefreshList();
            }

            this.Close();
        }

        private void ClearForm(){
            txtName.Clear();
            txtPrice.Clear();
        }

        public CriarProduct()
        {
            this.Text = "Registar carro";
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

            this.lblPrice = new Label();
            this.lblPrice.Text = "Preço:";
            this.lblPrice.Location = new System.Drawing.Point(10, 70);
            this.lblPrice.Size = new System.Drawing.Size(50, 20);

            this.txtPrice = new TextBox();
            this.txtPrice.Location = new System.Drawing.Point(80, 70);
            this.txtPrice.Size = new System.Drawing.Size(150, 20);

            this.btnRegister = new Button();
            this.btnRegister.Text = "Registrar";
            this.btnRegister.Location = new System.Drawing.Point(80, 110);
            this.btnRegister.Size = new System.Drawing.Size(150, 35);
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnRegister);

        }
    }

}