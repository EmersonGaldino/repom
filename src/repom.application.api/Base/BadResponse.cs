namespace repom.application.api.Base;

public class BadResponse : BaseResponse
{
    public BadResponse(string error) : base(false)
    {
        Errors = new List<string>();
    }

    public BadResponse(List<string> errors) : base (false)
    {
        Errors = errors;
    }
        
    public List<string> Errors { get; private set; }
}