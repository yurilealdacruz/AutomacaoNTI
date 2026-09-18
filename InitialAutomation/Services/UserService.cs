using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitialAutomation.Models;

namespace InitialAutomation.Services
{
    public class UserService
    {
        private readonly DomainService domainService = new();

        public string LimparUsuarios()
        {
            return domainService.ExecutePowerShell(@"
$adminBuiltIn = Get-LocalUser |
Where-Object { $_.SID -like '*-500' }

if ($null -eq $adminBuiltIn)
{
    Write-Output 'Administrador nao encontrado.'
    return
}

try
{
    Enable-LocalUser -Name $adminBuiltIn.Name -ErrorAction Stop

    Write-Output ('Administrador habilitado: ' + $adminBuiltIn.Name)
}
catch
{
    Write-Output ('ERRO AO HABILITAR ADMINISTRADOR: ' + $_.Exception.Message)
}

$usuarios = Get-LocalUser |
Where-Object { $_.SID -notlike '*-500' }

foreach ($u in $usuarios)
{
    try
    {
        Disable-LocalUser -Name $u.Name -ErrorAction Stop

        Write-Output ('Desabilitado: ' + $u.Name)
    }
    catch
    {
        Write-Output ('Falha ao desabilitar: ' + $u.Name)
    }
}

Write-Output 'Limpeza concluida.'
");
        }

        public List<string> ObterUsuariosParaLimpeza()
        {
            string resultado = domainService.ExecutePowerShell(@"
Get-LocalUser |
Where-Object { $_.SID -notlike '*-500' } |
Select-Object -ExpandProperty Name
");

            return resultado
                .Split(
                    Environment.NewLine,
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }

        public UserCleanupResult ObterUsuariosQueSeriamDesabilitados()
        {
            var usuarios = ObterUsuariosParaLimpeza();

            return new UserCleanupResult
            {
                TotalUsuarios = usuarios.Count,
                UsuariosAfetados = usuarios
            };
        }
        public List<string> ObterUsuarios()
        {
            string resultado = domainService.ExecutePowerShell(
                "Get-LocalUser | Select-Object -ExpandProperty Name"
            );

            return resultado
                .Split(
                    Environment.NewLine,
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
    }
}
