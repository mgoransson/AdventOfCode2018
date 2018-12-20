using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day13
    {
        public static void Run()
        {
            var input = ReadInput();

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input));

            Console.WriteLine("Part II");
            Console.WriteLine(Part02(input));
        }

        public static string[] ReadInput() 
        {
            return File.ReadAllLines(@"Inputs/Day13.input.txt");
        }

        public static string Part01(string[] input)
        {
            var carts = GetCarts(input);
            RemoveCartsFromInput(input);

            var firstCollision = string.Empty;            
            while(true)
            {
                foreach(var cart in carts.OrderBy(c => c.Y).ThenBy(c => c.X))
                {
                    MoveCart(input, cart);

                    var groupedCarts = carts.GroupBy(a=> a.X + "," + a.Y).Select(a=> new { Point = a.Key, Count = a.Count() }).OrderByDescending(c => c.Count);
                    if (groupedCarts.First().Count > 1)
                    {
                        firstCollision = groupedCarts.First().Point;
                        return firstCollision;
                    }
                }
            }
        }

        public static string Part02(string[] input)
        {
            var carts = GetCarts(input);
            RemoveCartsFromInput(input);

            while(true)
            {
                foreach(var cart in carts.OrderBy(c => c.Y).ThenBy(c => c.X))
                {
                    if (!cart.Collided)
                        MoveCart(input, cart);

                    var groupedCarts = carts.Where(g => !g.Collided).GroupBy(a=> a.X + "," + a.Y).Select(a=> new { Point = a.Key, Count = a.Count() });
                    if (groupedCarts.Any(g => g.Count > 1))
                    {
                        foreach(var group in groupedCarts.Where(gc => gc.Count > 1))
                        {
                            foreach(var c2 in carts.Where(c => c.X + "," + c.Y == group.Point))
                            {
                                c2.Collided = true;
                            }
                        }
                    }
                    if (carts.Count(c => !c.Collided) == 1)
                    {
                        MoveCart(input, carts.Single(s => !s.Collided));
                        return $"{carts.Single(s => !s.Collided).X},{carts.Single(s => !s.Collided).Y}";
                    }
                }
            }
        }

        private static List<Cart> GetCarts(string[] input)
        {
            var carts = new List<Cart>();
            for (var y = 0; y < input.Length; y++)
            {
                for(var x = 0; x < input[y].Length; x++)
                {
                    var direction = Direction.Down;
                    var add = false;
                    switch (input[y][x])
                    {
                        case '<':
                            direction = Direction.Left;
                            add = true;
                        break;
                        case '>':
                            direction = Direction.Right;
                            add = true;
                        break;
                        case '^':
                            direction = Direction.Up;
                            add = true;
                        break;
                        case 'v':
                            direction = Direction.Down;
                            add = true;
                        break;
                    }
                    if (add)
                    {
                        carts.Add(new Cart() {
                            X = x,
                            Y = y,
                            Direction = direction
                        });
                    }
                }
            }
            return carts;
        }

        private static void RemoveCartsFromInput(string[] input)
        {
            for(var i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Replace("<", "-");
                input[i] = input[i].Replace(">", "-");
                input[i] = input[i].Replace("^", "|");
                input[i] = input[i].Replace("v", "|");
            }
        }

        private static void MoveCart(string[] input, Cart cart)
        {
            var intersectionRules = new []
            {
                Direction.Left,
                Direction.Straight,
                Direction.Right
            };

            switch (cart.Direction)
            {
                case Direction.Left:
                    cart.X--;
                break;
                case Direction.Right:
                    cart.X++;
                break;
                case Direction.Up:
                    cart.Y--;
                break;
                case Direction.Down:
                    cart.Y++;
                break;
            }

            switch (input[cart.Y][cart.X])
            {
                case '/':
                    switch(cart.Direction)
                    {
                        case Direction.Left:
                            cart.Direction = Direction.Down;
                        break;
                        case Direction.Right:
                            cart.Direction = Direction.Up;
                        break;
                        case Direction.Up:
                            cart.Direction = Direction.Right;
                        break;
                        case Direction.Down:
                            cart.Direction = Direction.Left;
                        break;
                    }
                break;
                case '\\':
                    switch(cart.Direction)
                    {
                        case Direction.Left:
                            cart.Direction = Direction.Up;
                        break;
                        case Direction.Right:
                            cart.Direction = Direction.Down;
                        break;
                        case Direction.Up:
                            cart.Direction = Direction.Left;
                        break;
                        case Direction.Down:
                            cart.Direction = Direction.Right;
                        break;
                    }
                break;
                case '+':
                    var turn = intersectionRules[(cart.IntersectionCount) % intersectionRules.Length];
                    if (turn != Direction.Straight)
                    {
                        switch(cart.Direction)
                        {
                            case Direction.Left:
                                cart.Direction = turn == Direction.Left ? Direction.Down : Direction.Up;
                            break;
                            case Direction.Right:
                                cart.Direction = turn == Direction.Left ? Direction.Up : Direction.Down;
                            break;
                            case Direction.Up:
                                cart.Direction = turn == Direction.Left ? Direction.Left : Direction.Right;
                            break;
                            case Direction.Down:
                                cart.Direction = turn == Direction.Left ? Direction.Right : Direction.Left;
                            break;
                        }
                    }
                    cart.IntersectionCount++;
                break;
            }
        }

        class Cart
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Direction Direction { get; set; }
            public int IntersectionCount { get; set; }
            public bool Collided { get; set; }
        }

        enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            Straight
        }
    }
}
