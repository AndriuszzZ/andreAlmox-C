namespace Views {

    public class ListarAlmox : Form{

        ListView listAlmox;
        public ListarAlmox(){

            this.Controls.Add(listAlmox);
            this.Size = new Size(720, 370);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Listar Almoxs";

                listAlmox = new ListView();
                listAlmox.Size = new Size(605, 180);
                listAlmox.Location = new Point(50, 50);
                listAlmox.View = View.Details;
                listAlmox.Columns.Add("ID", 50);
                listAlmox.Columns.Add("Nome", 100);
                listAlmox.Columns[0].Width = 30;
                listAlmox.Columns[1].Width = 100;
                listAlmox.FullRowSelect = true;
                this.Controls.Add(listAlmox);

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
            new CriarAlmox().ShowDialog();
            RefreshList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Almox almox = GetProdutoBySelected();
                var editarAlmoxView = new Views.EditarAlmox(almox);
                if (editarAlmoxView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Almox modificado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e){

            try{
                Models.Almox almox = GetProdutoBySelected();
                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar esse item?", "Confirmar exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Controllers.Almox.DeletarAlmox(almox);
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

        public void AddToListView(Models.Almox almox)
        {
            ListViewItem item = new ListViewItem(almox.Id.ToString());
            item.SubItems.Add(almox.Nome);
            listAlmox.Items.Add(item);
        }

        public void RefreshList()
        {
            listAlmox.Items.Clear();

            List<Models.Almox> almoxs = Controllers.Almox.ListarAlmoxs();


            foreach (Models.Almox almox in almoxs)
            {
                AddToListView(almox);
            }
        }
        public Models.Almox GetProdutoBySelected()
        {
            if (listAlmox.SelectedItems.Count > 0)
            {
                int selectedProduct = int.Parse(listAlmox.SelectedItems[0].Text);
                return Controllers.Almox.BuscarAlmox(selectedProduct);
            }
            else
            {
                throw new Exception("Por gentileza, selecione um item para prosseguir com a ação" );
            }
        }
    }
}
