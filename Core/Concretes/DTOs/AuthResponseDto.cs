namespace Core.Concretes.DTOs
{
    public class AuthResponseDto
    {
        public bool IsSuccessful { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
