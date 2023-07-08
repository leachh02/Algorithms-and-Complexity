using System;
using System.Diagnostics;


public class JobCollection : IJobCollection
{
    private IJob[] jobs;
    private uint count;

    public JobCollection(uint capacity)
    {
        if (!(capacity >= 1)) throw new ArgumentException();
        jobs = new IJob[capacity];
        count = 0;
    }

    public uint Capacity
    {
        get { return (uint)jobs.Length; }
    }

    public uint Count
    {
        get { return count; }
    }

    public bool Add(IJob job)
    {
        if (Count >= Capacity || job == null || Contains(job.Id))
        {
            Console.WriteLine("The Job of ID {0} was not added", job.Id);
            return false;
        }
        else
        {
            jobs[count++] = job;
            return true;
        }
    }

    public bool Contains(uint id)
    {

        if (count == 0)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < Count; i++)
            {
                if (jobs[i].Id == id)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public IJob? Find(uint id)
    {
        if (count == 0)
        {
            return null;
        }
        else
        {
            foreach (IJob existingJob in jobs)
            {
                if (existingJob.Id == id)
                {
                    return existingJob;
                }
            }
            Console.WriteLine("Job of ID {0} was not found", id);
            return null;
        }
    }

    public bool Remove(uint id)
    {
        if (Contains(id))
        {
            for (int i = 0; i < Count; i++)
            {
                if (jobs[i].Id == id)
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        jobs[j] = jobs[j + 1];
                    }
                    jobs[count - 1] = null;
                    count--;
                    return true;
                }
            }
        }
        Console.WriteLine("The Job of ID {0} was removed unsuccessfully", id);
        return false;
    }

    public IJob[] ToArray()
    {
        IJob[] jobsArray = new IJob[Count];

        for (int i = 0; i < Count; i++)
        {
            jobsArray[i] = jobs[i];
        }
        return jobsArray;

    }
}
