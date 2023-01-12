using System;
using System.Drawing;
using System.Windows.Forms;


namespace Jean_Guilherme_Reval
{
    public partial class FrmCdClientes : Form
    {
        public FrmCdClientes()
        {
            InitializeComponent();
        }

        public void disbleButtons()
        {
            txtNome.Enabled = false;
            txtTelefone.Enabled = false;
            txtRg.Enabled = false;
            txtCidade.Enabled = false;
            txtCpfCnpj.Enabled = false;
            txtEmail.Enabled = false;
            txtBairro.Enabled = false;
            txtRua.Enabled = false;
            txtNumero.Enabled = false;
            chkBloqueado.Enabled = false;
        }

        public void enableButtons()
        {
            txtNome.Enabled = true;
            txtTelefone.Enabled = true;
            txtRg.Enabled = true;
            txtCidade.Enabled = true;
            txtCpfCnpj.Enabled = true;
            txtEmail.Enabled = true;
            txtBairro.Enabled = true;
            txtRua.Enabled = true;
            txtNumero.Enabled = true;
            chkBloqueado.Enabled = true;
        }

        public void clearInputs()
        {
            txtId.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
            txtRg.Clear();
            txtCidade.Clear();
            txtCpfCnpj.Clear();
            txtEmail.Clear();
            txtBairro.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            chkBloqueado.Checked = false;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            //verificação no texto do botão para tomar a decição
            if (btnIncluir.Text == "Incluir Registro")
            {
                //vamos limpar o campo id
                txtId.Clear();

                //vamos mudar o texto do campo
                btnIncluir.Text = "Salvar registro";

                //Limpar os campos
                clearInputs();

                //Vamos desabilitar os campos
                enableButtons();

                //Vamos dar o foco no primeiro campo
                txtNome.Focus();

                //Tambem vamos distivar os outros botões para não aver erros..
                btnAtualizar.Enabled = false;
                btnExcluir.Enabled = false;

            }
            else
            {
               

                //Verificar se os campos foram preenchidos.
                //Somente um campo para demonstrar.
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Todos os campos precisam ser preenchidos, porfavor verifique.", "Controle de registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNome.Focus();
                    return;
                }

                //vamos voltar o texto no botão
                btnIncluir.Text = "Incluir Registro";

                //vamos desabilitar os botoes
                disbleButtons();


                // Inserir o registro no banco de dados -- Retorno TRUE -- SUCESSO           
                if (Cadastros.clsOperations.Adicionar_Cliente(txtNome.Text, txtTelefone.Text, txtRg.Text,
                    txtCidade.Text, txtCpfCnpj.Text, txtEmail.Text, txtBairro.Text, txtRua.Text, txtNumero.Text, chkBloqueado.Checked.ToString()))
                {
                    //txtCliente_ID.Text = ID_CLIENTE.ToString(); //Colocando o ID do novo cliente na tela, recebido na resposta da API
                    MessageBox.Show("Registro incluído com sucesso.", "Controle de registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //vamos desabilitar os botoes
                    disbleButtons();

                    //Limpar os campos
                    clearInputs();

                    btnAtualizar.Enabled = true;
                    btnExcluir.Enabled = true;

                    //Ah vamos atualizar a lista
                    dgvClientes.Columns.Clear();
                    dgvClientes.DataSource = Cadastros.clsOperations.Lista_de_clientes();
                }
                else
                {
                    //vamos desabilitar os botoes
                    disbleButtons();

                    //Limpar os campos
                    clearInputs();

                    MessageBox.Show("Falha na inclusão do registro, por favor verifique sua conexão com a internet ou entre em contato com o suporte técnico.", "Controle de registros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        //No carregamento do form, vamos atulizar a lista de cadastros
        private void FrmCdClientes_Load(object sender, EventArgs e)
        {
            dgvClientes.Columns.Clear();
            dgvClientes.DataSource = Cadastros.clsOperations.Lista_de_clientes();
        }

        //Aqui vamos jogar os valores nos seus respectvos campos para uma atualização ou exclusão do registro
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.SelectedRows.Count != 0)
            {

                //Ao clicar na GRID vamos pegar os dados da linha selecionada e jogar nos campos da tela
                txtId.Text = this.dgvClientes.CurrentRow.Cells["id"].Value.ToString().Trim();
                txtNome.Text = this.dgvClientes.CurrentRow.Cells["nome"].Value.ToString().Trim();
                txtTelefone.Text = this.dgvClientes.CurrentRow.Cells["telefone"].Value.ToString().Trim();
                txtRg.Text = this.dgvClientes.CurrentRow.Cells["rg"].Value.ToString().Trim();
                txtCidade.Text = this.dgvClientes.CurrentRow.Cells["cidade"].Value.ToString().Trim();
                txtCpfCnpj.Text = this.dgvClientes.CurrentRow.Cells["cpf_cnpj"].Value.ToString().Trim();
                txtEmail.Text = this.dgvClientes.CurrentRow.Cells["email"].Value.ToString().Trim();
                txtBairro.Text = this.dgvClientes.CurrentRow.Cells["bairro"].Value.ToString().Trim();
                txtRua.Text = this.dgvClientes.CurrentRow.Cells["rua"].Value.ToString().Trim();
                txtNumero.Text = this.dgvClientes.CurrentRow.Cells["numero"].Value.ToString().Trim();

                string bloqueado = this.dgvClientes.CurrentRow.Cells["bloqueado"].Value.ToString().Trim();

                if (bloqueado == "False")
                {
                    chkBloqueado.Checked = false;
                }
                else { chkBloqueado.Checked = true; }
            }
        }

        //Aqui vamos concelar todas as operações 
        private void btnCancelarOperacao_Click(object sender, EventArgs e)
        {
            //Vamos certificar que os textos dos botões estão corretos
            btnIncluir.Text = "Incluir Registro";
            btnAtualizar.Text = "Atualizar Registro";

            //Vamos habilitar os botões
            btnExcluir.Enabled = true;
            btnAtualizar.Enabled = true;
            btnIncluir.Enabled = true;

            //Desabilitar campos
            disbleButtons();

            //Limpar os campos
            clearInputs();

            //Vamos trocar as cores dos campos ?
            txtNome.BackColor = Color.White;
            txtTelefone.BackColor = Color.White;
            txtRg.BackColor = Color.White;
            txtCidade.BackColor = Color.White;
            txtCpfCnpj.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
            txtBairro.BackColor = Color.White;
            txtRua.BackColor = Color.White;
            txtNumero.BackColor = Color.White;
           
        }

        //Aqui vamos atualizar o registro caso algum esteja selecionado
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            //Testando o campo id 
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Nenhum registro foi selecionado para a atualizaçao, operação cancelada.", "Controle de registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (btnAtualizar.Text == "Atualizar Registro")
            {
                //Mudar o texto para salvar 
                btnAtualizar.Text = "Salvar Atualização";

                //Habilitar campos
                enableButtons();

                //Vamos trocar as cores dos campos ?
                txtNome.BackColor = Color.Yellow;
                txtTelefone.BackColor = Color.Yellow;
                txtRg.BackColor = Color.Yellow;
                txtCidade.BackColor = Color.Yellow;
                txtCpfCnpj.BackColor = Color.Yellow;
                txtEmail.BackColor = Color.Yellow;
                txtBairro.BackColor = Color.Yellow;
                txtRua.BackColor = Color.Yellow;
                txtNumero.BackColor = Color.Yellow;


                //Lançar o foco sobre o primeiro campo
                txtNome.Focus();

                btnIncluir.Enabled = false;
                btnExcluir.Enabled = false;
   
            }
            else
            {
                

                //Verificar se os campos foram preenchidos antes de inserir no DB
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Todos os campos precisam ser preenchidos, porfavor verifique.", "Controle de registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNome.Focus();
                    return;
                }

                //Então vamos voltar o texto original no botão 
                btnAtualizar.Text = "Atualizar Registro";

                //desabilitar campos
                disbleButtons();

                //Vamos trocar as cores dos campos ?
                txtNome.BackColor = Color.White;
                txtTelefone.BackColor = Color.White;
                txtRg.BackColor = Color.White;
                txtCidade.BackColor = Color.White;
                txtCpfCnpj.BackColor = Color.White;
                txtEmail.BackColor = Color.White;
                txtBairro.BackColor = Color.White;
                txtRua.BackColor = Color.White;
                txtNumero.BackColor = Color.White;

                // Atualizar o registro no banco de dados -- Retorno TRUE -- SUCESSO
                if (Cadastros.clsOperations.Atualizar_Cliente(int.Parse(txtId.Text), txtNome.Text, txtTelefone.Text, txtRg.Text,
                    txtCidade.Text, txtCpfCnpj.Text, txtEmail.Text, txtBairro.Text, txtRua.Text, txtNumero.Text, chkBloqueado.Checked.ToString()))
                {

                    MessageBox.Show("Registro atualizado com sucesso.", "Controle de registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    MessageBox.Show("Falha na atualização do registro, por favor verifique sua conexão com a internet ou entre em contato com o suporte técnico.", "Controle de registros", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                //Ativar os botões
                btnIncluir.Enabled = true;
                btnExcluir.Enabled = true;

                //Atualizar a lista
                dgvClientes.Columns.Clear();
                dgvClientes.DataSource = Cadastros.clsOperations.Lista_de_clientes();

            }
        }

        //Aqui tambem, vamos excluir o registro caso esteja selecionado
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //vamos testar o campo id se esta vazio
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Nenhum registro foi selecionado para a atualizaçao, operação cancelada.", "Controle de registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //////////////////////////////////////////////////////////////
            // Questionar o usuário, confirmando a exclusão /////////////
            ////////////////////////////////////////////////////////////
            DialogResult MSG_YN_Perugar_Ao_Usuario = MessageBox.Show("Deseja realmente excluir o registro atual?",
                      "Controle de rergistros", MessageBoxButtons.YesNo);

            switch (MSG_YN_Perugar_Ao_Usuario)
            {
                case DialogResult.Yes:
                    if (Cadastros.clsOperations.Excluir_Cliente(int.Parse(txtId.Text)))
                    {
                        MessageBox.Show("Registro excluído com sucesso.", "Controle de registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Limpar os campos
                        clearInputs();

                        

                        dgvClientes.Columns.Clear();
                        dgvClientes.DataSource = Cadastros.clsOperations.Lista_de_clientes();

                    }
                    else
                    {
                        MessageBox.Show("Falha na exclusão do registro, por favor verifique sua conexão com a internet ou entre em contato com o suporte técnico.", "Controle de registros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        //Em fim, uma consulta por nome usando o Like
        private void btnConsulta_Click(object sender, EventArgs e)
        {
            dgvClientes.Columns.Clear();
            dgvClientes.DataSource = Cadastros.clsOperations.Pesquisar_Cliente_Nome(txtConsulta.Text.Trim());
        }
    }
}
