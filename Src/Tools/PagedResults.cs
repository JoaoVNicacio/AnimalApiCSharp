namespace AnimalApiCSharp.Tools
{
  public class PagedResults<T>
  {
    public IEnumerable<T> Result { get; set; }
    public bool HasNextPage { get; set; }
    public int PageIndex { get; }
    public int PageSize { get; }

    public PagedResults(IEnumerable<T> result, bool hasNextPage, int pageIndex, int pageSize)
    {
      Result = result;
      HasNextPage = hasNextPage;
      PageIndex = pageIndex;
      PageSize = pageSize;
    }
  }
}