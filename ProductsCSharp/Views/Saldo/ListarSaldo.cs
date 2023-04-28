namespace Views{

    public class ListarSaldo : Form{

        public ListView listSaldos;
        public ListarSaldo(){

            this.Controls.Add(listSaldos);
            this.Size = new Size(720, 370);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Listar Saldos";

            listSaldos = new ListView();
            listSaldos.Size = new Size(605, 180);
            listSaldos.Location = new Point(50, 50);
            listSaldos.View = View.Details;
            listSaldos.Columns.Add("ID", 50);
            listSaldos.Columns.Add("Product", 100);
            listSaldos.Columns.Add("Almox", 100);
            listSaldos.Columns.Add("Quantidade", 100);
            listSaldos.Columns[0].Width = 30;
            listSaldos.Columns[1].Width = 100;
            listSaldos.Columns[2].Width = 100;
            listSaldos.Columns[3].Width = 100;
            listSaldos.FullRowSelect = true;
            this.Controls.Add(listSaldos);

            RefreshList();

            Button btnAdd = new Button();
            btnAdd.Text = "Adicionar";
            btnAdd.Size = new Size(100, 30);
            btnAdd.Location = new Point(50, 270);
            btnAdd.Click += new EventHandler(btnAdd_Click);
            this.Controls.Add(btnAdd);

            Button btnEdit = new Button();
            btnEdit.Text = "Editar";
            btnEdit.Size = new Size(100, 30);
            btnEdit.Location = new Point(170, 270);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            this.Controls.Add(btnEdit);

            Button btnDelete = new Button();
            btnDelete.Text = "Deletar";
            btnDelete.Size = new Size(100, 30);
            btnDelete.Location = new Point(290, 270);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            this.Controls.Add(btnDelete);


            Button btnClose = new Button();
            btnClose.Text = "Sair";
            btnClose.Size = new Size(100, 30);
            btnClose.Location = new Point(550, 270);
            btnClose.Click += new EventHandler(btnExit_Click);
            this.Controls.Add(btnClose);
        }

        private void btnAdd_Click(object sender, EventArgs e){
            new CriarSaldo().ShowDialog();
            RefreshList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Saldo saldo = GetProductBySelected();
                var editarSaldoView = new Views.EditarSaldo(saldo);
                if (editarSaldoView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Saldo modificado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e){

            try{
                Models.Saldo saldo = GetProductBySelected();
                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar esse item?", "Confirmar exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Controllers.Saldo.DeletarSaldo(saldo);
                    RefreshList();
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e){
            this.Close();
        }

        public void AddToListView(Models.Saldo saldo)
        {
            Models.Product nameProduct = Controllers.Product.BuscarProduct(saldo.IdProduct);
            Models.Almox nameAlmox = Controllers.Almox.BuscarAlmox(saldo.IdAlmox);

            string[] row = { 
                saldo.Id.ToString(),
                nameProduct.Nome,
                nameAlmox.Nome,
                saldo.Quantidade.ToString()
            };
            ListViewItem item = new ListViewItem(row);
            listSaldos.Items.Add(item);
        }

        public void RefreshList()
        {
            listSaldos.Items.Clear();
            List<Models.Saldo> saldos = Controllers.Saldo.ListarSaldos();

            foreach (Models.Saldo saldo in saldos)
            {
                AddToListView(saldo);
            }
        }
        public Models.Saldo GetProductBySelected()
        {
            if (listSaldos.SelectedItems.Count > 0)
            {
                int selectedProduct = int.Parse(listSaldos.SelectedItems[0].Text);
                return Controllers.Saldo.BuscarSaldo(selectedProduct);
            }
            else
            {
                throw new Exception("Por gentileza, selecione um item para prosseguir com a ação" );
            }
        }
            
        
    }
}