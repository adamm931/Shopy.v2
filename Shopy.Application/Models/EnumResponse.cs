namespace Shopy.Application.Models
{
    public class EnumResponse<TEnum>
    {
        public TEnum Id { get; set; }

        public string Code { get; set; }
    }
}
