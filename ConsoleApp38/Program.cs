using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем список вакантных рабочих мест
            List<JobListing> jobListings = new List<JobListing>
            {
                new JobListing("Компания А", 5, "Разработчик", "Средняя квалификация", 2, 80000, true, 28),
                new JobListing("Компания Б", 3, "Менеджер", "Высшая квалификация", 3, 90000, true, 30),
                new JobListing("Компания В", 10, "Системный администратор", "Среднее специальное", 1, 60000, false, 25),
                new JobListing("Компания Г", 2, "Дизайнер", "Средняя квалификация", 2, 70000, true, 22)
            };

            // Ввод требований клиента
            Console.WriteLine("Введите вашу квалификацию:");
            string qualification = Console.ReadLine();

            Console.WriteLine("Введите максимальное расстояние от центра города (км):");
            int maxDistance = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите минимальную зарплату (в месяц):");
            int minSalary = int.Parse(Console.ReadLine());

            // Поиск подходящих вакансий
            List<JobListing> suitableJobs = new List<JobListing>();
            foreach (var job in jobListings)
            {
                if (job.IsSuitable(qualification, maxDistance, minSalary))
                {
                    suitableJobs.Add(job);
                }
            }

            // Вывод результатов
            if (suitableJobs.Count > 0)
            {
                Console.WriteLine("\nПодходящие вакансии:");
                foreach (var job in suitableJobs)
                {
                    Console.WriteLine(job);
                }
            }
            else
            {
                Console.WriteLine("Не найдено подходящих вакансий.");
            }
        }
    }

    class JobListing
    {
        public string OrganizationName { get; set; }
        public int Distance { get; set; } // Расстояние в км
        public string PositionName { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; } // Стаж в годах
        public int Salary { get; set; } // З/п в месяц
        public bool SocialSecurity { get; set; } // Наличие социального страхования
        public int VacationDuration { get; set; } // Продолжительность отпуска

        public JobListing(string orgName, int distance, string position, string qualification,
                          int experience, int salary, bool socialSecurity, int vacationDuration)
        {
            OrganizationName = orgName;
            Distance = distance;
            PositionName = position;
            Qualification = qualification;
            Experience = experience;
            Salary = salary;
            SocialSecurity = socialSecurity;
            VacationDuration = vacationDuration;
        }

        public bool IsSuitable(string qualification, int maxDistance, int minSalary)
        {
            // Проверка подходящих критериев
            return Qualification.ToLower().Contains(qualification.ToLower())

                   && Distance <= maxDistance
                   && Salary >= minSalary;
        }

        public override string ToString()
        {
            return $"Организация: {OrganizationName}, Расстояние: {Distance} км, Должность: {PositionName}, " +
                   $"Квалификация: {Qualification}, Стаж: {Experience} года, З/п: {Salary}, " +
                   $"Социальное страхование: {(SocialSecurity ? "Да" : "Нет")}, Продолжительность отпуска: {VacationDuration} дней.";
        }
    }
}
