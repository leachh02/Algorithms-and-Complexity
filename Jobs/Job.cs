using System;

public class Job : IJob {
	public Job( uint jobId, uint timeReceived, uint executionTime, uint priority ) {
		Id = jobId;
		TimeReceived = timeReceived;
		ExecutionTime = executionTime;
		Priority = priority;
	}

	private uint id;
	private uint timeReceived;
	private uint executionTime;
	private uint priority;

	public uint Id {
        get
        {
			return id;
		}
		private set {
			if (!IsValidId( value ))
				throw new ArgumentOutOfRangeException( nameof( Id ) );
			id = value;
		}
	}

	public uint TimeReceived {
		get {
			return timeReceived;
		}
		private set {
            if (!IsTimeReceived(value))
                throw new ArgumentOutOfRangeException(nameof(TimeReceived));
            timeReceived = value;
		}
	}

	public uint ExecutionTime {
		get {
			return executionTime;
		}
		private set {
			if (!IsValidExecutionTime( value ))
				throw new ArgumentOutOfRangeException( nameof( ExecutionTime ) );
			executionTime = value;
		}
	}

	public uint Priority {
		get {
			return priority;
		}
		private set {
			if (!IsValidPriority( value ))
				throw new ArgumentException( nameof( Priority ) );
			priority = value;
		}
	}

	public static bool IsValidId( uint id ) {
		if (id < 1 || id > 999)
		{
            Console.WriteLine("Job of id {0} is invalid", id);
            return false;
		}

		else
		{
			return true;
		}
    }

	public static bool IsValidExecutionTime( uint executiontime ) {
        if (executiontime > 0)
        {
            return true;
        }
        else
        {
            Console.WriteLine("Execution Time of {0} is invalid", executiontime);
            return false;
        }
    }

    public static bool IsValidPriority( uint priority ) {
        if (priority < 1 || priority > 9)
        {
            Console.WriteLine("A Priority {0} is invalid, must be between 1 and 9", priority);
            return false;
        }
        else
        {
            return true;
        }
    }

    public static bool IsTimeReceived(uint time) {
        if (time > 0)
        {
            return true;
        }
        else
        {
            Console.WriteLine("A Received Time of {0} is invalid", time);
            return false;
        }
    }

    public override string ToString() {
		return $"Job(jobId: {id}, timeReceived: {timeReceived}, executionTime: {executionTime}, priority: {priority})";
	}
}
