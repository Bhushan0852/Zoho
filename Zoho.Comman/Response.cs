

namespace Zoho.Comman
{
    public abstract class Response : IResponse
    {
        public bool IsSuccessful { get; set; } = false;

        public List<string> Errors { get; set; } = new();
    }
}
