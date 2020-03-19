using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour
{
    // ---------- SHIP'S HEALTHPOINTS ---------- //
    public shipHP shipHealth = new shipHP();
  
    public class shipHP
    {
        // Max HP
        private int _maxHP = 100;
        private float _maxHP_Mul = 1f;
        private int _maxHP_Add = 0;

        public int maxHP { get { return _maxHP; } set { _maxHP = value; } } 
        public float maxHP_Mul { get { return _maxHP_Mul; } set { _maxHP_Mul = value; } } 
        public int maxHP_Add { get { return _maxHP_Add; } set { _maxHP_Add = value; } }

        // HP regenerated (per second)
        private int _hPRegen = 2;
        private float _hPRegen_Mul = 1f;
        private int _hPRegen_Add = 0;

        public int hPRegen { get { return _hPRegen; } set { _hPRegen = value; } }
        public float hPRegen_Mul { get { return _hPRegen_Mul; } set { _hPRegen_Mul = value; } }
        public int hPRegen_Add { get { return _hPRegen_Add; } set { _hPRegen_Add = value; } }

        // HP regeneration limit (percent of total HP)
        private float _hPRegenLimit = 0.3f;
        private float _hPRegenLimit_Mul = 1f;
        private float _hPRegenLimit_Add = 0f;

        public float hPRegenLimit { get { return _hPRegenLimit; } set { _hPRegenLimit = value; } }
        public float hPRegenLimit_Mul { get { return _hPRegenLimit_Mul; } set { _hPRegenLimit_Mul = value; } }
        public float hPRegenLimit_Add { get { return _hPRegenLimit_Add; } set { _hPRegenLimit_Add = value; } }

        // Modifier for HP gained from pickups
        private float _hPPickupMod = 1f;
        private float _hPPickupMod_Mul = 1f;
        private float _hPPickupMod_Add = 0f;

        public float hPPickupMod { get { return _hPPickupMod; } set { _hPPickupMod = value; } }
        public float hPPickupMod_Mul { get { return _hPPickupMod_Mul; } set { _hPPickupMod_Mul = value; } }
        public float hPPickupMod_Add { get { return _hPPickupMod_Add; } set { _hPPickupMod_Add = value; } }
    }

    // ---------- SHIP'S SHIELDS ---------- //
    public shipShield shipShieldFSx = new shipShield();
    public shipShield shipShieldFCe = new shipShield();
    public shipShield shipShieldFDx = new shipShield();
    public shipShield shipShieldRSx = new shipShield();
    public shipShield shipShieldRCe = new shipShield();
    public shipShield shipShieldRDx = new shipShield();

    public class shipShield
    {
        // Max HP
        private int _hPShield = 100;
        private float _hPShield_Mul = 1f;
        private int _hPShield_Add = 0;

        public int hPShield { get { return _hPShield; } set { _hPShield = value; } }
        public float hPShield_Mul { get { return _hPShield_Mul; } set { _hPShield_Mul = value; } }
        public int hPShield_Add { get { return _hPShield_Add; } set { _hPShield_Add = value; } }

        // HP regeneration (per second)
        private int _hPShieldRegen = 0;
        private float _hPShieldRegen_Mul = 1f;
        private int _hPShieldRegen_Add = 0;

        public int hPShieldRegen { get { return _hPShieldRegen; } set { _hPShieldRegen = value; } }
        public float hPShieldRegen_Mul { get { return _hPShieldRegen_Mul; } set { _hPShieldRegen_Mul = value; } }
        public int hPShieldRegen_Add { get { return _hPShieldRegen_Add; } set { _hPShieldRegen_Add = value; } }

        // HP regeneration limit (percent of total HP)
        private float _hPShieldRegenLimit = 0f;
        private float _hPShieldRegenLimit_Mul = 1f;
        private float _hPShieldRegenLimit_Add = 0f;

        public float hPShieldRegenLimit { get { return _hPShieldRegenLimit; } set { _hPShieldRegenLimit = value; } }
        public float hPShieldRegenLimit_Mul { get { return _hPShieldRegenLimit_Mul; } set { _hPShieldRegenLimit_Mul = value; } }
        public float hPShieldRegenLimit_Add { get { return _hPShieldRegenLimit_Add; } set { _hPShieldRegenLimit_Add = value; } }

        // Modifier for HP gained from pickups
        private float _hPShieldPickupMod = 1f;
        private float _hPShieldPickupMod_Mul = 1f;
        private float _hPShieldPickupMod_Add = 0f;

        public float hPShieldPickupMod { get { return _hPShieldPickupMod; } set { _hPShieldPickupMod = value; } }
        public float hPShieldPickupMod_Mul { get { return _hPShieldPickupMod_Mul; } set { _hPShieldPickupMod_Mul = value; } }
        public float hPShieldPickupMod_Add { get { return _hPShieldPickupMod_Add; } set { _hPShieldPickupMod_Add = value; } }
    }

    // ---------- SHIP'S PROPERTIES ---------- //
    public shipProps shipProperties = new shipProps();

    public class shipProps
    {
        // Ship's Mass
        private int _mass = 100;
        private float _mass_Mul = 1f;
        private int _mass_Add = 0;

        public int mass { get { return _mass; } set { _mass = value; } }
        public float mass_Mul { get { return _mass_Mul; } set { _mass_Mul = value; } }
        public int mass_Add { get { return _mass_Add; } set { _mass_Add = value; } }

        // Engine's thrust
        private int _thrust = 30000;
        private float _thrust_Mul = 1f;
        private int _thrust_Add = 0;

        public int thrust { get { return _thrust; } set { _thrust = value; } }
        public float thrust_Mul { get { return _thrust_Mul; } set { _thrust_Mul = value; } }
        public int thrust_Add { get { return _thrust_Add; } set { _thrust_Add = value; } }

        // Engine's angular thrust
        private int _angularThrust = 100;
        private float _angularThrust_Mul = 1f;
        private int _angularThrust_Add = 0;

        public int angularThrust { get { return _angularThrust; } set { _angularThrust = value; } }
        public float angularThrust_Mul { get { return _angularThrust_Mul; } set { _angularThrust_Mul = value; } }
        public int angularThrust_Add { get { return _angularThrust_Add; } set { _angularThrust_Add = value; } }

        // Maximum speed
        private int _maxSpeed = 30;
        private float _maxSpeed_Mul = 1f;
        private int _maxSpeed_Add = 0;

        public int maxSpeed { get { return _maxSpeed; } set { _maxSpeed = value; } }
        public float maxSpeed_Mul { get { return _maxSpeed_Mul; } set { _maxSpeed_Mul = value; } }
        public int maxSpeed_Add { get { return _maxSpeed_Add; } set { _maxSpeed_Add = value; } }

        // Engine's Turbo thrust
        private int _turboThrust = 40000;
        private float _turboThrust_Mul = 1f;
        private int _turboThrust_Add = 0;

        public int turboThrust { get { return _turboThrust; } set { _turboThrust = value; } }
        public float turboThrust_Mul { get { return _turboThrust_Mul; } set { _turboThrust_Mul = value; } }
        public int turboThrust_Add { get { return _turboThrust_Add; } set { _turboThrust_Add = value; } }

        // Maximum Turbo speed
        private int _maxTurboSpeed = 50;
        private float _maxTurboSpeed_Mul = 1f;
        private int _maxTurboSpeed_Add = 0;

        public int maxTurboSpeed { get { return _maxTurboSpeed; } set { _maxTurboSpeed = value; } }
        public float maxTurboSpeed_Mul { get { return _maxTurboSpeed_Mul; } set { _maxTurboSpeed_Mul = value; } }
        public int maxTurboSpeed_Add { get { return _maxTurboSpeed_Add; } set { _maxTurboSpeed_Add = value; } }

        // TODO: aggiungere questi
        // Maximum Turbo Fuel
        // Turbo Fuel regeneration
        // Turbo Fuel regeneration limit
        // Modifier for Turbo Fuel gained from pickups

        // Ship's Size
        private int _size = 10;
        private float _size_Mul = 1f;
        private int _size_Add = 0;

        public int size { get { return _size; } set { _size = value; } }
        public float size_Mul { get { return _size_Mul; } set { _size_Mul = value; } }
        public int size_Add { get { return _size_Add; } set { _size_Add = value; } }

        // Ship's Drag
        private int _drag = 5;
        private float _drag_Mul = 1f;
        private int _drag_Add = 0;

        public int drag { get { return _drag; } set { _drag = value; } }
        public float drag_Mul { get { return _drag_Mul; } set { _drag_Mul = value; } }
        public int drag_Add { get { return _drag_Add; } set { _drag_Add = value; } }

        // Ship's Angular Drag
        private int _angularDrag = 10;
        private float _angularDrag_Mul = 1f;
        private int _angularDrag_Add = 0;

        public int angularDrag { get { return _angularDrag; } set { _angularDrag = value; } }
        public float angularDrag_Mul { get { return _angularDrag_Mul; } set { _angularDrag_Mul = value; } }
        public int angularDrag_Add { get { return _angularDrag_Add; } set { _angularDrag_Add = value; } }

        // Base Hit Damage Modifier (damage caused when hitting with ship)
        private int _hitBaseDamageMod = 1;
        private float _hitBaseDamageMod_Mul = 1f;
        private int _hitBaseDamageMod_Add = 0;

        public int hitBaseDamageMod { get { return _hitBaseDamageMod; } set { _hitBaseDamageMod = value; } }
        public float hitBaseDamageMod_Mul { get { return _hitBaseDamageMod_Mul; } set { _hitBaseDamageMod_Mul = value; } }
        public int hitBaseDamageMod_Add { get { return _hitBaseDamageMod_Add; } set { _hitBaseDamageMod_Add = value; } }

        // Shield Hit Damage Modifier (damage caused when hitting with shield)
        private int _hitShieldDamageMod = 1;
        private float _hitShieldDamageMod_Mul = 1f;
        private int _hitShieldDamageMod_Add = 0;

        public int hitShieldDamageMod { get { return _hitShieldDamageMod; } set { _hitShieldDamageMod = value; } }
        public float hitShieldDamageMod_Mul { get { return _hitShieldDamageMod_Mul; } set { _hitShieldDamageMod_Mul = value; } }
        public int hitShieldDamageMod_Add { get { return _hitShieldDamageMod_Add; } set { _hitShieldDamageMod_Add = value; } }
    }


    // ---------- WEAPONS ---------- //
    public shipWpn shipWeapon_1 = new shipWpn();
    public shipWpn shipWeapon_2 = new shipWpn();

    public class shipWpn
    {
        // Weapon Base Damage Modifier (damage caused to enemies' health)
        private int _baseDamageMod = 1;
        private float _baseDamageMod_Mul = 1f;
        private int _baseDamageMod_Add = 0;

        public int baseDamageMod { get { return _baseDamageMod; } set { _baseDamageMod = value; } }
        public float baseDamageMod_Mul { get { return _baseDamageMod_Mul; } set { _baseDamageMod_Mul = value; } }
        public int baseDamageMod_Add { get { return _baseDamageMod_Add; } set { _baseDamageMod_Add = value; } }

        // Weapon Shield Damage Modifier (damage caused to enemies' shield)
        private int _shieldDamageMod = 1;
        private float _shieldDamageMod_Mul = 1f;
        private int _shieldDamageMod_Add = 0;

        public int shieldDamageMod { get { return _shieldDamageMod; } set { _shieldDamageMod = value; } }
        public float shieldDamageMod_Mul { get { return _shieldDamageMod_Mul; } set { _shieldDamageMod_Mul = value; } }
        public int shieldDamageMod_Add { get { return _shieldDamageMod_Add; } set { _shieldDamageMod_Add = value; } }

        //// Weapon FireRate (bullets per seconds) VANNO RESI DEI MODIFIERS
        //private int _FireRate = 5;
        //private float _FireRate_Mul = 1f;
        //private int _FireRate_Add = 0;

        //public int FireRate { get { return _FireRate; } set { _FireRate = value; } }
        //public float FireRate_Mul { get { return _FireRate_Mul; } set { _FireRate_Mul = value; } }
        //public int FireRate_Add { get { return _FireRate_Add; } set { _FireRate_Add = value; } }

        //// Weapon Shoot Impulse Force
        //private int _ShootImpulse = 20;
        //private float _ShootImpulse_Mul = 1f;
        //private int _ShootImpulse_Add = 0;

        //public int ShootImpulse { get { return _ShootImpulse; } set { _ShootImpulse = value; } }
        //public float ShootImpulse_Mul { get { return _ShootImpulse_Mul; } set { _ShootImpulse_Mul = value; } }
        //public int ShootImpulse_Add { get { return _ShootImpulse_Add; } set { _ShootImpulse_Add = value; } }

        //// Weapon Life Time (in seconds)
        //private int _lifeTime = 1
    }
}
