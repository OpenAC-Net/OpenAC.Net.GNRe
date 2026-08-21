using System;
using System.IO;
using OpenAC.Net.DFe.Core;

namespace OpenAC.Net.GNRe.Tests;

public static class SchemaValidationHelper
{
    private static readonly string SchemasDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Schemas");

    public static string ObterCaminhoSchema(string schemaFileName)
    {
        return Path.Combine(SchemasDir, schemaFileName);
    }

    public static (bool IsValid, string[] Errors) ValidateXml(string xmlContent, string schemaFileName)
    {
        var schemaPath = ObterCaminhoSchema(schemaFileName);
        var isValid = XmlSchemaValidation.ValidarXml(xmlContent, schemaPath, out var errors, out _);
        return (isValid, errors);
    }

    public static (bool IsValid, string[] Errors, string[] Avisos) ValidateXmlComAvisos(string xmlContent, string schemaFileName)
    {
        var schemaPath = ObterCaminhoSchema(schemaFileName);
        var isValid = XmlSchemaValidation.ValidarXml(xmlContent, schemaPath, out var errors, out var avisos);
        return (isValid, errors, avisos);
    }
}
