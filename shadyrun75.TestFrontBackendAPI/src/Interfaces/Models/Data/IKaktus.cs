namespace shadyrun75.TestFrontBackendAPI.Interfaces.Models.Data
{
    public interface IKaktus
    {
        public Int64? Id { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }

        public bool Check(out string message)
        {
            message = string.Empty;
            if (Title == null || Title?.Trim()?.Length == 0)
                message += "Title is empty;";

            if (Category == null || Category?.Trim()?.Length == 0)
                message += "Category is empty;";

            if (ImageUrl == null || ImageUrl?.Trim()?.Length == 0)
                message += "Image Url is empty;";

            if (Price < 0)
                message += "Price less zero;";

            return message == string.Empty;
        }
    }
}