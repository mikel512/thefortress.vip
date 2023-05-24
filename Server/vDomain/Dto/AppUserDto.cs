namespace vDomain.Dto;

public class AppUserDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string OldPassword { get; set; }
    public string Password { get; set; }
    public bool MailingListEnabled { get; set; }
}
