using Realms;

namespace IChave.ModelRealm
{
    public class ReloadRealm : RealmObject
    {

        public string Name { get; set; }

        public ReloadRealm()
        {
        }

        public ReloadRealm(string name)
        {
            Name = name;
        }
    }
}