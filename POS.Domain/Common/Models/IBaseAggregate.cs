using NpgsqlTypes;

namespace POS.Domain.Common.Models;

public interface IBaseAggregate
{
    public NpgsqlTsVector SearchVector {get; set;}

}