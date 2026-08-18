<div align="center">

# OpenAC.Net.GNRe

[![NuGet](https://img.shields.io/nuget/v/OpenAC.Net.GNRe.svg)](https://www.nuget.org/packages/OpenAC.Net.GNRe/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/OpenAC.Net.GNRe.svg)](https://www.nuget.org/packages/OpenAC.Net.GNRe/)
[![Target Frameworks](https://img.shields.io/badge/.NET-%3E%3D%204.6.2%20%7C%20Standard%202.0%20%7C%20Core%206.0--10.0-blue.svg)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![Discord](https://img.shields.io/badge/Chat%20on-Discord-7289DA.svg)](https://discord.com/invite/brdmJ7Yv6w)

**Biblioteca .NET open-source de alto desempenho para emissão, consulta e processamento da GNRe (Guia Nacional de Recolhimento de Tributos Estaduais) nas versões 1.00 e 2.00.**

</div>

---

## 📋 Sobre o Projeto

O **OpenAC.Net.GNRe** faz parte do ecossistema [OpenAC .Net](https://github.com/OpenAC-Net) e foi desenvolvido para simplificar e padronizar a comunicação com os WebServices da **GNRe Nacional** (Portal GNRe PE).

A biblioteca oferece serialização e desserialização rápida de XML orientada a Source Generators, validação rigorosa de schemas XSD através do `OpenAC.Net.DFe.Core`, suporte completo a certificados digitais (A1/A3), além de compatibilidade multiplataforma (**Windows**, **Linux** e **macOS**).

---

## 🚀 Principais Funcionalidades

- **Suporte Completo a Versões**:
  - GNRe versão **1.00**
  - GNRe versão **2.00** (Múltiplas receitas, múltiplos documentos de origem, FECP, etc.)
- **Serviços Suportados**:
  - Envio de Lotes de GNRe (`RecepcaoLote` síncrono e assíncrono)
  - Consulta de Resultado de Processamento do Lote (`ConsultaLote`)
  - Consulta de Configuração da UF (`ConsultaConfigUF`)
  - Download e extração do PDF da Guia gerada pela SEFAZ
- **Validação de Schemas XSD**:
  - Validação integrada com os schemas oficiais da GNRe via `OpenAC.Net.DFe.Core.XmlSchemaValidation`.
- **Multiplataforma & Multi-target**:
  - Suporte a `.NET Framework 4.6.2+`, `.NET Standard 2.0`, `.NET 6.0`, `.NET 7.0`, `.NET 8.0`, `.NET 9.0` e `.NET 10.0`.
- **Aplicativo de Demonstração Multiplataforma**:
  - Demo moderno em **Avalonia UI** (.NET 10) que roda em Linux, Windows e macOS.

---

## 📦 Instalação

Instale via NuGet Package Manager:

```bash
dotnet add package OpenAC.Net.GNRe
```

Ou através do Console do Gerenciador de Pacotes:

```powershell
Install-Package OpenAC.Net.GNRe
```

---

## 💡 Exemplos de Uso

### 1. Inicialização e Configuração

```csharp
using System.Security.Cryptography.X509Certificates;
using OpenAC.Net.DFe.Core.Common;
using OpenAC.Net.GNRe;

var gnre = new OpenGNRe();

// Configurações Gerais
gnre.Config.Geral.FormaEmissao = DFeTipoEmissao.Normal;
gnre.Config.Geral.VersaoDFe = VersaoGNre.v200;

// Configurações de WebService
gnre.Config.WebServices.Ambiente = DFeTipoAmbiente.Homologacao;
gnre.Config.WebServices.Uf = "PE";
gnre.Config.WebServices.TimeOut = 30000;

// Configuração de Certificado Digital
gnre.Config.Certificados.Certificado = "caminho_ou_serial_do_certificado";
gnre.Config.Certificados.Senha = "senha_do_certificado";

// Diretório de Schemas XSD e Gravação de XMLs
gnre.Config.Arquivos.PathSchemas = @"C:\GNRe\Schemas";
gnre.Config.Arquivos.PathSalvar = @"C:\GNRe\Salvos";
gnre.Config.Arquivos.Salvar = true;
```

---

### 2. Consulta de Configurações da UF

Permite consultar as regras, receitas e campos exigidos por cada Estado:

```csharp
// Consulta geral da UF
var configUf = await gnre.ConsultaConfigUFAsync("PR");

if (configUf.Situacao.Codigo == "100")
{
    foreach (var receita in configUf.Dados.Receitas)
    {
        Console.WriteLine($"Receita: {receita.Codigo} - {receita.Descricao}");
        Console.WriteLine($"Exige Documento Origem: {receita.ExigeDocumentoOrigem?.Value}");
    }
}
```

---

### 3. Emissão e Envio de Lote GNRe (v2.00)

```csharp
using System;
using System.Collections.Generic;
using OpenAC.Net.GNRe.Commom;

var guia = new GuiaGNRe
{
    Versao = VersaoGNre.v200,
    UfFavorecida = "RJ",
    TipoGnre = TipoGnre.GnreSimples,
    ContribuinteEmitente = new ContribuinteEmitente
    {
        IdContribuinteEmitente = new IdContribuinte
        {
            Cnpj = "12345678000195"
        },
        RazaoSocial = "Empresa Exemplo LTDA",
        Endereco = "Av. Paulista, 1000",
        Municipio = 35503, // Código IBGE (5 dígitos)
        Uf = "SP",
        Cep = "01310100"
    },
    Item = new List<ItemGnre>
    {
        new()
        {
            Receita = "100102",
            DocumentoOrigem = new StringTipo
            {
                Tipo = "24", // Nota Fiscal Eletrônica
                Value = "35260112345678000195550010000000011000000011"
            },
            DataVencimento = DateTime.Today.AddDays(5),
            Valor = new List<DecimalCampo>
            {
                new()
                {
                    Tipo = "11", // Valor Principal
                    Value = 150.50M
                }
            }
        }
    },
    ValorGnre = 150.50M,
    DataPagamento = DateTime.Today
};

// Adiciona a guia ao componente
gnre.Guias.Add(guia);

// Envia o lote
var retornoEnvio = await gnre.EnviarLoteAsync();
Console.WriteLine($"Recibo: {retornoEnvio.Dados.Recibo.Numero}");
```

---

### 4. Consulta do Resultado do Lote e Download do PDF

```csharp
var numeroRecibo = retornoEnvio.Dados.Recibo.Numero;
var resultadoLote = await gnre.ConsultaLoteAsync(numeroRecibo, incluirPdf: true);

if (resultadoLote.Dados.SituacaoProcess.Codigo == "100") // Processado com Sucesso
{
    foreach (var g in resultadoLote.Dados.Resultado.Guia)
    {
        Console.WriteLine($"Linha Digitável: {g.LinhaDigitavel}");
        Console.WriteLine($"Código de Barras: {g.CodigoBarras}");
    }

    // Salvar PDF da Guia retornada pela SEFAZ
    resultadoLote.Dados.Resultado.SalvarGuia(@"C:\GNRe\PDFs\guia_gnre.pdf");
}
```

---

### 5. Validação de Schemas XSD

É possível validar o XML gerado utilizando a classe nativa do `OpenAC.Net.DFe.Core`:

```csharp
using OpenAC.Net.DFe.Core;

var xmlString = guia.GetXml();
var caminhoSchema = @"Schemas/lote_gnre_v2.00.xsd";

var valido = XmlSchemaValidation.ValidarXml(xmlString, caminhoSchema, out var erros, out var avisos);

if (!valido)
{
    foreach (var erro in erros)
        Console.WriteLine($"Erro de validação: {erro}");
}
```

---

## 🖥️ Aplicativo Demo (Avalonia UI)

O projeto inclui um aplicativo de demonstração multiplataforma construído com **Avalonia UI** (.NET 10):

```bash
dotnet run --project src/OpenAC.Net.GNRe.Demo/OpenAC.Net.GNRe.Demo.csproj
```

Ele permite:
- Testar a configuração do componente e certificados
- Gerar e emitir guias GNRe versão 1.00 e 2.00
- Consultar recibos e configurações por UF
- Visualizar os XMLs enviados e recebidos em tempo real

---

## 🧪 Testes Unitários

O projeto possui uma suíte completa de testes unitários utilizando **TUnit** com validação de serialização, desserialização e conformidade com os schemas XSD oficiais:

```bash
dotnet run --project src/OpenAC.Net.GNRe.Tests/OpenAC.Net.GNRe.Tests.csproj
```

---

## 🤝 Contribuindo

Contribuições são sempre bem-vindas! Para contribuir:

1. Faça um **Fork** do projeto
2. Crie uma branch para sua funcionalidade (`git checkout -b feature/minha-feature`)
3. Faça commit das alterações (`git commit -m 'Adiciona funcionalidade X'`)
4. Faça push para a branch (`git push origin feature/minha-feature`)
5. Abra um **Pull Request**

Dúvidas e discussões podem ser feitas através da nossa comunidade no [Discord](https://discord.com/invite/brdmJ7Yv6w).

---

## 📄 Licença

Este projeto é distribuído sob a licença **MIT**. Consulte o arquivo [LICENSE](LICENSE) para mais detalhes.
