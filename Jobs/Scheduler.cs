

public class Scheduler : IScheduler {
	public Scheduler( IJobCollection jobs ) {
		Jobs = jobs;
	}

	public IJobCollection Jobs { get; }

	public IJob[] FirstComeFirstServed() {
        IJob[] jobsArray = Jobs.ToArray();
        int j;
        IJob v;
        for ( int i = 1; i < Jobs.Count; i++ )
        {
            v = jobsArray[i];
            j = i - 1;
            while (j >= 0 && jobsArray[j].TimeReceived > v.TimeReceived)
            {
                jobsArray[j + 1] = jobsArray[j];
                j--;
            }
            jobsArray[j + 1] = v;
        }
        return jobsArray;
    }

    public IJob[] Priority() {
        IJob[] jobsArray = Jobs.ToArray();
        int j;
        IJob v;
        for (int i = 1; i < Jobs.Count; i++)
        {
            v = jobsArray[i];
            j = i - 1;
            while (j >= 0 && jobsArray[j].Priority > v.Priority)
            {
                jobsArray[j + 1] = jobsArray[j];
                j--;
            }
            jobsArray[j + 1] = v;
        }
        return jobsArray;

    }

    public IJob[] ShortestJobFirst() {
        IJob[] jobsArray = Jobs.ToArray();
        int j;
        IJob v;
        for (int i = 1; i < Jobs.Count; i++)
        {
            v = jobsArray[i];
            j = i - 1;
            while (j >= 0 && jobsArray[j].ExecutionTime > v.ExecutionTime)
            {
                jobsArray[j + 1] = jobsArray[j];
                j--;
            }
            jobsArray[j + 1] = v;
        }
        return jobsArray;
    }
}