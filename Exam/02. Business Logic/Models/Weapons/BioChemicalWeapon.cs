using PlanetWars.Utilities.Messages;
using System;

namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        public BioChemicalWeapon(int destructionLevel)
            : base(destructionLevel, 3.2)
        {
        }

    }
}
