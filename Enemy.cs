using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpPractice {
    class Enemy {
        public event Program.MyDelegate OnTakeDamage;
        private int m_health;

        public Enemy(string name) {
            Name = name;

        }
        public int Health {
            get {
                return m_health;
            }
            set {
                m_health = value;
                //OnTakeDamage(value);

            }
        }
        public string Name = "";

        public void LoseHealth(int damage) {
            Health -= damage;
            Console.WriteLine(this.Name + " has taken " + damage + " points of damage");

        }
    }

}
