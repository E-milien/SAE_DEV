﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_DEV_PROJ
{
    internal class Perso
    {
        const int _tailleX=0;
        const int _tailleY=0;
        private int _pvPerso;
        private bool _godMod;
        private string _skinPerso;
        private double _multiplicationVitesse;
        private Vector2 _deplacementPerso;

        public Perso(bool godMod, int pvPerso, string skinPerso, double multiplicationVitesse, Vector2 deplacementPerso)
        {
            this.GodMod = godMod;
            this.PvPerso = pvPerso;
            this.SkinPerso = skinPerso;
            this.MultiplicationVitesse = multiplicationVitesse;
            this.DeplacementPerso = deplacementPerso;
        }

        

        public bool GodMod
        {
            get
            {
                return this._godMod;
            }

            set
            {
                if (!(value == true || value == false))
                    throw new ArgumentException("value");
                this._godMod = value;
            }
        }
        public int PvPerso
        {
            get
            {
                return this._pvPerso;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value");
                if (GodMod == true)
                    this._pvPerso = 1000000000;
                this._pvPerso = value;
            }
        }

        public string SkinPerso
        {
            get
            {
                return this._skinPerso;
            }

            set
            {
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("value");
                this._skinPerso = value;
            }
        }

        public double MultiplicationVitesse
        {
            get
            {
                return this._multiplicationVitesse;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value");
                this._multiplicationVitesse = value;
            }
        }

        public Vector2 DeplacementPerso
        {
            get
            {
                return this._deplacementPerso;
            }

            set
            {
                this._deplacementPerso = value;
            }
        }
    }
}