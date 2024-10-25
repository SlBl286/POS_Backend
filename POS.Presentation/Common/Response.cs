using System.Net;

namespace POS.Presentation.Common;


public record ApiResponse<T>(
    bool Success,
    T Data,
    HttpStatusCode StatusCode,
    string Message = ""
);

public record ApiListResponse<T>(
    bool Success,
    List<T> Data,
    HttpStatusCode StatusCode,
    int PageSize,
    int Total,
    int Page,
    string Message = ""
);