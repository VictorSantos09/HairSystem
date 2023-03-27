namespace Hair.Application.Dto.UserCases
{
    public class UpdateUserServiceDto
    {
        public Guid UserID { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }
        public float OldValue { get; set; }
        public float NewValue { get; set; }
        public string? NewDescription { get; set; }
        public string OldType { get; set; }
        public string NewType { get; set; }
        public bool Confirmed { get; set; }

        public UpdateUserServiceDto(Guid userID, string oldName, string newName, float oldValue,
            float newValue, string? newDescription, string oldType, string newType, bool confirmed)
        {
            UserID = userID;
            OldName = oldName;
            NewName = newName;
            OldValue = oldValue;
            NewValue = newValue;
            NewDescription = newDescription;
            OldType = oldType;
            NewType = newType;
            Confirmed = confirmed;
        }
    }
}
