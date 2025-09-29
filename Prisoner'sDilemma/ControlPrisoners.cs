using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_sDilemma
{
    public class ControlPrisoners
    {
        private const int _countStep = 200;
        private const int KeyBitray = 1;
        private const int KeyNotBitray = 2;

        private Prisoner _prisonerOne;
        private Prisoner _prisonerTwo;
        private IStratege[] _strateges;

        private int _balsPrisonerOne;
        private int _balsPrisonerTwo;
        private IStratege _strategePrisonerOne;
        private IStratege _strategePrisonerTwo;

        public ControlPrisoners()
        {
            _prisonerOne = new Prisoner();
            _prisonerTwo = new Prisoner();

            _strateges = new IStratege[2];
            _strateges[0] = new AnEyeForEye();  
            _strateges[1] = new OnMyMind();  
        }

        public void Start()
        {
            for(int i = 0; i < _strateges.Length; i++)
            {
                _strategePrisonerOne = _strateges[i];
                
                for(int j = 0; j < _strateges.Length; j++)
                {
                    _balsPrisonerOne = 0;
                    _balsPrisonerTwo = 0;
                    _strategePrisonerTwo = _strateges[j];

                    int[] stepPrisonerOne = new int[_countStep];
                    int[] stepPrisonerTwo = new int[_countStep];

                    for (int g = 0; g < _countStep; g++)
                    {
                        _prisonerOne.Choice(_strategePrisonerOne.GetChoice());
                        _prisonerTwo.Choice(_strategePrisonerTwo.GetChoice());

                        ChoicePrisoner(stepPrisonerOne, g, _prisonerOne);
                        ChoicePrisoner(stepPrisonerTwo, g, _prisonerTwo);

                        _strategePrisonerOne.Start(stepPrisonerTwo, g);
                        _strategePrisonerTwo.Start(stepPrisonerOne, g);

                        if(_prisonerOne.IsBitray && _prisonerTwo.IsBitray)
                        {
                            _balsPrisonerOne += 1;
                            _balsPrisonerTwo += 1;
                        }
                        else if(_prisonerOne.IsBitray == false && _prisonerTwo.IsBitray)
                        {
                            _balsPrisonerOne += 0;
                            _balsPrisonerTwo += 5;
                        }
                        else if (_prisonerOne.IsBitray  && _prisonerTwo.IsBitray == false)
                        {
                            _balsPrisonerOne += 5;
                            _balsPrisonerTwo += 0;
                        }
                        else if (_prisonerOne.IsBitray == false && _prisonerTwo.IsBitray == false)
                        {
                            _balsPrisonerOne += 3;
                            _balsPrisonerTwo += 3;
                        }
                    }

                    PrintChoicesPrisoner(stepPrisonerOne, _strategePrisonerOne);
                    Console.WriteLine();
                    PrintChoicesPrisoner(stepPrisonerTwo, _strategePrisonerTwo);
                    Console.WriteLine();

                    Console.WriteLine($"{_strategePrisonerOne.Title} набрал {_balsPrisonerOne}");
                    Console.WriteLine($"{_strategePrisonerTwo.Title} набрал {_balsPrisonerTwo}");
                }
            }
        }

        private void PrintChoicesPrisoner(int[] stepPrisonerOne, IStratege stratege)
        {
            Console.Write($"{stratege.Title}");

            foreach (int key in stepPrisonerOne)
            {
                if (key == KeyBitray)
                    Console.Write(" да ");
                else
                    Console.Write(" нет ");
            }
        }

        private void ChoicePrisoner(int[] stepsPrisoner, int index, Prisoner prisoner)
        {
            if (prisoner.IsBitray)
                stepsPrisoner[index] = KeyBitray;
            else
                stepsPrisoner[index] = KeyNotBitray;
        }
    }
}