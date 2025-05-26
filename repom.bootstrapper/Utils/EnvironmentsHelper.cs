using System.Globalization;
using System.Text.RegularExpressions;

namespace repom.bootstrapper.Utils;

public static class EnvironmentsHelper
{
    public static bool Development => VerifyAmbient("Development", nameof(Development));
    public static bool Homolog => VerifyAmbient("Staging", "Staging");
    public static bool Production => VerifyAmbient("Production", "Production");

    public static bool Docker => VerifyAmbient("Docker", "Docker");
    public static string Nome => Development ? nameof(Development)
        : Homolog ? nameof(Homolog)
        : Production ? nameof(Production)
        : Docker ? nameof(Docker)
        : "Unknow";

    private static readonly string[] EnvVarirableNames = new[] { "ASPNETCORE_ENVIRONMENT", "WEBJOB_ENVIRONMENT" };

    private static bool VerifyAmbient(params string[] nomes) =>
        EnvVarirableNames.Select(e => Environment.GetEnvironmentVariable(e))
            .Where(e => !string.IsNullOrWhiteSpace(e))
            .Select(e => NormalizeName(e))
            .Any(e => nomes.Select(n => NormalizeName(n)).Any(n => n == e));


    private static string NormalizeName(string nome) =>
        Regex.Replace(nome.RemoveAscents(), "\\s", "");

    public static string RemoveAscents(this string text)
    {
        if (text == null) return null;

        var decomposed = text.Normalize(System.Text.NormalizationForm.FormD);
        var filtered = decomposed.Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
        return new string(filtered.ToArray());
    }
}