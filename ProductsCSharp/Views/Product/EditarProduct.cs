using Models;
using Controllers;


namespace Views{
    public class EditarProduct : Form{

        public Label lblName;
        public TextBox txtName;
        public Label lblPrice;
        public TextBox txtPrice;
        public Button btnRegister;
        public Models.Product Product;


        public void btnEdit_Click(object sender, EventArgs e){

            Models.Product Product = this.Product;
            Product.Nome = txtName.Text;
            Product.Preco = Convert.ToDecimal(txtPrice.Text);

            Controllers.Product.AtualizarProduct(Product);
            MessageBox.Show("O Produto foi alterado com sucesso!");

            Views.ListarProduct ProductList = Application.OpenForms.OfType<Views.ListarProduct>().FirstOrDefault();
            if (ProductList != null){
                ProductList.RefreshList();
            }
            this.Close();
        }
        public EditarProduct(Models.Product Product){

            this.Product = Product;

            this.Text = "Editar Produto";
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
            this.txtName.Text = Product.Nome;
            this.txtName.Location = new System.Drawing.Point(80, 40);
            this.txtName.Size = new System.Drawing.Size(150, 20);

            this.lblPrice = new Label();
            this.lblPrice.Text = "Preço:";
            this.lblPrice.Location = new System.Drawing.Point(10, 70);
            this.lblPrice.Size = new System.Drawing.Size(50, 20);

            this.txtPrice = new TextBox();
            this.txtPrice.Text = Product.Preco.ToString();
            this.txtPrice.Location = new System.Drawing.Point(80, 70);
            this.txtPrice.Size = new System.Drawing.Size(150, 20);

            this.btnRegister = new Button();
            this.btnRegister.Text = "Registrar";
            this.btnRegister.Location = new System.Drawing.Point(80, 110);
            this.btnRegister.Size = new System.Drawing.Size(150, 35);
            this.btnRegister.Click += new EventHandler(this.btnEdit_Click);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnRegister);
        }
    }
}