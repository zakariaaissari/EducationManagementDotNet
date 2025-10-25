using System.Text.Json.Serialization;

namespace isgasoir
{
    public class Activity
    {
        long id;
        string title;
        string description;
        string type; // "TP" or "TD"
        DateTime? dueDate;
        int duration; // in minutes
        string instructions;
        long chapitreId; // Foreign key
        [JsonIgnore]
        Chapitre? chapitre;

        public long Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Type { get => type; set => type = value; }
        public DateTime? DueDate { get => dueDate; set => dueDate = value; }
        public int Duration { get => duration; set => duration = value; }
        public string Instructions { get => instructions; set => instructions = value; }
        public long ChapitreId { get => chapitreId; set => chapitreId = value; }
        [JsonIgnore]
        public Chapitre? Chapitre { get => chapitre; set => chapitre = value; }
    }
}
