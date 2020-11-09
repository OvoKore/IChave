using Realms;

namespace IChave.Models
{
    public class Reload : RealmObject
    {

        public string Name { get; set; }

        public Reload()
        {
        }

        public Reload(string name)
        {
            Name = name;
        }
    }
}