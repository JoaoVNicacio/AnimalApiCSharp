namespace AnimalApiCSharp.Tools
{
  public class PagedResults<T>
  {
    public T Result { get; set; }
    public bool HasNextPage { get; set; }

    public PagedResults(T result, bool hasNextPage)
    {
      Result = result;
      HasNextPage = hasNextPage;
    }
  }
}