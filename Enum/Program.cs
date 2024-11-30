using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    enum State
    {
        Idle,
        Move,
        Attack
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Character play = new Character();
            play.Change(State.Idle);
        }
        public class Character
        {
            public void Change(State state)
            {
                switch (state){
                    case State.Idle:
                        Console.WriteLine("Dang dung");
                        break;
                    case State.Move:
                        Console.WriteLine("Dang di");
                        break;
                }
            }
        }
    }
}
