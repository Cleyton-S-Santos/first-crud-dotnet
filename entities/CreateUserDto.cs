namespace code_dotnet.entities
{
    public class CreateUserDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required DateTime DateOfBirth { get; set; }
    }
}