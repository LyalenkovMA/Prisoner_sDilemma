using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_sDilemma
{
    public class ControlPrisoners
    {
        private const int KeyBitray = 1;
        private const int KeyNotBitray = 2;
        private Prisoner _prisonerOne;
        private Prisoner _prisonerTwo;

        private int _balsPrisonerOne;
        private int _balsPrisonerTwo;

        public ControlPrisoners()
        {
            _prisonerOne = new Prisoner();
            _prisonerTwo = new Prisoner();

            _balsPrisonerOne = 0;
            _balsPrisonerTwo = 0;
        }

        public void Start()
        {
            int startBals = 1;
            bool isStart = true;

            while (isStart)
            {
                Console.WriteLine("на старт игры, каждому игроку дают по балу");
                Console.WriteLine("каждый игрок может отдать его соседу.");
                Console.WriteLine("за это другой игрок получает 3 бала с верху");
                Console.WriteLine("за сотрудничество каждый игрок получает по балу сверху своих");
                Console.WriteLine("Хотит предать?");
                _balsPrisonerOne = startBals;
                _balsPrisonerTwo = startBals;

                bool isBitrayPrisonerOne = Control(_prisonerOne);
                bool isBitrayPrisonerTwo = Control(_prisonerTwo);

                if (isBitrayPrisonerOne == false && isBitrayPrisonerTwo == false)
                {
                    _balsPrisonerOne += 2;
                    _balsPrisonerTwo += 2;
                }
                else
                {
                    if (_prisonerOne.IsBitray == true && _prisonerTwo.IsBitray == false)
                    {
                        _balsPrisonerOne += 4;
                        _balsPrisonerTwo -= 1;
                    }
                    if (_prisonerOne.IsBitray == false && _prisonerTwo.IsBitray == true)
                    {
                        _balsPrisonerOne -= 1;
                        _balsPrisonerTwo += 4;
                    }
                }

                PrintPrisoner(_prisonerOne,_balsPrisonerOne);
                PrintPrisoner(_prisonerTwo,_balsPrisonerTwo);

            }
        }

        private void PrintPrisoner(Prisoner prisoner, int bals)
        {
            if (prisoner.IsBitray)
                Console.WriteLine($"игрок предал у него {bals} ,балов");
            else
                Console.WriteLine($"игрок не предал у него {bals} ,балов");
        }

        private bool Control(Prisoner prisoner)
        {
            const string ComandYes = "да";
            const string ComandNot = "нет";

            string userComand;
            int key =0;
            bool isSerche = false;

            while(isSerche == false)
            {
                Console.WriteLine("Хотите сотрудничать, или предать поддельника:");
                Console.WriteLine($"если да то введите ({ComandYes})");
                Console.WriteLine($"если нет то введите ({ComandNot})");
                Console.Write("Ввод:");
                userComand = Console.ReadLine();

                switch (userComand)
                {
                    case ComandYes:
                        Choice(KeyNotBitray, out key, out isSerche, prisoner);
                        break;
                    case ComandNot:
                        Choice(KeyBitray, out key, out isSerche, prisoner);
                        break;
                }
            }

            prisoner.Choice(key);

            return prisoner.IsBitray;
        }

        private void Choice(int keyBitray, out int key, out bool isSerche, Prisoner prisoner)
        {
            key = keyBitray;
            isSerche = true;

            prisoner.Choice(key);
            
        }
    }
}
