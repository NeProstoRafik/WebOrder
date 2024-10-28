using System;


namespace WebOrder.Domain.Enum;

public enum StatusCode
{
    Error = 0,
    NotFoundOrders = 15,
    NullParametrs = 18,
    OK = 200,
    BadRequest = 400,
    NotFound = 404,
    InternalServerError = 500,
}
