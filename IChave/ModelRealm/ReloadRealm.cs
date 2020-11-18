﻿using System.Linq;
using Realms;

namespace IChave.ModelRealm
{
    public class ReloadRealm : RealmObject
    {
        
        public string Name { get; set; }
        private IQueryable<ReloadRealm> Reload;
        private readonly Realm realm;

        public ReloadRealm()
        {
        }

        public ReloadRealm(string name)
        {
            realm = Realm.GetInstance();
            Name = name;
        }

        public IQueryable<ReloadRealm> Get()
        {
            Reload = realm.All<ReloadRealm>().Where(x => x.Name == Name);
            return Reload;
            
        }

        public void Add()
        {
            realm.Write(() =>
            {
                realm.Add(new ReloadRealm(Name));
            });
        }

        public void Remove()
        {
            realm.Write(() =>
            {
                realm.RemoveRange(Reload);
            });
        }
    }
}