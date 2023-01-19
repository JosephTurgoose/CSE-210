using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Front-End Developer";
        job1._companyName = "GooseGoose Industries";
        job1._startYear = 2015;
        job1._endYear = 2018;

        Job job2 = new Job();
        job2._jobTitle = "Software Engineer";
        job2._companyName = "Macrotough";
        job2._startYear = 2018;
        job2._endYear = 2022;

        Resume myResume = new Resume();
        myResume._name = "Joseph";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}