namespace EntityLayer.ResultModel;

public interface IDataResult<T>:IResult
{
    T Data { get; set; }
    
}