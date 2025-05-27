namespace repom.application.api.Base;

public class SuccessResponse<TEntity> : BaseResponse where TEntity : class
{
    public TEntity Data { get; set; }

    public SuccessResponse(TEntity data) : base(true)
    {
        Data = data;
    }
}