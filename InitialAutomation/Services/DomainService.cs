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
                    try
                    {
                        string script = $@"
        $secSenha = ConvertTo-SecureString '{senha}' -AsPlainText -Force

        $cred = New-Object System.Management.Automation.PSCredential(
            '{usuario}',
            $secSenha
        )

        Write-Output 'Remoção simulada com sucesso'"
        /* Write-Output 'Remove-Computer `
            -UnjoinDomainCredential $cred `
            -WorkgroupName 'WORKGROUP' `
            -Force' */

        ;

                return ExecutePowerShell(script);
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
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

        public void IngressarDominio(
            string nomePc,
            string usuario,
            string senha,
            string dominio)
                {
                    string script = $@"
                $secSenha = ConvertTo-SecureString '{senha}' -AsPlainText -Force
                $cred = New-Object System.Management.Automation.PSCredential(
                    '{dominio}\{usuario}',
                    $secSenha
                )

                Add-Computer `
                    -DomainName '{dominio}' `
                    -NewName '{nomePc}' `
                    -Credential $cred `
                    -Force
            ";

                    ExecutePowerShell(script);
                }
        public string ExecutePowerShell(string command)
        {
            ProcessStartInfo psi = new()
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -Command \"{command}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
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