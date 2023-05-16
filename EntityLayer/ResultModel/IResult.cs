namespace EntityLayer.ResultModel;

public interface IResult
{
    bool IsSuccess { get; set; }
    string Message { get; set; }
    
}