using PlanetWars.Utilities.Messages;
using System;

namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        public NuclearWeapon(int destructionLevel)
            : base(destructionLevel, 15)
        {
        }        
    }
}
