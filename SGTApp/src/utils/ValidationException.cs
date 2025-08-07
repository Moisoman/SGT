namespace SGTApp.utils;

public class ValidationException : Exception
{
    public List<string> Erros { get; }

    public ValidationException(List<string> erros)
    {
        Erros = erros;
    }
}