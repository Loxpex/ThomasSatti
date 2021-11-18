using System;
using System.Collections.Generic;

namespace ThomasSatti
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCriteria = 0;
            int numberOfGrades = 0;

            var error = true;
            while (error)
            {
                try
                {
                    Console.WriteLine("Введите кол-во критериев");
                    numberOfCriteria = Convert.ToInt32(Console.ReadLine());
                    error = false;
                }
                catch 
                {
                    Console.WriteLine("Неверный ввод, нажмите enter и попробуйте снова");
                    Console.ReadKey();
                    Console.Clear();
                    numberOfCriteria = 0;
                }
            }


            for (int i = 1; i < numberOfCriteria; i++)
            {
                numberOfGrades += i;
            }

            double[,] MassiveOfGrades = new double[numberOfCriteria, numberOfCriteria];
            string[] MassiveOfCriteria = new string[numberOfCriteria];


            Console.WriteLine("Введите все критерии через enter");

            for (int i = 0; i < numberOfCriteria; i++) //ввод критериев
            {
                int n = 0;
                string criteria = "";
                Console.WriteLine("Введите название " +( n = i+1 )+ " критерия");
                criteria = Console.ReadLine();
                MassiveOfCriteria[i] = criteria;
            }

            for (int i = 0; i < numberOfCriteria - 1; i++) //Вроде гуд
            {
                for (int j = i + 1; j < numberOfCriteria; j++)
                {
                    error = true;
                    while (error)
                    {
                        try
                        {
                            Console.WriteLine("Оцените " + MassiveOfCriteria[i] + " по отношению к " + MassiveOfCriteria[j]);
                            double grade = Convert.ToDouble(Console.ReadLine());
                            MassiveOfGrades[i, j] = grade;
                            error = false;
                        }
                        catch
                        {
                            Console.WriteLine("Неверный ввод, нажмите enter и попробуйте снова");
                            Console.WriteLine("Используйте <,> а не <.> ");
                            Console.ReadKey();
                            Console.Clear();
                            
                        }
                    }
                }
            }
            BuildingTable(numberOfCriteria, MassiveOfCriteria, MassiveOfGrades);
        }

        public static void BuildingTable(int numberOfCriteria, string[] MassiveOfCriteria, double[,] MassiveOfGrades) //алилуя работает осталось сделать красивую таблицу, а не урода и посчитать коэфы и округлить их
        {
            double[] gradesSumm = new double[numberOfCriteria];
            double summOfGradesSumm = 0; // пардон што ? а ну ладно....
            double[] ratio = new double[numberOfCriteria];
            double ratioSumm = 0;

            for (int i = 0; i < numberOfCriteria; i++)
            {
                for (int j = 0; j < numberOfCriteria; j++)
                {
                    if (i == j)
                    {
                        MassiveOfGrades[i, j] = 1;
                    }
                    else if (i > j)
                    {
                        MassiveOfGrades[i, j] = 1 / MassiveOfGrades[j, i];
                    }
                    gradesSumm[i] = gradesSumm[i] + MassiveOfGrades[i, j];
                }
                summOfGradesSumm = summOfGradesSumm + gradesSumm[i];
            }

            Console.Clear();

            Console.Write("{0, -20}", "");
            for (int i = 0; i < numberOfCriteria; i++) //ЯБАДАБАДУУУ
            {
                ratio[i] = gradesSumm[i] / summOfGradesSumm;
                ratioSumm = Math.Round(ratioSumm + ratio[i], 2);
                Console.Write("{0, -20}", MassiveOfCriteria[i]);

            }
            ratioSumm = Math.Round(ratioSumm - 1, 2);
            ratio[0] = Math.Round(ratio[0] - ratioSumm, 2);


            for (int i = 0; i < numberOfCriteria; i++)
            {
                Console.WriteLine();
                Console.Write("{0, -20}", MassiveOfCriteria[i]);

                for (int j = 0; j < numberOfCriteria; j++)
                {
                    Console.Write("{0, -20}", Math.Round(MassiveOfGrades[i, j], 2));
                }
                Console.Write("{0, -15}", Math.Round(gradesSumm[i], 2));
                Console.Write("{0, -15}", Math.Round(ratio[i], 2));
            }
        }
    }
}