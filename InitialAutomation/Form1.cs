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
    private readonly UserService userService = new();

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

        DialogResult resposta =
            MessageBox.Show(
                $"Nome atual: {info.Hostname}\n" +
                $"Domínio atual: {info.Domain}\n\n" +
                $"Deseja ingressar no domínio {txtDominio.Text} ?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (resposta != DialogResult.Yes)
        {
            return;
        }

        string existe =
            domainService.VerificarNomeComputador(
                txtNomePc.Text
            );

                if (existe == "EXISTE")
                {
                    MessageBox.Show(
                        "Já existe um computador com esse patrimônio.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

        string retorno = domainService.IngressarDominio(
            txtNomePc.Text,
            txtUsuario.Text,
            txtSenha.Text,
            txtDominio.Text
        );

        Log(retorno);

    }

    private void btnRemoverDominio_Click(object sender, EventArgs e)
    {
        var info = domainService.ObterInformacoes();

        DialogResult resultado =
            MessageBox.Show(
                $"Nome atual: {info.Hostname}\n" +
                $"Domínio atual: {info.Domain}\n\n" +
                "Deseja realmente remover este computador do domínio?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

        if (resultado != DialogResult.Yes)
        {
            return;
        }

        string retorno = domainService.RemoverDominio(
            txtUsuario.Text,
            txtSenha.Text);

        Log(retorno);
    }

    private void btnUsuariosLocais_Click(object sender, EventArgs e)
    {

        var usuarios = userService.ObterUsuarios();

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

    private void btnLimparUsuarios_Click(
        object sender,
        EventArgs e)
    {
        var resultado =
            userService.ObterUsuariosQueSeriamDesabilitados();

        Log($"Usuários encontrados: {resultado.TotalUsuarios}");

        foreach (var usuario in resultado.UsuariosAfetados)
        {
            Log($"Será desabilitado: {usuario}");
        }
        DialogResult resposta =
    MessageBox.Show(
        $"Deseja desabilitar {resultado.TotalUsuarios} usuário(s)?",
        "Confirmação",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning);

        if (resposta != DialogResult.Yes)
        {
            return;
        }
        string retorno =
    userService.LimparUsuarios();

        Log(retorno);
    }
}
