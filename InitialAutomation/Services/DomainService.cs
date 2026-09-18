using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using InitialAutomation.Models;

namespace InitialAutomation.Services
{
    public class DomainService
    {
        public bool ValidarCampos(
            string nomePc,
            string usuario,
            string senha,
            string dominio)
        {
            return
                !string.IsNullOrWhiteSpace(nomePc) &&
                !string.IsNullOrWhiteSpace(usuario) &&
                !string.IsNullOrWhiteSpace(senha) &&
                !string.IsNullOrWhiteSpace(dominio);
        }
                    public string MontarScriptRemocao(
                        string usuario,
                        string senha)
                            {
                                return $@"
                    $secSenha = ConvertTo-SecureString '{senha}' -AsPlainText -Force

                    $cred = New-Object System.Management.Automation.PSCredential(
                        '{usuario}',
                        $secSenha
                    )

                    Remove-Computer `
                        -UnjoinDomainCredential $cred `
                        -WorkgroupName 'WORKGROUP' `
                        -Force
                    ";
                            }

                    public string VerificarNomeComputador(string nomePc)
                    {
                        string script = $@"
            try
            {{
                Get-ADComputer -Identity '{nomePc}' -ErrorAction Stop

                'EXISTE'
            }}
            catch
            {{
                'NAO_EXISTE'
            }}
            ";

                        return ExecutePowerShell(script).Trim();
                    }
        public DomainInfo ObterInformacoes()
        {
            return new DomainInfo
            {
                Hostname = ExecutePowerShell("hostname").Trim(),

                Domain = ExecutePowerShell(
                    "(Get-CimInstance Win32_ComputerSystem).Domain"
                ).Trim(),

                PartOfDomain = ExecutePowerShell(
                    "(Get-CimInstance Win32_ComputerSystem).PartOfDomain"
                ).Trim().Equals(
                    "True",
                    StringComparison.OrdinalIgnoreCase)
            };
        }
        public string RemoverDominio(
       string usuario,
       string senha)
        {
            string script = $@"
$sysInfo = Get-CimInstance Win32_ComputerSystem

$nomeAtual = $env:COMPUTERNAME

if ($sysInfo.PartOfDomain -and $sysInfo.Domain -eq '{{dominio}}')
{{
    if ($nomeAtual -ne '{{nomePc}}')
    {{
        Rename-Computer `
            -NewName '{{nomePc}}' `
            -DomainCredential $cred `
            -Force
    }}

    Write-Output 'Computador ja esta no dominio.'
}}
else
{{
    if ($nomeAtual -eq '{{nomePc}}')
    {{
        Add-Computer `
            -DomainName '{{dominio}}' `
            -Credential $cred `
            -Force
    }}
    else
    {{
        Add-Computer `
            -DomainName '{{dominio}}' `
            -NewName '{{nomePc}}' `
            -Credential $cred `
            -Force
    }}
}}

Write-Output 'Operacao concluida.'
";

            return ExecutePowerShell(script);
        }
        public string ObterUsuariosLocais()
        {
            return ExecutePowerShell(
                "Get-LocalUser | Select-Object Name"
            );
        }

        public List<string> ObterListaUsuarios()
        {
            string resultado = ExecutePowerShell(
                "Get-LocalUser | Select-Object -ExpandProperty Name"
            );

            return resultado
                .Split(
                    Environment.NewLine,
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
        public string ObterInformacoesDominio()
        {
                        return ExecutePowerShell(
                            "(Get-CimInstance Win32_ComputerSystem).Domain"
                        );
                    }

                    public string IngressarDominio(
                 string nomePc,
                 string usuario,
                 string senha,
                 string dominio)
                    {
                        try
                        {
                            string script = $@"
            $secSenha = ConvertTo-SecureString '{senha}' -AsPlainText -Force

            $cred = New-Object System.Management.Automation.PSCredential(
                '{dominio}\{usuario}',
                $secSenha
            )

            $sysInfo = Get-CimInstance Win32_ComputerSystem

            if ($sysInfo.PartOfDomain -and $sysInfo.Domain -eq '{dominio}')
            {{
                Rename-Computer `
                    -NewName '{nomePc}' `
                    -DomainCredential $cred `
                    -Force
            }}
            else
            {{
                Add-Computer `
                    -DomainName '{dominio}' `
                    -NewName '{nomePc}' `
                    -Credential $cred `
                    -Force
            }}

            'Operacao concluida. Reinicie o computador.'
            ";

                            return ExecutePowerShell(script);
                        }
                        catch (Exception ex)
                        {
                            return ex.Message;
                        }
                    }
        public string ExecutePowerShell(string command)
        {
            ProcessStartInfo psi = new()
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -Command \"{command}\"",

                UseShellExecute = false,

                RedirectStandardOutput = true,
                RedirectStandardError = true,

                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8,

                CreateNoWindow = true
            };

            using Process process = Process.Start(psi)!;

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            return string.IsNullOrWhiteSpace(error)
                ? output
                : error;
        }
    }


}