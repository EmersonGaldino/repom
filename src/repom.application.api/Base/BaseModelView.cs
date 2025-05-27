namespace repom.application.api.Base;

public class BaseModelView<TEntity> where TEntity :new()
{
    public bool Success { get; set; } = true;

    public string Message { get; set; }
    public long TimerProcessing { get; set; } = 0;
    public TEntity Data { get; set; }

    public void GenerateError(TEntity model, string message)
    {
        Message = message;
        Success = false;
    }
}