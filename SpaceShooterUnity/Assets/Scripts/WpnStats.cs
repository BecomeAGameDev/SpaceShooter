using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WpnStats : MonoBehaviour
{
    public baseStats leftWpnStats = new baseStats();
    public baseStats rightWpnStats = new baseStats();

    public class baseStats
    {
        // Weapon fireRate (bullets per seconds) VANNO RESI DEI MODIFIERS
        private int _fireRate = 5;
        private float _fireRate_Mul = 1f;
        private int _fireRate_Add = 0;

        public int fireRate { get { return _fireRate; } set { _fireRate = value; } }
        public float fireRate_Mul { get { return _fireRate_Mul; } set { _fireRate_Mul = value; } }
        public int fireRate_Add { get { return _fireRate_Add; } set { _fireRate_Add = value; } }

        // Weapon shoot Impulse Force
        private int _shootImpulse = 20;
        private float _shootImpulse_Mul = 1f;
        private int _shootImpulse_Add = 0;

        public int shootImpulse { get { return _shootImpulse; } set { _shootImpulse = value; } }
        public float shootImpulse_Mul { get { return _shootImpulse_Mul; } set { _shootImpulse_Mul = value; } }
        public int shootImpulse_Add { get { return _shootImpulse_Add; } set { _shootImpulse_Add = value; } }

        // Weapon Life Time (in seconds)
        private float _lifeTime = 1;
        private float _lifeTime_Mul = 1f;
        private float _lifeTime_Add = 0;

        public float lifeTime { get { return _lifeTime; } set { _lifeTime = value; } }
        public float lifeTime_Mul { get { return _lifeTime_Mul; } set { _lifeTime_Mul = value; } }
        public float lifeTime_Add { get { return _lifeTime_Add; } set { _lifeTime_Add = value; } }

        //TODO: mettere i vari tipi di danni
    }

    public dmgStats leftWpnDmg = new dmgStats();
    public dmgStats rightWpnDmg = new dmgStats();

    public class dmgStats
    {
        // Weapon base damage
        private int _baseDmg = 1;
        private float _baseDmg_Mul = 1f;
        private int _baseDmg_Add = 0;

        public int baseDmg { get { return _baseDmg; } set { _baseDmg = value; } }
        public float baseDmg_Mul { get { return _baseDmg_Mul; } set { _baseDmg_Mul = value; } }
        public int baseDmg_Add { get { return _baseDmg_Add; } set { _baseDmg_Add = value; } }

        // Weapon shield damage
        private int _shieldDmg = 1;
        private float _shieldDmg_Mul = 1f;
        private int _shieldDmg_Add = 0;

        public int shieldDmg { get { return _shieldDmg; } set { _shieldDmg = value; } }
        public float shieldDmg_Mul { get { return _shieldDmg_Mul; } set { _shieldDmg_Mul = value; } }
        public int shieldDmg_Add { get { return _shieldDmg_Add; } set { _shieldDmg_Add = value; } }
    }
}
    
