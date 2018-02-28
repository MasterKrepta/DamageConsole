using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpPractice {
    class Program {
        public delegate  void MyDelegate(int arg);
        
        
        static void Main(string[] args) {
            List<Enemy> enemies = new List<Enemy>();
            List<Enemy> deadEnemies = new List<Enemy>();
            Enemy enemy1 = new Enemy("Wizard");
            Enemy enemy2 = new Enemy("Scout");
            Enemy enemy3 = new Enemy("Dragon");
            
            enemies.Add(enemy1);
            enemies.Add(enemy2);
            enemies.Add(enemy3);
            foreach (Enemy enemy in enemies) {
                enemy.OnTakeDamage += enemy.LoseHealth;
                enemy.Health = 100;
            }
            string input = "";
            do {
              
                foreach (Enemy enemy in enemies) {
                    if (enemy.Health <= 0) {
                        deadEnemies.Add(enemy);
                        Console.WriteLine("\n" + enemy.Name + " has Died! ");
                    } else {
                        Console.WriteLine("\n" + enemy.Name + " ----- " + enemy.Health);
                    }
                    
                }

                foreach (Enemy enemy in deadEnemies) {
                    if(enemies.Contains(enemy))
                    enemies.Remove(enemy);
                }

                if (enemies.Count == 0) {
                    Console.WriteLine("\nAll enemies have been destroyed! game over");
                    input = "exit";
                }

                Console.WriteLine("\nSelect Enemy to target (or exit to quit)");
                input = Console.ReadLine();
                Enemy selected = null;
                if (!input.Equals("exit")) {
                    
                    for (int i = 0; i < enemies.Count; i++) {
                        if(input.ToLower() == enemies[i].Name.ToLower()) {
                            selected = enemies[i];
                        } 
                    }
                    if(selected == null) {
                        Console.WriteLine("\nEnemy not found");
                    }
                    else {
                        // damage selected enemy;
                        selected.LoseHealth(60);
                    }
                }

                
                Console.ReadLine();

            } while (input != "exit");
            Console.WriteLine("\nGoodBye");
            Console.ReadLine();
        }

    }
}
