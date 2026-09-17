namespace InitialAutomation;
using System.Text.Json;
using InitialAutomation.Models;
using InitialAutomation.Services;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        CarregarConfig();
    }
    private readonly DomainService domainService = new();

    private void Log(string mensagem)
    {
        rtbLog.AppendText(
            $"[{DateTime.Now:HH:mm:ss}] {mensagem}\n"
        );

        rtbLog.SelectionStart = rtbLog.Text.Length;
        rtbLog.ScrollToCaret();
    }

    private readonly string configPath =
    Path.Combine(
        Application.StartupPath,
        "config.json"
    );

    private void SalvarConfig()
    {
        try
        {
            var config = new ConfigModel
            {
                Dominio = txtDominio.Text,
                Usuario = txtUsuario.Text,
                Senha = chkLembrarSenha.Checked
                    ? txtSenha.Text
                    : string.Empty,
                LembrarSenha = chkLembrarSenha.Checked
            };

            string json = JsonSerializer.Serialize(
                config,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            File.WriteAllText(configPath, json);

            Log("Configuração salva com sucesso.");
        }
        catch (Exception ex)
        {
            Log($"Erro ao salvar: {ex.Message}");
        }
    }

    private void CarregarConfig()
    {
        try
        {
            if (!File.Exists(configPath))
            {
                Log("Nenhuma configuração encontrada.");
                return;
            }

            string json = File.ReadAllText(configPath);

            var config = JsonSerializer.Deserialize<ConfigModel>(json);

            if (config is null)
                return;

            txtDominio.Text = config.Dominio;
            txtUsuario.Text = config.Usuario;

            if (config.LembrarSenha)
            {
                txtSenha.Text = config.Senha;
                chkLembrarSenha.Checked = true;
            }
            else
            {
                txtSenha.Clear();
                chkLembrarSenha.Checked = false;
            }

            Log("Configuração carregada.");
        }
        catch (Exception ex)
        {
            Log($"Erro ao carregar configuração: {ex.Message}");
        }
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void label1_Click_1(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void label5_Click(object sender, EventArgs e)
    {

    }

    private void MainForm_Load(object sender, EventArgs e)
    {

    }

    private void btnVerificarAtualizacao_Click(object sender, EventArgs e)
    {
        Log("Verificando atualizações...");
    }

    private void btnSalvar_Click(object sender, EventArgs e)
    {
        SalvarConfig();
    }

    private void btnAdicionarDominio_Click(
     object sender,
     EventArgs e)
    {
        bool valido = domainService.ValidarCampos(
            txtNomePc.Text,
            txtUsuario.Text,
            txtSenha.Text,
            txtDominio.Text
        );

        if (!valido)
        {
            MessageBox.Show(
                "Preencha todos os campos.",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }
        var info = domainService.ObterInformacoes();

        Log($"Nome atual: {info.Hostname}");
        Log($"Domínio atual: {info.Domain}");
        Log($"Está em domínio? {(info.PartOfDomain ? "Sim" : "Não")}");

    }

    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult resultado =
            MessageBox.Show(
                "Deseja realmente remover este computador do domínio?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

        if (resultado == DialogResult.Yes)
        {
            string retorno = domainService.RemoverDominio(
                txtUsuario.Text,
                txtSenha.Text);

            Log(retorno);
        }
        Log("Script de remoção gerado:");

    }

    private void btnUsuariosLocais_Click(object sender, EventArgs e)
    {

        var usuarios =
            domainService.ObterListaUsuarios();

        Log($"Total de usuários: {usuarios.Count}");

        foreach (var usuario in usuarios)
        {
            Log($"Usuário: {usuario}");
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {

    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
}
