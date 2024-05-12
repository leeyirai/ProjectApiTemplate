namespace WebApplicationApiTemplate.Model
{
    public class TemplateModel
    {
        public class Request
        {
            public string? Account { get; set; }
            public string? Password { get; set; }
        }
        public class Response
        {
            public string? Name { get; set; }
            public string? Phone { get; set; }
            public string? Email { get; set; }
        }
    }
}
