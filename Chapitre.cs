using System.Text.Json.Serialization;

namespace isgasoir
{
    public class Chapitre
    {
        long id;
        string title;
        string content;
        [JsonIgnore]
        Module? module;
        double duree;

        public double Duree { get => duree; set => duree = value; }
        public long Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        [JsonIgnore]
        public Module? Module { get => module; set => module = value; }
    }
}
