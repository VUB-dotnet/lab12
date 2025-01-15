namespace ConferenceAPI.Models;

public class Talk {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Speaker { get; set; }
    public int ConferenceId { get; set; }
    public Conference? Conference { get; set; }
}