namespace ConsoleApp1 {
    internal class Program {
        private static void Main(string[] args) {
            var sodaMachine = new SodaMachine();
            sodaMachine.Start();
        }
    }

    public class SodaMachine {
        private static int _money;

        /// <summary>
        /// This is the starter method for the machine
        /// </summary>

        public void Start() {
            var inventory = new [] {
                new Soda {
                    Name = "coke", Quantity = 5, Price = 20
                }, new Soda {
                    Name = "sprite", Quantity = 3, Price = 15
                }, new Soda {
                    Name = "fanta", Quantity = 3, Price = 15
                }
            };

            while (true) {
                Console.WriteLine("\n\nAvailable commands:");
                Console.WriteLine("insert (money) - Money put into money slot");
                Console.WriteLine("order (coke, sprite, fanta) - Order from machines buttons");
                Console.WriteLine("sms order (coke, sprite, fanta) - Order sent by sms");
                Console.WriteLine("recall - gives money back");
                Console.WriteLine("-------");
                Console.WriteLine("Inserted money: " + _money);
                Console.WriteLine("-------\n\n");

                var input = Console.ReadLine();

                if (input.StartsWith("insert")) {
                    //Add to credit
                    _money += int.Parse(input.Split(' ')[1]);
                    Console.WriteLine("Adding " + int.Parse(input.Split(' ')[1]) + " to credit");
                }
                if (input.StartsWith("order")) {
                    // split string on space
                    var csoda = input.Split(' ')[1];
                    //Find out witch kind
                    switch (csoda) {
                    case "coke":
                        var coke = inventory[0];
                        if (coke.Name == csoda && _money >= coke.Price && coke.Quantity > 0) {
                            Console.WriteLine("Giving coke out");
                            _money -= coke.Price;
                            Console.WriteLine("Giving " + _money + " out in change");
                            _money = 0;
                            coke.Quantity -- ;
                        } else if (coke.Name == csoda && coke.Quantity == 0) {
                            Console.WriteLine("No coke left");
                        } else if (coke.Name == csoda) {
                            Console.WriteLine("Need " + (coke.Price - _money) + " more");
                        }

                        break;
                    case "fanta":
                        var fanta = inventory[2];
                        if (fanta.Name == csoda && _money >= fanta.Price && fanta.Quantity > 0) {
                            Console.WriteLine("Giving fanta out");
                            _money -= fanta.Price;
                            Console.WriteLine("Giving " + _money + " out in change");
                            _money = 0;
                            fanta.Quantity -- ;
                        } else if (fanta.Name == csoda && fanta.Quantity == 0) {
                            Console.WriteLine("No fanta left");
                        } else if (fanta.Name == csoda) {
                            Console.WriteLine("Need " + (fanta.Price - _money) + " more");
                        }

                        break;
                    case "sprite":
                        var sprite = inventory[1];
                        if (sprite.Name == csoda && _money >= sprite.Price && sprite.Quantity > 0) {
                            Console.WriteLine("Giving sprite out");
                            _money -= sprite.Price;
                            Console.WriteLine("Giving " + _money + " out in change");
                            _money = 0;
                            sprite.Quantity -- ;
                        } else if (sprite.Name == csoda && sprite.Quantity == 0) {
                            Console.WriteLine("No sprite left");
                        } else if (sprite.Name == csoda) {
                            Console.WriteLine("Need " + (sprite.Price - _money) + " more");
                        }
                        break;
                    default:
                        Console.WriteLine("No such soda");
                        break;
                    }
                }
                if (input.StartsWith("sms order")) {
                    var csoda = input.Split(' ')[2];
                    //Find out witch kind
                    switch (csoda) {
                    case "coke":
                        if (inventory[0].Quantity > 0) {
                            Console.WriteLine("Giving coke out");
                            inventory[0].Quantity -- ;
                        }
                        break;
                    case "sprite":
                        if (inventory[1].Quantity > 0) {
                            Console.WriteLine("Giving sprite out");
                            inventory[1].Quantity -- ;
                        }
                        break;
                    case "fanta":
                        if (inventory[2].Quantity > 0) {
                            Console.WriteLine("Giving fanta out");
                            inventory[2].Quantity -- ;
                        }
                        break;
                    }

                }

                if (input.Equals("recall")) {
                    //Give money back
                    Console.WriteLine("Returning " + _money + " to customer");
                    _money = 0;
                }

            }
        }
    }
    public class Soda {
        public string Name {
            get;
            set;
        }
        public int Quantity {
            get;
            set;
        }
        public int Price {
            get;
            set;
        }

    }
}
