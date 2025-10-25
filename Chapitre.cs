using System.Text.Json.Serialization;

namespace isgasoir
{
    public class Chapitre
    {
        long id;
        string title = string.Empty;
        string content = string.Empty;
        long moduleId; // Added for serialization
        [JsonIgnore]
        Module? module;
        double duree;
        List<Activity>? activities = new List<Activity>();

        public double Duree { get => duree; set => duree = value; }
        public long Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public long ModuleId { get => moduleId; set => moduleId = value; } // Public property for ModuleId
        [JsonIgnore]
        public Module? Module { get => module; set => module = value; }
        public List<Activity>? Activities { get => activities; set => activities = value; }
    }
}
