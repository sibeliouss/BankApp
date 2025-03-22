namespace BankApp.Core.Pagination;

public class PaginationParams
{
    public int Page { get; set; }
    public int Size { get; set; }

    public PaginationParams()
    {
        Page = 0;
        Size = 10;
    }

    public PaginationParams(int page, int size)
    {
        Page = page;
        Size = size;
    }
} 