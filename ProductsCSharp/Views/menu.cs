using Models;
using Controllers;


namespace Views
{

    public class Menu : Form{

        public Menu(){

            this.Text = "Menu";
            this.Size = new Size(300, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

                Button btnProducts = new Button();
                btnProducts.Text = "Products";
                btnProducts.Size = new Size(150, 50);
                btnProducts.Location = new Point(70, 50);
                btnProducts.Click += new EventHandler(btnProducts_Click);

                Button btnAlmox = new Button();
                btnAlmox.Text = "Almox";
                btnAlmox.Size = new Size(150, 50);
                btnAlmox.Location = new Point(70, 100);
                btnAlmox.Click += new EventHandler(btnAlmox_Click);

                Button btnSaldos = new Button();
                btnSaldos.Text = "Saldos";
                btnSaldos.Size = new Size(150, 50);
                btnSaldos.Location = new Point(70, 150);
                btnSaldos.Click += new EventHandler(btnSaldos_Click);

                Button btnSair = new Button();
                btnSair.Text = "Sair";
                btnSair.Size = new Size(150, 50);
                btnSair.Location = new Point(70, 200);
                btnSair.Click += new EventHandler(btnSair_Click);
            

            this.Controls.Add(btnProducts);
            this.Controls.Add(btnAlmox);
            this.Controls.Add(btnSaldos);    
            this.Controls.Add(btnSair);


        }

        private void btnProducts_Click(object sender, EventArgs e){
            ListarProduct ProductView = new ListarProduct();
            ProductView.Show();
        }

        private void btnAlmox_Click(object sender, EventArgs e){
            ListarAlmox almoxView = new ListarAlmox();
            almoxView.Show();
        }

        private void btnSaldos_Click(object sender, EventArgs e){
            ListarSaldo saldoView = new ListarSaldo();
            saldoView.Show();
        }

        private void btnSair_Click(object sender, EventArgs e){
            this.Close();
        }


    }
}