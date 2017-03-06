using UnityEngine;
using System.Collections;

public class Task {

   // An enum representing the current state of the task
    public enum TaskStatus : byte
    {
	Detached, // Task has not been attached to a TaskManager
	Pending, // Task has not been initialized
	Working, // Task has been initialized
	Success, // Task completed successfully
	Fail, // Task completed unsuccessfully
	Aborted // Task was aborted
    }
 
    // The only member variable that a base task has is its status
    public TaskStatus Status; 
    public Task NextTask;

    public Task() {
        Status = TaskStatus.Detached;
    }

    // Convenience status checking
    public bool IsDetached { get { return Status == TaskStatus.Detached; } }
    public bool IsAttached { get { return Status != TaskStatus.Detached; } }
    public bool IsPending { get { return Status == TaskStatus.Pending; } }
    public bool IsWorking { get { return Status == TaskStatus.Working; } }
    public bool IsSuccessful { get { return Status == TaskStatus.Success; } }
    public bool IsFailed { get { return Status == TaskStatus.Fail; } }
    public bool IsAborted { get { return Status == TaskStatus.Aborted; } }
    public bool IsFinished { get { return (Status == TaskStatus.Fail || Status == TaskStatus.Success || Status == TaskStatus.Aborted); } }
    
    
    public void Abort()
    {
            SetStatus(TaskStatus.Aborted);
    }


    internal void SetStatus(TaskStatus newStatus)
    {
	if (Status == newStatus) return;

	Status = newStatus;

	switch (newStatus)
	{
	    case TaskStatus.Working:   
		Init();
		break;

	    case TaskStatus.Success:
		OnSuccess();
		CleanUp();
		break;

	    case TaskStatus.Aborted:
		OnAbort();
		CleanUp();
		break;


	    case TaskStatus.Fail:
		OnFail();
		CleanUp();
		break;

	    case TaskStatus.Detached:
	    case TaskStatus.Pending:
		break;
	}
    } // end set status	

    // delegation pattern
    protected virtual void OnAbort() {}

    protected virtual void OnSuccess() {}

    protected virtual void OnFail() {}

    protected virtual void Init() {}
    
    public virtual void Update() {}
    
    protected virtual void CleanUp() {}

    public Task Then(Task task)
    {
        Debug.Assert(!task.IsAttached);
        NextTask = task;
        return task;
    }

}


public class AppearTask : Task {

    public AppearTask() {
         
    }

    protected override void Init() {
        // Init prefab
        // location

    }

    public override void Update() {
        // Boss slowly moves into ground
    }

}

public class ShiftAndWaitTask : Task {

    public ShiftAndWaitTask() {
         
    }

    protected override void Init() {
        // Init prefab
        // location

    }

    public override void Update() {
        // Boss will move left and right
        // and shoot bullet
        // Until other enemy die
    }

}


public class LargerTask : Task {

    public LargerTask() {
         
    }

    protected override void Init() {
        // Other enemy dies
    }

    public override void Update() {
        // Boss will become larger
        // and shoot fire
        // Until he dies
    }

}  
