using System;
using System.Globalization;
using Exercise01.Entities.Enums;
using Exercise01.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o nome do departamento: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Entre com os dados do trabalhador: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            //WorkerLevel lvl = Enum.Parse<WorkerLevel>(Console.ReadLine());
            WorkerLevel lvl = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());
            Console.Write("Salário Base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, lvl, baseSalary, dept);

            Console.Write("Quantos contratos este trabalhador vai ter? ");
            int qtde = int.Parse(Console.ReadLine());

            for (int i = 1; i <= qtde; i++)
            {
                Console.WriteLine($"Entre com o {i}º contrato: ");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime dt = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração (horas): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(dt, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Entre com mes e ano com o formato (MM/YYYY): ");
            string monthAndYear = (Console.ReadLine());
            int month = int.Parse(monthAndYear.Substring(0,2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Nome: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Departament.Name);

            Console.WriteLine("Renda no " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InstalledUICulture));
        }
    }
}
