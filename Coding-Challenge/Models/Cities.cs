using Newtonsoft.Json;

namespace Coding_Challenge
{
    public class Cities
    {
        [JsonIgnore]
        public virtual int Id { get; set; }
        public virtual string name { get; set; }
        public virtual float lat { get; set; }
        public virtual float @long { get; set; }
        [JsonIgnore]
        public virtual string country { get; set; }
        [JsonIgnore]
        public virtual string stateprov { get; set; }
        public virtual int score { get; set; }
    }
}