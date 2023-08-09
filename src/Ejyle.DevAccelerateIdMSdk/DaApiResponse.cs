namespace Ejyle.DevAccelerate.IdM
{
    public class DaApiResponse<T>
    {
        public T Data { get; set; }
    }

    public class DaApiResponseArray<T>
    {
        public int TotalCount { get; set; }
        public T[] Data { get; set; }
    }
}
